using AbilityMadness.Code.Extensions;
using TMPro;
using UnityEngine;
using SF = UnityEngine.SerializeField;

namespace AbilityMadness.Code.Infrastructure.Services.UI.Widgets
{
    public class RoundTimeWidget : MonoBehaviour
    {
        [SF] private TMP_Text roundText;

        public void SetRoundTime(int roundTime)
        {
            roundText.text = roundTime.ToFormattedTime();
        }
    }
}
