using System;
using System.Collections.Generic;
using Terraria;
using ModLibsCore.Libraries.Debug;
using ModLibsGeneral.Libraries.Projectiles.Attributes;


namespace ModLibsEntityGroups.Services.EntityGroups.Definitions {
	/// <summary></summary>
	public partial class ProjectileGroupIDs {
		/// <summary></summary>
		public const string AnyExplosive = "Any Explosive";
	}




	partial class EntityGroupDefs {
		internal static void DefineProjectileGroups1( IList<EntityGroupMatcherDefinition<Projectile>> defs ) {
			// General

			defs.Add( new EntityGroupMatcherDefinition<Projectile>(
				grpName: ProjectileGroupIDs.AnyExplosive,
				grpDeps: null,
				matcher: new ProjectileGroupMatcher( ( proj, grp ) => {
					int _;
					return ProjectileAttributeLibraries.IsExplosive( proj.type, out _, out _ );
				} )
			) );
		}
	}
}
