using Entitas;
using UnityEngine;

namespace AbilityMadness.Code.Gameplay.Area.Systems
{
    public class AreaDurationSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _areas;

        public AreaDurationSystem(GameContext gameContext)
        {
            _areas = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Area,
                    GameMatcher.Duration,
                    GameMatcher.TimeLeft));
        }

        public void Execute()
        {
            foreach (var area in _areas)
            {
                if (area.TimeLeft >= 0)
                    area.TimeLeft -= Time.deltaTime;
                else
                    area.isDestructed = true;
            }
        }
    }
}
