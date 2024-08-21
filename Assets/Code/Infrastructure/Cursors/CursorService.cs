using AbilityMadness.Code.Infrastructure.Configs;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace AbilityMadness.Code.Infrastructure.Cursors
{
    public enum CursorType { Unknown, Default, Select, Interact, Talk }

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

            var cursorConfig = await _configsService.GetCursor(cursorType);
            var cursor = cursorConfig.GetCursor(cursorType);
            Cursor.SetCursor(cursor.texture, cursor.center, CursorMode.Auto);
        }
    }
}
