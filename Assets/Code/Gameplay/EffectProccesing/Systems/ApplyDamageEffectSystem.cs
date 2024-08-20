using System.Collections.Generic;
using AbilityMadness.Code.Gameplay.EffectApplication;
using AbilityMadness.Code.Gameplay.EffectApplication.Factory;
using Entitas;
using UnityEngine;

namespace AbilityMadness.Code.Gameplay.EffectProccesing.Systems
{
    public class ApplyDamageEffectSystem : IExecuteSystem
    {
        private readonly List<GameEntity> _buffer = new(32);
        private IGroup<GameEntity> _effectRequests;
        private IGroup<GameEntity> _targets;
        private GameContext _gameContext;
        private IEffectFactory _effectFactory;
        private IGroup<GameEntity> _producers;

        public ApplyDamageEffectSystem(GameContext gameContext, IEffectFactory effectFactory)
        {
            _effectFactory = effectFactory;
            _gameContext = gameContext;
            _effectRequests = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.EffectApplication,
                    GameMatcher.DamageEffect,
                    GameMatcher.EffectValue,
                    GameMatcher.ProducerId,
                    GameMatcher.TargetId,
                    GameMatcher.DamageTypeId));

            _targets = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Team,
                    GameMatcher.Health,
                    GameMatcher.Alive));

            _producers = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Id,
                    GameMatcher.Team,
                    GameMatcher.Alive));
        }

        public void Execute()
        {
            foreach (var damageRequest in _effectRequests.GetEntities(_buffer))
            {
                var target = _gameContext.GetEntityWithId(damageRequest.TargetId);
                var producer = _gameContext.GetEntityWithId(damageRequest.ProducerId);

                var damage = Mathf.RoundToInt(damageRequest.EffectValue);
                target.Health -= damage;

                _effectFactory.CreateEffectReceived(EffectTypeId.Damage, damageRequest.DamageTypeId, damageRequest.ProducerId, target.Id, damage);

                if (_producers.ContainsEntity(producer))
                {
                    _effectFactory.CreateEffectDealt(EffectTypeId.Damage, damageRequest.DamageTypeId, producer.Id, target.Id, damage);
                }

                damageRequest.Destroy();
            }
        }
    }
}
