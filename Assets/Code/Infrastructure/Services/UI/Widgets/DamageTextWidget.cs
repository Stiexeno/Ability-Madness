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

            transform.DOMoveY(transform.position.y + 1f, 1f).OnComplete(() =>
            {
                _uiPool.Put(this);
            });
        }
    }
}
