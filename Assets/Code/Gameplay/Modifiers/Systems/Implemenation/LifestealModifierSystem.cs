using Entitas;

namespace AbilityMadness.Code.Gameplay.Modifiers.Systems.Implemenation
{
    public class LifestealModifierSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _entities;
        private IGroup<GameEntity> _modifiers;

        public LifestealModifierSystem(GameContext gameContext)
        {
            _entities = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Modifiable,
                    GameMatcher.OwnerId)
                .NoneOf(
                    GameMatcher.LifeSteal));

            _modifiers = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Id,
                    GameMatcher.LifeStealModifier,
                    GameMatcher.TargetId,
                    GameMatcher.ModifierValue));
        }

        public void Execute()
        {
            foreach (var modifier in _modifiers)
            foreach (var entity in _entities)
            {
                if (modifier.TargetId == entity.OwnerId)
                {
                    entity.AddLifeSteal(modifier.ModifierValue);
                }
            }
        }
    }
}
