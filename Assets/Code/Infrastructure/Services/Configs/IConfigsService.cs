using System.Collections.Generic;
using AbilityMadness.Code.Gameplay.Gears.Configs;
using AbilityMadness.Code.Gameplay.Upgrades.Configs;
using AbilityMadness.Code.Gameplay.Weapons;
using AbilityMadness.Code.Gameplay.Weapons.Bullets.Configs;
using AbilityMadness.Code.Gameplay.Weapons.Configs;
using AbilityMadness.Code.Infrastructure.Services.Cursors;
using AbilityMadness.Code.Infrastructure.Services.Cursors.Configs;
using AbilityMadness.Code.Infrastructure.Services.WorldBuilder.Configs;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace AbilityMadness.Infrastructure.Services.Configs
{
	public interface IConfigsService
	{
        UniTask<CursorConfig> GetCursor(CursorType type);
        WorldBuilderConfig GetWorldBuilderConfig(WorldType worldTyp);
        WeaponConfig GetWeaponConfig(WeaponTypeId type);
        BulletConfig GetBulletConfig(BulletTypeId type);
        List<ItemConfig> GetItemConfigs();
    }
}
