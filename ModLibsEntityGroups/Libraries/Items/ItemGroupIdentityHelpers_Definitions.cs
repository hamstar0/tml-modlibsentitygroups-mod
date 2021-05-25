﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Terraria.ID;
using ModLibsCore.Libraries.Debug;
using ModLibsCore.Libraries.DotNET.Reflection;
using ModLibsCore.Classes.DataStructures;
using ModLibsGeneral.Libraries.NPCs;
using ModLibsGeneral.Libraries.Items;


namespace ModLibsEntityGroups.Libraries.Items {
	/// <summary></summary>
	public class ItemGroupDefinition {
		/// <summary></summary>
		public string GroupName { get; }
		/// <summary></summary>
		public ISet<int> Group { get; }


		/// <summary></summary>
		/// <param name="groupName"></param>
		/// <param name="group"></param>
		public ItemGroupDefinition( string groupName, ISet<int> group ) {
			this.GroupName = groupName;
			this.Group = new ReadOnlySet<int>( group );
		}
	}




	/// <summary>
	/// Assorted static "helper" functions pertaining to item group identification.
	/// </summary>
	public partial class ItemGroupIdentityLibraries {
		/// <summary>
		/// Gets a set of "common" item groups (i.e. for RecipeGroup use).
		/// </summary>
		/// <returns>Group names mapped to group description and a set of item ids.</returns>
		public static IDictionary<string, ItemGroupDefinition> GetCommonItemGroups() {
			IEnumerable<PropertyInfo> itemGrpFields = typeof( ItemGroupIdentityLibraries )
					.GetProperties( ReflectionLibraries.MostAccess );

			itemGrpFields = itemGrpFields.Where( field => {
				return field.PropertyType == typeof( ItemGroupDefinition );
			} );

			var groups = itemGrpFields.ToDictionary(
				prop => prop.Name,
				prop => (ItemGroupDefinition)prop.GetValue( null )
			);
			/*groups["EvilBiomeBossChunks"] = groups["EvilBiomeBossDrops"];
			groups["EvilBiomeLightPet"] = groups["EvilBiomeLightPets"];
			groups["VanillaButterfly"] = groups["VanillaButterflies"];
			groups["VanillaGoldCritter"] = groups["VanillaGoldCritters"];
			groups["PressurePlates"] = groups["AllPressurePlates"];
			groups["WeightedPressurePlates"] = groups["WeightPressurePlates"];
			groups["ConveyorBelts"] = groups["ConveyorBeltPair"];
			groups["NpcBanners"] = ItemGroupIdentityHelpers.MobBanners;
			groups["VanillaRecordedMusicBoxes"] = ItemGroupIdentityHelpers.VanillaRecordedMusicBoxes;*/

			return groups;
		}


		////////////////

		/// <summary>
		/// All NPC banner items.
		/// </summary>
		public static ItemGroupDefinition MobBanners =>
			new ItemGroupDefinition(
				"Mob Banners",
				NPCBannerLibraries.GetBannerItemTypes()
			);

		/// <summary>
		/// All vanilla recorded music boxes.
		/// </summary>
		public static ItemGroupDefinition VanillaRecordedMusicBoxes =>
			new ItemGroupDefinition(
				"Recorded Music Box (vanilla)",
				MusicBoxLibraries.GetVanillaMusicBoxItemIds()
			);

		/// <summary>
		/// The special drops of each "evil" biome (Eater of Worlds and Brain of Cthulhu).
		/// </summary>
		public static ItemGroupDefinition EvilBiomeBossDrops =>
			new ItemGroupDefinition(
				"Evil Biome Boss Drops",
				new HashSet<int>( new int[] { ItemID.ShadowScale, ItemID.TissueSample } )
			);

		/// <summary>
		/// Each type of "evil" biome-originating light-emitting pet (Crimson Heart and Shadow Orb).
		/// </summary>
		public static ItemGroupDefinition EvilBiomeLightPets =>
			new ItemGroupDefinition(
				"Evil Biome Light Pet",
				new HashSet<int>( new int[] { ItemID.CrimsonHeart, ItemID.ShadowOrb } )
			);

