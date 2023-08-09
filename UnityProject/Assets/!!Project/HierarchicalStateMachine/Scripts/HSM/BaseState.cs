using System;

namespace itonigames.unitystuff.HierarchicalStateMachine.HSM
{
    [Serializable]
    public abstract class BaseState
    {
        private readonly StateMachine player;
        protected BaseState CurrentSubState;

        protected BaseState(StateMachine player)
        {
            this.player = player;
        }

        /// <summary>
        /// Runs on state enter
        /// </summary>
        public abstract void EnterState();

        /// <summary>
        /// Runs every Unity Update()
        /// </summary>
        protected abstract void UpdateState();

        /// <summary>
        /// Runs when state is exiting
        /// </summary>
        public abstract void ExitState();

        /// <summary>
        /// Check for conditions to switch to another state
        /// </summary>
        protected abstract void CheckSwitchState();

        public abstract void InitializeSubState();

        public void UpdateStates()
        {
            this.UpdateState();
            this.CurrentSubState?.UpdateState();

            this.CheckSwitchState();
        }

        /// <summary>
        /// Exits current state end enters newState
        /// </summary>
        /// <param name="newState"></param>
        public void SwitchState(BaseState newState)
        {
            this.ExitState();
            newState.EnterState();
            this.player.CurrentState = newState;
        }

        /// <summary>
        /// Set child state
        /// </summary>
        /// <param name="newSubState"></param>
        protected void SetSubState(BaseState newSubState)
        {
            this.CurrentSubState = newSubState;
        }
    }
}