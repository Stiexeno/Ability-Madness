using AbilityMadness;
using UnityEngine;

namespace Framework
{
	public static class ToolbarSavesStyle
	{
		public static readonly GUIStyle buttonStyle = new GUIStyle
		{
			alignment = TextAnchor.MiddleLeft,
			padding = new RectOffset(10, 0, 0, 0),
			hover =
			{
				textColor = new Color(0.73f, 0.73f, 0.73f),
				background = EditorHelper.CreateColorTexture(new Color(0.27f, 0.37f, 0.58f, 0.9f))
			},
			normal =
			{
				textColor = new Color(0.73f, 0.73f, 0.73f)
			}
		};
	}
}