using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using SF = UnityEngine.SerializeField;

namespace AbilityMadness.Code.Gameplay.UI.Hud.Widgets
{
    public class DamageFlashWidget : MonoBehaviour
    {
        [SF] private Image flash;

        public void Flash()
        {
            flash.gameObject.SetActive(true);
            flash.DOFade(0f, 0.1f)
                .OnComplete(() =>
                {
                    flash.gameObject.SetActive(false);
                    flash.color = new Color(1f, 0f, 0f, 0.3f);
                });
        }
    }
}
