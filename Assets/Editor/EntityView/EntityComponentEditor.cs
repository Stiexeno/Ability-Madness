using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AbilityMadness.Code.Common.Behaviours;
using AbilityMadness.Code.Infrastructure.View;
using AbilityMadness.Editor.Utilities;
using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

namespace AbilityMadness.Editor.Actors
{
	public class EntityComponentEditor
	{
		private static Lazy<EditorSkin> _skin = new Lazy<EditorSkin>(() => new EditorSkin());
		private static EditorSkin skin => _skin.Value;

		private EntityComponent[] components = Array.Empty<EntityComponent>();

		private EntityView actorView;
		private EntityEditor editor;

		private List<SerializedObject> serializedObjects = new();
		private UnityEditor.Editor[] editors = Array.Empty<UnityEditor.Editor>();

		private static Assembly[] assemblies;
		private static HashSet<Type> componentTypes;

		public EntityComponentEditor(EntityEditor editor, EntityView actorView)
		{
			this.editor = editor;
			this.actorView = actorView;

			//GatherComponents();
			Validate();
		}

		private void GatherComponents()
		{
			if (assemblies == null)
			{
				assemblies = AppDomain.CurrentDomain.GetAssemblies();
				componentTypes = new HashSet<Type>();

				foreach (var assembly in assemblies)
				{
					foreach (var type in assembly.GetTypes())
					{
						if (!type.IsAbstract &&
						    type.IsSubclassOf(typeof(EntityComponent)) &&
						    type.GetCustomAttribute<ObsoleteAttribute>() == null)
						{
							componentTypes.Add(type);
						}
					}
				}
			}
		}

		private void AddComponent(Type type)
		{
			var component = Undo.AddComponent(actorView.gameObject, type);
			component.hideFlags = HideFlags.HideInInspector;

			var so = new SerializedObject(component);
			var sp = so.GetIterator();

			sp.isExpanded = true;

			EditorUtility.SetDirty(actorView);

			Validate();
			editor.Repaint();
		}

		public void Repaint()
		{
			editor.Repaint();
		}

		public void Validate()
		{
			components = actorView.GetComponents<EntityComponent>();

			// Sort components by alphabet
			//components.Sort((x, y) => String.Compare(x.GetType().Name.Replace("Actor", ""), y.GetType().Name.Replace("Actor", ""), StringComparison.Ordinal));

			editors = components
				.Select(x => editor.CreateEditor(x))
				.ToArray();
		}

		public void OnInspectorGUI()
		{
			GUILayout.Space(5);

			using (new EditorGUILayout.VerticalScope(GUI.skin.box))
			{
				var characterComponents = components;
				{
					var labelRect = EditorGUILayout.GetControlRect(true);
					var buttonRect = labelRect.SetWidth(skin.buttonWidth);
					EditorGUI.LabelField(buttonRect.AddX(skin.buttonWidth + 3).SetWidth(200), "Actor Components", EditorStyles.boldLabel);

					if (GUI.Button(buttonRect, "+", EditorStyles.miniButton))
					{
						GatherComponents();

						var existingComponentPrototypes = characterComponents
							.Select(x => x.GetType())
							.ToList();

						var availableComponents = componentTypes
							.Where(x => !existingComponentPrototypes.Contains(x))
							.ToList();

						var actorDropdown = new EntityDropdown(new AdvancedDropdownState(), actorView, this, availableComponents);
						actorDropdown.Show(buttonRect, 300, 230);
					}
				}

				using (new EditorGUI.IndentLevelScope())
				{
					for (var i = 0; i < characterComponents.Length; i++)
					{
						var c = characterComponents[i];
						if (c == null)
						{
							Validate();
							return;
						}

						var so = GetOrCreateSerializedObject(c);
						var sp = so.GetIterator();
						var rect = GUILayoutUtility.GetRect(GUIContent.none, skin.inspectorTitlebar);
						sp.isExpanded = EditorGUI.InspectorTitlebar(rect, sp.isExpanded, c, true);
						Rect textRect = new Rect(rect.x + 35, rect.y, rect.width - 100, rect.height);

						if (Event.current.type == EventType.Repaint)
						{
							if (c.hideFlags != HideFlags.HideInInspector)
							{
								c.hideFlags = HideFlags.HideInInspector;
							}

							using (new ColorScope(skin.inspectorTitlebarBackground))
							{
								var texRect = textRect;
								texRect.y += 2;
								texRect.height -= 2;
								GUI.DrawTextureWithTexCoords(texRect, Texture2D.whiteTexture, new Rect(0.5f, 0.5f, 0.0f, 0.0f), false);
							}

							skin.inspectorTitlebar.Draw(textRect, $"{c.GetType().Name.Replace("Actor", "")}", false, false, false, false);
						}

						if (sp.isExpanded)
						{
							editors[i].OnInspectorGUI();
						}
					}
				}
			}
		}

		private SerializedObject GetOrCreateSerializedObject(EntityComponent component)
		{
			for (var i = 0; i < serializedObjects.Count; i++)
			{
				if (serializedObjects[i].targetObject == component)
				{
					return serializedObjects[i];
				}
			}

			var so = new SerializedObject(component);
			serializedObjects.Add(so);

			return so;
		}

		public void OnDestroy()
		{
			if (actorView != null)
				return;

			for (int i = components.Length - 1; i >= 0; i--)
			{
				var component = components[i];
				if (component == null)
					continue;

				Undo.DestroyObjectImmediate(component);
			}
		}
	}
}
