using System;
using System.Collections.Generic;
using Terraria;
using ModLibsCore.Classes.DataStructures;
using ModLibsCore.Classes.Loadable;
using ModLibsCore.Libraries.Debug;
using ModLibsCore.Services.Timers;

namespace ModLibsEntityGroups.Services.EntityGroups {
	/// <summary>
	/// Supplies collections of named entity groups based on traits shared between entities. Groups are either items, NPCs,
	/// or projectiles. Must be enabled on mod load to be used (note: collections may require memory).
	/// </summary>
	public partial class EntityGroups : ILoadable {
		public event Action OnLoad;


		////////////////

		private IDictionary<string, IReadOnlySet<int>> ItemGroups = new Dictionary<string, IReadOnlySet<int>>();
		private IDictionary<string, IReadOnlySet<int>> NPCGroups = new Dictionary<string, IReadOnlySet<int>>();
		private IDictionary<string, IReadOnlySet<int>> ProjGroups = new Dictionary<string, IReadOnlySet<int>>();

		private IDictionary<int, IReadOnlySet<string>> GroupsPerItem = new Dictionary<int, IReadOnlySet<string>>();
		private IDictionary<int, IReadOnlySet<string>> GroupsPerNPC = new Dictionary<int, IReadOnlySet<string>>();
		private IDictionary<int, IReadOnlySet<string>> GroupsPerProj = new Dictionary<int, IReadOnlySet<string>>();

		private IList<EntityGroupBuilderDefinition<Item>> CustomItemGrpBuilders = new List<EntityGroupBuilderDefinition<Item>>();
		private IList<EntityGroupBuilderDefinition<NPC>> CustomNPCGrpBuilders = new List<EntityGroupBuilderDefinition<NPC>>();
		private IList<EntityGroupBuilderDefinition<Projectile>> CustomProjGrpBuilders = new List<EntityGroupBuilderDefinition<Projectile>>();

		private IList<Item> ItemPool = null;
		private IList<NPC> NPCPool = null;
		private IList<Projectile> ProjPool = null;



		////////////////

		internal EntityGroups() { }

		void ILoadable.OnModsLoad() { }

		void ILoadable.OnPostModsLoad() {
			Timers.SetTimer( 1, true, () => {
				this.InitializePools();
				this.InitializeDefinitions();
				return false;
			} );
		}

		void ILoadable.OnModsUnload() { }



		////////////////

		private void InitializePools() {
			this.GetItemPool();
			this.GetNPCPool();
			this.GetProjPool();
		}

		private int _InitCheck = 0;

		private void InitializeDefinitions() {
			this._InitCheck = 0;

			IList<EntityGroupBuilderDefinition<Item>> itemMatchers;
			IList<EntityGroupBuilderDefinition<NPC>> npcMatchers;
			IList<EntityGroupBuilderDefinition<Projectile>> projMatchers;

			try {
				itemMatchers = EntityGroups.DefineItemGroupDefinitions();
				 this._InitCheck++;
				npcMatchers = EntityGroups.DefineNPCGroupDefinitions();
				 this._InitCheck++;
				projMatchers = EntityGroups.DefineProjectileGroupDefinitions();
				 this._InitCheck++;
			} catch( Exception e ) {
				LogLibraries.Warn( "Initialization failed 1 (at #" + this._InitCheck + "): " + e.ToString() );
				return;
			}

			//

			this.ComputeGroups<Item>( itemMatchers, this.ItemGroups, this.GroupsPerItem );
			 this._InitCheck++;

			this.ComputeGroups<NPC>( npcMatchers, this.NPCGroups, this.GroupsPerNPC );
			 this._InitCheck++;

			this.ComputeGroups<Projectile>( projMatchers, this.ProjGroups, this.GroupsPerProj );
			 this._InitCheck++;

			//

			this.ComputeGroups<Item>( this.CustomItemGrpBuilders, this.ItemGroups, this.GroupsPerItem );
			 this._InitCheck++;

			this.ComputeGroups<NPC>( this.CustomNPCGrpBuilders, this.NPCGroups, this.GroupsPerNPC );
			 this._InitCheck++;

			this.ComputeGroups<Projectile>( this.CustomProjGrpBuilders, this.ProjGroups, this.GroupsPerProj );
			 this._InitCheck++;

			//

			this.CustomItemGrpBuilders = null;
			this.CustomNPCGrpBuilders = null;
			this.CustomProjGrpBuilders = null;
			this.ItemPool = null;
			this.NPCPool = null;
			this.ProjPool = null;

			//

			this.OnLoad?.Invoke();

			//

			this._InitCheck++;
		}
	}
}
