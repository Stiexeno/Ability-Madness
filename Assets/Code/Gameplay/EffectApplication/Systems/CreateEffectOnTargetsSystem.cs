using AbilityMadness.Code.Gameplay.EffectApplication.Factory;
using Entitas;

namespace AbilityMadness.Code.Gameplay.DamageApplication.Systems
{
    public class CreateEffectOnTargetsSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _damageApplicators;
        private GameContext _gameContext;
        private IGroup<GameEntity> _targets;
        private IEffectFactory _effectFactory;

        public CreateEffectOnTargetsSystem(GameContext gameContext, IEffectFactory  effectFactory)
        {
            _effectFactory = effectFactory;
            _gameContext = gameContext;
            _damageApplicators = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.TargetBuffer,
                    GameMatcher.EffectSetups,
                    GameMatcher.Team,
                    GameMatcher.Alive));

            _targets = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Team,
                    GameMatcher.Health,
                    GameMatcher.Alive));
        }

        public void Execute()
        {
            foreach (var damageApplicator in _damageApplicators)
            foreach (var targetId in damageApplicator.TargetBuffer)
            {
                var entity = _gameContext.GetEntityWithId(targetId);

                if (_targets.ContainsEntity(entity) && entity.Team != damageApplicator.Team)
                {
                    foreach (var effectSetup in damageApplicator.EffectSetups)
                    {
                        _effectFactory.CreateEffect(effectSetup,damageApplicator.Id, targetId);
                    }
                }
            }
        }
    }
}
