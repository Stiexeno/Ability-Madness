using System;

namespace AbilityMadness.Code.Gameplay.Status.Factory
{
    [Serializable]
    public class StatusSetup
    {
        public StatusTypeId type;
        public float duration;
        public float period;
        public float value;
    }
}
