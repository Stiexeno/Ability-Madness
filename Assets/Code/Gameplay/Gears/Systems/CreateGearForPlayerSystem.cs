using AbilityMadness.Code.Gameplay.Gears.Factory;
using Entitas;

namespace AbilityMadness.Code.Gameplay.Gears.Systems
{
    public class CreateGearForPlayerSystem : IExecuteSystem
    {
        private IGearFactory _gearFactory;
        private IGroup<GameEntity> _requests;
        private IGroup<GameEntity> _players;

        public CreateGearForPlayerSystem(GameContext gameContext, IGearFactory gearFactory)
        {
            _gearFactory = gearFactory;

            _requests = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.GearRequest,
                    GameMatcher.GearTypeId));

            _players = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Player,
                    GameMatcher.Id));
        }

        public void Execute()
        {
            foreach (var request in _requests)
            {
                foreach (var player in _players)
                {
                    _gearFactory.CreateGear(request.GearTypeId, player.Id, player.Id);
                    request.isDestructed = true;
                }
            }
        }
    }
}
