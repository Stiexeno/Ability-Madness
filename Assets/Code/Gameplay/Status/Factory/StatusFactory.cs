using System;
using AbilityMadness.Code.Common;
using AbilityMadness.Code.Extensions;
using AbilityMadness.Code.Infrastructure.Identifiers;

namespace AbilityMadness.Code.Gameplay.Status.Factory
{
    public class StatusFactory : IStatusFactory
    {
        private IIdentifierService _identifierService;

        public StatusFactory(IIdentifierService identifierService)
        {
            _identifierService = identifierService;
        }

        public GameEntity CreateStatus(StatusSetup setup, int producerId, int targetId)
        {
            return setup.type switch
            {
                StatusTypeId.Fire => CreateFireStatus(setup, producerId, targetId),
                StatusTypeId.Poison => CreatePoisonStatus(setup, producerId, targetId),
                StatusTypeId.Freeze => CreateFreezeStatus(setup, producerId, targetId),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        private GameEntity CreateFireStatus(StatusSetup setup, int producerId, int targetId)
        {
            return CreateEmptyStatus(setup, producerId, targetId)
                .With(x => x.isFire = true);
        }

        private GameEntity CreatePoisonStatus(StatusSetup setup, int producerId, int targetId)
        {
            return CreateEmptyStatus(setup, producerId, targetId)
                .With(x => x.isPoison = true);
        }

        public GameEntity CreateFreezeStatus(StatusSetup setup, int producerId, int targetId)
        {
            return CreateEmptyStatus(setup, producerId, targetId)
                .With(x => x.isFreeze = true);
        }

        private GameEntity CreateEmptyStatus(StatusSetup setup, int producerId, int targetId)
        {
            return CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .With(x => x.isStatus = true)
                .AddStatusTypeId(setup.type)
                .AddProducerId(producerId)
                .AddTargetId(targetId)
                .AddDamageTypeId(setup.damageType)

                .AddEffectValue(setup.value)

                .With(x => x.AddDuration(setup.duration), when: setup.duration > 0)
                .With(x => x.AddTimeLeft(setup.duration), when: setup.duration > 0)

                .With(x => x.AddPeriod(setup.period), when: setup.period > 0)
                .With(x => x.AddTimeSinceLastTick(0), when: setup.period > 0);
        }
    }
}
