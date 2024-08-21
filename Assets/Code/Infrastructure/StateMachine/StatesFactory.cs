using AbilityMadness.Code.Infrastructure.Instantiator;

namespace AbilityMadness.Code.Infrastructure.StateMachine
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
			return _instantiatorProvider.Instantiator.Instantiate<T>();
		}
	}
}