using AbilityMadness.Code.Gameplay.Movement.Systems;
using AbilityMadness.Code.Gameplay.Movement.Systems.Dash;
using AbilityMadness.Code.Infrastructure.ECS;

namespace AbilityMadness.Code.Gameplay.Movement
{
    public class MovementUpdateFeature : Feature
    {
        public MovementUpdateFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<SetWorldPositionByTransformSystem>());
            Add(systemFactory.Create<MoveTransformSystem>());

            Add(systemFactory.Create<SetVelocityByDirectionSystem>());
            Add(systemFactory.Create<MoveRigidbodySystem>());
            Add(systemFactory.Create<ResetVelocityOnDeathSystem>());

            Add(systemFactory.Create<MoveForwardDirectionSystem>());

            Add(systemFactory.Create<MoveFollowTargetSystem>());

            Add(systemFactory.Create<IncreaseDistanceTraveledSystem>());

            Add(systemFactory.Create<StartDashSystem>());
            Add(systemFactory.Create<DashingCooldownSystem>());
            Add(systemFactory.Create<RigidbodyDashSystem>());
        }
    }
}
