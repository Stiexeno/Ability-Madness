using AbilityMadness.Code.Infrastructure.Services.ECS;
using Zenject;

namespace AbilityMadness.Infrastructure.Services.StateMachine.Implementations
{
    public class GameLoopState : IState, IEnter, ITickable, IFixedTickable, ILateTickable
    {
        private UpdateSystems _updateSystems;
        private FixedUpdateSystems _fixedUpdateSystems;
        private LateUpdateSystems _lateUpdateSystems;
        private IECSFacade _ecsFacade;

        public GameLoopState(
            UpdateSystems updateSystems,
            FixedUpdateSystems fixedUpdateSystems,
            LateUpdateSystems lateUpdateSystems,
            IECSFacade ecsFacade)
        {
            _ecsFacade = ecsFacade;
            _lateUpdateSystems = lateUpdateSystems;
            _fixedUpdateSystems = fixedUpdateSystems;
            _updateSystems = updateSystems;
        }

        public void Enter()
        {
            _ecsFacade.Initialize();
        }

        public void Tick()
        {
            _updateSystems.Execute();
            _updateSystems.Cleanup();
        }

        public void FixedTick()
        {
            _fixedUpdateSystems.Execute();
            _fixedUpdateSystems.Cleanup();
        }

        public void LateTick()
        {
            _lateUpdateSystems.Execute();
            _lateUpdateSystems.Cleanup();
        }
    }
}
