using System;

namespace AbilityMadness
{
	public interface ISceneService
	{
		void Load(string name, Action onLoaded = null);
	}
}