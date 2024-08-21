using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace AbilityMadness.Code.Infrastructure.Loading
{
    public class SwitchToEntySceneInEditor : MonoBehaviour
    {
        #if UNITY_EDITOR
        private const int EntySceneIndex = 0;

        private void Awake()
        {
            if (ProjectContext.HasInstance)
                return;

            foreach (var root in gameObject.scene.GetRootGameObjects())
            {
                root.SetActive(false);
            }

            SceneManager.LoadScene(EntySceneIndex);
        }
        #endif
    }
}
