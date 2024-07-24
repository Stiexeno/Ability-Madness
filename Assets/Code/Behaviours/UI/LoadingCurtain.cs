using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;
using SF = UnityEngine.SerializeField;

namespace Apocalypse
{
	[RequireComponent(typeof(CanvasGroup))]
	public class LoadingCurtain : MonoBehaviour, ILoadingCurtain
	{
		// Serialized fields

		[SF] private TMP_Text loadingText;

		[SF] private string[] tips;

		// Private fields

		private int _tipIndex;
		
		private CanvasGroup _canvasGroup;

		// Properties

		private void Awake()
		{
			_canvasGroup = GetComponent<CanvasGroup>();
		}

		private void OnEnable()
		{
			loadingText.gameObject.SetActive(true);
			_canvasGroup.alpha = 1f;

			StartCoroutine(LoadingCoroutine());
		}

		public void Show()
		{
			gameObject.SetActive(true);
		}

		public void Hide()
		{
			StartCoroutine(HideCoroutine());
		}
		
		private IEnumerator HideCoroutine()
		{
			loadingText.gameObject.SetActive(false);
			
			while (_canvasGroup.alpha > 0f)
			{
				_canvasGroup.alpha -= 0.03f;
				yield return new WaitForSeconds(0.01f);
			}
			
			gameObject.SetActive(false);
		}

		private IEnumerator LoadingCoroutine()
		{
			while (true)
			{
				var tip = GetNextTip();
				var chars = tip.ToCharArray();
				loadingText.text = string.Empty;
				
				for (int i = 0; i < chars.Length; i++)
				{
					loadingText.text += chars[i];
					yield return new WaitForSeconds(0.05f);
				}

				yield return new WaitForSeconds(0.5f);
			}
		}

		private string GetNextTip()
		{
			if (_tipIndex >= tips.Length)
			{
				_tipIndex = 0;
			}

			return tips[_tipIndex++];
		}
	}
}