﻿using System;
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
		private bool ComputeGroups<T>(
					IList<EntityGroupMatcherDefinition<T>> matchers,
					IDictionary<string, IReadOnlySet<int>> groups,
					IDictionary<int, IReadOnlySet<string>> groupsPerEnt )
					where T : Entity {
			IDictionary<int, ISet<string>> rawGroupsPerEnt;

			this.GetComputedGroups(
				matchers: ref matchers,
				groups: ref groups,
				groupsPerEnt: out rawGroupsPerEnt
			);

			foreach( EntityGroupMatcherDefinition<T> def in matchers ) {
				if( !groups.ContainsKey( def.GroupName ) ) {
					LogLibraries.Log( "!Entity group " + def.GroupName + " not loaded." );
				}
			}

			if( ModLibsEntityGroupsConfig.Instance.DebugModeInfo ) {
				ModLibsEntGroupsMod.Instance.Logger.Info( typeof(T).Name+" has groups "+string.Join(", ", groups.Keys) );
			}

			foreach( (int itemType, ISet<string> groupNames) in rawGroupsPerEnt ) {
				groupsPerEnt[ itemType ] = new ReadOnlySet<string>( groupNames );
			}

			//

			if( ModLibsEntityGroupsConfig.Instance.DebugModeInfo ) {
				foreach( (string groupName, IReadOnlySet<int> entIds) in groups ) {
					EntityGroups.LogGroup( typeof(T), groupName, entIds );
				}
			}

			//LogHelpers.Log( "ent:" + typeof( T ).Name + ", OK " + groups.Count );
			return true;
		}


		private void GetComputedGroups<T>(
					ref IList<EntityGroupMatcherDefinition<T>> matchers,
					ref IDictionary<string, IReadOnlySet<int>> groups,
					out IDictionary<int, ISet<string>> groupsPerEnt )
					where T : Entity {
			IDictionary<int, ISet<string>> myGroupsPerEnt = new Dictionary<int, ISet<string>>();
			IDictionary<EntityGroupMatcherDefinition<T>, int> reQueuedCounts = new Dictionary<EntityGroupMatcherDefinition<T>, int>();
			IList<T> entityPool = this.GetPool<T>();

			int count = matchers.Count;
			
			for( int i=0; i<count; i++ ) {
				EntityGroupMatcherDefinition<T> matcher = matchers[i];

				this.ComputeGroup(
					matcher: matcher,
					entityPool: entityPool,
					matchers: ref matchers,
					reQueuedCounts: ref reQueuedCounts,
					groups: ref groups,
					groupsPerEnt: ref myGroupsPerEnt
				);
			}

			groupsPerEnt = myGroupsPerEnt;
		}
	}
}
