using System;
using System.Collections.Generic;
using AbilityMadness.Code.Gameplay.EffectApplication.Factory;
using Sirenix.OdinInspector;

namespace AbilityMadness.Code.Gameplay.Projectile.Factory
{
    [Serializable]
    public class ThrowableSetup
    {
        public float maxHeight = 3f;
        public float movementSpeed = 0.15f;

        [Unit(Units.Meter)] public float range;

        public List<EffectSetup> effectSetups;
    }
}
