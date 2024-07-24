﻿using AbilityMadness.Code.Common.Systems;
using AbilityMadness.Code.Infrastructure.Services.ECS;

namespace AbilityMadness.Code.Common
{
    public class ViewFeature : Feature
    {
        public ViewFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<BindEntityViewFromPathSystem>());

            Add(systemFactory.Create<DisableGameObjectSystem>());
            Add(systemFactory.Create<EnableGameObjectSystem>());

            Add(systemFactory.Create<CleanupDestructedSystem>());
        }
    }
}