using Zenject;

namespace AbilityMadness.Code.Infrastructure.Instantiator
{
	public class InstantiatorSetter : IInitializable
	{
		public InstantiatorSetter(IInstantiator instantiator, InstantiatorProvider instantiatorProvider)
		{
			instantiatorProvider.Instantiator = instantiator;
		}

		public void Initialize()
		{
		}
	}
}
