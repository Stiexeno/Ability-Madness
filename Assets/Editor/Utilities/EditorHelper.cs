using System.Linq;
using UnityEditor;
using UnityEngine;

namespace AbilityMadness
{
	public class EditorHelper : MonoBehaviour
	{
		public static GUIContent CreateNamedIcon(string text, string iconId, string toolTip = null)
		{
			var icon = new GUIContent();
			if (string.IsNullOrEmpty(iconId) == false)
			{
				icon = new GUIContent(EditorGUIUtility.IconContent($"{iconId}"));
			}

			return new GUIContent($"{text}", icon.image, $"{toolTip}");
		}

		public static Texture2D CreateColorTexture(Color color)
		{
			var texture = new Texture2D(Screen.width, Screen.height);
			Color[] pixels = Enumerable.Repeat(color, Screen.width * Screen.height).ToArray();
			texture.SetPixels(pixels);
			texture.Apply();
			return texture;
		}
	}
}