
using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace AbilityMadness.Code.Gameplay.EffectProccesing
{
    [Game] public class EffectReceived : IComponent { [EntityIndex] public int Value; }
    [Game] public class EffectDealt : IComponent { [EntityIndex] public int Value; }

}
