using System;
using System.Collections.Generic;
using System.Reflection;
using AbilityMadness.Code.Common.Behaviours;
using AbilityMadness.Editor.Actors;
using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

namespace AbilityMadness
{
	public class EntityDropdown : AdvancedDropdown
	{
		private List<Type> componentsType;

		private AdvancedDropdownState state = new AdvancedDropdownState();
		private EntityView actorView;
		private EntityComponentEditor editor;

		public EntityDropdown(AdvancedDropdownState state, EntityView actorView, EntityComponentEditor editor, List<Type> componentsType) : base(state)
		{
			this.editor = editor;
			this.actorView = actorView;
			this.componentsType = componentsType;
		}

		// protected override AdvancedDropdownItem BuildRoot()
		// {
		// 	var root = new AdvancedDropdownItem("Actor Components");
		//
		// 	var firstHalf = new AdvancedDropdownItem("First half");
		// 	var secondHalf = new AdvancedDropdownItem("Second half");
		// 	var weekend = new AdvancedDropdownItem("Weekend");
		//
		// 	firstHalf.AddChild(new AdvancedDropdownItem("Monday"));
		// 	firstHalf.AddChild(new AdvancedDropdownItem("Tuesday"));
		// 	secondHalf.AddChild(new AdvancedDropdownItem("Wednesday"));
		// 	secondHalf.AddChild(new AdvancedDropdownItem("Thursday"));
		// 	weekend.AddChild(new AdvancedDropdownItem("Friday"));
		// 	weekend.AddChild(new AdvancedDropdownItem("Saturday"));
		// 	weekend.AddChild(new AdvancedDropdownItem("Sunday"));
		//
		// 	root.AddChild(firstHalf);
		// 	root.AddChild(secondHalf);
		// 	root.AddChild(weekend);
		//
		// 	return root;
		// }

		protected override AdvancedDropdownItem BuildRoot()
		{
			var root = new EntityRootDropdownItem("Actor Components");

			foreach (var componenType in componentsType)
			{
				var targetRoot = GetOrCreateSubFolder(ref root, componenType);

				targetRoot.AddChild(new EntityDropdownItem(actorView, componenType));
			}

			return root;
		}

		protected override void ItemSelected(AdvancedDropdownItem item)
		{
			if (item is IActorDropdown actorDropdownItem)
			{
				actorDropdownItem.AddComponent();

				EditorUtility.SetDirty(actorView);

				editor.Validate();
				editor.Repaint();
			}
		}

		private AdvancedDropdownItem GetOrCreateSubFolder(ref EntityRootDropdownItem root, Type componentType)
		{
			var tagAttribute = componentType.GetCustomAttribute<EntityTag>();

			if (tagAttribute == null)
				return root;

			foreach (var child in root.children)
			{
				if (child.name == tagAttribute.tag)
					return child;
			}

			var newChild = new EntityRootDropdownItem(tagAttribute.tag);
			root.AddChild(newChild);

			return newChild;
		}
	}

	public static class AdvancedDropdownExtensions
	{
		public static void Show(this AdvancedDropdown dropdown, Rect buttonRect, float maxHeight, float width)
		{
			dropdown.Show(buttonRect);
			SetMaxHeightForOpenedPopup(buttonRect, maxHeight, width);
		}

		private static void SetMaxHeightForOpenedPopup(Rect buttonRect, float maxHeight, float width)
		{
			var window = EditorWindow.focusedWindow;

			if(window == null)
			{
				Debug.LogWarning("EditorWindow.focusedWindow was null.");
				return;
			}

			if(!string.Equals(window.GetType().Namespace, typeof(AdvancedDropdown).Namespace))
			{
				Debug.LogWarning("EditorWindow.focusedWindow " + EditorWindow.focusedWindow.GetType().FullName + " was not in expected namespace.");
				return;
			}

			var position = window.position;
			position.width = width;

			position.height = maxHeight;

			window.minSize = position.size;
			window.maxSize = position.size;
			window.position = position;

			window.ShowAsDropDown(GUIUtility.GUIToScreenRect(buttonRect), position.size);
		}
	}
}
