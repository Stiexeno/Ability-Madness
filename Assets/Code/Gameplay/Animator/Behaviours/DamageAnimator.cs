using System.Collections;
using AbilityMadness.Code.Gameplay.Animator.Registrars;
using AbilityMadness.Code.Infrastructure.View;
using UnityEngine;
using SF = UnityEngine.SerializeField;

namespace AbilityMadness.Code.Common.Behaviours
{
    [RequireComponent(typeof(DamageAnimatorRegistrar))]
    public class DamageAnimator : EntityComponent
    {
        [SF] private SpriteRenderer spriteRenderer;

        private Renderer _renderer;
        private MaterialPropertyBlock _materialPropertyBlock;
        private Coroutine _flashCoroutine;

        private static readonly int flashProperty = Shader.PropertyToID("_FlashAmount");

        private void Awake()
        {
            _materialPropertyBlock = new MaterialPropertyBlock();
            _renderer = spriteRenderer.GetComponent<Renderer>();
        }

        public void PlayDamageAnimation()
        {
            if (_flashCoroutine != null)
            {
                StopCoroutine(_flashCoroutine);
                _flashCoroutine = null;
            }

            _flashCoroutine = StartCoroutine(FlashCoroutine());
        }

        private IEnumerator FlashCoroutine()
        {
            _renderer.GetPropertyBlock(_materialPropertyBlock);
            _materialPropertyBlock.SetFloat(flashProperty, 1);
            _renderer.SetPropertyBlock(_materialPropertyBlock);

            yield return new WaitForSeconds(0.15f);

            _materialPropertyBlock.SetFloat(flashProperty, 0);
            _renderer.SetPropertyBlock(_materialPropertyBlock);
        }
    }
}
