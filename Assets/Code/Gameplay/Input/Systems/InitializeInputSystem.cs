using AbilityMadness.Code.Common;
using AbilityMadness.Code.Extensions;
using Entitas;
using UnityEngine;

namespace AbilityMadness.Code.Gameplay.Input.Systems
{
    public class InitializeInputSystem : IInitializeSystem
    {
        public void Initialize()
        {
            CreateEntity.Empty()
                .With(x => x.isInput = true)
                .AddAxisInput(Vector2.zero)
                .AddLookInput(Vector2.zero)
                .AddMousePosition(Vector2.zero);
        }
    }
}
