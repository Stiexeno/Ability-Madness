using AbilityMadness.Code.Gameplay.Abilities;
using AbilityMadness.Code.Gameplay.Modifiers;
using AbilityMadness.Code.Infrastructure.Services.Assembler.Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace AbilityMadness.Code.Infrastructure.Services.Assembler
{
    [CreateAssetMenu(fileName = nameof(AttachmentConfig), menuName = Constants.Root + "/Assembler/AttachmentConfig")]
    public class AttachmentConfig : ScriptableObject
    {
        [HideInInspector] public Array2DBool shape;
        [HideInInspector] public AttachmentTypeId type;

        [HideInInspector] public AbilityTypeId abilityType;
        [HideInInspector] public ModifierTypeId modifierType;

        public Sprite icon;
        public Sprite blockIcon;

        // public Attachment CreateAttachment()
        // {
        //     var attachment = new Attachment
        //     {
        //         type = type,
        //         abilityType = abilityType,
        //         modifierType = modifierType,
        //         shape = shape
        //     };
        // }
        //
        // private Vector2Int[] CreateShape()
        // {
        //
        // }

        [ContextMenu("Test")]
        public void Test()
        {
            foreach (var shap in shape.GetShape())
            {
                Debug.LogError(shap);
            }
        }
    }
}
