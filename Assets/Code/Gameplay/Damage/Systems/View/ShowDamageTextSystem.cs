using AbilityMadness.Infrastructure.UI;
using Cysharp.Threading.Tasks;
using Entitas;

namespace AbilityMadness.Code.Gameplay.DamageApplication.Systems.View
{
    public class ShowDamageTextSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _entities;
        private IUIFactory _uiFactory;
        private IGroup<GameEntity> _targets;
        private GameContext _gameContext;

        public ShowDamageTextSystem(GameContext gameContext, IUIFactory uiFactory)
        {
            _gameContext = gameContext;
            _uiFactory = uiFactory;
            _entities = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.EffectReceived,
                    GameMatcher.DamageEffect,
                    GameMatcher.EffectValue,
                    GameMatcher.TargetId,
                    GameMatcher.DamageTypeId));

            _targets = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.WorldPosition,
                    GameMatcher.Alive));
        }

        public void Execute()
        {
            foreach (var entity in _entities)
            {
                var target = _gameContext.GetEntityWithId(entity.TargetId);

                if (_targets.ContainsEntity(target))
                {
                    _uiFactory.CreateDamageText(target.WorldPosition, entity.DamageTypeId, (int)entity.EffectValue).Forget();
                }
            }
        }
    }
}
