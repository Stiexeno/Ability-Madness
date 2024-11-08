using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using SF = UnityEngine.SerializeField;
namespace AbilityMadness.Code.Gameplay.UI.Hud.Widgets
{
    public class SmallBulletWidget : MonoBehaviour
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
                .OnComplete(Cleanup)
                .SetEase(Ease.OutBack);

            icon.transform.DOShakeRotation(0.15f, 50);
        }

        private void Cleanup()
        {
            icon.gameObject.SetActive(false);
            icon.transform.localScale = Vector3.one;
        }
    }
}
