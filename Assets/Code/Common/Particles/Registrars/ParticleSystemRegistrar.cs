using AbilityMadness.Code.Infrastructure.View;
using UnityEngine;
using SF = UnityEngine.SerializeField;

namespace AbilityMadness.Code.Common.Particles.Registrars
{
    [EntityTag("Registrars")]
    public class ParticleSystemRegistrar : EntityComponentRegistrar
    {
        [SF] private new ParticleSystem particleSystem;

        public override void RegisterComponents(GameEntity entity)
        {
            entity.AddParticleSystem(particleSystem);
        }

        public override void UnregisterComponents(GameEntity entity)
        {
            entity.RemoveParticleSystem();
        }
    }
}
