using AbilityMadness.Code.Gameplay.Abilities;
using AbilityMadness.Code.Gameplay.Modifiers;
using AbilityMadness.Code.Infrastructure.Services.Assembler.Common;
using UnityEditor;
using UnityEngine;

namespace AbilityMadness.Code.Infrastructure.Services.Assembler.Editor
{
    [CustomEditor(typeof(AttachmentConfig)), CanEditMultipleObjects]
    public class AttachmentConfigEditor : UnityEditor.Editor
    {
        private AttachmentConfig _config;

        private const int SIZE = 3;

        private void OnEnable()
        {
            _config = (AttachmentConfig)target;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            DrawType();

            var initialBackgroundColor = GUI.backgroundColor;

            GUILayout.Space(10);

            var shape = new Array2DBool(SIZE);

            CopyShape(_config, to: shape);

            DrawBoolGrid(shape, initialBackgroundColor);
        }

        private void DrawType()
        {
            using (var check = new EditorGUI.ChangeCheckScope())
            {
                _config.type = (AttachmentTypeId)EditorGUILayout.EnumPopup("Type", _config.type);

                switch (_config.type)
                {
                    case AttachmentTypeId.Unknown:
                        break;
                    case AttachmentTypeId.Ability:
                        _config.abilityType = (AbilityTypeId)EditorGUILayout.EnumPopup("Ability Type", _config.abilityType);
                        break;
                    case AttachmentTypeId.Modifier:
                        _config.modifierType = (ModifierTypeId)EditorGUILayout.EnumPopup("Modifier Type", _config.modifierType);
                        break;
                }

                if (check.changed)
                {
                    EditorUtility.SetDirty(target);
                }
            }
        }

        private void DrawBoolGrid(Array2DBool shape, Color initialBackgroundColor)
        {
            EditorGUILayout.BeginHorizontal(GetTableStyle());
            for (var x = 0; x < shape.GridSize; x++)
            {
                EditorGUILayout.BeginVertical(GetColumnStyle());
                for (var z = 0; z < shape.GridSize; z++)
                {
                    if (x >= 0 && z >= 0)
                    {
                        EditorGUILayout.BeginHorizontal(GetRowStyle());

                        GUI.backgroundColor = shape[x, z] ? Color.green : Color.black;

                        if (GUILayout.Button(" "))
                        {
                            shape[x, z] = !shape[x, z];
                            _config.shape = shape;
                            EditorUtility.SetDirty(target);
                        }

                        GUI.backgroundColor = initialBackgroundColor;

                        EditorGUILayout.EndHorizontal();
                    }
                }

                EditorGUILayout.EndVertical();
            }

            EditorGUILayout.EndHorizontal();
        }

        private static void CopyShape(AttachmentConfig attachmentConfig, Array2DBool to)
        {
            if (attachmentConfig.shape == null || attachmentConfig.shape.Cells == null)
            {
                attachmentConfig.shape = new Array2DBool(SIZE);
            }

            for (var x = 0; x < attachmentConfig.shape.GridSize; x++)
            for (var z = 0; z < attachmentConfig.shape.GridSize; z++)
            {
                to.SetCell(x, z, attachmentConfig.shape.GetCell(x, z));
            }
        }

        private GUIStyle GetRowStyle()
        {
            GUIStyle rowStyle = new GUIStyle();
            rowStyle.fixedHeight = 25;

            return rowStyle;
        }

        private GUIStyle GetColumnStyle()
        {
            GUIStyle columnStyle = new GUIStyle();
            columnStyle.fixedWidth = 25;

            return columnStyle;
        }

        private GUIStyle GetTableStyle()
        {
            var tableStyle = new GUIStyle("box");
            tableStyle.padding = new RectOffset(10, 10, 10, 10);
            tableStyle.margin.left = 25;

            return tableStyle;
        }
    }
}
