using UnityEngine;

namespace AbilityMadness.Code.Gameplay.Weapons
{
    public static class ProjectileExtensions
    {
        public static Vector3 CalculateSpreadDirection(float spread, Vector3 direction)
        {
            var randomSpread = Random.Range(-spread, spread);
            return Quaternion.Euler(0, 0, randomSpread) * direction;
        }
    }
}
