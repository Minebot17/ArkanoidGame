using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace ArkanoidView.Utils
{
    public class PlayerInputLinker : MonoBehaviour
    {
        [SerializeField] 
        private PlayerInput _playerInput;

        [Inject]
        public void Construct(ArkanoidControls controls)
        {
            _playerInput.actions = controls.asset;
        }
    }
}