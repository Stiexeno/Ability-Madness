using AbilityMadness.Code.Gameplay.Abilities;
using AbilityMadness.Code.Gameplay.Abilities.Configs;
using AbilityMadness.Code.Infrastructure.Services.Assembler;
using AbilityMadness.Code.Infrastructure.Services.Cursors;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace AbilityMadness.Infrastructure.Services.Configs
{
	public interface IConfigsService
	{
        AttachmentConfig[] AttachmentConfigs { get; }
        AbilityConfig GetAbilityConfig(AbilityTypeId type);
        UniTask<Texture2D> GetCursor(CursorType type);
    }
}
