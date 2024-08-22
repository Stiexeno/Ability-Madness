using AbilityMadness.Code.Gameplay.Health;
using UnityEngine;

namespace AbilityMadness.Code.Gameplay.Area.Factory
{
    public interface IAreaFactory
    {
        GameEntity CreateArea(AreaTypeId type, int producerId, Vector3 position, Team team);
    }
}
