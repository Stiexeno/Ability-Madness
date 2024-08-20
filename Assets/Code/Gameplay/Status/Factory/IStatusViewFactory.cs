namespace AbilityMadness.Code.Gameplay.Status.Factory
{
    public interface IStatusViewFactory
    {
        GameEntity CreateStatus(StatusTypeId type, int producerId, int targetId);
    }
}
