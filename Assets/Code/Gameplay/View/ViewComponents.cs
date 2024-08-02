using AbilityMadness.Code.Infrastructure.View;
using Entitas;

namespace AbilityMadness.Code.Common
{
    [Game] public class View : IComponent { public EntityView Value; }
    [Game] public class ViewPath : IComponent { public string Value; }
    [Game] public class Loading : IComponent { }
    [Game] public class Destructed : IComponent { }

    [Game] public class Enabled : IComponent { }
    [Game] public class Disabled : IComponent { }
}
