using Entitas;
using UnityEngine;

namespace AbilityMadness.Code.Gameplay.Status.Systems
{
    public class StatusDurationSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _statuses;

        public StatusDurationSystem(GameContext gameContext)
        {
            _statuses = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Status,
                    GameMatcher.Duration,
                    GameMatcher.TimeLeft));
        }

        public void Execute()
        {
            foreach (var status in _statuses)
            {
                if (status.TimeLeft >= 0)
                    status.TimeLeft -= Time.deltaTime;
                else
                    status.isDepleted = true;
            }
        }
    }
}
