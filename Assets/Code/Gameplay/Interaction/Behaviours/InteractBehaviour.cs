using AbilityMadness.Code.Common.Behaviours;
using AbilityMadness.Code.Gameplay.Interaction.Registrars;
using UnityEngine;

namespace AbilityMadness.Code.Gameplay.Interaction.Behaviours
{
    [RequireComponent(typeof(InteractRegistrar))]
    public class InteractBehaviour : EntityComponent
    {
        private SpriteOutline _spriteOutline;

        private void Awake()
        {
            _spriteOutline = GetComponentInChildren<SpriteOutline>();
        }

        public void SetInteracted(bool value)
        {
            if (_spriteOutline != null)
                _spriteOutline.SetEnabled(value);
        }
    }
}
