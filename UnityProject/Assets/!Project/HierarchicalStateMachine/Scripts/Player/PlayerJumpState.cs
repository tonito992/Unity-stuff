using UnityEngine;

namespace itonigames.unitystuff.HierarchicalStateMachine.Player
{
    public class PlayerJumpState : PlayerBaseState
    {
        private Vector3 currentMovement;
        private Vector3 appliedMovement;
        private float gravity = -10;
        private float initialJumpVelocity = 10;
        private float maxJumpHeight = 3;
        private float maxJumpTime = 0.5f;

        public PlayerJumpState(PlayerController context, PlayerStateFactory stateFactory) : base(context, stateFactory)
        {
        }

        public override void EnterState()
        {
            this.PrepareJump();

            this.currentMovement.y = this.initialJumpVelocity;
            this.appliedMovement.y = this.currentMovement.y;
        }

        protected override void UpdateState()
        {
            this.UpdateGravity();
            this.player.CharacterController.Move(this.appliedMovement * Time.deltaTime);
        }

        protected override void CheckSwitchState()
        {
            if (this.player.CharacterController.isGrounded)
            {
                this.SwitchState(this.stateFactory.GetState(PlayerStateFactory.State.Idle));
            }
        }

        private void UpdateGravity()
        {
            var previousYVelocity = this.currentMovement.y;
            this.currentMovement.y += this.gravity * Time.deltaTime;
            this.appliedMovement.y = Mathf.Max((previousYVelocity + this.currentMovement.y) * 0.5f, -20.0f);
        }

        private void PrepareJump()
        {
            var timeToApex = this.maxJumpTime / 2;
            this.gravity = (-2 * this.maxJumpHeight) / Mathf.Pow(timeToApex, 2);
            this.initialJumpVelocity = (2 * this.maxJumpHeight) / timeToApex;
        }
    }
}