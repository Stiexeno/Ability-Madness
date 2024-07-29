using Entitas;
using UnityEngine;

namespace AbilityMadness.Code.Gameplay.Vitals.Systems
{
    public class DecreaseFoodSystem : IExecuteSystem
    {
        private const float DepleteDuration = 500f;

        private IGroup<GameEntity> _foodEntities;

        public DecreaseFoodSystem(Contexts contexts)
        {
            _foodEntities = contexts.game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Food,
                    GameMatcher.MaxFood));
        }

        public void Execute()
        {
            foreach (var waterEntity in _foodEntities)
            {
                var depleteRate = waterEntity.MaxWater / DepleteDuration;

                if (waterEntity.Food > 0)
                {
                    waterEntity.Food -= depleteRate * Time.deltaTime;
                }
            }
        }
    }
}
