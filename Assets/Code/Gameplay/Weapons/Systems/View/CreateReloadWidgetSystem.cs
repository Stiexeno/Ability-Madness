using System.Collections.Generic;
using AbilityMadness.Code.Gameplay.UI.Factory;
using AbilityMadness.Infrastructure.UI;
using Entitas;

namespace AbilityMadness.Code.Gameplay.Weapons.Systems.View
{
    public class CreateReloadWidgetSystem : IExecuteSystem
    {
        private readonly List<GameEntity> _buffer = new(32);

        private IGroup<GameEntity> _ownerEntities;

        private IUIFactory _uiFactory;
        private IGroup<GameEntity> _weapons;
        private IGroup<GameEntity> _owners;
        private GameContext _gameContext;
        private IUIEntityFactory _uiEntityFactory;

        public CreateReloadWidgetSystem(GameContext gameContext, IUIEntityFactory uiEntityFactory)
        {
            _uiEntityFactory = uiEntityFactory;
            _gameContext = gameContext;

            _weapons = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Weapon,
                    GameMatcher.Reloading,
                    GameMatcher.WeaponAnimator,
                    GameMatcher.ReloadTime));

            _owners = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Id)
                .NoneOf(
                    GameMatcher.HasReloadWidget));
        }

        public void Execute()
        {
            foreach (var weapon in _weapons.GetEntities(_buffer))
            {
                var owner = _gameContext.GetEntityWithId(weapon.OwnerId);

                if (_owners.ContainsEntity(owner))
                {
                    _uiEntityFactory.CreateReloadWidget(owner);
                    owner.HasReloadWidget = true;

                    weapon.WeaponAnimator.Reload(weapon.ReloadTime);
                }
            }
        }
    }
}
