using AbilityMadness.Code.Gameplay.Abilities.Systems;
using AbilityMadness.Code.Gameplay.Abilities.Systems.Implementation.Fireball;
using AbilityMadness.Code.Infrastructure.Services.ECS;

namespace AbilityMadness.Code.Gameplay.Abilities
{
    public class AbilityFeature : Feature
    {
        public AbilityFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<SetAbilityReadyOnCooldownUpSystem>());

            Add(systemFactory.Create<FireballManualLaunchAbilitySystem>());
            Add(systemFactory.Create<FireballAutoLaunchAbilitySystem>());

            //Add(systemFactory.Create<TornadoAutoLaunchAbilitySystem>());

            Add(systemFactory.Create<PutAbilityOnCooldownSystem>());
        }
    }
}
