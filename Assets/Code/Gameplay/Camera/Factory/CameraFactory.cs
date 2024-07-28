using AbilityMadness.Code.Common;
using AbilityMadness.Code.Common.Behaviours;
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
            var cameraEntityView = _cameraProvider.Camera.GetComponent<EntityView>();

            var cameraEntity = CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .With(x => x.isCamera = true)
                .With(x => x.isTransformMovement = true)
                .AddFollowTargetId(0)
                .AddCameraOffset(Vector2.zero)
                .AddWorldPosition(Vector3.zero)

                .AddCameraSmooth(0.1f)
                .AddCameraVelocity(Vector3.zero);

            cameraEntityView.LinkEntity(cameraEntity);
            return cameraEntity;
        }
    }
}
