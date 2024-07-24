using AbilityMadness.Infrastructure.Services.Instantiator;

namespace AbilityMadness.Infrastructure.Services.StateMachine
{
	public class StatesFactory : IStatesFactory
	{
		private InstantiatorProvider _instantiatorProvider;

		public StatesFactory(InstantiatorProvider instantiatorProvider)
		{
			_instantiatorProvider = instantiatorProvider;
		}

		public T Create<T>() where T : IState
		{
			return _instantiatorProvider.instantiator.Instantiate<T>();
		}
	}
}