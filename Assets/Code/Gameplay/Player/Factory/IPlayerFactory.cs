using UnityEngine;

namespace AbilityMadness.Factory
{
    public interface IPlayerFactory
    {
        GameEntity CreatePlayer(Vector3 position);
    }
}
