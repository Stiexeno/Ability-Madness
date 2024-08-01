using AbilityMadness.Code.Common;
using AbilityMadness.Code.Extensions;
using AbilityMadness.Code.Gameplay.Lifetime;
using AbilityMadness.Code.Infrastructure.Services.Identifiers;
using AbilityMadness.Code.Infrastructure.Services.View;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace AbilityMadness.Code.Gameplay.EffectApplication.Factory
{
    public class EffectFactory : IEffectFactory
    {
        private IViewPool _viewPool;
        private IIdentifierService _identifierService;

        public EffectFactory(IViewPool viewPool, IIdentifierService identifierService)
        {
            _identifierService = identifierService;
            _viewPool = viewPool;
        }

        public async UniTaskVoid CreateEffect(string path, Vector3 position)
        {
            var effect = await _viewPool.Take(path);

            var entity = CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .AddView(effect)
                .SetLifetime(GetParticleDuration(effect.gameObject))

                .With(x => x.isTransformMovement = true);

            effect.LinkEntity(entity);
            effect.transform.position = position;
            effect.gameObject.SetActive(true);
        }

        private float GetParticleDuration(GameObject gameObject)
        {
           var particleSystems = gameObject.GetComponentsInChildren<ParticleSystem>();

           var duration = 0f;

           foreach (var particleSystem in particleSystems)
           {
               duration = Mathf.Max(duration, particleSystem.main.duration);
           }

           return duration;
        }
    }
}
