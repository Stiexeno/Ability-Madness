using AbilityMadness.Infrastructure.Services.Configs;
using UnityEngine;

namespace AbilityMadness.Code.Infrastructure.Services.Cursors
{
    public enum CursorType { Default, Aim, Interact, Talk }

    public class CursorService : ICursorService
    {
        private CursorType _cursorType;

        private IConfigsService _configsService;

        public CursorService(IConfigsService configsService)
        {
            _configsService = configsService;
            SetCursor(CursorType.Default);
        }

        public void SetCursor(CursorType cursorType)
        {
            if (_cursorType == cursorType)
                return;

            _cursorType = cursorType;

            var cursorConfig = _configsService.CursorConfig;
            Texture2D cursor = cursorConfig.GetCursor(cursorType);
            Cursor.SetCursor(cursor, Vector2.one * 16, CursorMode.Auto);
        }
    }
}
