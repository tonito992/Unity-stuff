using System.Collections.Generic;

namespace itonigames.unitystuff.HierarchicalStateMachine.Player
{
    public class PlayerStateFactory : StateFactory
    {
        public enum State
        {
            Jump,
            Idle
        }

        private readonly Dictionary<State, PlayerBaseState> states = new();

        public PlayerStateFactory(PlayerController context) : base()
        {
            this.states.Add(State.Idle, new PlayerIdleState(context, this));
            this.states.Add(State.Jump, new PlayerJumpState(context, this));
        }

        public PlayerBaseState GetState(State state)
        {
            return this.states[state];
        }
    }
}