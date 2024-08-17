using System;
using AbilityMadness.Code.Gameplay.Gears.UI.ItemSelection;
using AbilityMadness.Code.Gameplay.Weapons.Bullets.Configs;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;
using SF = UnityEngine.SerializeField;

namespace AbilityMadness.Code.Gameplay.Gears.UI.Inventory
{
    public class BulletWidget : Widget, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
    {
        [SF] private Image icon;
        [SF] private Image shadow;

        [SF] private GameObject selectIcon;

        private ItemDescriptionWindow _descriptionWindow;
        private BulletConfig _bulletConfig;
        private IItemSelectModel _itemSelectModel;

        [Inject]
        private void Construct(IUIService uiService, IItemSelectModel itemSelectModel)
        {
            _itemSelectModel = itemSelectModel;
            _descriptionWindow = uiService.Get<ItemDescriptionWindow>();
        }

        public void Setup(BulletConfig bulletConfig)
        {
            _bulletConfig = bulletConfig;
            icon.sprite = bulletConfig.icon;
            shadow.sprite = bulletConfig.icon;

            icon.transform.localPosition = Vector3.zero;
            icon.transform.rotation = Quaternion.Euler(Vector3.zero);

            gameObject.SetActive(true);
        }

        private void OnDisable()
        {
            icon.gameObject.SetActive(true);
            selectIcon.SetActive(false);
        }

        public void Replace(BulletConfig bulletConfig)
        {
            shadow.sprite = bulletConfig.icon;

            var jumpPosition= icon.transform.position;
            jumpPosition.y -= 200f;
            jumpPosition.x -= 100f;

            icon.transform.DOJump(jumpPosition, 100f, 1, 0.25f)
                .SetEase(Ease.OutQuad)
                .SetUpdate(true);

            icon.transform.DORotate(Vector3.forward * 150f, 0.25f)
                .SetUpdate(true);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            selectIcon.SetActive(true);
            _descriptionWindow.Setup(_bulletConfig);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            selectIcon.SetActive(false);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (_itemSelectModel.IsAnySelected())
            {
                _itemSelectModel.Replace(this);
            }
        }
    }
}
