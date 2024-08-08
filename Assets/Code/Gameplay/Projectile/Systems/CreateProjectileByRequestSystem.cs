using System.Collections.Generic;
using AbilityMadness.Code.Gameplay.Projectile.Factory;
using Entitas;
using UnityEngine;

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
                    GameMatcher.ProjectileRequest));
        }

        public void Execute()
        {
            foreach (var request in _requests.GetEntities(_buffer))
            {
                for (int i = 0; i < request.ProjectileRequest.spawnCount; i++)
                {
                    var randomSpread = Random.Range(-request.ProjectileRequest.spread, request.ProjectileRequest.spread);
                    request.ProjectileRequest.direction = Quaternion.Euler(0, 0, randomSpread) * request.ProjectileRequest.direction;
                    _projectileFactory.CreateProjectile(request.ProjectileRequest);
                }

                request.Destroy();
            }
        }
    }
}
