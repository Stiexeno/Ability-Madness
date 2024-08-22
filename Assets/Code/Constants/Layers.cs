using System.Collections.Generic;
using AbilityMadness.Code.Gameplay.Health;

namespace AbilityMadness
{
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
