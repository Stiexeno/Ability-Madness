using AbilityMadness.Code.Common.Factory;
using Cysharp.Threading.Tasks;
using Entitas;

namespace AbilityMadness.Code.Common.Systems
{
    public class BindEntityViewFromPathSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _entities;
        private IViewFactory _viewFactory;

        public BindEntityViewFromPathSystem(Contexts contexts, IViewFactory viewFactory)
        {
            _viewFactory = viewFactory;

            _entities = contexts.game.GetGroup(GameMatcher
                .AllOf(GameMatcher.ViewPath)
                .NoneOf(GameMatcher.Loading, GameMatcher.View));
        }

        public void Execute()
        {
            foreach (var entity in _entities.GetEntities())
            {
                if (string.IsNullOrEmpty(entity.ViewPath))
                    continue;

                entity.isLoading = true;

                _viewFactory.CreateView(entity, entity.ViewPath).Forget();
            }
        }
    }
}
