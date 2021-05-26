using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;


namespace ModLibsEntityGroups {
	/// <summary>
	/// Defines config settings.
	/// </summary>
	[Label( "Mod Libs - Entity Groups - Settings" )]
	public class ModLibsEntityGroupsConfig : ModConfig {
		/// <summary>
		/// Gets the stack-merged singleton instance of this config file.
		/// </summary>
		public static ModLibsEntityGroupsConfig Instance => ModContent.GetInstance<ModLibsEntityGroupsConfig>();



		////////////////

		/// @private
		public override ConfigScope Mode => ConfigScope.ServerSide;



		////////////////

		/// <summary>
		/// Displays all entity groups in the log on mod load.
		/// </summary>
		[Label( "Debug Mode - Display entity groups" )]
		[Tooltip( "Displays all entity groups in the log on mod load." )]
		public bool DebugModeInfo { get; set; } = false;
	}
}
