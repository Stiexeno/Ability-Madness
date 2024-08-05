using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AbilityMadness.Code.Infrastructure.Services.Assembler.Common
{
    [System.Serializable]
    public abstract class Array2D<T> : IEnumerable<T>
    {
        public int gridSize;

        public T this[int x, int y]
        {
            get => GetCell(x, y);
            set => SetCell(x, y, value);
        }

        protected abstract Cell<T> GetCellByIndex(int index);

        public void SetCell(int x, int z, T value)
        {
            if (x < 0 || x >= gridSize || z < 0 || z >= gridSize)
                return;

            int index = z * gridSize + x;
            GetCellByIndex(index).Value = value;
        }

        public T GetCell(int x, int z)
        {
            if (x < 0 || x >= gridSize || z < 0 || z >= gridSize)
                return default;

            int index = z * gridSize + x;
            return GetCellByIndex(index).Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int x = 0; x < gridSize; x++)
            {
                for (int y = 0; y < gridSize; y++)
                {
                    yield return this[x, y];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }
    }
}
