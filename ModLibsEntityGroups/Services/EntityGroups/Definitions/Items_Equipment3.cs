using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using ModLibsCore.Libraries.Debug;
using ModLibsCore.Libraries.Items.Attributes;
using ModLibsGeneral.Libraries.Recipes;


namespace ModLibsEntityGroups.Services.EntityGroups.Definitions {
	/// <summary></summary>
	public partial class ItemGroupIDs {
		/// <summary></summary>
		public const string AnyOreBarEquipment = "Any Ore Bar Equipment";
		/// <summary></summary>
		public const string AnyCactusEquipment = "Any Cactus Equipment";
		//"Any Tiki Equipment",
		//"Any Plain Wood Equipment",
		//"Any Boreal Wood Equipment",
		//"Any Palm Wood Equipment",
		//"Any Rich Mahogany Equipment",
		//"Any Ebonwood Equipment",
		//"Any Shadewood Equipment",
		//"Any Pearlwood Equipment",
		//"Any Dynasty Wood Equipment",
		//"Any Spooky Wood Equipment",
		//"Any Tin Equipment",
		//"Any Copper Equipment",
		//"Any Iron Equipment",
		//"Any Lead Equipment",
		//"Any Silver Equipment",
		//"Any Tungsten Equipment",
		//"Any Gold Equipment",
		//"Any Platinum Equipment",
		//"Any Demonite Equipment",
		//"Any Crimtane Equipment",
		/// <summary></summary>
		public const string AnyMeteorEquipment = "Any Meteor Equipment";
		/// <summary></summary>
		public const string AnyJungleEquipment = "Any Jungle Equipment";
		/// <summary></summary>
		public const string AnyBeeEquipment = "Any Bee Equipment";
		/// <summary></summary>
		public const string AnyBoneEquipment = "Any Bone Equipment";
		/// <summary></summary>
		public const string AnyHellstoneEquipment = "Any Hellstone Equipment";
		//"Any Cobalt Equipment",
		//"Any Palladium Equipment",
		//"Any Mythril Equipment",
		//"Any Orichalcum Equipment",
		//"Any Adamantite Equipment",
		//"Any Titanium Equipment",
		/// <summary></summary>
		public const string AnyFrostCoreEquipment = "Any Frost Core Equipment";
		/// <summary></summary>
		public const string AnyForbiddenEquipment = "Any Forbidden Equipment";
		/// <summary></summary>
		public const string AnyHallowEquipment = "Any Hallow Equipment";
		//"Any Chlorophyte Equipment",
		//"Any Shroomite Equipment",
		//"Any Spectre Equipment",
		/// <summary></summary>
		public const string AnyShellEquipment = "Any Shell Equipment";
		//"Any Nebula Equipment",
		//"Any Vortex Equipment",
		//"Any Solar Equipment",
		//"Any Stardust Equipment",
		/// <summary></summary>
		public const string AnyLuminiteOreEquipment = "Any Luminite Ore Equipment";
	}




	partial class EntityGroupDefs {
		private static bool IsEquipOfGroup( Item item, ISet<int> equipGrp, ISet<int> otherGrp ) {
			bool isEquip = equipGrp.Contains( item.type );
			if( !isEquip ) { return false; }

			bool has = RecipeFinderLibraries.RecipeExists_Cached(
				createItemTypes: new HashSet<int> { item.type },
				allIngredients: null,
				anyIngredients: otherGrp.ToDictionary(
					i => i,
					i => (1, 999)
				)
			); ;

			if( !has ) { return false; }
			return item.createTile == -1 && item.createWall == -1;
		}

		////

