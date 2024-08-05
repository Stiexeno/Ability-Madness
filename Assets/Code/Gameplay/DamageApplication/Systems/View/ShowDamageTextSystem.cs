using AbilityMadness.Infrastructure.Factories.UI;
using Cysharp.Threading.Tasks;
using Entitas;

namespace AbilityMadness.Code.Gameplay.DamageApplication.Systems.View
{
    public class ShowDamageTextSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _damagedEntities;
        private IUIFactory _uiFactory;

        public ShowDamageTextSystem(GameContext gameContext, IUIFactory uiFactory)
        {
            _uiFactory = uiFactory;
            _damagedEntities = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.DamageReceived,
                    GameMatcher.WorldPosition,
                    GameMatcher.Alive));
        }

        public void Execute()
        {
            foreach (var damagedEntity in _damagedEntities)
            {
                _uiFactory.CreateDamageText(damagedEntity.WorldPosition, damagedEntity.DamageReceived).Forget();
            }
        }
    }
}
