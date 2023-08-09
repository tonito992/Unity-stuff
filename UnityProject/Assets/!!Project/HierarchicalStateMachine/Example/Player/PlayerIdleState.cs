namespace itonigames.unitystuff.HierarchicalStateMachine.Example.Player
{
    public class PlayerIdleState : PlayerBaseState
    {
        public PlayerIdleState(PlayerController player, PlayerStateFactory stateFactory) : base(player, stateFactory)
        {
        }

        protected override void CheckSwitchState()
        {
            base.CheckSwitchState();

            if (this.player.IsJumpPressed)
            {
                this.SwitchState(this.stateFactory.GetState(PlayerStateFactory.State.Jump));
            }
        }
    }
}