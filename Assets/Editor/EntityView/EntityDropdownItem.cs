using System;
using System.Linq;
using AbilityMadness.Code.Common.Behaviours;
using Apocalypse;
using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

namespace AbilityMadness
{
    public class EntityDropdownItem : AdvancedDropdownItem, IActorDropdown
    {
        private Type componentType;
        private EntityView entityView;

        public EntityDropdownItem(EntityView entityView, Type componentType) : base(componentType.Name)
        {
            this.entityView = entityView;
            this.componentType = componentType;

            icon = EditorGUIUtility.IconContent("cs Script Icon").image as Texture2D;
        }

        public void AddComponent()
        {
            var component = Undo.AddComponent(entityView.gameObject, componentType);

            if (component == null)
                return;

            component.hideFlags = HideFlags.HideInInspector;

            var so = new SerializedObject(component);
            var sp = so.GetIterator();

            sp.isExpanded = true;

            EditorUtility.SetDirty(component);
            AssetDatabase.SaveAssets();
        }

        public override int CompareTo(object o)
        {
            var item = (AdvancedDropdownItem)o;

            var difference = children.Count() - item.children.Count();
            return difference;
        }
    }
}
