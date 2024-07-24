using Cysharp.Threading.Tasks;

namespace AbilityMadness.Infrastructure.Factories.UI
{
	public interface IUIFactory
	{
		T CreateWindow<T>() where T : Window;
		UniTask CreateUIRoot();
	}
}