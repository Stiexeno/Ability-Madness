using System.IO;
using UnityEditor;
using UnityEngine;

namespace AbilityMadness.Editor.Saves
{
	[InitializeOnLoad]
    public class ToolbarSaves
    {
	    static ToolbarSaves()
	    {
		    ToolbarExtender.RegisterRightEntry(OnToolbarGUI, 0);
	    }

	    private static void OnToolbarGUI()
	    {
		    var cachedGUI = GUI.color;
		    
		    var configPath = Path.Combine("Assets", "Saves");
		    if (!AssetDatabase.IsValidFolder(configPath))
			    GUI.color = new Color(0.53f, 0.53f, 0.53f);
			    
		    var content = new GUIContent(EditorGUIUtility.IconContent("d_TreeEditor.Trash"));
		    var guiContent = new GUIContent( content.image);
		    
		    if (GUILayout.Button(guiContent, EditorStyles.toolbarButton,GUILayout.Width(30.0f)))
		    {
			    var e = Event.current;
			    if (e.button == 1 && e.type == EventType.Used)
			    {
				    ToolbarSavesPopup.Open();
				    e.Use();
				    return;
			    }
			    
			    if (AssetDatabase.IsValidFolder(configPath))
			    {
				    var result = EditorUtility.DisplayDialog("Delete save data",
					    "Are you sure you want to delete all save data?\n\nYou cannot undo the delete assets action", "Delete", "Cancel");

				    if (result)
				    {
					    AssetDatabase.DeleteAsset(configPath);
					    AssetDatabase.Refresh();      
				    }
			    }
		    }

		    GUI.color = cachedGUI;
	    }
    }
}