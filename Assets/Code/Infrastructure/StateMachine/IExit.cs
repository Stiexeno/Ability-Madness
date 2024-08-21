using Cysharp.Threading.Tasks;

namespace AbilityMadness.Code.Infrastructure.StateMachine
{
	public interface IExit
	{
		UniTask Exit();
	}
}
