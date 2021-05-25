using System;
using System.Collections.Generic;
using Terraria;
using ModLibsCore.Classes.Loadable;


namespace ModLibsEntityGroups.Libraries.Recipes {
	/// @private
	public partial class RecipeGroupLibraries : ILoadable {
		private IDictionary<string, RecipeGroup> _Groups = null;



		////////////////

		void ILoadable.OnModsLoad() { }

		void ILoadable.OnModsUnload() { }

		void ILoadable.OnPostModsLoad() { }
	}
}
