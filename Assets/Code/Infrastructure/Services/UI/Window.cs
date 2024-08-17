using UnityEngine;
using SF = UnityEngine.SerializeField;

namespace AbilityMadness
{
    public abstract class Window : MonoBehaviour
    {
        public void Open()
        {
            OnBeforeOpen();
            gameObject.SetActive(true);
        }

        public void Close()
        {
            OnBeforeClose();
            gameObject.SetActive(false);
        }

        protected virtual void OnBeforeOpen()
        {
        }

        protected virtual void OnBeforeClose()
        {
        }
    }
}
