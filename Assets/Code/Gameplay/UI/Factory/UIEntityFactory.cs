using AbilityMadness.Code.Common;
using AbilityMadness.Code.Extensions;
using UnityEngine;

namespace AbilityMadness.Code.Gameplay.UI.Factory
{
    public class UIEntityFactory : IUIEntityFactory
    {
        public GameEntity CreateHealthbar(GameEntity gameEntity)
        {
            return CreateEntity.Empty()
                .AddViewPath(Constants.Prefabs.Widgets.HealthbarWidget)
                .AddTargetId(gameEntity.Id)
                .AddWorldPosition(Vector2.one * 999)
                .With(x => x.isTransformMovement = true);
        }

        public GameEntity CreateReloadWidget(GameEntity gameEntity)
        {
            return CreateEntity.Empty()
                .AddViewPath(Constants.Prefabs.Widgets.ReloadWidget)
                .AddTargetId(gameEntity.Id)
                .AddWorldPosition(Vector2.one * 999)
                .With(x => x.isTransformMovement = true);
        }
    }
}
