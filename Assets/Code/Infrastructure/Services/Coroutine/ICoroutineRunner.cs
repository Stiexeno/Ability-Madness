using System.Collections;

namespace AbilityMadness.Infrastructure.Services
{
	public interface ICoroutineRunner
	{
		UnityEngine.Coroutine StartCoroutine(IEnumerator routine);
		void StopCoroutine(UnityEngine.Coroutine coroutine);
	}
}