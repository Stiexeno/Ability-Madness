﻿using System.Collections.Generic;
using Entitas;

namespace AbilityMadness.Code.Common.Collision.Systems
{
    public class CleanupCollisionSystem : ICleanupSystem
    {
        private List<GameEntity> _buffer = new(32);
        private IGroup<GameEntity> _collisions;

        public CleanupCollisionSystem(Contexts contexts)
        {
            _collisions = contexts.game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Collision));
        }

        public void Cleanup()
        {
            foreach (var collision in _collisions.GetEntities(_buffer))
            {
                collision.Destroy();
            }
        }
    }
}
