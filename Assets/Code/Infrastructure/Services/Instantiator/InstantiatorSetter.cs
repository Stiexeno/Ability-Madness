using Zenject;

namespace AbilityMadness.Infrastructure.Services.Instantiator
{
	public class InstantiatorSetter : IInitializable
	{
		public InstantiatorSetter(IInstantiator instantiator, InstantiatorProvider instantiatorProvider)
		{
			instantiatorProvider.instantiator = instantiator;
		}
        
		public void Initialize()
		{
		}
	}
}