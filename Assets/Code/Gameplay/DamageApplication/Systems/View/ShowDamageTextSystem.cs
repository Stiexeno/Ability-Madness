using AbilityMadness.Infrastructure.Factories.UI;
using Cysharp.Threading.Tasks;
using Entitas;

namespace AbilityMadness.Code.Gameplay.DamageApplication.Systems.View
{
    public class ShowDamageTextSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _damageReceivedEvents;
        private IUIFactory _uiFactory;
        private IGroup<GameEntity> _targets;
        private GameContext _gameContext;

        public ShowDamageTextSystem(GameContext gameContext, IUIFactory uiFactory)
        {
            _gameContext = gameContext;
            _uiFactory = uiFactory;
            _damageReceivedEvents = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.DamageReceived,
                    GameMatcher.TargetId));

            _targets = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.WorldPosition,
                    GameMatcher.Alive));
        }

        public void Execute()
        {
            foreach (var damageReceivedEvent in _damageReceivedEvents)
            {
                var target = _gameContext.GetEntityWithId(damageReceivedEvent.TargetId);

                if (_targets.ContainsEntity(target))
                {
                    _uiFactory.CreateDamageText(target.WorldPosition, damageReceivedEvent.Damage).Forget();
                }
            }
        }
    }
}
