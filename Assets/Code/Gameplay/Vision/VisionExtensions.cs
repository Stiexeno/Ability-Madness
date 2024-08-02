using System.Collections.Generic;
using AbilityMadness.Code.Extensions;
using UnityEngine;

namespace AbilityMadness.Code.Gameplay.Vision
{
    public static class VisionExtensions
    {
        public static GameEntity GetClosestTarget(this GameEntity attacker)
        {
            var distance = float.MaxValue;
            var closestTarget = default(GameEntity);

            foreach (var target in attacker.TargetsInSight)
            {
                var targetEntity = Contexts.sharedInstance.game.GetEntityWithId(target);
                var newDistance = Vector3.Distance(attacker.WorldPosition, targetEntity.WorldPosition);

                if (newDistance < distance)
                {
                    distance = newDistance;
                    closestTarget = targetEntity;
                }
            }

            return closestTarget;
        }

        public static GameEntity SetVision(this GameEntity gameEntity, float radius, float interval, int layer)
        {
            return gameEntity
                .With(x => x.isVision = true)
                .AddTargetsInSight(new List<int>(64))
                .AddVisionRadius(radius)
                .AddVisionLayer(layer)
                .AddVisionInterval(interval)
                .AddVisionTimer(0f);
        }
    }
}
