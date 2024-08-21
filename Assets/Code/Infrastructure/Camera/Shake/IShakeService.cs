using Cysharp.Threading.Tasks;
using UnityEngine;

namespace AbilityMadness.Code.Infrastructure.Camera.Shake
{
	public interface IShakeService
	{
		public void Shake(CameraShakeConfig config, float power, Behaviour activator = null);
		public void Shake(CameraShakeConfig config, Vector3 position, Behaviour activator = null);
        UniTaskVoid Shake(string path, float power);
    }
}
