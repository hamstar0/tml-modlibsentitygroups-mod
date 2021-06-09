using System;
using Terraria;
using Terraria.ModLoader;
using ModLibsCore.Classes.DataStructures;
using ModLibsCore.Classes.Errors;


namespace ModLibsEntityGroups.Services.EntityGroups {
	/// <summary>
	/// Supplies collections of named entity groups based on traits shared between entities. Groups are either items, NPCs,
	/// or projectiles. Must be enabled on mod load to be used (note: collections may require memory).
	/// </summary>
	public partial class EntityGroups {
		/// <summary></summary>
		public static int ItemCount => ModContent.GetInstance<EntityGroups>()?.ItemGroups.Count ?? -1;

		/// <summary></summary>
		public static int NPCCount => ModContent.GetInstance<EntityGroups>()?.ItemGroups.Count ?? -1;

		/// <summary></summary>
		public static int ProjectileCount => ModContent.GetInstance<EntityGroups>()?.ItemGroups.Count ?? -1;



		////////////////

		/// <summary>
		/// Defines a custom item group to add to the database.
		/// 
		/// Reminder: Must be called after EntityGroups.Enable(), but before mods finish loading (PostSetupContent,
		/// PostAddRecipes, etc.).
		/// </summary>
		/// <param name="groupName"></param>
		/// <param name="groupDependencies">Other groups the current group references.</param>
		/// <param name="matcher">Function to use to match items for this group.</param>
		public static void AddCustomItemGroup( string groupName, string[] groupDependencies, ItemGroupMatcher matcher ) {
			var entGrps = ModContent.GetInstance<EntityGroups>();
			if( entGrps.CustomItemGrpBuilders == null ) { throw new ModLibsException( "Mods loaded; cannot add new groups." ); }

			var entry = new EntityGroupBuilderDefinition<Item>( groupName, groupDependencies, matcher );
			entGrps.CustomItemGrpBuilders.Add( entry );
		}

		/// <summary>
		/// Defines a custom NPC group to add to the database.
		/// 
		/// Reminder: Must be called after EntityGroups.Enable(), but before mods finish loading (PostSetupContent,
		/// PostAddRecipes, etc.).
		/// </summary>
		/// <param name="groupName"></param>
		/// <param name="groupDependencies">Other groups the current group references.</param>
		/// <param name="matcher">Function to use to match NPCs for this group.</param>
		public static void AddCustomNPCGroup( string groupName, string[] groupDependencies, NPCGroupMatcher matcher ) {
			var entGrps = ModContent.GetInstance<EntityGroups>();
			if( entGrps.CustomNPCGrpBuilders == null ) { throw new Exception( "Mods loaded; cannot add new groups." ); }

			var entry = new EntityGroupBuilderDefinition<NPC>( groupName, groupDependencies, matcher );
			entGrps.CustomNPCGrpBuilders.Add( entry );
		}

		/// <summary>
		/// Defines a custom Projectile group to add to the database.
		/// 
		/// Reminder: Must be called after EntityGroups.Enable(), but before mods finish loading (PostSetupContent,
		/// PostAddRecipes, etc.).
		/// </summary>
		/// <param name="groupName"></param>
		/// <param name="groupDependencies">Other groups the current group references.</param>
		/// <param name="matcher">Function to use to match NPCs for this group.</param>
		public static void AddCustomProjectileGroup( string groupName, string[] groupDependencies,
					ProjectileGroupMatcher matcher ) {
			var entGrps = ModContent.GetInstance<EntityGroups>();
			if( entGrps.CustomProjGrpBuilders == null ) { throw new Exception( "Mods loaded; cannot add new groups." ); }

			var entry = new EntityGroupBuilderDefinition<Projectile>( groupName, groupDependencies, matcher );
			entGrps.CustomProjGrpBuilders.Add( entry );
		}



		////////////////

		/// <summary>
		/// Retrieves an item group by its name.
		/// 
		/// Reminder: This must be called after entity groups are initialized (EntityGroups.Enable()), and then after mods are
		/// loaded (use CustomLoadHooks with EntityGroups.LoadedAllValidator).
		/// </summary>
		/// <param name="name"></param>
		/// <param name="group"></param>
		/// <returns></returns>
		public static bool TryGetItemGroup( string name, out IReadOnlySet<int> group ) {
			return ModContent.GetInstance<EntityGroups>().ItemGroups.TryGetValue( name, out group );
		}
		/// <summary>
		/// Retrieves an NPC group by its name.
		/// 
		/// Reminder: This must be called after entity groups are initialized (EntityGroups.Enable()), and then after mods are
		/// loaded (use CustomLoadHooks with EntityGroups.LoadedAllValidator).
		/// </summary>
		/// <param name="name"></param>
		/// <param name="group"></param>
		/// <returns></returns>
		public static bool TryGetNpcGroup( string name, out IReadOnlySet<int> group ) {
			return ModContent.GetInstance<EntityGroups>().NPCGroups.TryGetValue( name, out group );
		}
		/// <summary>
		/// Retrieves a projectile group by its name.
		/// 
		/// Reminder: This must be called after entity groups are initialized (EntityGroups.Enable()), and then after mods are
		/// loaded (use CustomLoadHooks with EntityGroups.LoadedAllValidator).
		/// </summary>
		/// <param name="name"></param>
		/// <param name="group"></param>
		/// <returns></returns>
		public static bool TryGetProjectileGroup( string name, out IReadOnlySet<int> group ) {
			return ModContent.GetInstance<EntityGroups>().ProjGroups.TryGetValue( name, out group );
		}

		/// <summary>
		/// Retrieves all groups (names) of a given item (type).
		/// 
		/// Reminder: This must be called after entity groups are initialized (EntityGroups.Enable()), and then after mods are
		/// loaded (use CustomLoadHooks with EntityGroups.LoadedAllValidator).
		/// </summary>
		/// <param name="itemType"></param>
		/// <param name="groupNames"></param>
		/// <returns></returns>
		public static bool TryGetGroupsPerItem( int itemType, out IReadOnlySet<string> groupNames ) {
			return ModContent.GetInstance<EntityGroups>().GroupsPerItem.TryGetValue( itemType, out groupNames );
		}
		/// <summary>
		/// Retrieves all groups (names) of a given NPC (type).
		/// 
		/// Reminder: This must be called after entity groups are initialized (EntityGroups.Enable()), and then after mods are
		/// loaded (use CustomLoadHooks with EntityGroups.LoadedAllValidator).
		/// </summary>
		/// <param name="npcType"></param>
		/// <param name="groupNames"></param>
		/// <returns></returns>
		public static bool TryGetGroupsPerNPC( int npcType, out IReadOnlySet<string> groupNames ) {
			return ModContent.GetInstance<EntityGroups>().GroupsPerNPC.TryGetValue( npcType, out groupNames );
		}
		/// <summary>
		/// Retrieves all groups (names) of a given projectile (type).
		/// 
		/// Reminder: This must be called after entity groups are initialized (EntityGroups.Enable()), and then after mods are
		/// loaded (use CustomLoadHooks with EntityGroups.LoadedAllValidator).
		/// </summary>
		/// <param name="projType"></param>
		/// <param name="groupNames"></param>
		/// <returns></returns>
		public static bool TryGetGroupsPerProjectile( int projType, out IReadOnlySet<string> groupNames ) {
			return ModContent.GetInstance<EntityGroups>().GroupsPerProj.TryGetValue( projType, out groupNames );
		}
	}
}
