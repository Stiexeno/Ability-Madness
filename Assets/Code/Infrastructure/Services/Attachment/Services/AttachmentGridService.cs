using AbilityMadness.Code.Infrastructure.Services.Assembler.Common;
using UnityEngine;

namespace AbilityMadness.Code.Infrastructure.Services.Assembler
{
    public class AttachmentGridService : IAttachmentGridService
    {
        private Attachment[,] grid;
        private IUIService _uiService;

        private const int width = 5;
        private const int height = 5;

        public Vector2Int Size => new Vector2Int(width, height);

        public AttachmentGridService(IUIService uiService)
        {
            _uiService = uiService;
            GenerateGrid();
        }

        private void GenerateGrid()
        {
            grid = new Attachment[width, height];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    grid[x, y] = new Attachment();
                }
            }
        }

        // public void SelectAttachment(AttachmentConfig attachmentConfig)
        // {
        //     var attachment = new Attachment();
        //     attachment
        //     if ()
        //     {
        //
        //     }
        // }

        public Vector2Int[] GetFittingCells(Vector2Int position, Vector2Int[] shape)
        {
            var fittingCells = new Vector2Int[shape.Length];

            for (int i = 0; i < shape.Length; i++)
            {
                fittingCells[i] = position + shape[i];
            }

            return fittingCells;
        }
    }
}
