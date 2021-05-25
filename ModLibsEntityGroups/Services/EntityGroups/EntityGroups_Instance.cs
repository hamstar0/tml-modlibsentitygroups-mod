using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Terraria;
using ModLibsCore.Classes.DataStructures;
using ModLibsCore.Classes.Loadable;
using ModLibsCore.Libraries.Debug;
using ModLibsCore.Libraries.DotNET.Threading;
using ModLibsCore.Services.Hooks.LoadHooks;


namespace ModLibsEntityGroups.Services.EntityGroups {
	/// <summary>
	/// Supplies collections of named entity groups based on traits shared between entities. Groups are either items, NPCs,
	/// or projectiles. Must be enabled on mod load to be used (note: collections may require memory).
	/// </summary>
	public partial class EntityGroups : ILoadable {
		public event Action OnLoad;


		////////////////

		private bool IsReadyToLoad = false;
		private bool IsLoadedPostModLoad = false;

		private IDictionary<string, IReadOnlySet<int>> ItemGroups = new Dictionary<string, IReadOnlySet<int>>();
		private IDictionary<string, IReadOnlySet<int>> NPCGroups = new Dictionary<string, IReadOnlySet<int>>();
		private IDictionary<string, IReadOnlySet<int>> ProjGroups = new Dictionary<string, IReadOnlySet<int>>();

		private IDictionary<int, IReadOnlySet<string>> GroupsPerItem = new Dictionary<int, IReadOnlySet<string>>();
		private IDictionary<int, IReadOnlySet<string>> GroupsPerNPC = new Dictionary<int, IReadOnlySet<string>>();
		private IDictionary<int, IReadOnlySet<string>> GroupsPerProj = new Dictionary<int, IReadOnlySet<string>>();

		private IList<EntityGroupMatcherDefinition<Item>> CustomItemMatchers = new List<EntityGroupMatcherDefinition<Item>>();
		private IList<EntityGroupMatcherDefinition<NPC>> CustomNPCMatchers = new List<EntityGroupMatcherDefinition<NPC>>();
		private IList<EntityGroupMatcherDefinition<Projectile>> CustomProjMatchers = new List<EntityGroupMatcherDefinition<Projectile>>();

		private IList<Item> ItemPool = null;
		private IList<NPC> NPCPool = null;
		private IList<Projectile> ProjPool = null;



		////////////////

		internal EntityGroups() {
			LoadHooks.AddPostModLoadHook( () => {
				if( this.IsReadyToLoad ) {
					this.InitializePools();
					this.InitializeDefinitions();
					this.IsLoadedPostModLoad = true;
				}
			} );

			//LoadHooks.AddModUnloadHook( () => {
			//	lock( EntityGroups.MyLock ) { }
			//} );
		}

		void ILoadable.OnModsLoad() { }

		void ILoadable.OnPostModsLoad() { }

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

			IList<EntityGroupMatcherDefinition<Item>> itemMatchers;
			IList<EntityGroupMatcherDefinition<NPC>> npcMatchers;
			IList<EntityGroupMatcherDefinition<Projectile>> projMatchers;

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

			this.ComputeGroups<Item>( this.CustomItemMatchers, this.ItemGroups, this.GroupsPerItem );
			this._InitCheck++;

			this.ComputeGroups<NPC>( this.CustomNPCMatchers, this.NPCGroups, this.GroupsPerNPC );
			this._InitCheck++;

			this.ComputeGroups<Projectile>( this.CustomProjMatchers, this.ProjGroups, this.GroupsPerProj );
			this._InitCheck++;

			//

			this.CustomItemMatchers = null;
			this.CustomNPCMatchers = null;
			this.CustomProjMatchers = null;
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
