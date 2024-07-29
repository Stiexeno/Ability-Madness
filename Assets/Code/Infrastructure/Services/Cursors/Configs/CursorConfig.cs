using System;
using UnityEngine;

namespace AbilityMadness.Code.Infrastructure.Services.Cursors.Configs
{
    [CreateAssetMenu(fileName = "CursorConfig", menuName = Constants.Root + "/Cursors/CursorConfig")]
    public class CursorConfig : ScriptableObject
    {
        public CursorIcon[] cursorIcons;

        public Texture2D GetCursor(CursorType cursorType)
        {
            foreach (CursorIcon cursorIcon in cursorIcons)
            {
                if (cursorIcon.type == cursorType)
                {
                    return cursorIcon.texture;
                }
            }

            return null;
        }
    }

    [Serializable]
    public struct CursorIcon
    {
        public CursorType type;
        public Texture2D texture;
    }
}
