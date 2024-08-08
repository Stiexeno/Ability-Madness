using AbilityMadness.Code.Gameplay.Weapons.Registrars;
using AbilityMadness.Code.Infrastructure.View;
using UnityEngine;
using SF = UnityEngine.SerializeField;

namespace AbilityMadness.Code.Gameplay.Weapons.Behaviours
{
    [RequireComponent(typeof(ReloadWidgetRegistrar))]
    public class ReloadWidget : EntityComponent
    {
        [SF] private RectTransform fillRect;

        private const float WIDTH = 0.2959f;

        public void Refresh(float normalizedValue)
        {
            var targetPosition = fillRect.anchoredPosition;
            targetPosition.x = Mathf.Lerp(-WIDTH, WIDTH, normalizedValue);
            fillRect.anchoredPosition = targetPosition;
        }
    }
}
