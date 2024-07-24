using Entitas;

namespace AbilityMadness.Code.Common.Systems
{
    public class EnableGameObjectSystem : IExecuteSystem
    {
        private Contexts _contexts;
        private IGroup<GameEntity> _entities;

        public EnableGameObjectSystem(Contexts contexts)
        {
            _contexts = contexts;

            _entities = contexts.game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Enabled,
                    GameMatcher.View));
        }

        public void Execute()
        {
            foreach (var entity in _entities)
            {
                var gameObject = entity.View.gameObject;
                gameObject.SetActive(true);
            }
        }
    }
}
