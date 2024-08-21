namespace AbilityMadness.Code.Infrastructure.StateMachine.Application
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