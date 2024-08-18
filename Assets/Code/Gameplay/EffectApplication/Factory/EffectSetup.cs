using System;
using AbilityMadness.Code.Gameplay.DamageApplication;
using UnityEngine;

namespace AbilityMadness.Code.Gameplay.EffectApplication.Factory
{
    [Serializable]
    public class EffectSetup
    {
        public EffectTypeId type;
        public float value;
        
        [HideInInspector] public DamageTypeId damageType = DamageTypeId.Flat;
    }
}
