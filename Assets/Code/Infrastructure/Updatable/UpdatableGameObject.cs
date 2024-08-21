using UnityEngine;
using Zenject;

namespace AbilityMadness.Code.Infrastructure.Updatable
{
	public class UpdatableGameObject : MonoBehaviour
	{
		private IUpdateService updateService;

		[Inject]
		private void Construct(IUpdateService updateService)
		{
			this.updateService = updateService;
		}

		private void OnEnable() => AddUpdatables();
		private void OnDisable() => RemoveUpdatables();

		private void RemoveUpdatables()
		{
			var updatables = gameObject.GetComponentsInChildren<IUpdatable>();

			foreach (var updatable in updatables)
			{
				updateService.Remove(updatable);
			}
		}

		private void AddUpdatables()
		{
			var updatables = gameObject.GetComponentsInChildren<IUpdatable>();

			foreach (var updatable in updatables)
			{
				updateService.Add(updatable);
			}
		}
	}
}