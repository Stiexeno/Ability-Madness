using Entitas;

namespace AbilityMadness.Code.Gameplay.Movement.Systems
{
    public class MoveFollowTargetSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _movers;
        private GameContext _gameContext;

        public MoveFollowTargetSystem(GameContext gameContext)
        {
            _gameContext = gameContext;
            _movers = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.TransformMovement,
                    GameMatcher.Transform,
                    GameMatcher.FollowMovement,
                    GameMatcher.TargetId));
        }

        public void Execute()
        {
            foreach (var mover in _movers)
            {
                var target = _gameContext.GetEntityWithId(mover.TargetId);

                if (target != null)
                {
                    mover.Transform.position = target.Transform.position;
                }
            }
        }
    }
}
