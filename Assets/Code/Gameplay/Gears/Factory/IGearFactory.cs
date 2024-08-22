namespace AbilityMadness.Code.Gameplay.Gears.Factory
{
    public interface IGearFactory
    {
        GameEntity CreateGear(GearTypeId type, int producerId, int targetId);
        GameEntity CreateGearRequest(GearTypeId type);
    }
}
