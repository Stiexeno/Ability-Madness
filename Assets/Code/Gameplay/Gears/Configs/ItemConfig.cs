using Sirenix.OdinInspector;
using UnityEngine;

namespace AbilityMadness.Code.Gameplay.Gears.Configs
{
    public abstract class ItemConfig : ScriptableObject
    {
        [PreviewField] public Sprite icon;
        public new string name;

        [Unit(Units.Percent)] public float chance;
    }
}
