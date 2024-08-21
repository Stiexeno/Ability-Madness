using AbilityMadness.Code.Common.Factory;
using Cysharp.Threading.Tasks;
using Entitas;

namespace AbilityMadness.Code.Common.Systems
{
    public class BindEntityViewFromReferenceSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _entities;
        private IViewFactory _viewFactory;

        public BindEntityViewFromReferenceSystem(Contexts contexts, IViewFactory viewFactory)
        {
            _viewFactory = viewFactory;

            _entities = contexts.game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.ViewReference)
                .NoneOf(
                    GameMatcher.Loading,
                    GameMatcher.View));
        }

        public void Execute()
        {
            foreach (var entity in _entities.GetEntities())
            {
                if (entity.ViewReference == null)
                    continue;

                entity.isLoading = true;

                _viewFactory.CreateView(entity, entity.ViewReference).Forget();
            }
        }
    }
}
