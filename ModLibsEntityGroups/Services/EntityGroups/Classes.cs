using System;
using System.Collections.Generic;
using Terraria;
using ModLibsCore.Classes.Errors;


namespace ModLibsEntityGroups.Services.EntityGroups {
	/// <summary>
	/// Defines a set of entity groups.
	/// </summary>
	public class EntityGroupDependencies : Dictionary<string, ISet<int>> { }




	/// <summary>
	/// Wraps a function for matching entities for a given group.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class EntityGroupBuilder<T> where T : Entity {
		/// <summary>
		/// Delegate for matching entity group entities. Receives an entity and the group's dependencies as parameters.
		/// Returns `true` if a match is found.
		/// </summary>
		public Func<T, EntityGroupDependencies, bool> BuilderFunc;
	}

	/// <summary></summary>
	public class ItemGroupMatcher : EntityGroupBuilder<Item> {
		/// <summary></summary>
		/// <param name="matcherFun"></param>
		public ItemGroupMatcher( Func<Item, EntityGroupDependencies, bool> matcherFun ) {
			this.BuilderFunc = matcherFun;
		}
	}

	/// <summary></summary>
	public class NPCGroupMatcher : EntityGroupBuilder<NPC> {
		/// <summary></summary>
		/// <param name="matcherFun"></param>
		public NPCGroupMatcher( Func<NPC, EntityGroupDependencies, bool> matcherFun ) {
			this.BuilderFunc = matcherFun;
		}
	}

	/// <summary></summary>
	public class ProjectileGroupMatcher : EntityGroupBuilder<Projectile> {
		/// <summary></summary>
		/// <param name="matcherFun"></param>
		public ProjectileGroupMatcher( Func<Projectile, EntityGroupDependencies, bool> matcherFun ) {
			this.BuilderFunc = matcherFun;
		}
	}




	class EntityGroupBuilderDefinition<T> where T : Entity {
		public string GroupName;
		public string[] GroupDependencies;
		public EntityGroupBuilder<T> Builder;

		public EntityGroupBuilderDefinition( string grpName, string[] grpDeps, EntityGroupBuilder<T> matcher ) {
			this.GroupName = grpName;
			this.GroupDependencies = grpDeps;
			this.Builder = matcher;
		}
	}
}
