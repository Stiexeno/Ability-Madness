using Cysharp.Threading.Tasks;

namespace AbilityMadness.Infrastructure.Services.StateMachine
{
	public interface IExit
	{
		UniTask Exit();
	}
}
