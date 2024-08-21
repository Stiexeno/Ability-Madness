using System.Collections.Generic;
using AbilityMadness.Code.Gameplay.Enemy;
using AbilityMadness.Code.Gameplay.Enemy.Configs;
using AbilityMadness.Code.Gameplay.Enemy.Waves.Configs;
using AbilityMadness.Code.Gameplay.Upgrades.Configs;
using AbilityMadness.Code.Gameplay.Weapons;
using AbilityMadness.Code.Gameplay.Weapons.Bullets.Configs;
using AbilityMadness.Code.Gameplay.Weapons.Configs;
using AbilityMadness.Code.Infrastructure.Cursors;
using AbilityMadness.Code.Infrastructure.Cursors.Configs;
using AbilityMadness.Code.Infrastructure.Services.WorldBuilder.Configs;
using Cysharp.Threading.Tasks;

namespace AbilityMadness.Code.Infrastructure.Configs
{
	public interface IConfigsService
	{
        UniTask<CursorConfig> GetCursor(CursorType type);
        WorldBuilderConfig GetWorldBuilderConfig(WorldType worldTyp);
        WeaponConfig GetWeaponConfig(WeaponTypeId type);
        BulletConfig GetBulletConfig(BulletTypeId type);
        List<ItemConfig> GetItemConfigs();
        EnemyConfig GetEnemyConfig(EnemyTypeId type);
        WaveConfig[] WaveConfigs { get; }
    }
}
