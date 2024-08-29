using System;
using System.Collections.Generic;
using AbilityMadness.Code.Gameplay.EffectApplication.Factory;
using AbilityMadness.Code.Gameplay.Status.Factory;
using Sirenix.OdinInspector;

namespace AbilityMadness.Code.Gameplay.Projectile.Factory
{
    [Serializable]
    public class ProjectileSetup
    {
        [Unit(Units.KilometersPerHour)] public float movementSpeed = 0.15f;

        [Unit(Units.Degree)] public float spread = 0;
        public int pierce = 0;
        public int ricochet = 0;
        [Unit(Units.Meter)] public float range;

        public List<EffectSetup> effectSetups;
        public List<StatusSetup> statusSetups;
    }
}