		internal static void DefineItemEquipmentGroups3( IList<EntityGroupBuilderDefinition<Item>> defs ) {
			// Equipment Tiers

			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: ItemGroupIDs.AnyOreBarEquipment,
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment, ItemGroupIDs.AnyOreBar },
				matcher: new ItemGroupMatcher( (item, grps) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];
					ISet<int> oreBarGrp = grps[ItemGroupIDs.AnyOreBar];
/*LogLibraries.LogOnce( "EQUIPS: "+string.Join(", ", equipGrp.Select(it=>ItemNameAttributeLibraries.GetQualifiedName(it))) );
LogLibraries.LogOnce( "ORES: "+string.Join(", ", oreBarGrp.Select(it=>ItemNameAttributeLibraries.GetQualifiedName(it))) );
LogLibraries.LogOnce( "ITEM "+item.Name+" HAS ORES?: "+has
	+" RECIPES: ["+string.Join(", ",
	RecipeFinderLibraries.GetRecipesOfItem_Cached(item.type)
		.Select(
			r=>string.Join("], [",
			r.requiredItem.Where(i=>!i.IsAir).Select(i=>i.Name+" ("+i.stack+")"))
		)
	)+"]"
);*/
					return EntityGroupDefs.IsEquipOfGroup( item, equipGrp, oreBarGrp );
				} )
			) );

			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Tiki Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];

					bool isEquip = equipGrp.Contains( item.type );
					if( !isEquip ) { return false; }

					string name = ItemNameAttributeLibraries.GetQualifiedName( item );

					if( !name.Contains("Tiki") ) { return false; }
					return item.createTile == -1 && item.createWall == -1;
				} )
			) );

			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: ItemGroupIDs.AnyCactusEquipment,
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment, },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];
					return EntityGroupDefs.IsEquipOfGroup( item, equipGrp, new HashSet<int> { ItemID.Cactus } );
				} )
			) );

			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Plain Wood Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];
					return EntityGroupDefs.IsEquipOfGroup( item, equipGrp, new HashSet<int> { ItemID.Wood } );
				} )
			) );
			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Boreal Wood Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];
					return EntityGroupDefs.IsEquipOfGroup( item, equipGrp, new HashSet<int> { ItemID.BorealWood } );
				} )
			) );
			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Palm Wood Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];
					return EntityGroupDefs.IsEquipOfGroup( item, equipGrp, new HashSet<int> { ItemID.PalmWood } );
				} )
			) );
			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Rich Mahogany Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];
					return EntityGroupDefs.IsEquipOfGroup( item, equipGrp, new HashSet<int> { ItemID.RichMahogany } );
				} )
			) );
			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Ebonwood Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];
					return EntityGroupDefs.IsEquipOfGroup( item, equipGrp, new HashSet<int> { ItemID.Ebonwood } );
				} )
			) );
			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Shadewood Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];
					return EntityGroupDefs.IsEquipOfGroup( item, equipGrp, new HashSet<int> { ItemID.Shadewood } );
				} )
			) );
			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Pearlwood Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];
					return EntityGroupDefs.IsEquipOfGroup( item, equipGrp, new HashSet<int> { ItemID.Pearlwood } );
				} )
			) );
			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Spooky Wood Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];
					return EntityGroupDefs.IsEquipOfGroup( item, equipGrp, new HashSet<int> { ItemID.SpookyWood } );
				} )
			) );

			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Tin Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];
					return EntityGroupDefs.IsEquipOfGroup( item, equipGrp, new HashSet<int> { ItemID.TinBar } );
				} )
			) );
			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Copper Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];
					return EntityGroupDefs.IsEquipOfGroup( item, equipGrp, new HashSet<int> { ItemID.CopperBar } );
				} )
			) );

			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Iron Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];
					return EntityGroupDefs.IsEquipOfGroup( item, equipGrp, new HashSet<int> { ItemID.IronBar } );
				} )
			) );
			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Lead Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];
					return EntityGroupDefs.IsEquipOfGroup( item, equipGrp, new HashSet<int> { ItemID.LeadBar } );
				} )
			) );

			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Silver Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];
					return EntityGroupDefs.IsEquipOfGroup( item, equipGrp, new HashSet<int> { ItemID.SilverBar } );
				} )
			) );
			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Tungsten Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];
					return EntityGroupDefs.IsEquipOfGroup( item, equipGrp, new HashSet<int> { ItemID.TungstenBar } );
				} )
			) );

			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Gold Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];
					return EntityGroupDefs.IsEquipOfGroup( item, equipGrp, new HashSet<int> { ItemID.GoldBar } );
				} )
			) );
			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Platinum Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];
					return EntityGroupDefs.IsEquipOfGroup( item, equipGrp, new HashSet<int> { ItemID.PlatinumBar } );
				} )
			) );

			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Meteor Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];
					return EntityGroupDefs.IsEquipOfGroup( item, equipGrp, new HashSet<int> { ItemID.MeteoriteBar } );
				} )
			) );
			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Demonite Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];
					return EntityGroupDefs.IsEquipOfGroup( item, equipGrp, new HashSet<int> { ItemID.DemoniteBar } );
				} )
			) );
			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Crimtane Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];
					return EntityGroupDefs.IsEquipOfGroup( item, equipGrp, new HashSet<int> { ItemID.CrimtaneBar } );
				} )
			) );
			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Jungle Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];
					return EntityGroupDefs.IsEquipOfGroup( item, equipGrp, new HashSet<int> { ItemID.JungleSpores } );
				} )
			) );
			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Bee Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];
					return EntityGroupDefs.IsEquipOfGroup( item, equipGrp, new HashSet<int> { ItemID.BeeWax } );
				} )
			) );
			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Bone Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];
					return EntityGroupDefs.IsEquipOfGroup( item, equipGrp, new HashSet<int> { ItemID.Bone } );
				} )
			) );
			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Hellstone Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];
					return EntityGroupDefs.IsEquipOfGroup( item, equipGrp, new HashSet<int> { ItemID.HellstoneBar } );
				} )
			) );

			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Cobalt Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];
					return EntityGroupDefs.IsEquipOfGroup( item, equipGrp, new HashSet<int> { ItemID.CobaltBar } );
				} )
			) );
			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Palladium Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];
					return EntityGroupDefs.IsEquipOfGroup( item, equipGrp, new HashSet<int> { ItemID.PalladiumBar } );
				} )
			) );
			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Mythril Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];
					return EntityGroupDefs.IsEquipOfGroup( item, equipGrp, new HashSet<int> { ItemID.MythrilBar } );
				} )
			) );
			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Orichalcum Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];
					return EntityGroupDefs.IsEquipOfGroup( item, equipGrp, new HashSet<int> { ItemID.OrichalcumBar } );
				} )
			) );
			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Adamantite Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];
					return EntityGroupDefs.IsEquipOfGroup( item, equipGrp, new HashSet<int> { ItemID.AdamantiteBar } );
				} )
			) );
			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Titanium Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];
					return EntityGroupDefs.IsEquipOfGroup( item, equipGrp, new HashSet<int> { ItemID.TitaniumBar } );
				} )
			) );

			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: ItemGroupIDs.AnyFrostCoreEquipment,
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];
//var frostHelmRecipes = Main.recipe.Where( r => r.createItem.type == ItemID.FrostHelmet );
//LogLibraries.LogOnce( "FROST HELMET RECIPES ["
//	+frostHelmRecipes.Select( r=>r.requiredItem.Select(i=>i.Name).ToStringJoined(",") ).ToStringJoined("], [")
//);
					return EntityGroupDefs.IsEquipOfGroup( item, equipGrp, new HashSet<int> { ItemID.FrostCore } );
				} )
			) );
			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: ItemGroupIDs.AnyForbiddenEquipment,
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];
					return EntityGroupDefs.IsEquipOfGroup( item, equipGrp, new HashSet<int> { ItemID.AncientBattleArmorMaterial } );
				} )
			) );
			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: ItemGroupIDs.AnyHallowEquipment,
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];
					return EntityGroupDefs.IsEquipOfGroup( item, equipGrp, new HashSet<int> { ItemID.HallowedBar } );
				} )
			) );
			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Chlorophyte Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];
					return EntityGroupDefs.IsEquipOfGroup( item, equipGrp, new HashSet<int> { ItemID.ChlorophyteBar } );
				} )
			) );
			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Shroomite Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];
					return EntityGroupDefs.IsEquipOfGroup( item, equipGrp, new HashSet<int> { ItemID.ShroomiteBar } );
				} )
			) );
			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Spectre Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];
					return EntityGroupDefs.IsEquipOfGroup( item, equipGrp, new HashSet<int> { ItemID.SpectreBar } );
				} )
			) );
			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Shell Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];

					bool isEquip = equipGrp.Contains( item.type );

					bool has = RecipeFinderLibraries.RecipeExists_Cached(
						createItemTypes: new HashSet<int> { item.type },
						allIngredients: null,
						anyIngredients: new Dictionary<int, (int, int)> {
							{ ItemID.BeetleShell, (1, 1000) },
							{ ItemID.TurtleShell, (1, 1000) }
						}
					);

					if( !isEquip || !has ) { return false; }
					return item.createTile == -1 && item.createWall == -1;
				} )
			) );

			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Nebula Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];
					return EntityGroupDefs.IsEquipOfGroup( item, equipGrp, new HashSet<int> { ItemID.FragmentNebula } );
				} )
			) );
			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Vortex Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];
					return EntityGroupDefs.IsEquipOfGroup( item, equipGrp, new HashSet<int> { ItemID.FragmentVortex } );
				} )
			) );
			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Solar Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];
					return EntityGroupDefs.IsEquipOfGroup( item, equipGrp, new HashSet<int> { ItemID.FragmentSolar } );
				} )
			) );
			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Stardust Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];
					return EntityGroupDefs.IsEquipOfGroup( item, equipGrp, new HashSet<int> { ItemID.FragmentStardust } );
				} )
			) );
			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Luminite Ore Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];
					return EntityGroupDefs.IsEquipOfGroup( item, equipGrp, new HashSet<int> { ItemID.LunarBar } );
				} )
			) );
		}
	}
}
