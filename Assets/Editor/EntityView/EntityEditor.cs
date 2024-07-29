using AbilityMadness.Code.Common.Behaviours;
using AbilityMadness.Code.Infrastructure.View;
using UnityEditor;
using Object = System.Object;

namespace AbilityMadness.Editor.Actors
{
	[CanEditMultipleObjects]
	[CustomEditor(typeof(EntityView), true)]
	public class EntityEditor : UnityEditor.Editor
	{
		// Private fields

		private EntityView entityView;

		private EntityComponentEditor componentEditor;

		// Properties

		// EntityComponentEditor

		// MonoBehaviour

		private void OnEnable()
		{
			entityView = target as EntityView;
			componentEditor = new EntityComponentEditor(this, entityView);
		}

		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();
			componentEditor.OnInspectorGUI();
		}

		public UnityEditor.Editor CreateEditor(Object target)
		{
			return UnityEditor.Editor.CreateEditor((UnityEngine.Object)target);
		}

		private void OnDestroy()
		{
			componentEditor.OnDestroy();
		}
	}
}
