using Cysharp.Threading.Tasks;

namespace AbilityMadness.Code.Infrastructure.Services.Cursors
{
    public interface ICursorService
    {
        UniTaskVoid SetCursor(CursorType cursorType);
    }
}
