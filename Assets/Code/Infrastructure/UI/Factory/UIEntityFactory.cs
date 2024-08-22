using AbilityMadness.Code.Common;
using AbilityMadness.Code.Extensions;
using UnityEngine;

namespace AbilityMadness.Code.Infrastructure.UI.Factory
{
    public class UIEntityFactory : IUIEntityFactory
    {
        public GameEntity CreateHealthbar(GameEntity gameEntity)
        {
            return CreateEntity.Empty()
                .AddViewPath(Prefabs.Widgets.HealthbarWidget)
                .AddTargetId(gameEntity.Id)
                .AddWorldPosition(Vector2.one * 999)
                .With(x => x.isTransformMovement = true);
        }

        public GameEntity CreateReloadWidget(GameEntity gameEntity)
        {
            return CreateEntity.Empty()
                .AddViewPath(Prefabs.Widgets.ReloadWidget)
                .AddTargetId(gameEntity.Id)
                .AddWorldPosition(Vector2.one * 999)
                .With(x => x.isTransformMovement = true);
        }
    }
}
