using AbilityMadness.Code.Common;
using Entitas;
using UnityEngine;

namespace AbilityMadness.Code.Gameplay.Input.Systems
{
    public class InitializeInputSystem : IInitializeSystem
    {
        public void Initialize()
        {
            CreateEntity.Empty()
                .AddAxisInput(Vector2.zero)
                .AddLookInput(Vector2.zero);
        }
    }
}
