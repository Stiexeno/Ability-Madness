using System.Collections.Generic;
using AbilityMadness.Code.Extensions;
using AbilityMadness.Infrastructure.Factories.UI;
using Entitas;

namespace AbilityMadness.Code.Gameplay.Health.Systems
{
    public class DisplayHealthbarSystem : IExecuteSystem
    {
        private readonly List<GameEntity> _buffer = new(32);

        private IGroup<GameEntity> _healthbarEntities;
        private IGroup<GameEntity> _ownerEntities;

        private IUIFactory _uiFactory;

        public DisplayHealthbarSystem(GameContext gameContext, IUIFactory uiFactory)
        {
            _uiFactory = uiFactory;
            _healthbarEntities = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.TargetId,
                    GameMatcher.Healthbar,
                    GameMatcher.WorldPosition)
                .NoneOf(GameMatcher.Destructed));

            _ownerEntities = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Id,
                    GameMatcher.Health,
                    GameMatcher.MaxHealth));
        }

        public void Execute()
        {
            foreach (var owner in _ownerEntities.GetEntities(_buffer))
            {
                var hasHealthbar = false;

                foreach (var healthbarEntity in _healthbarEntities)
                {
                    if (healthbarEntity.TargetId == owner.Id)
                    {
                        if (owner.isHealthbarLoading)
                            owner.isHealthbarLoading = false;

                        hasHealthbar = true;
                        healthbarEntity.WorldPosition = owner.WorldPosition.AddY(0.5f);
                        healthbarEntity.Healthbar.SetHealth(owner.Health / (float)owner.MaxHealth);
                    }
                }

                if (hasHealthbar == false && owner.isHealthbarLoading == false)
                {
                    owner.isHealthbarLoading = true;
                    _uiFactory.CreateHealthbar(owner);
                }
            }
        }
    }
}
