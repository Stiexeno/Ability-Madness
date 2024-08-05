using AbilityMadness.Code.Common;
using AbilityMadness.Code.Extensions;
using AbilityMadness.Code.Infrastructure.Services.Identifiers;

namespace AbilityMadness.Code.Gameplay.Enemy.Waves.Factory
{
    public class WaveFactory : IWaveFactory
    {
        private IIdentifierService _identifierService;

        public WaveFactory(IIdentifierService identifierService)
        {
            _identifierService = identifierService;
        }

        public GameEntity CreateWave()
        {
            return CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .With(x => x.isWave = true)
                .AddTimeElapsed(0f)
                .AddInterval(1f);
        }
    }
}
