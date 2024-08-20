using System.Collections.Generic;
using Entitas;

namespace AbilityMadness.Code.Common.Particles.Systems
{
    public class DestructParticlesSystem : IExecuteSystem
    {
        private readonly List<GameEntity> _buffer = new(32);
        private IGroup<GameEntity> _particles;
        private GameContext _gameContext;

        public DestructParticlesSystem(GameContext gameContext)
        {
            _gameContext = gameContext;
            _particles = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Id,
                    GameMatcher.ParticleSystem,
                    GameMatcher.ProducerId)
                .NoneOf(
                    GameMatcher.Emitting));
        }

        public void Execute()
        {
            foreach (var particle in _particles.GetEntities(_buffer))
            {
                var producer = _gameContext.GetEntityWithId(particle.ProducerId);

                if (producer == null && particle.ParticleSystem.IsAlive(withChildren: true) == false)
                {
                    particle.isDestructed = true;
                }
            }
        }
    }
}
