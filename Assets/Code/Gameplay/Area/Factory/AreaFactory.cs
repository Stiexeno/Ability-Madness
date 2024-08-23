using System.Collections.Generic;
using AbilityMadness.Code.Common;
using AbilityMadness.Code.Extensions;
using AbilityMadness.Code.Gameplay.Health;
using AbilityMadness.Code.Gameplay.Status;
using AbilityMadness.Code.Gameplay.Status.Factory;
using AbilityMadness.Code.Gameplay.TargetCollection;
using AbilityMadness.Code.Infrastructure.Identifiers;
using UnityEngine;

namespace AbilityMadness.Code.Gameplay.Area.Factory
{
    public class AreaFactory : IAreaFactory
    {
        private IIdentifierService _identifierService;

        public AreaFactory(IIdentifierService identifierService)
        {
            _identifierService = identifierService;
        }

        public GameEntity CreateArea(AreaTypeId type, int producerId, Vector3 position, Team team)
        {
            return type switch
            {
                AreaTypeId.Fire => CreateFireArea(producerId, position, team),
                AreaTypeId.Poison => CreatePoisonArea(producerId, position, team),
                AreaTypeId.Freeze => CreateFreezeArea(producerId, position, team),
                _ => CreateFireArea(producerId, position, team)
            };
        }

        private GameEntity CreateFireArea(int producerId, Vector3 position, Team team)
        {
            return CreateEmptyArea(AreaTypeId.Fire, producerId, position, team)
                .AddViewPath(Prefabs.Areas.Fire)
                .AddDuration(3)
                .AddTimeLeft(3)

                .CollectTargetsWithSphereCast(0.3f)
                .AddStatusSetups(new List<StatusSetup>
                {
                    new StatusSetup
                    {
                        type = StatusTypeId.Fire,
                        duration = 3,
                        period = 0.5f,
                        value = 1
                    }
                });
        }

        private GameEntity CreatePoisonArea(int producerId, Vector3 position, Team team)
        {
            return CreateEmptyArea(AreaTypeId.Fire, producerId, position, team)
                .AddViewPath(Prefabs.Areas.Poison)
                .AddDuration(3)
                .AddTimeLeft(3)

                .CollectTargetsWithSphereCast(0.3f)
                .AddStatusSetups(new List<StatusSetup>
                {
                    new StatusSetup
                    {
                        type = StatusTypeId.Poison,
                        duration = 3,
                        period = 0.5f,
                        value = 1
                    }
                });
        }

        private GameEntity CreateFreezeArea(int producerId, Vector3 position, Team team)
        {
            return CreateEmptyArea(AreaTypeId.Freeze, producerId, position, team)
                .AddViewPath(Prefabs.Areas.Freeze)
                .AddDuration(3)
                .AddTimeLeft(3)

                .CollectTargetsWithSphereCast(0.3f)
                .AddStatusSetups(new List<StatusSetup>
                {
                    new StatusSetup
                    {
                        type = StatusTypeId.Freeze,
                        duration = 3,
                        value = -0.8f
                    }
                });
        }

        private GameEntity CreateEmptyArea(AreaTypeId type, int producerId, Vector3 position, Team team)
        {
            return CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .With(x => x.isArea = true)

                .AddWorldPosition(position)

                .AddAreaTypeId(type)
                .AddProducerId(producerId)
                .AddTeam(team);
        }
    }
}
