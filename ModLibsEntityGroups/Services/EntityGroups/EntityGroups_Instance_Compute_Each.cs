using System;
using System.Collections.Generic;
using Terraria;
using ModLibsCore.Classes.DataStructures;
using ModLibsCore.Classes.Errors;
using ModLibsCore.Libraries.Debug;
using ModLibsCore.Libraries.DotNET.Extensions;


namespace ModLibsEntityGroups.Services.EntityGroups {
	/// <summary>
	/// Supplies collections of named entity groups based on traits shared between entities. Groups are either items, NPCs,
	/// or projectiles. Must be enabled on mod load to be used (note: collections may require memory).
	/// </summary>
	public partial class EntityGroups {
		private bool ComputeGroup<T>(
					EntityGroupMatcherDefinition<T> matcher,
					IList<T> entityPool,
					ref IList<EntityGroupMatcherDefinition<T>> matchers,
					ref IDictionary<EntityGroupMatcherDefinition<T>, int> reQueuedCounts,
					ref IDictionary<string, IReadOnlySet<int>> groups,
					ref IDictionary<int, ISet<string>> groupsPerEnt )
					where T : Entity {
			ISet<int> grp;

			if( !this.ComputeGroupMatcher(matcher, entityPool, out grp ) ) {    //matchers,
				matchers.Add( matcher );

				reQueuedCounts.AddOrSet( matcher, 1 );

				if( reQueuedCounts[matcher] > 100 ) {
					LogLibraries.Warn( "Could not find all dependencies for " + matcher.GroupName );
					return false;
				}

				return true;
			}

			groups[ matcher.GroupName ] = new ReadOnlySet<int>( grp );

			foreach( int grpIdx in grp ) {
				groupsPerEnt.Set2D( grpIdx, matcher.GroupName );
			}

			return true;
		}


		private bool ComputeGroupMatcher<T>(
					EntityGroupMatcherDefinition<T> matcher,
					IList<T> entityPool,
					//IList<EntityGroupMatcherDefinition<T>> matchers,
					out ISet<int> entityIdsOfGroup )
					where T : Entity {
			entityIdsOfGroup = new HashSet<int>();
			EntityGroupDependencies deps;

			bool groupsFound = this.GetGroupsAsDependencies<T>(
				matcher.GroupName,
				matcher.GroupDependencies,
				out deps
			);
			if( !groupsFound ) {
				return false;
			}

			for( int i = 1; i < entityPool.Count; i++ ) {
				if( (i == 102 || i == 221) && entityPool[i].GetType() == typeof(Projectile) ) {
					continue;	// Go away, log warning spam
				}

				try {
					if( matcher.Matcher.MatcherFunc(entityPool[i], deps) ) {
						entityIdsOfGroup.Add( i );
					}
				} catch( Exception ) {
					LogLibraries.Alert( "Compute fail for '"+matcher.GroupName+"' with ent ("+i+") "+(entityPool[i] == null ? "null" : entityPool[i].ToString()) );
				}
			}

			if( entityIdsOfGroup.Count == 0 ) {
				LogLibraries.Info( "!Group "+matcher.GroupName+" has no entries." );
			}
			
			return true;
		}


		////////////////

		private bool GetGroupsAsDependencies<T>(
					string groupName,
					string[] dependencies,
					out EntityGroupDependencies groupDependencies )
					where T : Entity {
			groupDependencies = new EntityGroupDependencies();
			if( dependencies == null || dependencies.Length == 0 ) {
				return true;
			}

			IDictionary<string, IReadOnlySet<int>> entityGroups;

			switch( typeof(T).Name ) {
			case "Item":
				entityGroups = this.ItemGroups;
				break;
			case "NPC":
				entityGroups = this.NPCGroups;
				break;
			case "Projectile":
				entityGroups = this.ProjGroups;
				break;
			default:
				throw new NotImplementedException( "Invalid Entity type " + typeof( T ).Name );
			}

			foreach( string dependency in dependencies ) {
				if( !entityGroups.ContainsKey( dependency ) ) {
					return false;
				}

				groupDependencies[dependency] = entityGroups[dependency];
			}

			return true;
		}
	}
}
