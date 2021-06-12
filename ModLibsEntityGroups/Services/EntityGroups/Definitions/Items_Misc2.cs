using System;
using System.Collections.Generic;
using Terraria;
using ModLibsCore.Libraries.Debug;
using ModLibsGeneral.Libraries.Recipes;


namespace ModLibsEntityGroups.Services.EntityGroups.Definitions {
	/// <summary></summary>
	public partial class ItemGroupIDs {
		/// <summary></summary>
		public const string AnyFoodIngredient = "Any Food Ingredient";
	}




	partial class EntityGroupDefs {
		internal static void DefineItemMiscGroups2( IList<EntityGroupBuilderDefinition<Item>> defs ) {
			defs.Add( new EntityGroupBuilderDefinition<Item>(
				grpName: ItemGroupIDs.AnyFoodIngredient,
				grpDeps: new string[] { ItemGroupIDs.AnyFood },
				matcher: new ItemGroupMatcher( ( item, grps ) => {
					foreach( int foodId in grps[ItemGroupIDs.AnyFood] ) {
						IEnumerable<Recipe> recipes = RecipeFinderLibraries.GetRecipesOfItem_Cached( foodId );

						foreach( Recipe recipe in recipes ) {
							for( int i = 0; i < recipe.requiredItem.Length; i++ ) {
								Item reqItem = recipe.requiredItem[i];
								if( reqItem == null || reqItem.IsAir ) { continue; }

								if( reqItem.type == item.type ) {
									return true;
								}
							}
						}
					}
					return false;
				} )
			) );
		}
	}
}
