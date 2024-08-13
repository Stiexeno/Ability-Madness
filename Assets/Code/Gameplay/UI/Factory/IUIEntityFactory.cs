namespace AbilityMadness.Code.Gameplay.UI.Factory
{
    public interface IUIEntityFactory
    {
        GameEntity CreateHealthbar(GameEntity gameEntity);
        GameEntity CreateReloadWidget(GameEntity gameEntity);
    }
}
