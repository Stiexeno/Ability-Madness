using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        [SF] private ParticleSystem shootVFX;

        private Vector2 _direction;

        private Dictionary<Transform, Vector3> _childs = new Dictionary<Transform, Vector3>();

        private void Awake()
        {
            var childs = weapon.GetComponentsInChildren<Transform>().Skip(1);

            foreach (var child in childs)
            {
                _childs.Add(child, child.localPosition);
            }
        }

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

            FlipChilds(weapon.flipY);
        }

        private void FlipChilds(bool flip)
        {
            foreach (var child in _childs)
            {
                var childPosition = child.Key.localPosition;
                childPosition.y = flip ? -child.Value.y : child.Value.y;
                child.Key.localPosition = childPosition;
            }
        }

        public void Shoot()
        {
           weaponAnimancer.Play(shootClip, 0f, mode: FadeMode.FromStart);
           shootVFX.Play();
        }

        public void Reload(float duration)
        {
            //StartCoroutine(ReloadCoroutine(duration));
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
