using System;
using System.Collections.Generic;
using Terraria;
using ModLibsCore.Libraries.Debug;
using ModLibsEntityGroups.Services.EntityGroups.Definitions;


namespace ModLibsEntityGroups.Services.EntityGroups {
	/// <summary>
	/// Supplies collections of named entity groups based on traits shared between entities. Groups are either items, NPCs,
	/// or projectiles. Must be enabled on mod load to be used (note: collections may require memory).
	/// </summary>
	public partial class EntityGroups {
		private static IList<EntityGroupBuilderDefinition<Item>> DefineItemGroupDefinitions() {
			var matchers = new List<EntityGroupBuilderDefinition<Item>>();

			EntityGroupDefs.DefineItemEquipmentGroups1( matchers );
			EntityGroupDefs.DefineItemAccessoriesGroups1( matchers );
			EntityGroupDefs.DefineItemWeaponGroups1( matchers );
			EntityGroupDefs.DefineItemPlaceablesGroups1( matchers );
			EntityGroupDefs.DefineItemMiscGroups1( matchers );

			EntityGroupDefs.DefineItemEquipmentGroups2( matchers );
			//EntityGroupDefs.DefineItemAccessoriesGroups2( matchers );
			EntityGroupDefs.DefineItemWeaponGroups2( matchers );
			EntityGroupDefs.DefineItemPlaceablesGroups2( matchers );
			EntityGroupDefs.DefineItemMiscGroups2( matchers );

			EntityGroupDefs.DefineItemEquipmentGroups3( matchers );
			//EntityGroupDefs.DefineItemAccessoriesGroups3( matchers );
			//EntityGroupDefs.DefineItemWeaponGroups3( matchers );
			//EntityGroupDefs.DefineItemPlaceablesGroups3( matchers );
			EntityGroupDefs.DefineItemMiscGroups3( matchers );

			EntityGroupDefs.DefineItemEquipmentGroups4( matchers );
			//EntityGroupDefs.DefineItemAccessoriesGroups4( matchers );
			//EntityGroupDefs.DefineItemWeaponGroups4( matchers );
			//EntityGroupDefs.DefineItemPlaceablesGroups4( matchers );
			EntityGroupDefs.DefineItemMiscGroups4( matchers );

			EntityGroupDefs.DefineItemEquipmentGroups5( matchers );
			
			return matchers;
		}


		private static IList<EntityGroupBuilderDefinition<NPC>> DefineNPCGroupDefinitions() {
			var matchers = new List<EntityGroupBuilderDefinition<NPC>>();

			EntityGroupDefs.DefineNPCGroups1( matchers );

			return matchers;
		}


		private static IList<EntityGroupBuilderDefinition<Projectile>> DefineProjectileGroupDefinitions() {
			var matchers = new List<EntityGroupBuilderDefinition<Projectile>>();

			EntityGroupDefs.DefineProjectileGroups1( matchers );

			return matchers;
		}
	}
}
