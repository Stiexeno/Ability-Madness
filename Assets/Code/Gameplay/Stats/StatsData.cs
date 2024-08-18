using System;
using System.Collections.Generic;

namespace AbilityMadness.Code.Gameplay.Stats
{
    [Serializable]
    public class StatsData
    {
        public Dictionary<StatsTypeId, float> stats = new Dictionary<StatsTypeId, float>
        {
            { StatsTypeId.MaxHealth, 0f },
            { StatsTypeId.MovementSpeed, 0f },
            { StatsTypeId.MovementSpeedMultiplier, 1f },
            { StatsTypeId.DamageMultiplier, 0f }
        };

        public float this[StatsTypeId key]
        {
            get => stats[key];
            set => stats[key] = value;
        }

        public StatsData()
        {
        }

        public StatsData(Stats stats)
        {
            this[StatsTypeId.MaxHealth] = stats.maxHealth;
            this[StatsTypeId.MovementSpeed] = stats.movementSpeed;
            this[StatsTypeId.MovementSpeedMultiplier] = stats.movementSpeedMultiplier;
            this[StatsTypeId.DamageMultiplier] = stats.damageMultiplier;
        }

        public void Reset()
        {
            stats[StatsTypeId.MaxHealth] = 0f;
            stats[StatsTypeId.MovementSpeed] = 0f;
            stats[StatsTypeId.MovementSpeedMultiplier] = 1f;
            stats[StatsTypeId.DamageMultiplier] = 0f;
        }
    }
}
