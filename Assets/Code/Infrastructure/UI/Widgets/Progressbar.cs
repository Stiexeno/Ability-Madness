using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
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

        private float _normalizedValue = -1f;
        private TweenerCore<float, float, FloatOptions> _tween;

        // Properties

        //Progressbar

        private void OnEnable()
        {
            _tween = null;
            _normalizedValue = -1f;
            fill.fillAmount = 1f;
        }

        private void OnDisable()
        {
            _tween = null;
            _normalizedValue = -1f;
            fill.fillAmount = 1f;
        }

        public void SetProgress(float normalizedValue)
        {
            fill.fillAmount = normalizedValue;
        }

        public void SetProgress(float normalizedValue, float duration, float delay)
        {
            if (Math.Abs(_normalizedValue - normalizedValue) > 0.001f)
            {
                if (_tween != null)
                {
                    _tween.Kill();
                }

                _tween = DOTween.To(() => fill.fillAmount, x => fill.fillAmount = x, normalizedValue, duration).SetDelay(delay);
                _normalizedValue = normalizedValue;
            }
        }
    }
}
