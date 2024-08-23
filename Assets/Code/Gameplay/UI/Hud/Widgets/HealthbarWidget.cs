using System;
using System.Collections.Generic;
using AbilityMadness.Code.Infrastructure.Services.UI;
using AbilityMadness.Code.Infrastructure.UI.Factory;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;
using SF = UnityEngine.SerializeField;

namespace AbilityMadness.Code.Gameplay.UI.Hud.Widgets
{
    public class HealthbarWidget : MonoBehaviour
    {
        private bool _isLoading;

        private List<HeartWidget> _hearts = new();
        private IUIFactory _uiFactory;
        private IUIPool _uiPool;
        private int _maxHealth;

        [Inject]
        private void Construct(IUIFactory uiFactory, IUIPool uiPool)
        {
            _uiPool = uiPool;
            _uiFactory = uiFactory;
        }

        private void Cleanup()
        {
            foreach (var heart in _hearts)
            {
                _uiPool.Put(heart);
            }

            _hearts.Clear();
        }

        public async UniTaskVoid SetHealth(int health, int maxHealth)
        {
            if (_isLoading)
                return;

            if (_maxHealth != maxHealth)
            {
                _isLoading = true;
                await AddHearts(maxHealth);
                _maxHealth = maxHealth;
            }

            _isLoading = false;

            for (int i = 0; i < _hearts.Count; i++)
            {
                if (i < health / 2)
                {
                    _hearts[i].SetHeartType(HeartTypeId.Full);
                }
                else if (i < health / 2 + 1 && health % 2 != 0)
                {
                    _hearts[i].SetHeartType(HeartTypeId.Half);
                }
                else
                {
                    _hearts[i].SetHeartType(HeartTypeId.Empty);
                }
            }
        }

        private async UniTask AddHearts(int maxHealth)
        {
            Cleanup();

            var halfMaxHealth = Mathf.CeilToInt(maxHealth / 2f);

            for (int i = 0; i < halfMaxHealth; i++)
            {
                var heart = await _uiFactory.CreateHeartWidget(transform);
                heart.gameObject.SetActive(true);
                _hearts.Add(heart);
            }
        }
    }
}
