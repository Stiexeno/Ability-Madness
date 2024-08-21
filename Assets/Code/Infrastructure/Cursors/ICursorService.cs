using Cysharp.Threading.Tasks;

namespace AbilityMadness.Code.Infrastructure.Cursors
{
    public interface ICursorService
    {
        UniTaskVoid SetCursor(CursorType cursorType);
    }
}
