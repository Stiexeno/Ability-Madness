using DG.Tweening;
using TMPro;
using UnityEngine;
using Zenject;
using SF = UnityEngine.SerializeField;

namespace AbilityMadness.Code.Infrastructure.Services.UI.Widgets
{
    public class DamageTextWidget : MonoBehaviour
    {
        [SF] private TMP_Text damageText;

        private IUIPool _uiPool;

        [Inject]
        private void Construct(IUIPool uiPool)
        {
            _uiPool = uiPool;
        }

        public void Show(int damage)
        {
            damageText.text = damage.ToString();

            const float OFFSET = 0.25f;
            var randomX = Random.Range(-OFFSET, OFFSET);
            var randomY = Random.Range(-OFFSET, OFFSET);

            transform.position = new Vector3(transform.position.x + randomX, transform.position.y + randomY, transform.position.z);
            transform.DOPunchScale(Vector3.one * 1.2f, 0.15f)
                .OnComplete(() =>
                {
                    transform.DOMoveY(transform.position.y + 1f, 1f).OnComplete(() =>
                    {
                        _uiPool.Put(this);
                    });
                });

            transform.DOPunchRotation(Vector3.forward * Random.Range(-35f, 35f), 0.15f);
        }
    }
}
