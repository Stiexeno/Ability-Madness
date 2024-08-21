namespace AbilityMadness.Code.Infrastructure.Updatable
{
	public interface IUpdateService
	{
		void Add(IUpdatable updatable);
		void Remove(IUpdatable updatable);
	}
}