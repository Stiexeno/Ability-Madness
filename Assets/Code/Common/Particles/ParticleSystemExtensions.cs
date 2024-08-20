using UnityEngine;

namespace AbilityMadness.Code.Common.Particles
{
    public static class ParticleSystemExtensions
    {
        public static float GetTotalDuration(this ParticleSystem particleSystem)
        {
            var particleSystems = particleSystem.GetComponentsInChildren<ParticleSystem>();
            var duration = 0f;

            foreach (var system in particleSystems)
            {
                var mainModule = system.main;
                var systemDuration = mainModule.duration + mainModule.startLifetime.constant;

                duration = Mathf.Max(duration, systemDuration);
            }

            return duration;
        }
    }
}
