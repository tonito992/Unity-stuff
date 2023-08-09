using itonigames.unitystuff.HierarchicalStateMachine.HSM;
using TMPro;
using UnityEngine;

namespace itonigames.unitystuff.HierarchicalStateMachine.Example.Player
{
    public class PlayerController : StateMachine
    {
        [SerializeField] private TMP_Text debugStateText;

        private InputManager playerInput;
        private PlayerStateFactory stateFactory;
        private CharacterController characterController;

        private bool isJumpPressed;

        public bool IsJumpPressed => this.isJumpPressed;

        public InputManager PlayerInput => this.playerInput;

        public CharacterController CharacterController => this.characterController;

        protected override void Update()
        {
            base.Update();
            this.isJumpPressed = this.playerInput.Keys.Spacebar.WasPressedThisFrame();

            this.debugStateText.SetText(CurrentState.ToString());
        }

        private void Setup()
        {
            //Create state factory for this controller and assign starting state
            this.stateFactory = new PlayerStateFactory(this);
            CurrentState = this.stateFactory.GetState(PlayerStateFactory.State.Idle);

            this.playerInput = new InputManager();
            this.characterController = this.GetComponent<CharacterController>();
        }

        private void Awake()
        {
            this.Setup();
        }

        private void OnEnable()
        {
            this.playerInput.Enable();
        }

        private void OnDisable()
        {
            this.playerInput.Disable();
        }
    }
}