namespace AbilityMadness.Infrastructure.Services.Updatable
{
	public interface IUpdateService
	{
		void Add(IUpdatable updatable);
		void Remove(IUpdatable updatable);
	}
}