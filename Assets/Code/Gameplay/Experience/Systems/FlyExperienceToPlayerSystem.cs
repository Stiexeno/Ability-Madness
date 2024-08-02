using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace AbilityMadness.Code.Gameplay.Experience.Systems
{
    public class FlyExperienceToPlayerSystem : IExecuteSystem
    {
        private readonly List<GameEntity> _buffer = new(32);
        private IGroup<GameEntity> _experiences;
        private IGroup<GameEntity> _players;

        public FlyExperienceToPlayerSystem(GameContext gameContext)
        {
            _experiences = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Experience,
                    GameMatcher.ExperienceTypeId,
                    GameMatcher.PickedUp)
                .NoneOf(
                    GameMatcher.Destructed));

            _players = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Player,
                    GameMatcher.Experience,
                    GameMatcher.WorldPosition));
        }

        public void Execute()
        {
            foreach (var experience in _experiences.GetEntities(_buffer))
            {
                foreach (var player in _players)
                {
                    var direction = (player.WorldPosition - experience.WorldPosition).normalized;
                    experience.ReplaceDirection(direction);

                    var distance = Vector3.Distance(player.WorldPosition, experience.WorldPosition);

                    if (distance <= 0.5f)
                    {
                        player.Experience += experience.Experience;
                        experience.isDestructed = true;
                    }
                }
            }
        }
    }
}
