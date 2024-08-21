using System;

namespace AbilityMadness.Code.Infrastructure.Scene
{
	public interface ISceneService
	{
		void Load(string name, Action onLoaded = null);
	}
}