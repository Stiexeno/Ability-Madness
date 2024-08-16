using TMPro;
using UnityEngine;
using SF = UnityEngine.SerializeField;

namespace AbilityMadness.Code.Tools
{
    public class FPSCounter : MonoBehaviour
    {
        [SF] private TMP_Text fpsText;

        private int _fpsAccumulator = 0;
        private float _fpsNextPeriod = 0;
        private int _currentFps;

        const float FPS_MEASURE_PERIOD = 0.2f;

        // FpsDialog

        private void Update()
        {
            _fpsAccumulator++;

            if (Time.realtimeSinceStartup > _fpsNextPeriod)
            {
                _currentFps = (int)(_fpsAccumulator / FPS_MEASURE_PERIOD);
                _fpsAccumulator = 0;
                _fpsNextPeriod += FPS_MEASURE_PERIOD;
                fpsText.text = $"FPS: {_currentFps}";
            }
        }

        private void Awake()
        {
            _fpsNextPeriod = Time.realtimeSinceStartup + FPS_MEASURE_PERIOD;
        }
    }
}
