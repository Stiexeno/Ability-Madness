using System.IO;
using AbilityMadness;
using AbilityMadness.Editor;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace AbilityMadness
{
	public class ToolbarSavesPopup : EditorWindow
	{
		// Private fields

		private static ToolbarSavesPopup popup;

		private string searchQuery = "";

		private Rect targetRect;
		private Vector2 scrollPosition = Vector2.zero;

		private const int SEARCHBAR_HEIGHT = 25;
		private const int ELEMENT_HEIGH = 25;
		private const int MAX_HEIGHT = 275;

		private const string SAVE_PATH = "Saves";
		private const string SEARCH_PATTERN = "*.json";
		
		// Properties

		public static void Open()
		{
			if (popup != null)
			{
				popup.ForceClose();
			}

			popup = CreateInstance<ToolbarSavesPopup>();
			popup.Init();
		}

		private void Init()
		{
			SetSize(new Vector2(250, 275));

			var dynamicPosition = this.position;
			dynamicPosition.x = GUIUtility.GUIToScreenPoint(Event.current.mousePosition).x; // - (position.width / 2) - 100;
			dynamicPosition.y = GUIUtility.GUIToScreenPoint(Event.current.mousePosition).y;
			this.position = dynamicPosition;

			UpdateSize();
			ShowPopup();
		}

		private void OnGUI()
		{
			if (popup == null)
			{
				Close();
				return;
			}
			
			EditorGUI.DrawRect(new Rect(0, 0, position.width, position.height), new Color(0.1f, 0.1f, 0.1f, 0.9f));
			EditorGUI.DrawRect(new Rect(0, 0, position.width, position.height).Expand(-1), new Color(0.19f, 0.19f, 0.19f, 0.9f));

			DrawSearchbar();
			DrawContent();
			Repaint();
		}

		private void DrawSearchbar()
		{
			var rect = new Rect(1, 1, position.width - 2, SEARCHBAR_HEIGHT);
			EditorGUI.DrawRect(rect, new Color(0.24f, 0.24f, 0.24f));

			GUI.SetNextControlName("SearchField");
			searchQuery = GUI.TextField(new Rect(3, 4, position.width - 6, SEARCHBAR_HEIGHT), searchQuery,
				GUI.skin.FindStyle("ToolbarSearchTextField"));
			EditorGUI.FocusTextInControl("SearchField");
			
			rect.y += rect.height;
			rect.height = 1;
			EditorGUI.DrawRect(rect, new Color(0.16f, 0.16f, 0.16f));
		}

		private void DrawContent()
		{
			string folderPath = Application.dataPath + $"/{SAVE_PATH}";

			if (!Directory.Exists(folderPath))
				return;

			scrollPosition = GUI.BeginScrollView(
				new Rect(0, SEARCHBAR_HEIGHT,
					position.width,
					position.height - SEARCHBAR_HEIGHT),
				scrollPosition,
				new Rect(0, 0, position.width - 20, ELEMENT_HEIGH * Directory.GetFiles(folderPath, SEARCH_PATTERN).Length));

			var configPath = Path.Combine("Assets", SAVE_PATH);

			var buttonRect = new Rect(1, 0, position.width - 2, ELEMENT_HEIGH);
			string[] filePaths = Directory.GetFiles(folderPath, SEARCH_PATTERN);

			for (var i = 0; i < filePaths.Length; i++)
			{
				string path = filePaths[i];
				string fileName = Path.GetFileNameWithoutExtension(path);

				if (searchQuery != "" && fileName.ToLower().Contains(searchQuery.ToLower()) == false)
					continue;

				DrawHorizontalLine(buttonRect);
				var assetPath = "Assets" + path.Substring(Application.dataPath.Length);

				if (GUI.Button(buttonRect.SetWidth(25f).AddX(buttonRect.width - 30), "", GUIStyle.none))
				{
					var asset = AssetDatabase.LoadAssetAtPath<Object>(assetPath);
					AssetDatabase.OpenAsset(asset);
					Event.current.Use();
				}

				if (GUI.Button(buttonRect, new GUIContent($"{fileName}"), ToolbarSavesStyle.buttonStyle))
				{
					if (AssetDatabase.IsValidFolder(configPath))
					{
						var result = EditorUtility.DisplayDialog("Delete save data",
							$"Are you sure you want to delete {fileName} save data?\n\nYou cannot undo the delete assets action", "Delete", "Cancel");

						if (result)
						{
							AssetDatabase.DeleteAsset(assetPath);
							AssetDatabase.Refresh();

							string[] paths = Directory.GetFiles(folderPath, SEARCH_PATTERN);
							if (paths.Length == 0)
							{
								AssetDatabase.DeleteAsset(configPath);
								AssetDatabase.Refresh();
							}

							UpdateSize();
							ForceClose();
						}
						else
						{
							Focus();
						}
					}
				}

				EditorGUI.LabelField(buttonRect.SetWidth(25f).AddX(buttonRect.width - 30), EditorHelper.CreateNamedIcon("", "editicon.sml"));
				EditorGUI.LabelField(buttonRect.SetWidth(25f).AddX(buttonRect.width - 50), EditorHelper.CreateNamedIcon("", "d_TreeEditor.Trash"));

				buttonRect.y += 25f;
			}

			GUI.EndScrollView();
		}
		
		private void UpdateSize()
		{
			string folderPath = Application.dataPath + $"/{SAVE_PATH}";

			if (!Directory.Exists(folderPath))
				return;
			
			var length = Directory.GetFiles(folderPath, SEARCH_PATTERN).Length;
			var dynamicPosition = position;
			dynamicPosition.height = Mathf.Clamp(SEARCHBAR_HEIGHT + (ELEMENT_HEIGH * length), 0, MAX_HEIGHT);
			position = dynamicPosition;
		}

		private void SetSize(Vector2 size)
		{
			minSize = size;
			maxSize = size;

			var targetPosition = position;
			targetPosition.width = size.x;
			targetPosition.height = size.y;
			position = targetPosition;
		}

		private void OnLostFocus()
		{
			if (popup != null)
			{
				ForceClose();
			}
		}

		private void ForceClose()
		{
			Close();
			DestroyImmediate(popup);
			popup = null;
		}

		private void DrawHorizontalLine(Rect rect)
		{
			rect.y += rect.height - 1;
			rect.height = 1;
			rect.x += 5;
			rect.width -= 10;

			EditorGUI.DrawRect(rect, new Color(0.16f, 0.16f, 0.16f));
			EditorGUI.DrawRect(rect.AddY(1), new Color(0.24f, 0.24f, 0.24f));
		}
	}
}