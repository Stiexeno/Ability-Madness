namespace AbilityMadness.Infrastructure.Services.StateMachine.Implementations
{
	public class ApplicationStateMachine : StateMachine, IApplicationStateMachine
	{
		public ApplicationStateMachine(IStatesFactory statesFactory) : base(statesFactory)
		{
		}

		public override void Initialize()
		{
		}
	}
}