using System;
using System.Linq;
using AbilityMadness.Code.Infrastructure.View;
using AbilityMadness.Editor;
using Entitas.VisualDebugging.Unity;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace AbilityMadness
{
    [InitializeOnLoad]
    public static class EntityViewLinkHeaderEditor
    {
        private static GameEntity _entity;
        private static GameObject _visualDebugGameObject;

        static EntityViewLinkHeaderEditor()
        {
            UnityEditor.Editor.finishedDefaultHeaderGUI += OnPostHeaderGUI;
            Selection.selectionChanged += OnSelectionChanged;
        }

        private static void OnSelectionChanged()
        {
             _entity = null;
             _visualDebugGameObject = null;
        }

        private static void OnPostHeaderGUI(UnityEditor.Editor obj)
        {
            try
            {
                if (_entity == null)
                {
                    FindTargetEntity(obj);
                }
                else
                {
                    var controlRect = EditorGUILayout.GetControlRect();

                    EditorGUI.LabelField(controlRect.SetWidth(40f).AddX(40), "From");

                    GUI.enabled = false;
                    EditorGUI.ObjectField(controlRect.AddX(80).AddWidth(-80f), _visualDebugGameObject, typeof(GameEntity), true);
                    GUI.enabled = true;
                }
            }
            catch (Exception e)
            {
                // ignored
            }
        }

        private static void FindTargetEntity(UnityEditor.Editor obj)
        {
            var target = obj.target;

            if (target is GameObject gameObject && gameObject.TryGetComponent(out EntityView entityView))
            {
                if (entityView.Entity != null)
                {
                    _entity = entityView.Entity;
                    FindVisualDebugGameObject();
                }
            }
        }

        private static void FindVisualDebugGameObject()
        {
            _visualDebugGameObject = Object.FindObjectsOfType<EntityBehaviour>()
                .Single(e => e.entity == _entity).gameObject;
        }
    }
}
