using System;
using AbilityMadness.Code.Extensions;
using AbilityMadness.Code.Gameplay.Weapons.Bullets.Configs;
using AbilityMadness.Code.Infrastructure.Services.UI;
using AbilityMadness.Code.Infrastructure.Updatable;
using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Zenject;
using SF = UnityEngine.SerializeField;

namespace AbilityMadness.Code.Gameplay.Upgrades.UI.ItemSelection
{
    [RequireComponent(typeof(UpdatableGameObject))]
    public class BulletDragWidget : Widget, IUpdatable
    {
        [SF] private Image icon;

        private bool _isReplacing;

        private Vector3 _velocity;
        private Vector2 _mouseToWorld;

        private InputAction _mousePosition;
        private IUIPool _uiPool;

        [Inject]
        private void Construct(PlayerInput playerInput, IUIPool uiPool)
        {
            _uiPool = uiPool;
            _mousePosition = playerInput.actions[Constants.Input.MousePosition];
        }

        public void Setup(BulletConfig config)
        {
            _isReplacing = false;

            icon.sprite = config.icon;
            transform.position = _mousePosition.ReadValue<Vector2>();

            transform.DOKill(true);
            transform.DOScale(Vector3.one * 1.5f, 0.2f)
                .SetUpdate(true)
                .OnComplete(() =>
                {
                    transform.DOScale(Vector3.one * 1.25f, 0.4f)
                        .SetUpdate(true)
                        .SetLoops(-1, LoopType.Yoyo)
                        .SetDelay(0.15f);
                });

            gameObject.SetActive(true);
        }

        public void Replace(Transform pivot, Action onComplete = null)
        {
            _isReplacing = true;

            transform.DOKill(true);
            transform.DOMove(pivot.position, 0.25f)
                .SetUpdate(true);

            transform.DOScale(Vector3.one, 0.25f)
                .SetUpdate(true)
                .OnComplete(() =>
                {
                    _uiPool.Put(this);
                    onComplete?.Invoke();
                });
        }

        public void Tick()
        {
            if (_isReplacing)
                return;

            Move();
           // RotateAlongVelocity();
        }

        private void Move()
        {
            _mouseToWorld = _mousePosition.ReadValue<Vector2>();
            var offset = _mouseToWorld.AddY(150f);

            transform.position = Vector3.SmoothDamp(
                transform.position,
                offset,
                ref _velocity,
                0.2f,
                float.MaxValue,
                Time.unscaledDeltaTime);
        }

        private void RotateAlongVelocity()
        {
            var velocity = _velocity.normalized;

            // Rotate only by X axis
            // If velocity X is 1.5f, then angle must be 20f degrees
            // If velocity X is -1.5f, then angle must be -20f degrees
            transform.rotation = Quaternion.Euler(0f, 0f, velocity.x * 20f);
        }
    }
}
