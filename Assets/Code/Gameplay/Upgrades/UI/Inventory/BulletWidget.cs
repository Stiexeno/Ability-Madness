using AbilityMadness.Code.Gameplay.Upgrades.UI.ItemSelection;
using AbilityMadness.Code.Gameplay.Weapons.Bullets.Configs;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;
using SF = UnityEngine.SerializeField;

namespace AbilityMadness.Code.Gameplay.Upgrades.UI.Inventory
{
    public class BulletWidget : Widget, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
    {
        [SF] private Image icon;
        [SF] private Image shadow;

        [SF] private GameObject selectIcon;

        private int _index;
        private BulletConfig _bulletConfig;

        private ItemDescriptionWindow _descriptionWindow;

        private IUpgradeSelectModel _upgradeSelectModel;

        [Inject]
        private void Construct(IUIService uiService, IUpgradeSelectModel upgradeSelectModel)
        {
            _upgradeSelectModel = upgradeSelectModel;
            _descriptionWindow = uiService.Get<ItemDescriptionWindow>();
        }

        public void Setup(BulletConfig bulletConfig, int index)
        {
            _bulletConfig = bulletConfig;
            _index = index;

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
            if (_upgradeSelectModel.IsAnySelected())
            {
                _upgradeSelectModel.Replace(this, _index);
            }
        }
    }
}
