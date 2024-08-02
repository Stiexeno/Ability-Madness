using Entitas;
using UnityEngine;

namespace AbilityMadness.Code.Gameplay.Vision.Systems
{
    public class CleanupTargetsInSightSystem : ICleanupSystem
    {
        private IGroup<GameEntity> _visionEntities;

        public CleanupTargetsInSightSystem(GameContext gameContext)
        {
            _visionEntities = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.TargetsInSight));
        }

        public void Cleanup()
        {
            foreach (var visionEntity in _visionEntities)
            {
                visionEntity.TargetsInSight.Clear();
            }
        }
    }
}