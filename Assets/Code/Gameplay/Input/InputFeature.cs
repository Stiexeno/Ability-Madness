using AbilityMadness.Code.Gameplay.Input.Systems;
using AbilityMadness.Code.Infrastructure.ECS;

namespace AbilityMadness.Code.Gameplay.Input
{
    public class InputFeature : Feature
    {
        public InputFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<InitializeInputSystem>());

            Add(systemFactory.Create<SetAxisInputSystem>());
            Add(systemFactory.Create<SetLookInputSystem>());
            Add(systemFactory.Create<SetMousePositionInputSystem>());

            Add(systemFactory.Create<HandleMouseEnterSystem>());
            Add(systemFactory.Create<HandleMouseExitSystem>());

            Add(systemFactory.Create<MarkMouseHoverSystem>());
            Add(systemFactory.Create<RemoveMouseHoverSystem>());
            Add(systemFactory.Create<CleanupMouseTriggerSystem>());

            Add(systemFactory.Create<SetAttackInputSystem>());
            Add(systemFactory.Create<SetDashInputSystem>());
        }
    }
}
