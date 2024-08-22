using AbilityMadness.Code.Gameplay.Status.Factory;

namespace AbilityMadness.Code.Gameplay.Status.Services
{
    public class StatusService : IStatusService
    {
        private IStatusFactory _statusFactory;

        public StatusService(IStatusFactory statusFactory)
        {
            _statusFactory = statusFactory;
        }

        public GameEntity ApplyStatus(StatusSetup setup, int producerId, int targetId)
        {
            return _statusFactory.CreateStatusRequest(setup, producerId, targetId);
        }
    }
}
