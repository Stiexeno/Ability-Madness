using UnityEngine;
using UnityEngine.UI;
using SF = UnityEngine.SerializeField;

namespace AbilityMadness
{
    public class FoodWidget : MonoBehaviour
    {
        [SF] private Image fill;

        public void SetValue(float normalizedValue)
        {
            fill.fillAmount = normalizedValue;
        }
    }
}
