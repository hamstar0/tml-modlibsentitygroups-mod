using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using ModLibsGeneral.Libraries.Recipes;


namespace ModLibsEntityGroups.Services.EntityGroups.Definitions {
	/// <summary></summary>
	public partial class ItemGroupIDs {
		/// <summary></summary>
		public const string AnyWoodEquipment = "Any Wood Equipment";
		/// <summary></summary>
		public const string AnyCopperOrTinEquipment = "Any Copper Or Tin Equipment";
		/// <summary></summary>
		public const string AnyIronOrLeadEquipment = "Any Iron Or Lead Equipment";
		/// <summary></summary>
		public const string AnySilverOrTungstenEquipment = "Any Silver Or Tungsten Equipment";
		/// <summary></summary>
		public const string AnyGoldOrPlatinumEquipment = "Any Gold Or Platinum Equipment";
		/// <summary></summary>
		public const string AnyDemoniteOrCrimtaneEquipment = "Any Demonite Or Crimtane Equipment";
		/// <summary></summary>
		public const string AnyMeteorOrJungleOrBoneOrBeeEquipment = "Any Meteor Or Jungle Or Bone Or Bee Equipment";
		/// <summary></summary>
		public const string AnyCobaltOrPalladiumEquipment = "Any Cobalt Or Palladium Equipment";
		/// <summary></summary>
		public const string AnyMythrilOrOrichalcumEquipment = "Any Mythril Or Orichalcum Equipment";
		/// <summary></summary>
		public const string AnyAdamantiteOrTitaniumEquipment = "Any Adamantite Or Titanium Equipment";
		/// <summary></summary>
		public const string AnyFrostCoreOrForbiddenEquipment = "Any Frost Core Or Forbidden Equipment";
		/// <summary></summary>
		public const string AnyChlorophyteOrShroomiteOrSpectreEquipment = "Any Chlorophyte Or Shroomite Or Spectre Equipment";
		/// <summary></summary>
		public const string AnyCelestialEquipment = "Any Celestial Equipment";
	}
	



	partial class EntityGroupDefs {
		internal static void DefineItemEquipmentGroups4( IList<EntityGroupBuilderDefinition<Item>> defs ) {
			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: ItemGroupIDs.AnyWoodEquipment,
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment, "Any Wood" },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					IDictionary<int, (int, int)> anyEquipGrp = grps[ItemGroupIDs.AnyEquipment].ToDictionary( id=>id, id=>(1, 1000) );
					IDictionary<int, (int, int)> anyWoodGrp = grps["Any Wood"].ToDictionary( id => id, id=>(1, 1000) );

					bool isCraftedWithWood = RecipeLibraries.RecipeExists(
						new HashSet<int> { item.type },
						anyWoodGrp
					);

					if( !anyEquipGrp.ContainsKey(item.type) || !isCraftedWithWood ) { return false; }
					return item.createTile == -1 && item.createWall == -1;
				} )
			) );
			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: ItemGroupIDs.AnyCopperOrTinEquipment,
				grpDeps: new string[] { "Any Copper Equipment", "Any Tin Equipment" },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					return	grps["Any Copper Equipment"].Contains( item.type ) ||
							grps["Any Tin Equipment"].Contains( item.type );
				} )
			) );
			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: ItemGroupIDs.AnyIronOrLeadEquipment,
				grpDeps: new string[] { "Any Iron Equipment", "Any Lead Equipment" },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					return	grps["Any Iron Equipment"].Contains( item.type ) ||
							grps["Any Lead Equipment"].Contains( item.type );
				} )
			) );
			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: ItemGroupIDs.AnySilverOrTungstenEquipment,
				grpDeps: new string[] { "Any Silver Equipment", "Any Tungsten Equipment" },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					return	grps["Any Silver Equipment"].Contains( item.type ) ||
							grps["Any Tungsten Equipment"].Contains( item.type );
				} )
			) );
			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: ItemGroupIDs.AnyGoldOrPlatinumEquipment,
				grpDeps: new string[] { "Any Gold Equipment", "Any Platinum Equipment" },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					return grps["Any Gold Equipment"].Contains( item.type ) ||
						grps["Any Platinum Equipment"].Contains( item.type );
				} )
			) );
			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: ItemGroupIDs.AnyDemoniteOrCrimtaneEquipment,
				grpDeps: new string[] { "Any Demonite Equipment", "Any Crimtane Equipment" },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					return grps["Any Demonite Equipment"].Contains( item.type ) ||
						grps["Any Crimtane Equipment"].Contains( item.type );
				} )
			) );
			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: ItemGroupIDs.AnyMeteorOrJungleOrBoneOrBeeEquipment,
				grpDeps: new string[] { "Any Meteor Equipment", "Any Jungle Equipment", "Any Bone Equipment", "Any Bee Equipment" },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					return grps["Any Meteor Equipment"].Contains( item.type ) ||
						grps["Any Jungle Equipment"].Contains( item.type ) ||
						grps["Any Bone Equipment"].Contains( item.type ) ||
						grps["Any Bee Equipment"].Contains( item.type );
				} )
			) );
			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: ItemGroupIDs.AnyCobaltOrPalladiumEquipment,
				grpDeps: new string[] { "Any Cobalt Equipment", "Any Palladium Equipment" },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					return grps["Any Cobalt Equipment"].Contains( item.type ) ||
						grps["Any Palladium Equipment"].Contains( item.type );
				} )
			) );
			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: ItemGroupIDs.AnyMythrilOrOrichalcumEquipment,
				grpDeps: new string[] { "Any Mythril Equipment", "Any Orichalcum Equipment" },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					return grps["Any Mythril Equipment"].Contains( item.type ) ||
						grps["Any Orichalcum Equipment"].Contains( item.type );
				} )
			) );
			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: ItemGroupIDs.AnyAdamantiteOrTitaniumEquipment,
				grpDeps: new string[] { "Any Adamantite Equipment", "Any Titanium Equipment" },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					return grps["Any Adamantite Equipment"].Contains( item.type ) ||
						grps["Any Titanium Equipment"].Contains( item.type );
				} )
			) );
			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: ItemGroupIDs.AnyFrostCoreOrForbiddenEquipment,
				grpDeps: new string[] { "Any Frost Core Equipment", "Any Forbidden Equipment" },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					return grps["Any Frost Core Equipment"].Contains( item.type ) ||
						grps["Any Forbidden Equipment"].Contains( item.type );
				} )
			) );
			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: ItemGroupIDs.AnyChlorophyteOrShroomiteOrSpectreEquipment,
				grpDeps: new string[] { "Any Chlorophyte Equipment", "Any Shroomite Equipment", "Any Spectre Equipment" },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					return grps["Any Chlorophyte Equipment"].Contains( item.type ) ||
						grps["Any Shroomite Equipment"].Contains( item.type ) ||
						grps["Any Spectre Equipment"].Contains( item.type );
				} )
			) );
			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: ItemGroupIDs.AnyCelestialEquipment,
				grpDeps: new string[] {
					"Any Nebula Equipment",
					"Any Vortex Equipment",
					"Any Solar Equipment",
					"Any Stardust Equipment" },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					return grps["Any Nebula Equipment"].Contains( item.type ) ||
						grps["Any Vortex Equipment"].Contains( item.type ) ||
						grps["Any Solar Equipment"].Contains( item.type ) ||
						grps["Any Stardust Equipment"].Contains( item.type );
				} )
			) );
		}
	}
}
