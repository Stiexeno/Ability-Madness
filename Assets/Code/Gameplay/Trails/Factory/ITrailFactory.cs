namespace AbilityMadness.Code.Gameplay.Trails.Factory
{
    public interface ITrailFactory
    {
        GameEntity CreateTrail(TrailTypeId type, int producerId, int targetId);
    }
}
