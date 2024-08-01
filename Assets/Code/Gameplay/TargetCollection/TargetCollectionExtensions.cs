using System.Collections.Generic;
using AbilityMadness.Code.Extensions;

namespace AbilityMadness.Code.Gameplay.TargetCollection
{
    public static class TargetCollectionExtensions
    {
        public static GameEntity CollectTargetsWithSphereCast(this GameEntity entity, float radius)
        {
            return entity
                .With(x => x.isSphereCast = true)
                .AddTargetBuffer(new List<int>(64))
                .AddProccessedTargets(new List<int>(64))
                .AddSphereCastRadius(radius);
        }
    }
}
