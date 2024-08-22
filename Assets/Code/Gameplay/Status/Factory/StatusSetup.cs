using System;
using Sirenix.OdinInspector;

namespace AbilityMadness.Code.Gameplay.Status.Factory
{
    [Serializable]
    public class StatusSetup
    {
        public StatusTypeId type;
        [Unit(Units.Second)] public float duration;
        [Unit(Units.Second)] public float period;
        public float value;
    }
}
