using System;
using AbilityMadness.Code.Gameplay.Modifiers;

namespace AbilityMadness.Code.Gameplay.Abilities.Configs
{
    [Serializable]
    public struct AbilityModifier
    {
        public ModifierTypeId type;
        public float value;
    }
}
