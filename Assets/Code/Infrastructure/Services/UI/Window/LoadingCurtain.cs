using UnityEngine;

namespace AbilityMadness
{
    public class LoadingCurtain : MonoBehaviour, ILoadingCurtain
    {
        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
