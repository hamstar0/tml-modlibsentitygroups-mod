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
		internal static void DefineItemEquipmentGroups3( IList<EntityGroupBuilderDefinition<Item>> defs ) {
			// Equipment Tiers

			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: ItemGroupIDs.AnyOreBarEquipment,
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment, ItemGroupIDs.AnyOreBar },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];
					ISet<int> oreBarGrp = grps[ItemGroupIDs.AnyEquipment];

					bool isEquip = equipGrp.Contains( item.type );

					bool has = RecipeLibraries.RecipeExists(
						new HashSet<int> { item.type },
						oreBarGrp.ToDictionary(i=>i, i=>(1, 1000))
					);
					
					if( !isEquip || !has ) { return false; }
					return item.createTile == -1 && item.createWall == -1;
				} )
			) );

			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Tiki Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];
					bool isEquip = equipGrp.Contains( item.type );
					string name = ItemNameAttributeLibraries.GetQualifiedName( item );

					if( !isEquip || !name.Contains( "Tiki" ) ) { return false; }
					return item.createTile == -1 && item.createWall == -1;
				} )
			) );

			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Cactus Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment, },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];
					bool isEquip = equipGrp.Contains( item.type );

					bool has = RecipeLibraries.RecipeExists(
						new HashSet<int> { item.type },
						new Dictionary<int, (int, int)> {
							{ ItemID.Cactus, (1, 1000) }
						}
					);

					if( !has ) { return false; }
					return item.createTile == -1 && item.createWall == -1;
				} )
			) );

			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Plain Wood Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];

					bool isEquip = equipGrp.Contains( item.type );

					bool has = RecipeLibraries.RecipeExists(
						new HashSet<int> { item.type },
						new Dictionary<int, (int, int)> {
							{ ItemID.Cactus, (1, 1000) }
						}
					);

					if( !isEquip || !has ) { return false; }
					return item.createTile == -1 && item.createWall == -1;
				} )
			) );
			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Boreal Wood Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];

					bool isEquip = equipGrp.Contains( item.type );

					bool has = RecipeLibraries.RecipeExists(
						new HashSet<int> { item.type },
						new Dictionary<int, (int, int)> {
							{ ItemID.BorealWood, (1, 1000) }
						}
					);

					if( !isEquip || !has ) { return false; }
					return item.createTile == -1 && item.createWall == -1;
				} )
			) );
			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Palm Wood Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];

					bool isEquip = equipGrp.Contains( item.type );

					bool has = RecipeLibraries.RecipeExists(
						new HashSet<int> { item.type },
						new Dictionary<int, (int, int)> {
							{ ItemID.PalmWood, (1, 1000) }
						}
					);

					if( !isEquip || !has ) { return false; }
					return item.createTile == -1 && item.createWall == -1;
				} )
			) );
			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Rich Mahogany Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];

					bool isEquip = equipGrp.Contains( item.type );

					bool has = RecipeLibraries.RecipeExists(
						new HashSet<int> { item.type },
						new Dictionary<int, (int, int)> {
							{ ItemID.RichMahogany, (1, 1000) }
						}
					);

					if( !isEquip || !has ) { return false; }
					return item.createTile == -1 && item.createWall == -1;
				} )
			) );
			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Ebonwood Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];

					bool isEquip = equipGrp.Contains( item.type );

					bool has = RecipeLibraries.RecipeExists(
						new HashSet<int> { item.type },
						new Dictionary<int, (int, int)> {
							{ ItemID.Ebonwood, (1, 1000) }
						}
					);

					if( !isEquip || !has ) { return false; }
					return item.createTile == -1 && item.createWall == -1;
				} )
			) );
			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Shadewood Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];

					bool isEquip = equipGrp.Contains( item.type );

					bool has = RecipeLibraries.RecipeExists(
						new HashSet<int> { item.type },
						new Dictionary<int, (int, int)> {
							{ ItemID.Shadewood, (1, 1000) }
						}
					);

					if( !isEquip || !has ) { return false; }
					return item.createTile == -1 && item.createWall == -1;
				} )
			) );
			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Pearlwood Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];

					bool isEquip = equipGrp.Contains( item.type );

					bool has = RecipeLibraries.RecipeExists(
						new HashSet<int> { item.type },
						new Dictionary<int, (int, int)> {
							{ ItemID.Pearlwood, (1, 1000) }
						}
					);

					if( !isEquip || !has ) { return false; }
					return item.createTile == -1 && item.createWall == -1;
				} )
			) );
			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Spooky Wood Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];

					bool isEquip = equipGrp.Contains( item.type );

					bool has = RecipeLibraries.RecipeExists(
						new HashSet<int> { item.type },
						new Dictionary<int, (int, int)> {
							{ ItemID.SpookyWood, (1, 1000) }
						}
					);

					if( !isEquip || !has ) { return false; }
					return item.createTile == -1 && item.createWall == -1;
				} )
			) );

			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Tin Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];

					bool isEquip = equipGrp.Contains( item.type );

					bool has = RecipeLibraries.RecipeExists(
						new HashSet<int> { item.type },
						new Dictionary<int, (int, int)> {
							{ ItemID.TinBar, (1, 1000) }
						}
					);

					if( !isEquip || !has ) { return false; }
					return item.createTile == -1 && item.createWall == -1;
				} )
			) );
			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Copper Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];

					bool isEquip = equipGrp.Contains( item.type );

					bool has = RecipeLibraries.RecipeExists(
						new HashSet<int> { item.type },
						new Dictionary<int, (int, int)> {
							{ ItemID.CopperBar, (1, 1000) }
						}
					);
