namespace AbilityMadness.Infrastructure.UI
{
	public interface IUIService
	{
		T Get<T>() where T :Window;
		void Open<T>() where T : Window;
		void Close<T>() where T : Window;
	}
}
