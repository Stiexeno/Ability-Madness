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

            public const string WindowLabel = "window";

            public static class Projectiles
            {
                public const string Fireball = "Prefabs/Projectiles/Projectile_Fireball";
            }

            public static class Effects
            {
                public const string FireballHitEffect = "Prefabs/Effects/Effect_Fireball_Hit";
            }
        }

        public static class Input
        {
            public const string Movement = "Movement";
            public const string Aiming = "Aiming";
            public const string Attack = "Attack";
        }

        public static class Configs
        {
            public const string CursorConfig = "CursorConfig";
        }

        public static class Layers
        {
            public const int Default = 0;
            public const int Interactable = 6;
        }
    }
}
