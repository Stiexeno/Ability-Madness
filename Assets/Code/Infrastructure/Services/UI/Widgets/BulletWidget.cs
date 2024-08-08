using AbilityMadness.Code.Extensions;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using SF = UnityEngine.SerializeField;
namespace AbilityMadness.Code.Infrastructure.Services.UI.Widgets
{
    public class BulletWidget : MonoBehaviour
    {
        [SF] private Image icon;

        private bool isRefilled;

        public void Refill()
        {
            if (isRefilled)
                return;

            isRefilled = true;

            icon.gameObject.SetActive(true);
        }

        public void SetEmpty()
        {
            if (isRefilled == false)
                return;

            isRefilled = false;

            icon.transform.DOScale(Vector3.one * 1.4f, 0.15f)
                .OnComplete(() =>
                {
                    icon.gameObject.SetActive(false);
                    icon.transform.localScale = Vector3.one;
                }).SetEase(Ease.OutBack);

            icon.transform.DOShakeRotation(0.15f, 50);
        }
    }
}
