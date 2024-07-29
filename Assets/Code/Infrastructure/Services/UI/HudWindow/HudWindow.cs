using SF = UnityEngine.SerializeField;

namespace AbilityMadness
{
    public class HudWindow : Window
    {
        // Serialized fields

        [SF] private WaterWidget waterWidget;
        [SF] private FoodWidget foodWidget;
        [SF] private HealthWidget healthWidget;

    	// Private fields

    	// Properties

    	//HudWindow

        public void SetFood(float normalizedValue)
        {
            foodWidget.SetValue(normalizedValue);
        }

        public void SetWater(float normalizedValue)
        {
            waterWidget.SetValue(normalizedValue);
        }

        public void SetHealth(float normalizedValue)
        {
            healthWidget.SetValue(normalizedValue);
        }
    }
}
