using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace AbilityMadness.Code.Gameplay.Lifetime.Systems
{
    public class ProcessLifetimeSystem : IExecuteSystem
    {
        private readonly List<GameEntity> _buffer = new(32);
        private IGroup<GameEntity> _lifetimeEntities;

        public ProcessLifetimeSystem(GameContext gameContext)
        {
            _lifetimeEntities = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.LifeTime,
                    GameMatcher.LifeTimeTimeElapsed)
                .NoneOf(GameMatcher.Destructed));
        }

        public void Execute()
        {
            foreach (var lifetimeEntity in _lifetimeEntities.GetEntities(_buffer))
            {
                lifetimeEntity.LifeTimeTimeElapsed += Time.deltaTime;

                if (lifetimeEntity.LifeTimeTimeElapsed >= lifetimeEntity.LifeTime)
                {
                    lifetimeEntity.isDestructed = true;
                }
            }
        }
    }
}
