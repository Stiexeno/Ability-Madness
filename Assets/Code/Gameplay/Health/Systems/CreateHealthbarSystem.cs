using System.Collections.Generic;
using AbilityMadness.Infrastructure.Factories.UI;
using Entitas;

namespace AbilityMadness.Code.Gameplay.Health.Systems
{
    public class CreateHealthbarSystem : IExecuteSystem
    {
        private readonly List<GameEntity> _buffer = new(32);

        private IGroup<GameEntity> _ownerEntities;

        private IUIFactory _uiFactory;

        public CreateHealthbarSystem(GameContext gameContext, IUIFactory uiFactory)
        {
            _uiFactory = uiFactory;

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

                _uiFactory.CreateHealthbar(entity);
                entity.HasHealthbar = true;
            }
        }
    }
}