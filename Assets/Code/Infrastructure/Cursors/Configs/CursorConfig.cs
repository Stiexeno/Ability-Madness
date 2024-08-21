using System;
using UnityEngine;

namespace AbilityMadness.Code.Infrastructure.Cursors.Configs
{
    [CreateAssetMenu(fileName = "CursorConfig", menuName = Constants.Root + "/Cursors/CursorConfig")]
    public class CursorConfig : ScriptableObject
    {
        public CursorIcon[] cursorIcons;

        public CursorIcon GetCursor(CursorType cursorType)
        {
            foreach (CursorIcon cursorIcon in cursorIcons)
            {
                if (cursorIcon.type == cursorType)
                {
                    return cursorIcon;
                }
            }

            Debug.LogError($"CursorIcon with type {cursorType} not found");
            return default;
        }
    }

    [Serializable]
    public struct CursorIcon
    {
        public CursorType type;
        public Texture2D texture;
        public Vector2 center;
    }
}
