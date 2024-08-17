using AbilityMadness.Code.Common;
using AbilityMadness.Code.Common.Collision;
using AbilityMadness.Code.Common.Cooldown;
using AbilityMadness.Code.Common.Destruct;
using AbilityMadness.Code.Gameplay.Animator;
using AbilityMadness.Code.Gameplay.Camera;
using AbilityMadness.Code.Gameplay.Chest;
using AbilityMadness.Code.Gameplay.DamageApplication;
using AbilityMadness.Code.Gameplay.Enemy;
using AbilityMadness.Code.Gameplay.Enemy.Waves;
using AbilityMadness.Code.Gameplay.Experience;
using AbilityMadness.Code.Gameplay.Gears;
using AbilityMadness.Code.Gameplay.Health;
using AbilityMadness.Code.Gameplay.Input;
using AbilityMadness.Code.Gameplay.Interaction;
using AbilityMadness.Code.Gameplay.Lifetime;
using AbilityMadness.Code.Gameplay.Modifiers;
using AbilityMadness.Code.Gameplay.Movement;
using AbilityMadness.Code.Gameplay.Projectile;
using AbilityMadness.Code.Gameplay.Round;
using AbilityMadness.Code.Gameplay.Stats;
using AbilityMadness.Code.Gameplay.Status;
using AbilityMadness.Code.Gameplay.TargetCollection;
using AbilityMadness.Code.Gameplay.Upgrades;
using AbilityMadness.Code.Gameplay.Vision;
using AbilityMadness.Code.Gameplay.Weapons;

namespace AbilityMadness.Code.Infrastructure.Services.ECS
{
    public class BattleUpdateFeature : Feature
    {
        public BattleUpdateFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<InputFeature>());
            Add(systemFactory.Create<ViewFeature>());

            Add(systemFactory.Create<TargetCollectionFeature>());
            Add(systemFactory.Create<DamageFeature>());
            Add(systemFactory.Create<HealthFeature>());
            Add(systemFactory.Create<StatusFeature>());
            Add(systemFactory.Create<StatsFeature>());

            Add(systemFactory.Create<PlayerFeature>());
            Add(systemFactory.Create<CommonFeature>());

            Add(systemFactory.Create<MovementUpdateFeature>());
            Add(systemFactory.Create<CameraFreature>());

            Add(systemFactory.Create<AnimatorFeature>());

            Add(systemFactory.Create<InteractionFeature>());
            Add(systemFactory.Create<ChestFreature>());
            Add(systemFactory.Create<VisionFeature>());
            Add(systemFactory.Create<CooldownFeature>());

            Add(systemFactory.Create<ExperienceFeature>());
            Add(systemFactory.Create<GearFeature>());
            Add(systemFactory.Create<UpgradeFeature>());

            Add(systemFactory.Create<ModifierFeature>());
            Add(systemFactory.Create<ProjectileFeature>());
            Add(systemFactory.Create<WeaponFeature>());

            Add(systemFactory.Create<LifetimeFeature>());
            Add(systemFactory.Create<WaveFeature>());
            Add(systemFactory.Create<EnemyFeature>());

            Add(systemFactory.Create<RoundFeature>());

            Add(systemFactory.Create<CollisionFeature>());
            Add(systemFactory.Create<DestructFeature>());
        }
    }
}
