﻿using AbilityMadness.Code.Gameplay.Camera.Systems;
using AbilityMadness.Code.Infrastructure.ECS;

namespace AbilityMadness.Code.Gameplay.Camera
{
    public class CameraFreature : Feature
    {
        public CameraFreature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<InitializeCameraSystem>());
            Add(systemFactory.Create<MoveCameraToTargetSystem>());
        }
    }
}
