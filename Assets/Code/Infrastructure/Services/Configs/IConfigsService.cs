using AbilityMadness.Code.Gameplay.Weapons;
using AbilityMadness.Code.Gameplay.Weapons.Bullets.Configs;
using AbilityMadness.Code.Gameplay.Weapons.Configs;
using AbilityMadness.Code.Infrastructure.Services.Assembler;
using AbilityMadness.Code.Infrastructure.Services.Cursors;
using AbilityMadness.Code.Infrastructure.Services.WorldBuilder.Configs;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace AbilityMadness.Infrastructure.Services.Configs
{
	public interface IConfigsService
	{
        AttachmentConfig[] AttachmentConfigs { get; }
        UniTask<Texture2D> GetCursor(CursorType type);
        WorldBuilderConfig GetWorldBuilderConfig(WorldType worldTyp);
        WeaponConfig GetWeaponConfig(WeaponTypeId type);
        BulletConfig GetBulletConfig(BulletTypeId type);
    }
}
