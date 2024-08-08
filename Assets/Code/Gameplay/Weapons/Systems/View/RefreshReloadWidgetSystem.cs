using AbilityMadness.Code.Extensions;
using Entitas;

namespace AbilityMadness.Code.Gameplay.Weapons.Systems.View
{
    public class RefreshReloadWidgetSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _widgets;
        private IGroup<GameEntity> _weapons;
        private GameContext _gameContext;

        public RefreshReloadWidgetSystem(GameContext gameContext)
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
                    GameMatcher.Reloading,
                    GameMatcher.ReloadTime,
                    GameMatcher.Cooldown,
                    GameMatcher.CooldownLeft));
        }

        public void Execute()
        {
            foreach (var widget in _widgets)
            {
                var weapons = _gameContext.GetEntitiesWithOwnerId(widget.TargetId);

                foreach (var weapon in weapons)
                {
                    if (_weapons.ContainsEntity(weapon))
                    {
                        var owner = _gameContext.GetEntityWithId(weapon.OwnerId);

                        widget.WorldPosition = owner.WorldPosition.AddY(0.7f);
                        widget.ReloadWidget.Refresh(weapon.CooldownLeft / weapon.ReloadTime);
                    }
                }
            }
        }
    }
}
