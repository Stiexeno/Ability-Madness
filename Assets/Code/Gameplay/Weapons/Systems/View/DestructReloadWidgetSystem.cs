using System.Collections.Generic;
using Entitas;

namespace AbilityMadness.Code.Gameplay.Weapons.Systems.View
{
    public class DestructReloadWidgetSystem : IExecuteSystem
    {
        private readonly List<GameEntity> _buffer = new(32);
        private IGroup<GameEntity> _widgets;
        private IGroup<GameEntity> _weapons;
        private GameContext _gameContext;
        private IGroup<GameEntity> _owners;

        public DestructReloadWidgetSystem(GameContext gameContext)
        {
            _gameContext = gameContext;
            _widgets = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.ReloadWidget,
                    GameMatcher.View,
                    GameMatcher.TargetId));

            _weapons = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Weapon,
                    GameMatcher.OwnerId));

            _owners = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.HasReloadWidget,
                    GameMatcher.Id));
        }

        public void Execute()
        {
            foreach (var owner in _owners.GetEntities(_buffer))
            {
                var weapons = _gameContext.GetEntitiesWithOwnerId(owner.Id);

                foreach (var weapon in weapons)
                {
                    if (_weapons.ContainsEntity(weapon) && weapon.isReloading == false)
                    {
                        var widgets = _gameContext.GetEntitiesWithTargetId(owner.Id);

                        foreach (var widget in widgets)
                        {
                            if (_widgets.ContainsEntity(widget))
                            {
                                widget.isDestructed = true;
                                owner.HasReloadWidget = false;
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}
