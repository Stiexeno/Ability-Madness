﻿using System;
using UnityEngine;

namespace AbilityMadness.Code.Gameplay.Projectile.Factory
{
    [Serializable]
    public class ProjectileSetup
    {
        public int damage = 10;
        public float movementSpeed = 0.15f;

        [Space(10)]
        public int spawnCount = 1;
        public float lifeTime = 5;
        public float spread = 0;

        [Space(10)]
        public int pierce = 0;
        public int ricochet = 0;
    }
}