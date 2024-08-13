namespace AbilityMadness.Code.Gameplay.Stats.Factory
{
    public interface IStatsFactory
    {
        GameEntity CreateStatsChange(StatsTypeId type, int producerId, int targetId, float value);
    }
}