//var recipes = Main.recipe.Where( i => !i.createItem.IsAir && i.createItem.type == item.type );
//var recipeItems = recipes.Select( r => r.requiredItem.Where(i => !i.IsAir) );
//var recipeItemsNames = recipeItems.Select( r => r.Select(i => i.Name+":"+i.type+" ("+i.stack+")") );
//var concatRecipeItemsNames = recipeItemsNames.Select( rin => string.Join(",", rin) );
//LogLibraries.Log( item.Name+" equip? "+isEquip+" copper?"+has
//	+" recipes: ["+string.Join("], [", concatRecipeItemsNames)+"]" );
					
					if( !isEquip || !has ) { return false; }
					return item.createTile == -1 && item.createWall == -1;
				} )
			) );

			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Iron Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];

					bool isEquip = equipGrp.Contains( item.type );

					bool has = RecipeLibraries.RecipeExists(
						new HashSet<int> { item.type },
						new Dictionary<int, (int, int)> {
							{ ItemID.IronBar, (1, 1000) }
						}
					);

					if( !isEquip || !has ) { return false; }
					return item.createTile == -1 && item.createWall == -1;
				} )
			) );
			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Lead Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];

					bool isEquip = equipGrp.Contains( item.type );

					bool has = RecipeLibraries.RecipeExists(
						new HashSet<int> { item.type },
						new Dictionary<int, (int, int)> {
							{ ItemID.LeadBar, (1, 1000) }
						}
					);

					if( !isEquip || !has ) { return false; }
					return item.createTile == -1 && item.createWall == -1;
				} )
			) );

			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Silver Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];

					bool isEquip = equipGrp.Contains( item.type );

					bool has = RecipeLibraries.RecipeExists(
						new HashSet<int> { item.type },
						new Dictionary<int, (int, int)> {
							{ ItemID.SilverBar, (1, 1000) }
						}
					);

					if( !isEquip || !has ) { return false; }
					return item.createTile == -1 && item.createWall == -1;
				} )
			) );
			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Tungsten Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];

					bool isEquip = equipGrp.Contains( item.type );

					bool has = RecipeLibraries.RecipeExists(
						new HashSet<int> { item.type },
						new Dictionary<int, (int, int)> {
							{ ItemID.TungstenBar, (1, 1000) }
						}
					);

					if( !isEquip || !has ) { return false; }
					return item.createTile == -1 && item.createWall == -1;
				} )
			) );

			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Gold Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];

					bool isEquip = equipGrp.Contains( item.type );

					bool has = RecipeLibraries.RecipeExists(
						new HashSet<int> { item.type },
						new Dictionary<int, (int, int)> {
							{ ItemID.GoldBar, (1, 1000) }
						}
					);

					if( !isEquip || !has ) { return false; }
					return item.createTile == -1 && item.createWall == -1;
				} )
			) );
			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Platinum Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];

					bool isEquip = equipGrp.Contains( item.type );

					bool has = RecipeLibraries.RecipeExists(
						new HashSet<int> { item.type },
						new Dictionary<int, (int, int)> {
							{ ItemID.PlatinumBar, (1, 1000) }
						}
					);

					if( !isEquip || !has ) { return false; }
					return item.createTile == -1 && item.createWall == -1;
				} )
			) );

			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Meteor Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];

					bool isEquip = equipGrp.Contains( item.type );

					bool has = RecipeLibraries.RecipeExists(
						new HashSet<int> { item.type },
						new Dictionary<int, (int, int)> {
							{ ItemID.MeteoriteBar, (1, 1000) }
						}
					);

					if( !isEquip || !has ) { return false; }
					return item.createTile == -1 && item.createWall == -1;
				} )
			) );
			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Demonite Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];

					bool isEquip = equipGrp.Contains( item.type );

					bool has = RecipeLibraries.RecipeExists(
						new HashSet<int> { item.type },
						new Dictionary<int, (int, int)> {
							{ ItemID.DemoniteBar, (1, 1000) }
						}
					);

					if( !isEquip || !has ) { return false; }
					return item.createTile == -1 && item.createWall == -1;
				} )
			) );
			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Crimtane Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];

					bool isEquip = equipGrp.Contains( item.type );

					bool has = RecipeLibraries.RecipeExists(
						new HashSet<int> { item.type },
						new Dictionary<int, (int, int)> {
							{ ItemID.CrimtaneBar, (1, 1000) }
						}
					);

					if( !isEquip || !has ) { return false; }
					return item.createTile == -1 && item.createWall == -1;
				} )
			) );
			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Jungle Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];

					bool isEquip = equipGrp.Contains( item.type );

					bool has = RecipeLibraries.RecipeExists(
						new HashSet<int> { item.type },
						new Dictionary<int, (int, int)> {
							{ ItemID.JungleSpores, (1, 1000) }
						}
					);

					if( !isEquip || !has ) { return false; }
					return item.createTile == -1 && item.createWall == -1;
				} )
			) );
			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Bee Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];

					bool isEquip = equipGrp.Contains( item.type );

					bool has = RecipeLibraries.RecipeExists(
						new HashSet<int> { item.type },
						new Dictionary<int, (int, int)> {
							{ ItemID.BeeWax, (1, 1000) }
						}
					);

					if( !isEquip || !has ) { return false; }
					return item.createTile == -1 && item.createWall == -1;
				} )
			) );
			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Bone Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];

					bool isEquip = equipGrp.Contains( item.type );

					bool has = RecipeLibraries.RecipeExists(
						new HashSet<int> { item.type },
						new Dictionary<int, (int, int)> {
							{ ItemID.Bone, (1, 1000) }
						}
					);

					if( !isEquip || !has ) { return false; }
					return item.createTile == -1 && item.createWall == -1;
				} )
			) );
			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Hellstone Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];

					bool isEquip = equipGrp.Contains( item.type );

					bool has = RecipeLibraries.RecipeExists(
						new HashSet<int> { item.type },
						new Dictionary<int, (int, int)> {
							{ ItemID.HellstoneBar, (1, 1000) }
						}
					);

					if( !isEquip || !has ) { return false; }
					return item.createTile == -1 && item.createWall == -1;
				} )
			) );

			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Cobalt Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];

					bool isEquip = equipGrp.Contains( item.type );

					bool has = RecipeLibraries.RecipeExists(
						new HashSet<int> { item.type },
						new Dictionary<int, (int, int)> {
							{ ItemID.CobaltBar, (1, 1000) }
						}
					);

					if( !isEquip || !has ) { return false; }
					return item.createTile == -1 && item.createWall == -1;
				} )
			) );
			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Palladium Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];

					bool isEquip = equipGrp.Contains( item.type );

					bool has = RecipeLibraries.RecipeExists(
						new HashSet<int> { item.type },
						new Dictionary<int, (int, int)> {
							{ ItemID.PalladiumBar, (1, 1000) }
						}
					);

					if( !isEquip || !has ) { return false; }
					return item.createTile == -1 && item.createWall == -1;
				} )
			) );
			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Mythril Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];

					bool isEquip = equipGrp.Contains( item.type );

					bool has = RecipeLibraries.RecipeExists(
						new HashSet<int> { item.type },
						new Dictionary<int, (int, int)> {
							{ ItemID.MythrilBar, (1, 1000) }
						}
					);

					if( !isEquip || !has ) { return false; }
					return item.createTile == -1 && item.createWall == -1;
				} )
			) );
			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Orichalcum Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];

					bool isEquip = equipGrp.Contains( item.type );

					bool has = RecipeLibraries.RecipeExists(
						new HashSet<int> { item.type },
						new Dictionary<int, (int, int)> {
							{ ItemID.OrichalcumBar, (1, 1000) }
						}
					);

					if( !isEquip || !has ) { return false; }
					return item.createTile == -1 && item.createWall == -1;
				} )
			) );
			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Adamantite Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];

					bool isEquip = equipGrp.Contains( item.type );

					bool has = RecipeLibraries.RecipeExists(
						new HashSet<int> { item.type },
						new Dictionary<int, (int, int)> {
							{ ItemID.AdamantiteBar, (1, 1000) }
						}
					);

					if( !isEquip || !has ) { return false; }
					return item.createTile == -1 && item.createWall == -1;
				} )
			) );
			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Titanium Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];

					bool isEquip = equipGrp.Contains( item.type );

					bool has = RecipeLibraries.RecipeExists(
						new HashSet<int> { item.type },
						new Dictionary<int, (int, int)> {
							{ ItemID.TitaniumBar, (1, 1000) }
						}
					);

					if( !isEquip || !has ) { return false; }
					return item.createTile == -1 && item.createWall == -1;
				} )
			) );

			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Frost Core Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];

					bool isEquip = equipGrp.Contains( item.type );

					bool has = RecipeLibraries.RecipeExists(
						new HashSet<int> { item.type },
						new Dictionary<int, (int, int)> {
							{ ItemID.FrostCore, (1, 1000) }
						}
					);

					if( !isEquip || !has ) { return false; }
					return item.createTile == -1 && item.createWall == -1;
				} )
			) );
			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Forbidden Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];

					bool isEquip = equipGrp.Contains( item.type );

					bool has = RecipeLibraries.RecipeExists(
						new HashSet<int> { item.type },
						new Dictionary<int, (int, int)> {
							{ ItemID.AncientBattleArmorMaterial, (1, 1000) }
						}
					);

					if( !isEquip || !has ) { return false; }
					return item.createTile == -1 && item.createWall == -1;
				} )
			) );
			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Hallow Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];

					bool isEquip = equipGrp.Contains( item.type );

					bool has = RecipeLibraries.RecipeExists(
						new HashSet<int> { item.type },
						new Dictionary<int, (int, int)> {
							{ ItemID.HallowedBar, (1, 1000) }
						}
					);

					if( !isEquip || !has ) { return false; }
					return item.createTile == -1 && item.createWall == -1;
				} )
			) );
			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Chlorophyte Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];

					bool isEquip = equipGrp.Contains( item.type );

					bool has = RecipeLibraries.RecipeExists(
						new HashSet<int> { item.type },
						new Dictionary<int, (int, int)> {
							{ ItemID.ChlorophyteBar, (1, 1000) }
						}
					);

					if( !isEquip || !has ) { return false; }
					return item.createTile == -1 && item.createWall == -1;
				} )
			) );
			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Shroomite Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];

					bool isEquip = equipGrp.Contains( item.type );

					bool has = RecipeLibraries.RecipeExists(
						new HashSet<int> { item.type },
						new Dictionary<int, (int, int)> {
							{ ItemID.ShroomiteBar, (1, 1000) }
						}
					);

					if( !isEquip || !has ) { return false; }
					return item.createTile == -1 && item.createWall == -1;
				} )
			) );
			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Spectre Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];

					bool isEquip = equipGrp.Contains( item.type );

					bool has = RecipeLibraries.RecipeExists(
						new HashSet<int> { item.type },
						new Dictionary<int, (int, int)> {
							{ ItemID.SpectreBar, (1, 1000) }
						}
					);

					if( !isEquip || !has ) { return false; }
					return item.createTile == -1 && item.createWall == -1;
				} )
			) );
			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Shell Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];

					bool isEquip = equipGrp.Contains( item.type );

					bool has1 = RecipeLibraries.RecipeExists(
						new HashSet<int> { item.type },
						new Dictionary<int, (int, int)> {
							{ ItemID.BeetleShell, (1, 1000) }
						}
					);
					bool has2 = RecipeLibraries.RecipeExists(
						new HashSet<int> { item.type },
						new Dictionary<int, (int, int)> {
							{ ItemID.TurtleShell, (1, 1000) }
						}
					);

					if( !isEquip || (!has1 && !has2) ) { return false; }
					return item.createTile == -1 && item.createWall == -1;
				} )
			) );

			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Nebula Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];

					bool isEquip = equipGrp.Contains( item.type );

					bool has = RecipeLibraries.RecipeExists(
						new HashSet<int> { item.type },
						new Dictionary<int, (int, int)> {
							{ ItemID.FragmentNebula, (1, 1000) }
						}
					);

					if( !isEquip || !has ) { return false; }
					return item.createTile == -1 && item.createWall == -1;
				} )
			) );
			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Vortex Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];

					bool isEquip = equipGrp.Contains( item.type );

					bool isCraftedWithVortex = RecipeLibraries.RecipeExists(
						new HashSet<int> { item.type },
						new Dictionary<int, (int, int)> {
							{ ItemID.FragmentVortex, (1, 1000) }
						}
					);

					if( !isEquip || !isCraftedWithVortex ) { return false; }
					return item.createTile == -1 && item.createWall == -1;
				} )
			) );
			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Solar Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];

					bool isEquip = equipGrp.Contains( item.type );

					bool isCraftedWithSolar = RecipeLibraries.RecipeExists(
						new HashSet<int> { item.type },
						new Dictionary<int, (int, int)> {
							{ ItemID.FragmentSolar, (1, 1000) }
						}
					);

					if( !isEquip || !isCraftedWithSolar ) { return false; }
					return item.createTile == -1 && item.createWall == -1;
				} )
			) );
			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Stardust Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];

					bool isEquip = equipGrp.Contains( item.type );

					bool isCraftedWithStardust = RecipeLibraries.RecipeExists(
						new HashSet<int> { item.type },
						new Dictionary<int, (int, int)> {
							{ ItemID.FragmentStardust, (1, 1000) }
						}
					);

					if( !isEquip || !isCraftedWithStardust ) { return false; }
					return item.createTile == -1 && item.createWall == -1;
				} )
			) );
			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: "Any Luminite Ore Equipment",
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					ISet<int> equipGrp = grps[ItemGroupIDs.AnyEquipment];

					bool isEquip = equipGrp.Contains( item.type );

					bool has = RecipeLibraries.RecipeExists(
						new HashSet<int> { item.type },
						new Dictionary<int, (int, int)> {
							{ ItemID.LunarBar, (1, 1000) }
						}
					);

					if( isEquip || !has ) { return false; }
					return item.createTile == -1 && item.createWall == -1;
				} )
			) );
		}
	}
}
