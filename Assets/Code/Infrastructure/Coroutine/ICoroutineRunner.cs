using System.Collections;

namespace AbilityMadness.Code.Infrastructure.Coroutine
{
	public interface ICoroutineRunner
	{
		UnityEngine.Coroutine StartCoroutine(IEnumerator routine);
		void StopCoroutine(UnityEngine.Coroutine coroutine);
	}
}