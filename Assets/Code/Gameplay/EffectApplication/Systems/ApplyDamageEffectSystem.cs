using AbilityMadness.Code.Gameplay.EffectApplication.Factory;
using Entitas;
using UnityEngine;

namespace AbilityMadness.Code.Gameplay.EffectApplication.Systems
{
    public class ApplyDamageEffectSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _effectRequests;
        private IGroup<GameEntity> _targets;
        private GameContext _gameContext;
        private IEffectFactory _effectFactory;

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
                    GameMatcher.TargetId));

            _targets = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Team,
                    GameMatcher.Health,
                    GameMatcher.Alive));
        }

        public void Execute()
        {
            foreach (var damageRequest in _effectRequests)
            {
                var target = _gameContext.GetEntityWithId(damageRequest.TargetId);
                var producer = _gameContext.GetEntityWithId(damageRequest.ProducerId);

                if (_targets.ContainsEntity(target) && target.Team != producer.Team)
                {
                    var damage = Mathf.RoundToInt(damageRequest.EffectValue);
                    target.Health -= damage;

                    _effectFactory.CreateEffectReceived(EffectTypeId.Damage, damageRequest.ProducerId, target.Id, damage);
                    _effectFactory.CreateEffectDealt(EffectTypeId.Damage, producer.Id, producer.Id, damage);
                }
            }
        }
    }
}
