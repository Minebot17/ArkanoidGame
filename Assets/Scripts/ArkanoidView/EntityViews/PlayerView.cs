using ArkanoidModel.Entities;
using UnityEngine.InputSystem;
using Zenject;

namespace ArkanoidView.EntityViews
{
    public class PlayerView : EntityView<PlayerEntity>
    {
        private ArkanoidControls _controls;

        [Inject]
        public void Construct(ArkanoidControls controls)
        {
            _controls = controls;
        }

        private void Awake()
        {
            _controls.Game.Move.started += HandleMoveAction;
            _controls.Game.Move.canceled += HandleMoveAction;
            _controls.Game.Fire.performed += HandleFireAction;
        }
        
        private void OnDestroy()
        {
            _controls.Game.Move.started -= HandleMoveAction;
            _controls.Game.Move.canceled -= HandleMoveAction;
            _controls.Game.Fire.performed -= HandleFireAction;
        }

        private void HandleMoveAction(InputAction.CallbackContext context)
        {
            var direction = context.ReadValue<float>();
            var movingState = direction < 0 ? PlayerEntity.MovingState.MoveLeft 
                : direction > 0 ? PlayerEntity.MovingState.MoveRight 
                : PlayerEntity.MovingState.Stay;
            
            Entity.SetMovingState(movingState);
        }

        private void HandleFireAction(InputAction.CallbackContext context)
        {
            Entity.TryFire();
        }
    }
}