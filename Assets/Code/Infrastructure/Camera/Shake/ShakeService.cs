using AbilityMadness.Code.Infrastructure.Assets;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace AbilityMadness.Code.Infrastructure.Camera.Shake
{
	public class ShakeService : IShakeService, ILateTickable
	{
		private const float shakeAdditionLerpSpeed = 5;

		// Private fields

		private Vector3 defaultCamPos;

		private readonly ShakeBuilder shakeBuilder = new ShakeBuilder();
        private Transform pivot;
        private IAssets _assets;

        public ShakeService(UnityEngine.Camera camera, IAssets assets)
        {
            _assets = assets;
            pivot = camera.transform.parent;
            defaultCamPos = pivot.localPosition;
        }

        public async UniTaskVoid Shake(string path, float power)
        {
            var config = await _assets.LoadAsync<CameraShakeConfig>(path);
            Shake(config, power, null);
        }

		public void Shake(CameraShakeConfig config, float power, Behaviour activator = null)
		{
			power = config.powerBoostCurve.Evaluate(power);

			var shakeCommand = new ShakeCommand(
				activator,
				config.strength * power,
				config.duration,
				config.vibration,
				config.frequencyCurve,
				config.shakerCurve,
				config.strengthRandomizer * power,
				config.ignoreGlobalCap);

			shakeBuilder.AddCommand(shakeCommand);
		}

		public void Shake(CameraShakeConfig config, Vector3 position, Behaviour activator = null)
		{
			if (config == null)
				return;

			var distance = Vector3.Distance(pivot.position, position);

			Shake(config, distance, activator);
		}

        public void LateTick()
        {
            var shakeAddition = shakeBuilder.Run();
            var localCameraPosition = pivot.localPosition;
            pivot.localPosition =
                Vector3.Lerp(localCameraPosition,
                    defaultCamPos + shakeAddition,
                    Time.deltaTime * shakeAdditionLerpSpeed);
        }
    }
}
