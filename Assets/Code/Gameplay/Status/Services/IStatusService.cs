using AbilityMadness.Code.Gameplay.Status.Factory;

namespace AbilityMadness.Code.Gameplay.Status.Services
{
    public interface IStatusService
    {
        GameEntity ApplyStatus(StatusSetup setup, int producerId, int targetId);
    }
}
