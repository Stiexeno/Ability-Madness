using Entitas;
using UnityEngine;

namespace AbilityMadness.Code.Gameplay.Vitals.Systems
{
    public class DecreaseWaterSystem : IExecuteSystem
    {
        private const float DepleteDuration = 800f;

        private IGroup<GameEntity> _waterEntities;

        public DecreaseWaterSystem(Contexts contexts)
        {
            _waterEntities = contexts.game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Water,
                    GameMatcher.MaxWater));
        }

        public void Execute()
        {
            foreach (var waterEntity in _waterEntities)
            {
                var depleteRate = waterEntity.MaxWater / DepleteDuration;

                if (waterEntity.Water > 0)
                {
                    waterEntity.Water -= depleteRate * Time.deltaTime;
                }
            }
        }
    }
}
