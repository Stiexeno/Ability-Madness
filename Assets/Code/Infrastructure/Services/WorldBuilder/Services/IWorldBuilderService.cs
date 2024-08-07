using AbilityMadness.Code.Infrastructure.Services.WorldBuilder.Configs;
using Cysharp.Threading.Tasks;

namespace AbilityMadness.Code.Infrastructure.Services.WorldBuilder.Services
{
    public interface IWorldBuilderService
    {
        UniTask Generate(WorldType worldType);
    }
}
