using System;
using ArkanoidModel.Entities;
using UnityEngine;
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
            _controls.Game.Move.performed += HandleMoveAction;
            _controls.Game.Move.canceled += HandleMoveAction;
        }

        protected override void Start()
        {
            base.Start();
            transform.localScale = new Vector3(Entity.Bounds.Size.x, Entity.Bounds.Size.y, 1);
        }

        private void OnDestroy()
        {
            _controls.Game.Move.started -= HandleMoveAction;
            _controls.Game.Move.performed -= HandleMoveAction;
            _controls.Game.Move.canceled -= HandleMoveAction;
        }

        private void HandleMoveAction(InputAction.CallbackContext context)
        {
            Debug.LogError("a");
            var direction = context.ReadValue<float>();
            var movingState = direction < 0 ? PlayerEntity.MovingState.MoveLeft 
                : direction > 0 ? PlayerEntity.MovingState.MoveRight 
                : PlayerEntity.MovingState.Stay;
            
            Entity.SetMovingState(movingState);
        }
    }
}