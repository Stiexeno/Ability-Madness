using System.Collections.Generic;
using Zenject;

namespace AbilityMadness.Infrastructure.Services.Updatable
{
	public class UpdateService : IUpdateService, ITickable
	{
		private readonly List<IUpdatable> updatables;
        
		public bool IsActive { get; set; }

		public UpdateService(IEnumerable<IUpdatable> bindedUpdatables)
		{
			updatables = new List<IUpdatable>(bindedUpdatables);
			IsActive = true;
		}

		public void Add(IUpdatable updatable)
		{
			updatables.Add(updatable);
		}

		public void Remove(IUpdatable updatable)
		{
			if (updatables.Contains(updatable))
			{
				updatables.Remove(updatable);
			}
		}

		public void Tick()
		{
			if(!IsActive) return;

			int updatableCount = updatables.Count;
            
			for (int i = 0; i < updatableCount; i++)
			{
				var updatable = updatables[i];

				if (updatable == null)
				{
					updatables.RemoveAt(i);
					updatableCount--;
					i--;
                    
					continue;
				}
                
				updatable.Tick();       
			}
		}
	}
}