using AbilityMadness.Code.Common;
using AbilityMadness.Code.Extensions;
using AbilityMadness.Code.Infrastructure.Services.Camera;
using AbilityMadness.Code.Infrastructure.Services.Identifiers;
using UnityEngine;

namespace AbilityMadness.Code.Gameplay.Camera.Factory
{
    public class CameraFactory : ICameraFactory
    {
        private CameraProvider _cameraProvider;
        private IIdentifierService _identifierService;

        public CameraFactory(CameraProvider cameraProvider, IIdentifierService identifierService)
        {
            _identifierService = identifierService;
            _cameraProvider = cameraProvider;
        }

        public GameEntity CreateCamera()
        {
            var cameraEntity = CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .With(x => x.isCamera = true)
                .With(x => x.isTransformMovement = true)
                .AddFollowTargetId(0)
                .AddTransform(_cameraProvider.Camera.transform)
                .AddCameraOffset(Vector2.zero)
                .AddWorldPosition(Vector3.zero)

                .AddCameraSmooth(0.1f)
                .AddVelocity(Vector3.zero);

            return cameraEntity;
        }
    }
}
