using System;
using AbilityMadness.Code.Gameplay.Modifiers;
using UnityEngine;

namespace AbilityMadness.Code.Infrastructure.Services.Assembler.Common
{
    [Serializable]
    public class Attachment
    {
        public AttachmentTypeId type;
        public ModifierTypeId modifierType;

        public Vector2Int shape;
    }
}
