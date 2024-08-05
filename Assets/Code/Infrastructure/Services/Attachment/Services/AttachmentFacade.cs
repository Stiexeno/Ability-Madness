using AbilityMadness.Code.Gameplay.UI.Modifier;
using AbilityMadness.Code.Gameplay.UI.Upgrade;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace AbilityMadness.Code.Infrastructure.Services.Assembler
{
    public class AttachmentFacade : IAttachmentService, ITickable
    {
        private bool _isOpen;

        private GridData _gridData;
        private InputAction _openInput;
        private IUIService _uiService;

        private IAttachmentUpgradeService _upgrade;
        private IAttachmentCalculatorService _calculator;
        private IAttachmentGridService _grid;

        public Vector2Int Size => new Vector2Int(_grid.Size.x, _grid.Size.y);

        public AttachmentFacade(
            PlayerInput playerInput,
            IUIService uiService,
            IAttachmentUpgradeService upgrade,
            IAttachmentCalculatorService calculator,
            IAttachmentGridService grid)
        {
            _grid = grid;
            _calculator = calculator;
            _upgrade = upgrade;
            _uiService = uiService;
            _openInput = playerInput.actions[Constants.Input.OpenAssembler];
        }

        public void GiveUpgrades()
        {
            _uiService.Open<AttachmentWindow>();

            var upgradeWindow = _uiService.Get<UpgradeWindow>();
            upgradeWindow.DisplayUpgrades(_calculator.GenerateAttachments()).Forget();

            Time.timeScale = 0;
        }

        public void Tick()
        {
            if (_openInput.triggered)
            {
                GiveUpgrades();
                // if (_isOpen)
                // {
                //     Time.timeScale = 1;
                //     _uiService.Close<AssemblerWindow>();
                //     _isOpen = false;
                // }
                // else
                // {
                //     Time.timeScale = 0;
                //     _uiService.Open<AssemblerWindow>();
                //     _isOpen = true;
                // }
            }
        }
    }

    public class GridData
    {
        public int width;
        public int height;

        public GridData(int width, int height)
        {
            this.width = width;
            this.height = height;
        }
    }

    public class GridItem
    {

    }
}
