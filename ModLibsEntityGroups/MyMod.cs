using System;
using Terraria;
using Terraria.ModLoader;
using ModLibsCore.Libraries.Debug;


namespace ModLibsEntityGroups {
	/// @private
	partial class ModLibsEntGroupsMod : Mod {
		public static ModLibsEntGroupsMod Instance { get; private set; }



		////////////////

		public override void Load() {
			ModLibsEntGroupsMod.Instance = this;
		}

		////

		public override void Unload() {
			try {
				LogLibraries.Alert( "Unloading mod..." );
			} catch { }

			ModLibsEntGroupsMod.Instance = null;
		}
	}
}
