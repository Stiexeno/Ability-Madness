﻿using System;
using System.Collections.Generic;
using AbilityMadness.Code.Gameplay.EffectApplication.Factory;
using AbilityMadness.Code.Gameplay.Status.Factory;
using Sirenix.OdinInspector;
using UnityEngine;

namespace AbilityMadness.Code.Gameplay.Projectile.Factory
{
    [Serializable]
    public class ProjectileSetup
    {
        [Unit(Units.KilometersPerHour)] public float movementSpeed = 0.15f;

        [Space(10)]
        public int spawnCount = 1;
        [Unit(Units.Second)] public float lifeTime = 5;
        [Unit(Units.Degree)] public float spread = 0;

        [Space(10)]
        public int pierce = 0;
        public int ricochet = 0;

        public List<EffectSetup> effectSetups;
        public List<StatusSetup> statusSetups;
    }
}
