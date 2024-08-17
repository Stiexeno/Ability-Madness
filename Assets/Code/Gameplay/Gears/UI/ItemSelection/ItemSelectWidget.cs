using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using SF = UnityEngine.SerializeField;

namespace AbilityMadness.Code.Gameplay.Gears.UI.ItemSelection
{
    public abstract class ItemSelectWidget : Widget, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        [SF] protected Image icon;
        [SF] protected GameObject selectIcon;

        public void OnPointerEnter(PointerEventData eventData)
        {
            selectIcon.SetActive(true);
            OnHover();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            selectIcon.SetActive(false);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            OnClick();
        }

        protected abstract void OnHover();
        protected abstract void OnClick();
    }
}