		/// <summary>
		/// Each vanilla variant of a Magic Mirror.
		/// </summary>
		public static ItemGroupDefinition MagicMirrors =>
			new ItemGroupDefinition(
				"Magic Mirrors",
				new HashSet<int>( new int[] { ItemID.MagicMirror, ItemID.IceMirror } )
			);

		/// <summary>
		/// Each potion that performs non-random player warping.
		/// </summary>
		public static ItemGroupDefinition WarpPotions =>
			new ItemGroupDefinition(
				"Warp Potions",
				new HashSet<int>( new int[] { ItemID.RecallPotion, ItemID.WormholePotion } )
			);


		/// <summary>
		/// Each vanilla passive animal type.
		/// </summary>
		public static ItemGroupDefinition VanillaAnimals =>
			new ItemGroupDefinition(
				"Live Animal (vanilla)",
				new HashSet<int>( new int[] {
					ItemID.Bird, ItemID.BlueJay, ItemID.Cardinal,
					ItemID.Duck, ItemID.MallardDuck, ItemID.Penguin,
					ItemID.Bunny, ItemID.Squirrel, ItemID.SquirrelRed, ItemID.Frog, ItemID.Mouse,
					ItemID.Goldfish,
					ItemID.GoldBunny, ItemID.GoldBird, ItemID.GoldFrog, ItemID.GoldMouse, ItemID.SquirrelGold
				} )
			);
		
		/// <summary>
		/// Each vanilla passive bug type (including the Truffle Worm).
		/// </summary>
		public static ItemGroupDefinition VanillaBugs =>
			new ItemGroupDefinition(
				"Live Bug (vanilla)",
				new HashSet<int>( new int[] {
					ItemID.JuliaButterfly, ItemID.MonarchButterfly, ItemID.PurpleEmperorButterfly,
					ItemID.RedAdmiralButterfly, ItemID.SulphurButterfly, ItemID.TreeNymphButterfly,
					ItemID.UlyssesButterfly, ItemID.ZebraSwallowtailButterfly,
					ItemID.Scorpion, ItemID.BlackScorpion, ItemID.Grasshopper,
					ItemID.EnchantedNightcrawler, ItemID.Worm,
					ItemID.GlowingSnail, ItemID.Grubby, ItemID.Sluggy, ItemID.Snail,
					ItemID.TruffleWorm,
					ItemID.GoldGrasshopper, ItemID.GoldWorm, ItemID.GoldButterfly
				} )
			);
		
		/// <summary>
		/// Each banilla butterfly type.
		/// </summary>
		public static ItemGroupDefinition VanillaButterflies =>
			new ItemGroupDefinition(
				"Butterflies (vanilla)",
				new HashSet<int>( new int[] {
					ItemID.JuliaButterfly, ItemID.MonarchButterfly, ItemID.PurpleEmperorButterfly,
					ItemID.RedAdmiralButterfly, ItemID.SulphurButterfly, ItemID.TreeNymphButterfly,
					ItemID.UlyssesButterfly, ItemID.ZebraSwallowtailButterfly, ItemID.GoldButterfly
				} )
			);
		
		/// <summary>
		/// Each vanilla gold critter variant.
		/// </summary>
		public static ItemGroupDefinition VanillaGoldCritters =>
			new ItemGroupDefinition(
				"Gold Critters (vanilla)",
				new HashSet<int>( new int[] {
					ItemID.GoldBunny, ItemID.GoldMouse, ItemID.SquirrelGold, ItemID.GoldBird, ItemID.GoldFrog,
					ItemID.GoldGrasshopper, ItemID.GoldWorm, ItemID.GoldButterfly
				} )
			);
		
