using AbilityMadness.Code.Common;
using AbilityMadness.Code.Extensions;
using AbilityMadness.Code.Gameplay.Trails;
using AbilityMadness.Code.Infrastructure.Configs;
using AbilityMadness.Code.Infrastructure.Identifiers;

namespace AbilityMadness.Code.Gameplay.Gears.Factory
{
    public class GearFactory : IGearFactory
    {
        private IIdentifierService _identifierService;
        private IConfigsService _configsService;

        public GearFactory(IIdentifierService identifierService, IConfigsService configsService)
        {
            _configsService = configsService;
            _identifierService = identifierService;
        }

        public GameEntity CreateGear(GearTypeId type, int producerId, int targetId)
        {
            return type switch
            {
                GearTypeId.FireBoots => CreateFireBoots(producerId, targetId),
                GearTypeId.FreezeBoots => CreateFreezeBoots(producerId, targetId),
                GearTypeId.PoisonBoots => CreatePoisonBoots(producerId, targetId),
                _ => CreateEmptyGear(type, producerId, targetId)
            };
        }

        public GameEntity CreateGearRequest(GearTypeId type)
        {
            return CreateEntity.Empty()
                .With(x => x.isGearRequest = true)
                .AddGearTypeId(type);
        }

        private GameEntity CreateFireBoots(int producerId, int targetId)
        {
            return CreateEmptyGear(GearTypeId.FireBoots, producerId, targetId)
                .AddTrailTypeId(TrailTypeId.Fire);
        }

        private GameEntity CreateFreezeBoots(int producerId, int targetId)
        {
            return CreateEmptyGear(GearTypeId.FreezeBoots, producerId, targetId)
                .AddTrailTypeId(TrailTypeId.Freeze);
        }

        private GameEntity CreatePoisonBoots(int producerId, int targetId)
        {
            return CreateEmptyGear(GearTypeId.PoisonBoots, producerId, targetId)
                .AddTrailTypeId(TrailTypeId.Poison);
        }

        private GameEntity CreateEmptyGear(GearTypeId type, int producerId, int targetId)
        {
            var config = _configsService.GetGearConfig(type);

            return CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .With(x => x.isGear = true)
                .AddGearTypeId(type)
                .AddProducerId(producerId)
                .AddTargetId(targetId)
                .With(x => x.isNotApplied = true)

                .With(x => x.AddStatsSetups(config.statsSetup), when: config.statsSetup.Count > 0);
        }
    }
}
