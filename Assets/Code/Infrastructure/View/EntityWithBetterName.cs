using System;
using System.Text;
using AbilityMadness.Code.Extensions;
using Entitas;
using UnityEngine;

public sealed partial class GameEntity
{
  public bool IsValid() => this != null && this.GetComponents().Length > 0;

#if UNITY_EDITOR
  private string _oldBaseToStringCache;
  private string _toStringCache;
  private StringBuilder _toStringBuilder;

  public override string ToString()
  {
    InvalidateCache();

    if (_toStringCache == null)
    {
      if (_toStringBuilder == null)
        _toStringBuilder = new StringBuilder();

      _toStringBuilder.Length = 0;

      IComponent[] components = GetComponents();

      if (components.Length == 0) // do not set _toStringCache this time since components seem to be initialized later o_O
        return "No components";

      _toStringBuilder.Append($"{EntityName(components)}");

      _toStringCache = _toStringBuilder.ToString();

      _oldBaseToStringCache = base.ToString();
    }

    return _toStringCache;
  }

  private void InvalidateCache()
  {
    if (_oldBaseToStringCache != base.ToString())
      _toStringCache = null;
  }

  private string EntityName(IComponent[] components)
  {
    try
    {
      if (components.Length == 1)
        return components[0].GetType().Name.AddSpacesBetweenCapital().Replace("Component", string.Empty);
    }
    catch (Exception exception)
    {
      Debug.LogWarning(exception.Message);
    }

    foreach (IComponent component in components)
    {
      switch (component.GetType().Name)
      {
        case nameof(AbilityMadness.Code.Common.Transform):
          var name = "";
          var transform = ((AbilityMadness.Code.Common.TransformComponent) component).Value;

          if(transform != null) name = transform.gameObject.name;

          if (hasId) name += $" (id: {id.Value})";

          return name;
        case nameof(AbilityMadness.Code.Common.View):
            var viewName = "";
            var view = ((AbilityMadness.Code.Common.View) component).Value;

            if(view != null)
                viewName = view.gameObject.name;

            if (hasId) viewName += $" (id: {id.Value})";

            return viewName;
      }
    }

    return components[0].GetType().Name.AddSpacesBetweenCapital().Replace("Component", string.Empty);
  }
#endif
}
