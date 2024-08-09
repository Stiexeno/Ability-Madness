using UnityEngine;

namespace AbilityMadness.Code.Tools
{
    public class Trail : MonoBehaviour
    {
        private TrailRenderer trailRenderer;

        private void Awake()
        {
            trailRenderer = GetComponent<TrailRenderer>();
        }

        private void OnDisable()
        {
            trailRenderer.Clear();
        }
    }
}
