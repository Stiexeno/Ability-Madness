using AbilityMadness.Code.Infrastructure.Services.Assembler;
using AbilityMadness.Infrastructure.Factories.UI;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;
using SF = UnityEngine.SerializeField;

namespace AbilityMadness.Code.Gameplay.UI.Modifier
{
    public class AttachmentWindow : Window
    {
        [SF] private Transform content;

        private IUIFactory _uiFactory;
        private IAttachmentService _attachmentService;

        [Inject]
        private void Construct(IUIFactory uiFactory, IAttachmentService attachmentService)
        {
            _attachmentService = attachmentService;
            _uiFactory = uiFactory;

            SetGridSize(attachmentService.Size.x, attachmentService.Size.y).Forget();
        }

        public async UniTaskVoid SetGridSize(int width, int height)
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    var gridWidget = await _uiFactory.CreateGridWidget(content);
                    gridWidget.SetPosition(new Vector2Int(y, x));
                }
            }
        }
    }
}
