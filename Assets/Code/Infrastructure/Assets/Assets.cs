using System;
using System.Collections.Generic;
using AbilityMadness.Code.Infrastructure.Instantiator;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;

namespace AbilityMadness.Code.Infrastructure.Assets
{
	public class Assets : IAssets, IDisposable
	{
		private readonly InstantiatorProvider _instantiatorProvider;
		private readonly Dictionary<string, AsyncOperationHandle> _assetRequests = new();

		public Assets(InstantiatorProvider instantiatorProvider)
		{
			this._instantiatorProvider = instantiatorProvider;
		}

		public void Dispose()
		{
			CleanUp();
		}

		#region Addressables

		public async UniTask Initialize()
		{
			await Addressables.InitializeAsync().ToUniTask();
			Debug.Log($"{nameof(Addressables)} initialized");
		}

		public TAsset Load<TAsset>(string key) where TAsset : class
		{
			if (_assetRequests.TryGetValue(key, out AsyncOperationHandle handle) == false)
			{
				handle = Addressables.LoadAssetAsync<TAsset>(key);
				_assetRequests.Add(key, handle);
			}

			var result = handle.WaitForCompletion();

			return result as TAsset;
		}

		public async UniTask<TAsset> LoadAsync<TAsset>(string key) where TAsset : class
		{
			if (_assetRequests.TryGetValue(key, out AsyncOperationHandle handle) == false)
			{
				handle = Addressables.LoadAssetAsync<TAsset>(key);
				_assetRequests.Add(key, handle);
			}

			await handle.ToUniTask();

			return handle.Result as TAsset;
		}

		public async UniTask<TAsset> LoadAsync<TAsset>(AssetReference assetReference) where TAsset : class
		{
			string key = assetReference.AssetGUID;
			return await LoadAsync<TAsset>(key);
		}

		public async UniTask<TAsset[]> LoadAllAsync<TAsset>(List<string> keys) where TAsset : class
		{
			var tasks = new List<UniTask<TAsset>>(keys.Count);

			foreach (string key in keys)
				tasks.Add(LoadAsync<TAsset>(key));

			return await UniTask.WhenAll(tasks);
		}

		public List<string> GetAssetsListByLabel<TAsset>(string label)
		{
			return GetAssetsListByLabel(label, typeof(TAsset));
		}

		public List<string> GetAssetsListByLabel(string label, Type type = null)
		{
			AsyncOperationHandle<IList<IResourceLocation>> operationHandle = Addressables.LoadResourceLocationsAsync(label, type);

			IList<IResourceLocation> locations = operationHandle.WaitForCompletion();

			var assetKeys = new List<string>(locations.Count);

			foreach (IResourceLocation location in locations)
				assetKeys.Add(location.PrimaryKey);

			Addressables.Release(operationHandle);
			return assetKeys;
		}

		public T[] GetAssetsByLabel<T>(string label) where T : class
		{
			var assetKeys = GetAssetsListByLabel(label);

			var result = new T[assetKeys.Count];

			for (var i = 0; i < assetKeys.Count; i++)
			{
				var assetKey = assetKeys[i];
				var asset = Load<T>(assetKey);
				result[i] = asset;
			}

			return result;
		}

		public async UniTask<T[]> GetAssetsByLabelAsync<T>(string label) where T : class
		{
			var assetKeys = await GetAssetsListByLabelAsync(label);

			var result = new T[assetKeys.Count];

			for (var i = 0; i < assetKeys.Count; i++)
			{
				var assetKey = assetKeys[i];
				var asset = await LoadAsync<T>(assetKey);
				result[i] = asset;
			}

			return result;
		}

		public async UniTask<List<string>> GetAssetsListByLabelAsync<TAsset>(string label)
		{
			return await GetAssetsListByLabelAsync(label, typeof(TAsset));
		}

		public async UniTask<List<string>> GetAssetsListByLabelAsync(string label, Type type = null)
		{
			AsyncOperationHandle<IList<IResourceLocation>> operationHandle = Addressables.LoadResourceLocationsAsync(label, type);

			IList<IResourceLocation> locations = await operationHandle.Task;

			var assetKeys = new List<string>(locations.Count);

			foreach (IResourceLocation location in locations)
				assetKeys.Add(location.PrimaryKey);

			Addressables.Release(operationHandle);
			return assetKeys;
		}

		public void CleanUp()
		{
			foreach (var assetRequest in _assetRequests)
			{
				Addressables.Release(assetRequest.Value);
			}

			_assetRequests.Clear();
		}

		#endregion

		#region Instantiation

		public T Instantiate<T>(GameObject prefab, Vector3 at, Transform parent = null) where T : MonoBehaviour
		{
			var instantiated = _instantiatorProvider.Instantiator.InstantiatePrefabForComponent<T>(prefab, parent);
			instantiated.name = instantiated.name.Replace("(Clone)", string.Empty);
			var transform = instantiated.transform;
			transform.position = at;
			transform.rotation = Quaternion.identity;
			return instantiated;
		}

		public T Instantiate<T>(GameObject prefab, Vector3 at, Vector3 rotation, Transform parent = null) where T : MonoBehaviour
		{
			var instantiated = Instantiate<T>(prefab, at, parent);
			instantiated.transform.rotation = Quaternion.Euler(rotation);
			return instantiated;
		}

		public GameObject Instantiate(GameObject prefab, Vector3 at, Vector3 rotation, Transform parent = null)
		{
			var instantiated = _instantiatorProvider.Instantiator.InstantiatePrefab(prefab, parent);
			instantiated.name = instantiated.name.Replace("(Clone)", string.Empty);
			var transform = instantiated.transform;
			transform.position = at;
			transform.rotation = Quaternion.Euler(rotation);
			return instantiated;
		}

		public T Instantiate<T>(GameObject prefab) where T : MonoBehaviour
		{
			var instantiated = _instantiatorProvider.Instantiator.InstantiatePrefabForComponent<T>(prefab);
			instantiated.name = instantiated.name.Replace("(Clone)", string.Empty);
			var transform = instantiated.transform;
			transform.rotation = Quaternion.identity;
			return instantiated;
		}

		#endregion
	}
}
