using Entitas;
using UnityEngine;

namespace AbilityMadness.Code.Common.Particles
{
    [Game] public class ParticleSystemComponent : IComponent { public ParticleSystem Value; }
    [Game] public class Emitting : IComponent { }
}
