using AbilityMadness.Code.Common;

namespace AbilityMadness.Code.Gameplay.Round.Factory
{
    public class RoundFactory : IRoundFactory
    {
        public GameEntity CreateRound(int roundTime)
        {
            return CreateEntity.Empty()
                .AddRoundTime(roundTime)
                .AddTimeElapsed(0);
        }
    }
}
