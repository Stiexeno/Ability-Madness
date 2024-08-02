using Entitas;

namespace AbilityMadness.Code.Gameplay.Lifetime.Systems
{
    public class ProcessTimeElapsedSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _timeEntities;

        public ProcessTimeElapsedSystem(GameContext gameContext)
        {
            _timeEntities = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.TimeElapsed));
        }

        public void Execute()
        {
            foreach (var timeEntity in _timeEntities)
            {
                timeEntity.TimeElapsed += UnityEngine.Time.deltaTime;
            }
        }
    }
}
