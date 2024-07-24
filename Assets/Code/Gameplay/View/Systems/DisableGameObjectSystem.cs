using Entitas;

namespace AbilityMadness.Code.Common.Systems
{
    public class DisableGameObjectSystem : IExecuteSystem
    {
        private Contexts _contexts;
        private IGroup<GameEntity> _entities;

        public DisableGameObjectSystem(Contexts contexts)
        {
            _contexts = contexts;

            _entities = contexts.game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Disabled,
                    GameMatcher.View));
        }

        public void Execute()
        {
            foreach (var entity in _entities)
            {
                var gameObject = entity.View.gameObject;
                gameObject.SetActive(false);
            }
        }
    }
}
