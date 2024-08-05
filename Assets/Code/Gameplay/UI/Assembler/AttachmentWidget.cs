using AbilityMadness.Code.Infrastructure.Services.Assembler;
using UnityEngine;
using UnityEngine.UI;
using SF = UnityEngine.SerializeField;

namespace AbilityMadness.Code.Gameplay.UI.Modifier
{
    public class AttachmentWidget : MonoBehaviour
    {
        [SF] private Image icon;
        [SF] private Image background;

        public void Setup(AttachmentConfig config)
        {
            icon.sprite = config.icon;
            background.sprite = config.blockIcon;
        }
    }
}
