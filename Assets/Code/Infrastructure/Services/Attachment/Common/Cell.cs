using UnityEngine;

namespace AbilityMadness.Code.Infrastructure.Services.Assembler.Common
{
    [System.Serializable]
    public class Cell<T>
    {
        [SerializeField] private T cell;

        public T Value
        {
            get => cell;
            set => cell = value;
        }
    }
}
