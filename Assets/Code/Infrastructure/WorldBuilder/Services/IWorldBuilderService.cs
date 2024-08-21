using AbilityMadness.Code.Infrastructure.WorldBuilder.Configs;
using Cysharp.Threading.Tasks;

namespace AbilityMadness.Code.Infrastructure.WorldBuilder.Services
{
    public interface IWorldBuilderService
    {
        UniTask Generate(WorldType worldType);
    }
}
