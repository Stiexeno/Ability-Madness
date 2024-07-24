using UnityEngine;
using Zenject;

namespace AbilityMadness.Infrastructure.Services.StateMachine
{
	public abstract class StateMachine : IStateMachine, IInitializable, ITickable, IFixedTickable, ILateTickable
	{
		private IState _currentState;
		private IStatesFactory _statesFactory;

		public StateMachine(IStatesFactory statesFactory)
		{
			_statesFactory = statesFactory;
		}
		
		public abstract void Initialize();

		public virtual void Tick() => (_currentState as ITickable)?.Tick();
		public void FixedTick() => (_currentState as IFixedTickable)?.FixedTick();
		public void LateTick() => (_currentState as ILateTickable)?.LateTick();

		public void Enter<TState>() where TState : IState
		{
			var state = ChangeActiveStateTo<TState>();
			
			if (state == null)
				return;

			(state as IEnter)?.Enter();
		}
		
		public void Enter<TState, TPayload>(TPayload payload) where TState : IState, IPayloadedEnter<TPayload>
		{
			IState state = ChangeActiveStateTo<TState>();
			
			if (state == null)
				return;

			(state as IPayloadedEnter<TPayload>)?.Enter(payload);
		}
        
		public void Enter<TState, TPayload1, TPayload2>(TPayload1 payload1, TPayload2 payload2)
			where TState : IState, IPayloadedEnter<TPayload1, TPayload2>
		{
			IState state = ChangeActiveStateTo<TState>();
			
			if (state == null)
				return;

			(state as IPayloadedEnter<TPayload1, TPayload2>)?.Enter(payload1, payload2);
		}
        
		public void Enter<TState, TPayload1, TPayload2, TPayload3>(TPayload1 payload1, TPayload2 payload2, TPayload3 payload3)
			where TState : IState, IPayloadedEnter<TPayload1, TPayload2, TPayload3>
		{
			IState state = ChangeActiveStateTo<TState>();

			if (state == null)
				return;
			
			(state as IPayloadedEnter<TPayload1, TPayload2, TPayload3>)?.Enter(payload1, payload2, payload3);
		}

		private IState ChangeActiveStateTo<TState>() where TState : IState
		{
			if (_currentState != null && _currentState is TState)
				return null;
			
			(_currentState as IExit)?.Exit();

			_currentState = _statesFactory.Create<TState>();

			Debug.Log($"<color=green>{GetType().Name}</color> switched to <color=cyan>{typeof(TState).Name}</color>");

			return _currentState;
		}
	}
}