using AbilityMadness.Code.Gameplay.Status.Factory;
using Entitas;
using UnityEngine;

namespace AbilityMadness.Code.Gameplay.Modifiers.Systems.Implemenation.Ricochet
{
    public class ApplyStatusesSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _entities;
        private IGroup<GameEntity> _owners;
        private GameContext _gameContext;
        private IGroup<GameEntity> _targets;
        private IStatusFactory _statusFactory;

        public ApplyStatusesSystem(GameContext gameContext, IStatusFactory statusFactory)
        {
            _statusFactory = statusFactory;
            _gameContext = gameContext;
            _entities = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.EffectDealt,
                    GameMatcher.ProducerId,
                    GameMatcher.TargetId));

            _owners = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.StatusSetups));

            _targets = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Id,
                    GameMatcher.Alive));
        }

        public void Execute()
        {
            foreach (var entity in _entities)
            {
                var owner = _gameContext.GetEntityWithId(entity.ProducerId);
                var target = _gameContext.GetEntityWithId(entity.TargetId);

                if (_owners.ContainsEntity(owner) && _targets.ContainsEntity(target))
                {
                    foreach (var statusSetup in owner.StatusSetups)
                    {
                        _statusFactory.CreateStatus(statusSetup, owner.Id, target.Id);
                    }
                }
            }
        }
    }
}
