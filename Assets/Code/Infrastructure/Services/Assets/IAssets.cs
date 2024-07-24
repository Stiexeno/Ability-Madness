using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace AbilityMadness.Infrastructure.Services.Assets
{
	public interface IAssets
	{
		T Instantiate<T>(GameObject prefab) where T : MonoBehaviour;
		T Instantiate<T>(GameObject prefab, Vector3 at, Transform parent = null) where T : MonoBehaviour;
		T Instantiate<T>(GameObject prefab, Vector3 at, Vector3 rotation, Transform parent = null) where T : MonoBehaviour;
		GameObject Instantiate(GameObject prefab, Vector3 at, Vector3 rotation, Transform parent = null);
		UniTask<TAsset> LoadAsync<TAsset>(string key) where TAsset : class;
		UniTask<TAsset[]> LoadAllAsync<TAsset>(List<string> keys) where TAsset : class;
		UniTask<List<string>> GetAssetsListByLabelAsync<TAsset>(string label);
		UniTask<List<string>> GetAssetsListByLabelAsync(string label, Type type = null);
		UniTask<TAsset> LoadAsync<TAsset>(AssetReference assetReference) where TAsset : class;
		UniTask Initialize();
		TAsset Load<TAsset>(string key) where TAsset : class;
		List<string> GetAssetsListByLabel<TAsset>(string label);
		List<string> GetAssetsListByLabel(string label, Type type = null);
		T[] GetAssetsByLabel<T>(string label) where T : class;
		UniTask<T[]> GetAssetsByLabelAsync<T>(string label) where T : class;
	}
}