namespace AbilityMadness.Code.Gameplay.Status.Factory
{
    public interface IStatusFactory
    {
        GameEntity CreateStatus(StatusSetup setup, int producerId, int targetId);
        GameEntity CreateStatusRequest(StatusSetup setup, int producerId, int targetId);
    }
}
