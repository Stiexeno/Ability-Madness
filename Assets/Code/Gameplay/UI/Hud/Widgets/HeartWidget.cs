using UnityEngine.UI;
using SF = UnityEngine.SerializeField;

namespace AbilityMadness.Code.Gameplay.UI.Hud.Widgets
{
    public enum HeartTypeId { Unkonwn, Empty, Half, Full }

    public class HeartWidget : Widget
    {
        [SF] private Image emptyIcon;
        [SF] private Image fullIcon;
        [SF] private Image halfIcon;

        public void SetHeartType(HeartTypeId heartType)
        {
            switch (heartType)
            {
                case HeartTypeId.Empty:
                    emptyIcon.gameObject.SetActive(true);
                    halfIcon.gameObject.SetActive(false);
                    fullIcon.gameObject.SetActive(false);
                    break;
                case HeartTypeId.Half:
                    emptyIcon.gameObject.SetActive(false);
                    halfIcon.gameObject.SetActive(true);
                    fullIcon.gameObject.SetActive(false);
                    break;
                case HeartTypeId.Full:
                    emptyIcon.gameObject.SetActive(false);
                    halfIcon.gameObject.SetActive(false);
                    fullIcon.gameObject.SetActive(true);
                    break;
            }
        }
    }
}
