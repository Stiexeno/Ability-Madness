using AbilityMadness.Code.Gameplay.EffectApplication.Factory;
using Entitas;

namespace AbilityMadness.Code.Gameplay.DamageApplication.Systems.View
{
    public class ApplyDamageVFXSystem : IExecuteSystem
    {
        private GameContext _gameContext;
        private IGroup<GameEntity> _damageEffects;
        private IGroup<GameEntity> _targets;

        private IVFXFactory _ivfxFactory;

        public ApplyDamageVFXSystem(GameContext gameContext, IVFXFactory ivfxFactory)
        {
            _gameContext = gameContext;
            _ivfxFactory = ivfxFactory;

            _damageEffects = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Damage,
                    GameMatcher.TargetBuffer,
                    GameMatcher.EffectViewPath,
                    GameMatcher.Team));

            _targets = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.WorldPosition,
                    GameMatcher.Team,
                    GameMatcher.Alive));
        }

        public void Execute()
        {
            foreach (var damageEffect in _damageEffects)
            foreach (var targetId in damageEffect.TargetBuffer)
            {
                var target = _gameContext.GetEntityWithId(targetId);

                if (_targets.ContainsEntity(target) && target.Team != damageEffect.Team)
                {
                    _ivfxFactory.CreateVFX(damageEffect.EffectViewPath, target.WorldPosition);
                }
            }
        }
    }
}
