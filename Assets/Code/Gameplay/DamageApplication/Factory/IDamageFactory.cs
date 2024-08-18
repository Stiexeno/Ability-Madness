namespace AbilityMadness.Code.Gameplay.DamageApplication.Factory
{
    public interface IDamageFactory
    {
        GameEntity CreateDamageRequest(int producerId, int targetId, int damage);
        GameEntity CreateDamageReceived(int producerId, int targetId, int damage);
        GameEntity CreateDamageDealt(int producerId, int targetId, int damage);
    }
}
