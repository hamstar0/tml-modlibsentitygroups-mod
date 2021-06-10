﻿using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using ModLibsCore.Libraries.Debug;
using ModLibsGeneral.Libraries.Recipes;


namespace ModLibsEntityGroups.Services.EntityGroups.Definitions {
	/// <summary></summary>
	public partial class ItemGroupIDs {
		/// <summary></summary>
		public const string AnyPlainMaterial = "Any Plain Material";
		/// <summary></summary>
		public const string AnyVanillaCorruptionItem = "Any Vanilla Corruption Item";
		/// <summary></summary>
		public const string AnyVanillaCrimsonItem = "Any Vanilla Crimson Item";
		/// <summary></summary>
		public const string AnyVanillaAlchemyHerb = "Any Vanilla Alchemy Herb";
		/// <summary></summary>
		public const string AnyVanillaAlchemyFish = "Any Vanilla Alchemy Fish";
		/// <summary></summary>
		public const string AnyVanillaAlchemyMisc = "Any Vanilla Alchemy Misc";
	}




	partial class EntityGroupDefs {
		internal static void DefineItemMiscGroups3( IList<EntityGroupBuilderDefinition<Item>> defs ) {
			ISet<int> GetItemSet( int itemType ) {
				return new HashSet<int> { itemType };
			}
			IDictionary<int, (int, int)> GetMinIngreds( int itemType ) {
				return new Dictionary<int, (int, int)> { { itemType, (1, 1000) } };
			}

			//

			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: ItemGroupIDs.AnyPlainMaterial,
				grpDeps: new string[] { ItemGroupIDs.AnyEquipment },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					return item.material &&
						//!EntityGroups.ItemGroups["Any Placeable"].Contains( item.type ) &&
						!grps[ItemGroupIDs.AnyEquipment].Contains( item.type );
				} )
			) );

			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: ItemGroupIDs.AnyVanillaCorruptionItem,
				grpDeps: null,
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					switch( item.type ) {
					case ItemID.Ebonwood:
					case ItemID.EbonsandBlock:
					case ItemID.CorruptSandstone:
					case ItemID.CorruptSandstoneWall:
					case ItemID.CorruptHardenedSand:
					case ItemID.CorruptHardenedSandWall:
					case ItemID.EbonstoneBlock:
					case ItemID.DemoniteBrick:
					case ItemID.PurpleIceBlock:

					case ItemID.CorruptSeeds:
					case ItemID.VileMushroom:
					case ItemID.VilePowder:
					case ItemID.Deathweed:
					case ItemID.DeathweedSeeds:
					case ItemID.RottenChunk:
					case ItemID.WormTooth:
					case ItemID.SoulofNight:
					case ItemID.DarkShard:

					case ItemID.ShadowScale:
					case ItemID.EaterMask:
					case ItemID.EaterofWorldsTrophy:
					case ItemID.EatersBone:

					case ItemID.CorruptionKey:
					case ItemID.CorruptionKeyMold://?

					case ItemID.AncientShadowGreaves:
					case ItemID.AncientShadowHelmet:
					case ItemID.AncientShadowScalemail:
					case ItemID.BallOHurt:
					case ItemID.Musket:
					case ItemID.ShadowOrb:
					case ItemID.Vilethorn:
					case ItemID.BandofStarpower:

					case ItemID.ChainGuillotines:
					case ItemID.ClingerStaff:
					case ItemID.DartRifle:
					case ItemID.PutridScent:

					case ItemID.WormFood:
					case ItemID.NightsEdge:
					case ItemID.TrueNightsEdge:

					case ItemID.Ebonkoi:
					case ItemID.PurpleClubberfish:
					case ItemID.Toxikarp:
					case ItemID.CorruptFishingCrate:
						return true;
					}

					if( item.type <= ItemID.Count ) {
						if( RecipeLibraries.RecipeExists( GetItemSet(item.type), GetMinIngreds(ItemID.VilePowder) ) ) {
							return true;
						}
						if( RecipeLibraries.RecipeExists( GetItemSet(item.type), GetMinIngreds(ItemID.DemoniteOre) ) ) {
							return true;
						}
						if( RecipeLibraries.RecipeExists( GetItemSet(item.type), GetMinIngreds(ItemID.DemoniteBar) ) ) {
							return true;
						}
						
						if( RecipeLibraries.RecipeExists( GetItemSet(item.type), GetMinIngreds(ItemID.ShadowScale) ) ) {
							return true;
						}
						if( RecipeLibraries.RecipeExists( GetItemSet(item.type), GetMinIngreds(ItemID.CursedFlames) ) ) {
							return true;
						}
						
						if( RecipeLibraries.RecipeExists( GetItemSet(item.type), GetMinIngreds(ItemID.Ebonwood) ) ) {
							return true;
						}
						if( RecipeLibraries.RecipeExists( GetItemSet(item.type), GetMinIngreds(ItemID.PurpleIceBlock) ) ) {
							return true;
						}
						if( RecipeLibraries.RecipeExists( GetItemSet(item.type), GetMinIngreds(ItemID.EbonstoneBlock) ) ) {
							return true;
						}
						if( RecipeLibraries.RecipeExists( GetItemSet(item.type), GetMinIngreds(ItemID.EbonstoneBrick) ) ) {
							return true;
						}
						if( RecipeLibraries.RecipeExists( GetItemSet(item.type), GetMinIngreds(ItemID.DemoniteBrick) ) ) {
							return true;
						}
						
						if( RecipeLibraries.RecipeExists( GetItemSet(item.type), GetMinIngreds(ItemID.CorruptSeeds) ) ) {
							return true;
						}
					}

					return false;
				} )
			) );

			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: ItemGroupIDs.AnyVanillaCrimsonItem,
				grpDeps: null,
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					switch( item.type ) {
					case ItemID.Shadewood:
					case ItemID.CrimsandBlock:
					case ItemID.CrimsonSandstone:
					case ItemID.CrimsonSandstoneWall:
					case ItemID.CrimsonHardenedSand:
					case ItemID.CrimsonHardenedSandWall:
					case ItemID.CrimstoneBlock:
					case ItemID.CrimtaneBrick:
					case ItemID.RedIceBlock:
					case ItemID.FleshBlock:

					case ItemID.CrimsonSeeds:
					case ItemID.ViciousMushroom:
					case ItemID.ViciousPowder:
					case ItemID.Deathweed:
					case ItemID.DeathweedSeeds:
					case ItemID.Vertebrae:
					case ItemID.SoulofNight:
					case ItemID.DarkShard:
					case ItemID.MeatGrinder:

					case ItemID.TissueSample:
					case ItemID.BrainMask:
					case ItemID.BrainofCthulhuTrophy:
					case ItemID.BoneRattle:

					case ItemID.CrimsonKey:
					case ItemID.CrimsonKeyMold://?

					case ItemID.TheUndertaker:
					case ItemID.TheRottedFork:
					case ItemID.CrimsonRod:
					case ItemID.PanicNecklace:
					case ItemID.CrimsonHeart:

					case ItemID.SoulDrain:
					case ItemID.DartPistol:
					case ItemID.FetidBaghnakhs:
					case ItemID.FleshKnuckles:
					case ItemID.TendonHook:

					case ItemID.BloodySpine:
					case ItemID.NightsEdge:
					case ItemID.TrueNightsEdge:

					case ItemID.CrimsonTigerfish:
					case ItemID.Hemopiranha:
					case ItemID.CrimsonFishingCrate:
					case ItemID.Bladetongue:
						return true;
					}

					if( item.type <= ItemID.Count ) {
						if( RecipeLibraries.RecipeExists( GetItemSet(item.type), GetMinIngreds(ItemID.ViciousPowder) ) ) {
							return true;
						}
						if( RecipeLibraries.RecipeExists( GetItemSet(item.type), GetMinIngreds(ItemID.Vertebrae) ) ) {
							return true;
						}
						if( RecipeLibraries.RecipeExists( GetItemSet(item.type), GetMinIngreds(ItemID.CrimtaneOre) ) ) {
							return true;
						}
						if( RecipeLibraries.RecipeExists( GetItemSet(item.type), GetMinIngreds(ItemID.CrimtaneBar) ) ) {
							return true;
						}
						if( RecipeLibraries.RecipeExists( GetItemSet(item.type), GetMinIngreds(ItemID.Ichor) ) ) {
							return true;
						}
						
						if( RecipeLibraries.RecipeExists( GetItemSet(item.type), GetMinIngreds(ItemID.TissueSample) ) ) {
							return true;
						}
						
						if( RecipeLibraries.RecipeExists( GetItemSet(item.type), GetMinIngreds(ItemID.Shadewood) ) ) {
							return true;
						}
						if( RecipeLibraries.RecipeExists( GetItemSet(item.type), GetMinIngreds(ItemID.RedIceBlock) ) ) {
							return true;
						}
						if( RecipeLibraries.RecipeExists( GetItemSet(item.type), GetMinIngreds(ItemID.CrimstoneBlock) ) ) {
							return true;
						}
						if( RecipeLibraries.RecipeExists( GetItemSet(item.type), GetMinIngreds(ItemID.CrimtaneBrick) ) ) {
							return true;
						}
						if( RecipeLibraries.RecipeExists( GetItemSet(item.type), GetMinIngreds(ItemID.FleshBlock) ) ) {
							return true;
						}
						
						if( RecipeLibraries.RecipeExists( GetItemSet(item.type), GetMinIngreds(ItemID.CrimsonSeeds) ) ) {
							return true;
						}
					}

					return false;
				} )
			) );

			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: ItemGroupIDs.AnyVanillaAlchemyHerb,
				grpDeps: null,
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					switch( item.type ) {
					case ItemID.Daybloom:
					case ItemID.Blinkroot:
					case ItemID.Moonglow:
					case ItemID.Waterleaf:
					case ItemID.Deathweed:
					case ItemID.Fireblossom:
					case ItemID.Shiverthorn:
						return true;
					default:
						return false;
					}
				} )
			) );

			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: ItemGroupIDs.AnyVanillaAlchemyFish,
				grpDeps: null,
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					switch( item.type ) {
					case ItemID.DoubleCod:
					case ItemID.Damselfish:
					case ItemID.ArmoredCavefish:
					case ItemID.CrimsonTigerfish:
					case ItemID.Obsidifish:
					case ItemID.Prismite:
					case ItemID.PrincessFish:
					case ItemID.Hemopiranha:
					case ItemID.Stinkfish:
					case ItemID.VariegatedLardfish:
					case ItemID.FrostMinnow:
					case ItemID.Ebonkoi:
					case ItemID.SpecularFish:
					case ItemID.ChaosFish:
						return true;
					default:
						return false;
					}
				} )
			) );

			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: ItemGroupIDs.AnyVanillaAlchemyMisc,
				grpDeps: null,
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					switch( item.type ) {
					case ItemID.Mushroom:
					case ItemID.GlowingMushroom:
					case ItemID.Gel:
					case ItemID.Cactus:
					case ItemID.FallenStar:
					case ItemID.PinkGel:
					case ItemID.Lens:
					case ItemID.IronOre:
					case ItemID.LeadOre:
					case ItemID.GoldOre:
					case ItemID.PlatinumOre:
					case ItemID.Obsidian:
					case ItemID.Cobweb:
					case ItemID.CrispyHoneyBlock:
					case ItemID.Coral:
					case ItemID.Amber:
					case ItemID.Feather:
					case ItemID.AntlionMandible:
					case ItemID.SharkFin:
					case ItemID.Stinger:
					case ItemID.WormTooth:
					case ItemID.RottenChunk:
					case ItemID.Vertebrae:
					case ItemID.Bone:
					case ItemID.PixieDust:
					case ItemID.CrystalShard:
					case ItemID.UnicornHorn:
					case ItemID.FragmentNebula:
					case ItemID.FragmentSolar:
					case ItemID.FragmentStardust:
					case ItemID.FragmentVortex:
						return true;
					default:
						return false;
					}
				} )
			) );
		}
	}
}