		/// <summary>
		/// Each vanilla alchemy herb.
		/// </summary>
		public static ItemGroupDefinition VanillaAlchemyHerbs =>
			new ItemGroupDefinition(
				"Alchemy Herbs (vanilla)",
				new HashSet<int>( new int[] {
					ItemID.Daybloom, ItemID.Blinkroot, ItemID.Moonglow, ItemID.Deathweed, ItemID.Fireblossom, ItemID.Shiverthorn
				} )
			);
		/// <summary>
		/// Each vanilla 'strange plant'.
		/// </summary>
		public static ItemGroupDefinition VanillaStrangePlants =>
			new ItemGroupDefinition(
				"Strange Plant",
				new HashSet<int>( new int[] {
					ItemID.StrangePlant1, ItemID.StrangePlant2, ItemID.StrangePlant3, ItemID.StrangePlant4
				} )
			);
		
		/// <summary>
		/// All pressure plates.
		/// </summary>
		public static ItemGroupDefinition AllPressurePlates =>
			new ItemGroupDefinition(
				"Pressure Plates",
				new HashSet<int>( new int[] {
					ItemID.BluePressurePlate, ItemID.BrownPressurePlate, ItemID.GrayPressurePlate, ItemID.GreenPressurePlate,
					ItemID.LihzahrdPressurePlate, ItemID.RedPressurePlate, ItemID.YellowPressurePlate,
					ItemID.WeightedPressurePlateCyan, ItemID.WeightedPressurePlateOrange, ItemID.WeightedPressurePlatePink,
					ItemID.WeightedPressurePlatePurple, ItemID.ProjectilePressurePad
				} )
			);
		/// <summary>
		/// All weighted pressure plates.
		/// </summary>
		public static ItemGroupDefinition WeightPressurePlates =>
			new ItemGroupDefinition(
				"Weighted Pressure Plates",
				new HashSet<int>( new int[] {
					ItemID.WeightedPressurePlateCyan, ItemID.WeightedPressurePlateOrange, ItemID.WeightedPressurePlatePink,
					ItemID.WeightedPressurePlatePurple
				} )
			);
		/// <summary>
		/// All conveyor belts.
		/// </summary>
		public static ItemGroupDefinition ConveyorBeltPair =>
			new ItemGroupDefinition(
				"Conveyor Belts",
				new HashSet<int>( new int[] { ItemID.ConveyorBeltLeft, ItemID.ConveyorBeltRight } )
			);
		
