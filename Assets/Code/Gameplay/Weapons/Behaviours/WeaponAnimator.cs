using AbilityMadness.Code.Gameplay.Weapons.Registrars;
using AbilityMadness.Code.Infrastructure.View;
using UnityEngine;
using SF = UnityEngine.SerializeField;

namespace AbilityMadness.Code.Gameplay.Weapons.Behaviours
{
    [RequireComponent(typeof(WeaponAnimatorRegistrar))]
    public class WeaponAnimator : EntityComponent
    {
        [SF] private SpriteRenderer weapon;

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
    }
}
