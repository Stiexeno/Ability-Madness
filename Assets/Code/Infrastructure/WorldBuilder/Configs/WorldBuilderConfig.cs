using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Tilemaps;

namespace AbilityMadness.Code.Infrastructure.WorldBuilder.Configs
{
    [CreateAssetMenu(fileName = nameof(WorldBuilderConfig), menuName = Constants.Root + "/Configs/WorldBuilderConfig")]
    public class WorldBuilderConfig : ScriptableObject
    {
        public WorldType worldType;

        public int width;
        public int height;

        public float scale;
        public int octaves;

        public TileScheme[] tiles;
    }

    [Serializable]
    public struct TileScheme
    {
        public float value;
        public AssetReferenceT<TileBase> tileRef;
    }
}