		/// <summary>
		/// All paints cans.
		/// </summary>
		public static ItemGroupDefinition Paints =>
			new ItemGroupDefinition(
				"Paints",
				new HashSet<int>( new int[] {
					ItemID.BlackPaint, ItemID.BluePaint, ItemID.BrownPaint, ItemID.CyanPaint,
					ItemID.DeepBluePaint, ItemID.DeepCyanPaint, ItemID.DeepGreenPaint, ItemID.DeepLimePaint,
					ItemID.DeepOrangePaint, ItemID.DeepPinkPaint, ItemID.DeepPurplePaint, ItemID.DeepRedPaint,
					ItemID.DeepSkyBluePaint, ItemID.DeepTealPaint, ItemID.DeepVioletPaint, ItemID.DeepYellowPaint,
					ItemID.GrayPaint, ItemID.GreenPaint, ItemID.LimePaint, ItemID.NegativePaint, ItemID.OrangePaint,
					ItemID.PinkPaint, ItemID.PurplePaint, ItemID.RedPaint, ItemID.ShadowPaint, ItemID.SkyBluePaint,
					ItemID.TealPaint, ItemID.VioletPaint, ItemID.WhitePaint, ItemID.YellowPaint
				} )
			);
		/// <summary>
		/// All vanilla dyes.
		/// </summary>
		public static ItemGroupDefinition VanillaDyes =>
			new ItemGroupDefinition(
				"Dyes (vanilla)",
				new HashSet<int>( new int[] {
					ItemID.RedDye, ItemID.RedDye, ItemID.OrangeDye, ItemID.YellowDye, ItemID.LimeDye, ItemID.BrightTealDye, ItemID.BrightCyanDye,
					ItemID.BrightSkyBlueDye, ItemID.BrightBlueDye, ItemID.BrightPurpleDye, ItemID.BrightVioletDye, ItemID.BrightPinkDye,
					ItemID.BlackDye, ItemID.RedandSilverDye, ItemID.OrangeandSilverDye, ItemID.YellowandSilverDye, ItemID.LimeandSilverDye,
					ItemID.GreenandSilverDye, ItemID.TealandSilverDye, ItemID.CyanandSilverDye, ItemID.SkyBlueandSilverDye, ItemID.BlueandSilverDye,
					ItemID.PurpleandSilverDye, ItemID.VioletandSilverDye, ItemID.PinkandSilverDye, ItemID.IntenseFlameDye,
					ItemID.IntenseGreenFlameDye, ItemID.IntenseBlueFlameDye, ItemID.RainbowDye, ItemID.IntenseRainbowDye, ItemID.YellowGradientDye,
					ItemID.CyanGradientDye, ItemID.BrightGreenDye, ItemID.BrightLimeDye, ItemID.BrightYellowDye, ItemID.BrightOrangeDye,
					ItemID.GreenDye, ItemID.TealDye, ItemID.CyanDye, ItemID.SkyBlueDye, ItemID.BlueDye, ItemID.PurpleDye, ItemID.VioletDye,
					ItemID.PinkDye, ItemID.RedandBlackDye, ItemID.OrangeandBlackDye, ItemID.YellowandBlackDye, ItemID.LimeandBlackDye,
					ItemID.GreenandBlackDye, ItemID.OrichalcumRepeater, ItemID.TealandBlackDye, ItemID.SkyBlueandBlackDye, ItemID.BlueandBlackDye,
					ItemID.PurpleandBlackDye, ItemID.VioletandBlackDye, ItemID.PinkandBlackDye, ItemID.FlameDye, ItemID.FlameAndBlackDye,
					ItemID.GreenFlameDye, ItemID.GreenFlameAndBlackDye, ItemID.BlueFlameDye, ItemID.BlueFlameAndBlackDye, ItemID.SilverDye,
					ItemID.BrightRedDye, ItemID.CyanandBlackDye, ItemID.VioletGradientDye, ItemID.TeamDye, ItemID.MartianHairDye,
					ItemID.MartianArmorDye, ItemID.LivingFlameDye, ItemID.LivingRainbowDye, ItemID.ShadowDye, ItemID.NegativeDye,
					ItemID.LivingOceanDye, ItemID.PumpkinSink, ItemID.BrownDye, ItemID.DevDye, ItemID.PurpleOozeDye, ItemID.ReflectiveSilverDye,
					ItemID.ReflectiveGoldDye, ItemID.BlueAcidDye, ItemID.HadesDye, ItemID.TwilightDye, ItemID.AcidDye, ItemID.MushroomDye,
					ItemID.PhaseDye, ItemID.ReflectiveDye, ItemID.TwilightHairDye, ItemID.SolarDye, ItemID.NebulaDye, ItemID.VortexDye,
					ItemID.StardustDye, ItemID.VoidDye, ItemID.ShiftingSandsDye, ItemID.MirageDye, ItemID.ShiftingPearlSandsDye,
					ItemID.FlameAndSilverDye, ItemID.GreenFlameAndSilverDye, ItemID.BlueFlameAndSilverDye, ItemID.ReflectiveCopperDye,
					ItemID.ReflectiveObsidianDye, ItemID.ReflectiveMetalDye, ItemID.MidnightRainbowDye, ItemID.BlackAndWhiteDye,
					ItemID.BrightSilverDye, ItemID.SilverAndBlackDye, ItemID.RedAcidDye, ItemID.GelDye, ItemID.PinkGelDye, ItemID.BurningHadesDye,
					ItemID.GrimDye, ItemID.LokisDye, ItemID.ShadowflameHadesDye
				} )
			);

		/// <summary>
		/// All banner types.
		/// </summary>
		public static ItemGroupDefinition Banners =>
			new ItemGroupDefinition(
				"Banners",
				new HashSet<int>( NPCBannerLibraries.GetBannerItemTypes() )
			);
	}
}
