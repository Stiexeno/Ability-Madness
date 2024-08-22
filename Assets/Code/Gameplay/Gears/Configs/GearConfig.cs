using System.Collections.Generic;
using AbilityMadness.Code.Gameplay.Stats.Factory;
using AbilityMadness.Code.Gameplay.Upgrades.Configs;
using UnityEngine;

namespace AbilityMadness.Code.Gameplay.Gears.Configs
{
    [CreateAssetMenu(fileName = nameof(GearConfig), menuName = Constants.Root + "/Configs/GearConfig")]
    public class GearConfig : ItemConfig
    {
        [Space(10)]
        public GearTypeId type;

        public GearSetup gearSetup;
        public List<StatsSetup> statsSetup;
    }
}
