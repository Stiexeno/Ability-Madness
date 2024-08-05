using AbilityMadness.Code.Extensions;
using AbilityMadness.Code.Infrastructure.Services.Assembler;
using AbilityMadness.Infrastructure.Services.Updatable;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Zenject;
using SF = UnityEngine.SerializeField;

namespace AbilityMadness.Code.Gameplay.UI.Upgrade
{
    [RequireComponent(typeof(UpdatableGameObject))]
    public class UpgradeWidget : MonoBehaviour, IUpdatable, IPointerDownHandler, IPointerUpHandler
    {
        [SF] private Image icon;
        [SF] private Image background;

        [SF] private LayoutElement layoutElement;

        private bool isDragging;
        private Vector3 velocity;

        private InputAction _mousePosition;
        private Vector2 _mouseToWorld;

        [Inject]
        private void Construct(PlayerInput playerInput)
        {
            _mousePosition = playerInput.actions[Constants.Input.Aiming];
        }

        public void Setup(AttachmentConfig config)
        {
            icon.sprite = config.icon;
            background.sprite = config.blockIcon;

            RefreshLayout(config);
        }

        private void RefreshLayout(AttachmentConfig config)
        {
            var shape = config.shape;
            var dimension = shape.GetMaxDimensions();

            layoutElement.preferredWidth = dimension.x * 150;
            layoutElement.preferredHeight = dimension.y * 150;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            isDragging = true;
            transform.DOScale(Vector3.one * 1.4f, 0.15f).SetUpdate(true);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            isDragging = false;
            transform.DOScale(Vector3.one, 0.15f).SetUpdate(true);
            transform.DOMove(_mouseToWorld, 0.15f).SetUpdate(true);
        }

        public void Tick()
        {
            if (isDragging)
            {
                _mouseToWorld = _mousePosition.ReadValue<Vector2>();
                var offset = _mouseToWorld.AddY(150f);

                transform.position =  Vector3.SmoothDamp(
                    transform.position,
                    offset,
                    ref velocity,
                    0.2f,
                    float.MaxValue,
                    Time.unscaledDeltaTime);
            }
        }
    }
}
