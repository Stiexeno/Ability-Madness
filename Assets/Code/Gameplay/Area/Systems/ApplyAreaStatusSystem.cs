using System;
using AbilityMadness.Code.Gameplay.Status.Factory;
using AbilityMadness.Code.Gameplay.Status.Services;
using Entitas;

namespace AbilityMadness.Code.Gameplay.Area.Systems
{
    public class ApplyAreaStatusSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _areas;
        private IStatusFactory _statusFactory;
        private IStatusService _statusService;

        public ApplyAreaStatusSystem(GameContext gameContext, IStatusService statusService)
        {
            _statusService = statusService;
            _areas = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Area,
                    GameMatcher.StatusSetups,
                    GameMatcher.TargetBuffer));
        }

        public void Execute()
        {
            foreach (var area in _areas)
            {
                foreach (var target in area.TargetBuffer)
                {
                    foreach (var statusSetup in area.StatusSetups)
                    {
                        _statusService.ApplyStatus(statusSetup, area.Id, target);
                    }
                }
            }
        }
    }
}
