using Zenject;

namespace AbilityMadness.Code.Infrastructure.Services.Camera
{
    public class CameraSetter : IInitializable
    {
        public CameraSetter(UnityEngine.Camera camera, CameraProvider cameraProvider)
        {
            cameraProvider.Camera = camera;
        }

        public void Initialize()
        {
        }
    }
}
