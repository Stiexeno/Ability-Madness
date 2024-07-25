using AbilityMadness.Code.Gameplay.Input.Systems;
using AbilityMadness.Code.Infrastructure.Services.ECS;

namespace AbilityMadness.Code.Gameplay.Input
{
    public class InputFeature : Feature
    {
        public InputFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<InitializeInputSystem>());

            Add(systemFactory.Create<SetAxisInputSystem>());
            Add(systemFactory.Create<SetLookInputSystem>());
        }
    }
}
