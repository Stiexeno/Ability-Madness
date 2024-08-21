using AbilityMadness.Code.Infrastructure.View;
using Entitas;
using UnityEngine.AddressableAssets;

namespace AbilityMadness.Code.Common
{
    [Game] public class View : IComponent { public EntityView Value; }
    [Game] public class ViewPath : IComponent { public string Value; }
    [Game] public class ViewReference : IComponent { public AssetReferenceGameObject Value; }
    [Game] public class AssetReferenceComponent : IComponent { public AssetReferenceGameObject Value; }
    [Game] public class Loading : IComponent { }

    [Game] public class Enabled : IComponent { }
    [Game] public class Disabled : IComponent { }
}
