using System.Collections.Generic;
using AbilityMadness.Code.Gameplay.EffectApplication.Factory;
using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace AbilityMadness.Code.Gameplay.EffectApplication
{
    [Game] public class EffectApplication : IComponent {  }
    [Game] public class EffectValue : IComponent { public float Value;}

    [Game] public class EffectTypeIdComponent : IComponent { public EffectTypeId Value;  }
    [Game] public class EffectSetups : IComponent { public List<EffectSetup> Value;}
    [Game] public class DamageEffect : IComponent {  }
}
