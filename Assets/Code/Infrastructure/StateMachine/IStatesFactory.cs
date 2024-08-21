namespace AbilityMadness.Code.Infrastructure.StateMachine
{
	public interface IStatesFactory
	{
		T Create<T>() where T : IState;
	}
}