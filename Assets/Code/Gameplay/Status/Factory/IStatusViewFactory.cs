namespace AbilityMadness.Code.Gameplay.Status.Factory
{
    public interface IStatusViewFactory
    {
        GameEntity CreateStatusView(StatusTypeId type, int producerId, int targetId);
    }
}
