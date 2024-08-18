using System.Collections.Generic;
using AbilityMadness.Code.Gameplay.EffectApplication.Factory;
using UnityEngine;

namespace AbilityMadness.Code.Gameplay.Enemy.Configs
{
    [CreateAssetMenu(fileName = nameof(EnemyConfig), menuName = Constants.Root + "/Configs/EnemyConfig")]
    public class EnemyConfig : ScriptableObject
    {
        public EnemyTypeId type;

        public Stats.Stats baseStats;
        public List<EffectSetup> effectSetups;
    }
}
