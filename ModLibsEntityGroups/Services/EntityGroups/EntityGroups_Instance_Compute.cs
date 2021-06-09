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
		private bool ComputeGroups<T>(
					IList<EntityGroupBuilderDefinition<T>> groupBuilders,
					IDictionary<string, IReadOnlySet<int>> groups,
					IDictionary<int, IReadOnlySet<string>> groupsPerEnt )
					where T : Entity {
			IDictionary<int, ISet<string>> rawGroupsPerEnt;

			this.GetComputedGroups(
				groupBuilders: ref groupBuilders,
				groups: ref groups,
				groupsPerEnt: out rawGroupsPerEnt
			);

			foreach( EntityGroupBuilderDefinition<T> def in groupBuilders ) {
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

			//LogLibraries.Log( "ent:" + typeof( T ).Name + ", OK " + groups.Count );
			return true;
		}


		private void GetComputedGroups<T>(
					ref IList<EntityGroupBuilderDefinition<T>> groupBuilders,
					ref IDictionary<string, IReadOnlySet<int>> groups,
					out IDictionary<int, ISet<string>> groupsPerEnt )
					where T : Entity {
			IDictionary<int, ISet<string>> myGroupsPerEnt = new Dictionary<int, ISet<string>>();
			IDictionary<EntityGroupBuilderDefinition<T>, int> reQueuedCounts = new Dictionary<EntityGroupBuilderDefinition<T>, int>();
			IList<T> entityPool = this.GetPool<T>();

			int count = groupBuilders.Count;
			
			for( int i=0; i<count; i++ ) {
				this.ComputeGroupAndRunBuilderIf(
					groupBuilder: groupBuilders[i],
					entityPool: entityPool,
					allGroupBuilders: ref groupBuilders,
					reQueuedCounts: ref reQueuedCounts,
					groups: ref groups,
					groupsPerEnt: ref myGroupsPerEnt
				);
			}

			groupsPerEnt = myGroupsPerEnt;
		}
	}
}
