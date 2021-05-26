using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ModLoader;
using ModLibsCore.Libraries.Debug;
using ModLibsEntityGroups.Libraries.Items;


namespace ModLibsEntityGroups.Libraries.Recipes {
	/// <summary>
	/// Assorted static "helper" functions pertaining to common recipe groups.
	/// </summary>
	public partial class RecipeGroupLibraries {
		/// <summary>
		/// Recipe group of items of an "evil" biome boss's drops (Shadow Scale and Tissue Sample).
		/// </summary>
		public static RecipeGroup EvilBiomeBossDrops => RecipeGroupLibraries.Groups["ModLibs:EvilBiomeBossDrops"];
		/// <summary>
		/// Recipe group of light pet items of an "evil" biome (Shadow Orb and Crimson Heart).
		/// </summary>
		public static RecipeGroup EvilBiomeLightPet => RecipeGroupLibraries.Groups["ModLibs:EvilBossDropsEvilBiomeLightPet"];
		/// <summary></summary>
		public static RecipeGroup VanillaButterfly => RecipeGroupLibraries.Groups["ModLibs:EvilBossDropsVanillaButterfly"];
		/// <summary></summary>
		public static RecipeGroup VanillaGoldCritter => RecipeGroupLibraries.Groups["ModLibs:EvilBossDropsVanillaGoldCritter"];
		/// <summary></summary>
		public static RecipeGroup PressurePlates => RecipeGroupLibraries.Groups["ModLibs:EvilBossDropsPressurePlates"];
		/// <summary></summary>
		public static RecipeGroup WeightedPressurePlates => RecipeGroupLibraries.Groups["ModLibs:EvilBossDropsWeightedPressurePlates"];
		/// <summary></summary>
		public static RecipeGroup ConveyorBelts => RecipeGroupLibraries.Groups["ModLibs:EvilBossDropsConveyorBelts"];
		/// <summary></summary>
		public static RecipeGroup NpcBanners => RecipeGroupLibraries.Groups["ModLibs:EvilBossDropsNpcBanners"];
		/// <summary></summary>
		public static RecipeGroup RecordedMusicBoxes => RecipeGroupLibraries.Groups["ModLibs:EvilBossDropsRecordedMusicBoxes"];


		////

		/// <summary>
		/// A map of common recipe groups to their internal names.
		/// </summary>
		public static IDictionary<string, RecipeGroup> Groups {
			get {
				var recipeGrpsLibs = ModContent.GetInstance<RecipeGroupLibraries>();

				if( recipeGrpsLibs._Groups == null ) {
					recipeGrpsLibs._Groups = RecipeGroupLibraries.CreateRecipeGroups();
				}
				return recipeGrpsLibs._Groups;
			}
		}



		////////////////

		private static IDictionary<string, RecipeGroup> CreateRecipeGroups() {
			IDictionary<string, ItemGroupDefinition> commonItemGrps = ItemGroupIdentityLibraries.GetCommonItemGroups();

			IDictionary<string, RecipeGroup> groups = commonItemGrps.ToDictionary(
				kv => {
					string internalGrpName = kv.Key;
					return "ModLibs:" + internalGrpName;
				},
				kv => {
					string grpName = kv.Value.GroupName;
					ISet<int> itemIds = kv.Value.Group;

					return new RecipeGroup(
						() => Lang.misc[37].ToString() + " " + grpName,
						itemIds.ToArray()
					);
				}
			);

			return groups;
		}
	}
}
