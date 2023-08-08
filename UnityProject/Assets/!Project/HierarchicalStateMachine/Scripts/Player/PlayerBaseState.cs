namespace itonigames.unitystuff.HierarchicalStateMachine.Player
{
    public class PlayerBaseState : BaseState
    {
        protected readonly PlayerController player;
        protected readonly PlayerStateFactory stateFactory;

        protected PlayerBaseState(PlayerController player, PlayerStateFactory stateFactory) : base(player)
        {
            this.player = player;
            this.stateFactory = stateFactory;
        }

        public override void EnterState()
        {
        }

        protected override void UpdateState()
        {
        }

        public override void ExitState()
        {
        }

        protected override void CheckSwitchState()
        {
        }

        public override void InitializeSubState()
        {
        }
    }
}