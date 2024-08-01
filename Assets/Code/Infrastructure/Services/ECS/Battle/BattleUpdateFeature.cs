using AbilityMadness.Code.Common;
using AbilityMadness.Code.Common.Collision;
using AbilityMadness.Code.Common.Cooldown;
using AbilityMadness.Code.Common.Destruct;
using AbilityMadness.Code.Gameplay.Abilities;
using AbilityMadness.Code.Gameplay.Animator;
using AbilityMadness.Code.Gameplay.Chest;
using AbilityMadness.Code.Gameplay.DamageApplication;
using AbilityMadness.Code.Gameplay.Input;
using AbilityMadness.Code.Gameplay.Interaction;
using AbilityMadness.Code.Gameplay.Lifetime;
using AbilityMadness.Code.Gameplay.Modifiers;
using AbilityMadness.Code.Gameplay.Movement;
using AbilityMadness.Code.Gameplay.Projectile;
using AbilityMadness.Code.Gameplay.TargetCollection;
using AbilityMadness.Code.Gameplay.Vision;

namespace AbilityMadness.Code.Infrastructure.Services.ECS
{
    public class BattleUpdateFeature : Feature
    {
        public BattleUpdateFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<InputFeature>());
            Add(systemFactory.Create<ViewFeature>());
            Add(systemFactory.Create<PlayerFeature>());
            Add(systemFactory.Create<MovementUpdateFeature>());
            Add(systemFactory.Create<CommonFeature>());
            Add(systemFactory.Create<AnimatorFeature>());
            Add(systemFactory.Create<InteractionFeature>());
            Add(systemFactory.Create<ChestFreature>());
            Add(systemFactory.Create<VisionFeature>());
            Add(systemFactory.Create<ProjectileFeature>());
            Add(systemFactory.Create<CooldownFeature>());
            Add(systemFactory.Create<AbilityFeature>());
            Add(systemFactory.Create<TargetCollectionFeature>());
            Add(systemFactory.Create<DamageFeature>());
            Add(systemFactory.Create<LifetimeFeature>());
            Add(systemFactory.Create<ModifierFeature>());

            Add(systemFactory.Create<CollisionFeature>());
            Add(systemFactory.Create<DestructFeature>());
        }
    }
}
