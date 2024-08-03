using System.Collections.Generic;
using AbilityMadness.Code.Extensions;
using AbilityMadness.Code.Gameplay.Projectile.Factory;
using Entitas;

namespace AbilityMadness.Code.Gameplay.Projectile.Systems
{
    public class CreateProjectileByRequestSystem : IExecuteSystem
    {
        private readonly List<GameEntity> _buffer = new(32);

        private IGroup<GameEntity> _requests;

        private IProjectileFactory _projectileFactory;

        public CreateProjectileByRequestSystem(GameContext gameContext, IProjectileFactory projectileFactory)
        {
            _projectileFactory = projectileFactory;
            _requests = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.RequestProjectile,
                    GameMatcher.ProducerId,
                    GameMatcher.WorldPosition,
                    GameMatcher.Team,
                    GameMatcher.Direction,
                    GameMatcher.SpawnAmount));
        }

        public void Execute()
        {
            foreach (var request in _requests.GetEntities(_buffer))
            {
                for (int i = 0; i < request.SpawnAmount; i++)
                {
                    var spreadDirection = VectorExtensions.GetSpreadDirection(request.Direction, request.SpawnAmount, i);

                    _projectileFactory.CreateProjectile(
                        request.RequestProjectile,
                        request.ProducerId,
                        request.WorldPosition,
                        spreadDirection,
                        request.Team);
                }

                request.Destroy();
            }
        }
    }
}
