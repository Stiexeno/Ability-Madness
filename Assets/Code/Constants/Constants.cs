using System.Collections.Generic;
using AbilityMadness.Code.Gameplay.Health;

namespace AbilityMadness
{
    public static class Constants
    {
        public const string Root = "AbilityMadness";

        public static class Scenes
        {
            public const string BootSceneName = "BootScene";
            public const string GameplaySceneName = "GameplayScene";
        }

        public static class Prefabs
        {
            public const string UIRootPath = "Prefabs/UI/UIRoot";
            public const string WorldUIRootPath = "Prefabs/UI/WorldUIRoot";

            public const string WindowLabel = "window";

            public const string ProjectileLabel = "projectile";

            public static class Widgets
            {
                public const string DamageTextWidget = "Prefabs/UI/Widgets/DamageTextWidget";
                public const string HealthbarWidget = "Prefabs/UI/Widgets/HealthbarWidget";
                public const string ReloadWidget = "Prefabs/UI/Widgets/ReloadWidget";
                public const string SmallBulletWidget = "Prefabs/UI/Widgets/SmallBulletWidget";
                public const string BulletWidget = "Prefabs/UI/Widgets/BulletWidget";
                public const string BulletSelectionWidget = "Prefabs/UI/Widgets/BulletSelectionWidget";
                public const string BulletDragWidget = "Prefabs/UI/Widgets/BulletDragWidget";
            }

            public static class Effects
            {
                public const string FireballHitEffect = "Prefabs/Effects/Effect_Fireball_Hit";
                public const string BulletHitEffect = "Prefabs/Projectiles/Bullet/Effect_Bullet_Hit";
            }

            public static class Enemies
            {
                public const string Robot = "Character_Robot";
            }

            public static class Experiences
            {
                public const string Green = "Prefabs/Experience/Experience_Green";
            }
        }

        public static class Input
        {
            public const string Movement = "Movement";
            public const string MousePosition = "MousePosition";
            public const string RightClick = "RightClick";
            public const string Attack = "Attack";
            public const string Dash = "Dash";
            public const string OpenAssembler = "OpenAssembler";
        }

        public static class Configs
        {
            public const string CursorConfig = "CursorConfig";

            public const string AbilityConfigLabel = "config_ability";
            public const string AttachmentConfigLabel = "config_attachment";
            public const string WorldBuilderConfigLabel = "config_world";
            public const string WeaponConfigLabel = "config_weapon";
            public const string BulletConfigLabel = "config_bullet";
            public const string GearConfigLabel = "config_gear";
            public const string EnemyConfigLabel = "config_enemy";

            public const string ShakePlayerHit = "Configs/Shake/Shake_Player_Hit";
            public const string ShakeShoot = "Configs/Shake/Shake_Shoot";
        }

        public static class Layers
        {
            public const int Default = 0;
            public const int Interactable = 6;
            public const int Enemy = 7;
            public const int Player = 8;
            public const int Loot = 9;

            public static readonly Dictionary<Team, int> TeamToLayer = new()
            {
                {Team.Player, Enemy},
                {Team.Enemy, Player}
            };
        }
    }
}
