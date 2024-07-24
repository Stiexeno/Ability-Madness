namespace AbilityMadness.Code.Infrastructure.Services.ECS
{
    public class ECSFacade : IECSFacade
    {
        private Contexts _contexts;
        private UpdateSystems _updateSystems;
        private FixedUpdateSystems _fixedUpdateSystems;
        private LateUpdateSystems _lateUpdateSystems;

        public ECSFacade(
            Contexts contexts,
            UpdateSystems updateSystems,
            FixedUpdateSystems fixedUpdateSystems,
            LateUpdateSystems lateUpdateSystems)
        {
            _lateUpdateSystems = lateUpdateSystems;
            _fixedUpdateSystems = fixedUpdateSystems;
            _updateSystems = updateSystems;
            _contexts = contexts;
        }

        public void Initialize()
        {
            _updateSystems.ActivateReactiveSystems();
            _fixedUpdateSystems.ActivateReactiveSystems();
            _lateUpdateSystems.ActivateReactiveSystems();

            _updateSystems.Initialize();
            _fixedUpdateSystems.Initialize();
            _lateUpdateSystems.Initialize();
        }

        public void CleanUp()
        {
            _updateSystems.Cleanup();
            _updateSystems.DeactivateReactiveSystems();
            _updateSystems.ClearReactiveSystems();

            _fixedUpdateSystems.Cleanup();
            _fixedUpdateSystems.DeactivateReactiveSystems();
            _fixedUpdateSystems.ClearReactiveSystems();

            _lateUpdateSystems.Cleanup();
            _lateUpdateSystems.DeactivateReactiveSystems();
            _lateUpdateSystems.ClearReactiveSystems();

            _contexts.Reset();
        }
    }
}
