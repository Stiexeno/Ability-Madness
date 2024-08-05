using UnityEngine;
using SF = UnityEngine.SerializeField;

namespace AbilityMadness.Code.Gameplay.UI.Modifier
{
    public class GridWidget : MonoBehaviour
    {
        private Vector2Int position;

        public void SetPosition(Vector2Int position)
        {
            this.position = position;
        }
    }
}
