using System.Collections.Generic;
using Entitas;

namespace AbilityMadness.Code.Common.Particles.Systems
{
    public class StopParticlesOnNullProducerSystem : IExecuteSystem
    {
        private readonly List<GameEntity> _buffer = new(32);
        private IGroup<GameEntity> _particles;
        private GameContext _gameContext;

        public StopParticlesOnNullProducerSystem(GameContext gameContext)
        {
            _gameContext = gameContext;
            _particles = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.ParticleSystem,
                    GameMatcher.ProducerId,
                    GameMatcher.Emitting));
        }

        public void Execute()
        {
            foreach (var particle in _particles.GetEntities(_buffer))
            {
                var producer = _gameContext.GetEntityWithId(particle.ProducerId);

                if (producer == null)
                {
                    particle.ParticleSystem.Stop();
                    particle.isEmitting = false;
                }
            }
        }
    }
}
