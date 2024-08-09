namespace AbilityMadness.Code.Gameplay.Round.Factory
{
    public interface IRoundFactory
    {
        GameEntity CreateRound(int roundTime);
    }
}
