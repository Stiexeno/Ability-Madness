using UnityEngine;

namespace AbilityMadness.Code.Gameplay.Gears.Configs
{
    [CreateAssetMenu(fileName = nameof(GearConfig), menuName = Constants.Root + "/Configs/GearConfig")]
    public class GearConfig : ItemConfig
    {
        [Space(10)]
        public GearTypeId type;
    }
}
