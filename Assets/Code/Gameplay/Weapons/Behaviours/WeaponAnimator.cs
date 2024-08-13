using System.Collections;
using AbilityMadness.Code.Gameplay.Weapons.Registrars;
using AbilityMadness.Code.Infrastructure.View;
using Animancer;
using UnityEngine;
using SF = UnityEngine.SerializeField;

namespace AbilityMadness.Code.Gameplay.Weapons.Behaviours
{
    [RequireComponent(typeof(WeaponAnimatorRegistrar))]
    public class WeaponAnimator : EntityComponent
    {
        [SF] private SpriteRenderer weapon;
        [SF] private AnimancerComponent animancer;
        [SF] private AnimancerComponent weaponAnimancer;
        [SF] private ClipTransition reloadClip;
        [SF] private ClipTransition shootClip;

        private Vector2 _direction;

        public void SetDirection(Vector2 direction)
        {
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
            Flip(direction);
        }

        private void Flip(Vector2 lookDirection)
        {
            if (lookDirection.magnitude == 0f)
            {
                lookDirection = _direction;
            }

            float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
            weapon.flipY = angle > 90 || angle < -90;
        }

        public void Shoot()
        {
            weaponAnimancer.Play(shootClip, 0f, mode: FadeMode.FromStart);
        }

        public void Reload(float duration)
        {
            StartCoroutine(ReloadCoroutine(duration));
        }

        private IEnumerator ReloadCoroutine(float duration)
        {
            weapon.enabled = false;
            animancer.gameObject.SetActive(true);
            animancer.Play(reloadClip);
            yield return new WaitForSeconds(duration);

            animancer.gameObject.SetActive(false);
            weapon.enabled = true;
        }
    }
}
