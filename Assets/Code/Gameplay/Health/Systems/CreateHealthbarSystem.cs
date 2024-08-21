using System.Collections.Generic;
using AbilityMadness.Code.Gameplay.UI.Factory;
using AbilityMadness.Infrastructure.UI;
using Entitas;

namespace AbilityMadness.Code.Gameplay.Health.Systems
{
    public class CreateHealthbarSystem : IExecuteSystem
    {
        private readonly List<GameEntity> _buffer = new(32);

        private IGroup<GameEntity> _ownerEntities;

        private IUIFactory _uiFactory;
        private IUIEntityFactory _uiEntityFactory;

        public CreateHealthbarSystem(GameContext gameContext, IUIEntityFactory uiEntityFactory)
        {
            _uiEntityFactory = uiEntityFactory;
            _ownerEntities = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Id,
                    GameMatcher.Health,
                    GameMatcher.MaxHealth)
                .NoneOf(
                    GameMatcher.HasHealthbar,
                    GameMatcher.Player));
        }

        public void Execute()
        {
            foreach (var entity in _ownerEntities.GetEntities(_buffer))
            {
                if (entity.Health >= entity.MaxHealth)
                    continue;

                _uiEntityFactory.CreateHealthbar(entity);
                entity.HasHealthbar = true;
            }
        }
    }
}
