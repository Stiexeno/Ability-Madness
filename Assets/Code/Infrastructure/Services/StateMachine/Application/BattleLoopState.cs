using System;
using AbilityMadness.Code.Infrastructure.Services.ECS;
using UnityEngine;

namespace AbilityMadness.Infrastructure.Services.StateMachine.Implementations
{
    public class BattleLoopState : EndOfFrameExitState
    {
        private BattleUpdateFeature _battleUpdateFeature;
        private BattleFixedUpdateFeature _battleFixedUpdateFeature;
        private BattleLateUpdateFeature _battleLateUpdateFeature;
        private ISystemFactory _systemFactory;

        public BattleLoopState(ISystemFactory systemFactory)
        {
            _systemFactory = systemFactory;
        }

        protected override void OnEnter()
        {
            try
            {
                _battleUpdateFeature = _systemFactory.Create<BattleUpdateFeature>();
                _battleFixedUpdateFeature = _systemFactory.Create<BattleFixedUpdateFeature>();
                _battleLateUpdateFeature = _systemFactory.Create<BattleLateUpdateFeature>();

                _battleUpdateFeature.Initialize();
                _battleFixedUpdateFeature.Initialize();
                _battleLateUpdateFeature.Initialize();
            }
            catch (Exception e)
            {
                Debug.LogError(e);
                throw;
            }
        }

        protected override void OnTick()
        {
            _battleUpdateFeature.Execute();
            _battleUpdateFeature.Cleanup();
        }

        protected override void OnFixedTick()
        {
            _battleFixedUpdateFeature.Execute();
            _battleFixedUpdateFeature.Cleanup();
        }

        protected override void OnLateTick()
        {
            _battleLateUpdateFeature.Execute();
            _battleLateUpdateFeature.Cleanup();
        }

        protected override void OnExit()
        {
        }
    }
}
