using UnityEngine;

namespace AbilityMadness.Code.Infrastructure.Services.Assembler
{
    public interface IAttachmentGridService
    {
        Vector2Int Size { get; }
        Vector2Int[] GetFittingCells(Vector2Int position, Vector2Int[] shape);
    }
}
