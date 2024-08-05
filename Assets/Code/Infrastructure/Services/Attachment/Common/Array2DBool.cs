using UnityEngine;
using SF = UnityEngine.SerializeField;

namespace AbilityMadness.Code.Infrastructure.Services.Assembler.Common
{
    [System.Serializable]
    public class Array2DBool : Array2D<bool>
    {
        [SF] private CellBool[] cells;

        public int GridSize => gridSize;
        public CellBool[] Cells => cells;

        public Array2DBool(int size)
        {
            gridSize = size;
            cells = new CellBool[gridSize * gridSize];

            for (var x = 0; x < gridSize * gridSize; x++)
            {
                cells[x] = new CellBool();
            }
        }

        public Vector2Int[] GetShape()
        {
            var shape = new Vector2Int[GetCellCount()];
            var index = 0;

            for (int z = 0; z < gridSize; z++)
            {
                for (var x = 0; x < gridSize; x++)
                {
                    if (this[x, z] != false)
                    {
                        shape[index] = new Vector2Int(x, z);
                        index++;
                    }
                }
            }

            return shape;
        }

        private int GetCellCount()
        {
            var count = 0;

            for (int x = 0; x < gridSize; x++)
            {
                for (var z = 0; z < gridSize; z++)
                {
                    if (this[x, z] != false)
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        public Vector2Int GetMaxDimensions()
        {
            var width = 0;
            var height = 0;

            for (int x = 0; x < gridSize; x++)
            {
                for (var z = 0; z < gridSize; z++)
                {
                    if (this[x, z] != false)
                    {
                        width = Mathf.Max(width, x + 1);
                        height = Mathf.Max(height, z + 1);
                    }
                }
            }

            return new Vector2Int(width, height);
        }

        public bool IsValidCell(int x, int z) =>
            x >= 0 && z >= 0 && x < cells.Length && z < cells.Length;

        protected override Cell<bool> GetCellByIndex(int index)
        {
            return cells[index];
        }
    }
}
