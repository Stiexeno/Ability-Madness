using AbilityMadness.Infrastructure.Services.Configs;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace AbilityMadness.Code.Infrastructure.Services.Cursors
{
    public enum CursorType { Unknown, Default, Aim, Interact, Talk }

    public class CursorService : ICursorService
    {
        private CursorType _cursorType = CursorType.Unknown;

        private IConfigsService _configsService;

        public CursorService(IConfigsService configsService)
        {
            _configsService = configsService;
            SetCursor(CursorType.Default).Forget();
        }

        public async UniTaskVoid SetCursor(CursorType cursorType)
        {
            if (_cursorType == cursorType)
                return;

            _cursorType = cursorType;

            var cursorTexture = await _configsService.GetCursor(cursorType);
            Cursor.SetCursor(cursorTexture, Vector2.one * 16, CursorMode.Auto);
        }
    }
}
