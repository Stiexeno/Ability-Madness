using System.Collections.Generic;
using AbilityMadness.Code.Infrastructure.Assets;
using AbilityMadness.Code.Infrastructure.Services.WorldBuilder.Configs;
using AbilityMadness.Infrastructure.Services.Configs;
using Cysharp.Threading.Tasks;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace AbilityMadness.Code.Infrastructure.Services.WorldBuilder.Services
{
    public class WorldBuilderService : IWorldBuilderService
    {
        private Dictionary<TileBase, float> _tiles = new();

        private Tilemap[] _tilemaps;
        private IConfigsService _configsService;
        private IAssets _assets;
        private WorldBuilderConfig _config;

        public WorldBuilderService(Tilemap[] tilemaps, IConfigsService configsService, IAssets assets)
        {
            _assets = assets;
            _configsService = configsService;
            _tilemaps = tilemaps;
        }

        public async UniTask Generate(WorldType worldType)
        {
            _config = _configsService.GetWorldBuilderConfig(worldType);
            await LoadTiles();
            GenerateTiles();
        }

        private void GenerateTiles()
        {
            Vector2 origin = Vector2.zero;

            for (int x = 0; x < _config.width; x++)
            {
                for (int y = 0; y < _config.height; y++)
                {
                    float noiseValue = Noisefunction(x, y, origin);
                    var tile = GetTileByValue(noiseValue);

                    var tilePosition = new Vector3Int(x - Mathf.RoundToInt(_config.width / 2f), y - Mathf.RoundToInt(_config.height / 2f), 0);
                    _tilemaps[0].SetTile(tilePosition, tile);
                }
            }
        }

        private async UniTask LoadTiles()
        {
            foreach (var tileData in _config.tiles)
            {
                var tile = await _assets.LoadAsync<TileBase>(tileData.tileRef);
                _tiles.Add(tile, tileData.value);
            }
        }

        private TileBase GetTileByValue(float value)
        {
            foreach (var tileData in _tiles)
            {
                if (value < tileData.Value)
                {
                    return tileData.Key;
                }
            }

            return null;
        }

        private float Noisefunction(float x, float y, Vector2 Origin)
        {
            var size = _config.width * _config.height;

            var a = 0f;
            var noisesize = _config.scale;
            var opacity = 1f;

            for (int octaves = 0; octaves < _config.octaves; octaves++)
            {
                float xVal = (x / (noisesize * size)) + Origin.x;
                float yVal = (y / (noisesize * size)) - Origin.y;
                float z = noise.snoise(new float2(xVal, yVal));
                a += Mathf.InverseLerp(0, 1, z) / opacity;

                noisesize /= 2f;
                opacity *= 2f;
            }

            return a;
        }
    }
}
