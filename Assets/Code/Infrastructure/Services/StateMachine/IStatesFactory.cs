namespace AbilityMadness.Infrastructure.Services.StateMachine
{
	public interface IStatesFactory
	{
		T Create<T>() where T : IState;
	}
}