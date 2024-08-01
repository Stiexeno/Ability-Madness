using AbilityMadness.Code.Gameplay.EffectApplication.Factory;
using Entitas;

namespace AbilityMadness.Code.Gameplay.DamageApplication.View
{
    public class ApplyDamageEffectSystem : IExecuteSystem
    {
        private GameContext _gameContext;
        private IGroup<GameEntity> _damageEffects;
        private IGroup<GameEntity> _targets;

        private IEffectFactory _effectFactory;

        public ApplyDamageEffectSystem(GameContext gameContext, IEffectFactory effectFactory)
        {
            _gameContext = gameContext;
            _effectFactory = effectFactory;

            _damageEffects = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Damage,
                    GameMatcher.TargetBuffer,
                    GameMatcher.EffectViewPath,
                    GameMatcher.Team));

            _targets = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.WorldPosition,
                    GameMatcher.Team));
        }

        public void Execute()
        {
            foreach (var damageEffect in _damageEffects)
            foreach (var targetId in damageEffect.TargetBuffer)
            {
                var target = _gameContext.GetEntityWithId(targetId);

                if (_targets.ContainsEntity(target) && target.Team != damageEffect.Team)
                {
                    _effectFactory.CreateEffect(damageEffect.EffectViewPath, target.WorldPosition);
                }
            }
        }
    }
}
