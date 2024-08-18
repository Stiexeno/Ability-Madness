using AbilityMadness.Code.Gameplay.EffectApplication;
using AbilityMadness.Code.Gameplay.EffectApplication.Factory;
using Entitas;
using UnityEngine;

namespace AbilityMadness.Code.Gameplay.Status.Systems
{
    public class PeriodicDamageStatusSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _statuses;
        private IEffectFactory _effectFactory;

        public PeriodicDamageStatusSystem(GameContext gameContext, IEffectFactory effectFactory)
        {
            _effectFactory = effectFactory;
            _statuses = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Status,
                    GameMatcher.Period,
                    GameMatcher.TimeSinceLastTick,
                    GameMatcher.EffectValue,
                    GameMatcher.ProducerId,
                    GameMatcher.TargetId,
                    GameMatcher.DamageTypeId));
        }

        public void Execute()
        {
            foreach (var status in _statuses)
            {
                if (status.TimeSinceLastTick >= 0)
                {
                    status.TimeSinceLastTick -= Time.deltaTime;
                }
                else
                {
                    status.TimeSinceLastTick = status.Period;

                    var damageEffect = new EffectSetup
                    {
                        type = EffectTypeId.Damage,
                        value = status.EffectValue,
                        damageType =    status.DamageTypeId
                    };

                    _effectFactory.CreateEffect(damageEffect, status.ProducerId, status.TargetId);
                }
            }
        }
    }
}
