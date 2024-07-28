using AbilityMadness.Code.Gameplay.Movement.Systems;
using AbilityMadness.Code.Infrastructure.Services.ECS;

namespace AbilityMadness.Code.Gameplay.Movement
{
    public class MovementUpdateFeature : Feature
    {
        public MovementUpdateFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<SetVelocityByDirectionSystem>());
            Add(systemFactory.Create<SetWorldPositionByTransformSystem>());
            Add(systemFactory.Create<SetVelocityToRigidbodySystem>());

        }
    }
}
