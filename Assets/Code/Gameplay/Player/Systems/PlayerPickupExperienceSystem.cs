using AbilityMadness.Code.Gameplay.Movement;
using AbilityMadness.Code.Infrastructure.Physics;
using Entitas;

namespace AbilityMadness.Code.Gameplay.Player.Systems
{
    public class PlayerPickupExperienceSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _players;
        private IGroup<GameEntity> _experiences;
        private IPhysicsService _physicsService;

        public PlayerPickupExperienceSystem(GameContext gameContext, IPhysicsService physicsService)
        {
            _physicsService = physicsService;
            _players = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Player,
                    GameMatcher.PickupRadius));

            _experiences = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Id,
                    GameMatcher.Experience,
                    GameMatcher.ExperienceTypeId)
                .NoneOf(
                    GameMatcher.PickedUp));
        }

        public void Execute()
        {
            foreach (var player in _players)
            {
                var hits = _physicsService.CircleCast(
                    player.WorldPosition,
                    player.PickupRadius,
                    1 << Layers.Loot);

                foreach (var hit in hits)
                {
                    if (_experiences.ContainsEntity(hit) == false)
                        continue;

                    hit.isPickedUp = true;
                    hit.SetForwardMovement();
                }
            }
        }
    }
}
