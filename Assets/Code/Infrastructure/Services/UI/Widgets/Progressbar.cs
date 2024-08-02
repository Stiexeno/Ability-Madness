using UnityEngine;
using UnityEngine.UI;
using SF = UnityEngine.SerializeField;

namespace AbilityMadness
{
    public class Progressbar : MonoBehaviour
    {
        // Serialized fields

        [SF] private Image fill;

        // Private fields

        // Properties

        //Progressbar

        public void SetValue(float normalizedValue)
        {
            fill.fillAmount = normalizedValue;
        }
    }
}
