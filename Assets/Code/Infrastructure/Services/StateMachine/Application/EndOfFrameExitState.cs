using Cysharp.Threading.Tasks;
using Zenject;

namespace AbilityMadness.Infrastructure.Services.StateMachine.Implementations
{
    public abstract class EndOfFrameExitState : IState, IEnter, ITickable, IFixedTickable, ILateTickable, IExit
    {
        public void Enter() => OnEnter();

        public void Tick() => OnTick();

        public void FixedTick() => OnFixedTick();

        public void LateTick() => OnLateTick();

        public async UniTask Exit()
        {
            OnExit();
            await UniTask.Yield(PlayerLoopTiming.LastPostLateUpdate);
        }

        protected abstract void OnEnter();

        protected abstract void OnTick();

        protected abstract void OnFixedTick();

        protected abstract void OnLateTick();

        protected abstract void OnExit();
    }
}
