using UnityEngine;

namespace AbilityMadness.Code.Gameplay.Abilities.Configs
{
    [CreateAssetMenu(fileName = nameof(AbilityConfig), menuName = Constants.Root + "/Configs/AbilityConfig")]
    public sealed class AbilityConfig : ScriptableObject
    {
        public AbilityTypeId type;
        public float cooldown;
        public float damageMultiplier;

        public AbilityModifier[] modifiers;
    }
}
