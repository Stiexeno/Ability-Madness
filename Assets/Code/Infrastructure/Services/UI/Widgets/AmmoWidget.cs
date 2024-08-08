using AbilityMadness.Infrastructure.Factories.UI;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;
using SF = UnityEngine.SerializeField;

namespace AbilityMadness.Code.Infrastructure.Services.UI.Widgets
{
    public class AmmoWidget : MonoBehaviour
    {
        [SF] private Transform content;

        private int _maxAmmoCapacity;

        private BulletWidget[] bullets;
        private IUIFactory _uiFactory;

        [Inject]
        private void Construct(IUIFactory uiFactory)
        {
            _uiFactory = uiFactory;
        }

        public async UniTaskVoid Setup(int maxAmmoCapacity)
        {
            _maxAmmoCapacity = maxAmmoCapacity;
            bullets = new BulletWidget[maxAmmoCapacity];

            for (int i = 0; i < maxAmmoCapacity; i++)
            {
                var bulletWidget = await _uiFactory.CreateBulletWidget(content);
                bullets[i] = bulletWidget;
            }
        }

        public void Refresh(int ammoCapacity)
        {
            for (int i = 0; i < _maxAmmoCapacity; i++)
            {
                if (bullets[i] == null)
                    continue;

                if (i < ammoCapacity)
                {
                    bullets[i].Refill();
                }
                else
                {
                    bullets[i].SetEmpty();
                }
            }
        }
    }
}
