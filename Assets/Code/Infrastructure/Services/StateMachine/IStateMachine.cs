using Cysharp.Threading.Tasks;

namespace AbilityMadness.Infrastructure.Services.StateMachine
{
	public interface IStateMachine
	{
        UniTask Enter<TState>() where TState : IState;

        UniTask Enter<TState, TPayload>(TPayload payload) where TState : IState, IPayloadedEnter<TPayload>;

        UniTask Enter<TState, TPayload1, TPayload2>(TPayload1 payload1, TPayload2 payload2)
			where TState : IState, IPayloadedEnter<TPayload1, TPayload2>;

        UniTask Enter<TState, TPayload1, TPayload2, TPayload3>(TPayload1 payload1, TPayload2 payload2, TPayload3 payload3)
			where TState : IState, IPayloadedEnter<TPayload1, TPayload2, TPayload3>;
	}
}
