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

            public static class Widgets
            {
                public const string DamageTextWidget = "Prefabs/UI/Widgets/DamageTextWidget";
                public const string HealthbarWidget = "Prefabs/UI/Widgets/HealthbarWidget";
            }

            public static class Projectiles
            {
                public const string Fireball = "Prefabs/Projectiles/Projectile_Fireball";
                public const string Tornado = "Prefabs/Projectiles/Tornado/Projectile_Tornado";
            }

            public static class Effects
            {
                public const string FireballHitEffect = "Prefabs/Effects/Effect_Fireball_Hit";
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
            public const string Aiming = "Aiming";
            public const string Attack = "Attack";
            public const string Dash = "Dash";
        }

        public static class Configs
        {
            public const string CursorConfig = "CursorConfig";

            public const string AbilityConfigLabel = "config_ability";
        }

        public static class Layers
        {
            public const int Default = 0;
            public const int Interactable = 6;
            public const int Enemy = 7;
            public const int Player = 8;
            public const int Loot = 9;

        }
    }
}
