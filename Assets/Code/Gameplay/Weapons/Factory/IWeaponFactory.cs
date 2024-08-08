namespace AbilityMadness.Code.Gameplay.Weapons.Factory
{
    public interface IWeaponFactory
    {
        GameEntity CreateWeapon(GameEntity gameEntity, WeaponTypeId weaponType);
    }
}
