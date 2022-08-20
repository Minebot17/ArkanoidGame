using ArkanoidModel.Core;
using ArkanoidModel.Entities;
using ArkanoidView.UI;
using ArkanoidView.Utils;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace ArkanoidView
{
    public class GameModelHandler : MonoBehaviour
    {
        private IGameModel _gameModel;
        private IEntityViewSpawner _entityViewSpawner;
        private ArkanoidControls _controls;
        private GameMenuView _gameMenuView;
        private bool _isPause;
        
        public bool IsPause
        {
            get => _isPause;
            set
            {
                if (value == _isPause)
                {
                    return;
                }
                
                if (value)
                {
                    _controls.UI.Enable();
                    _controls.Game.Disable();
                    _gameMenuView.Show(GameMenuView.MenuMode.Pause);
                }
                else
                {
                    _controls.UI.Disable();
                    _controls.Game.Enable();
                    _gameMenuView.Hide();
                }
                
                _isPause = value;
            }
        }

        [Inject]
        public void Construct(
            IEntityViewSpawner entityViewSpawner, 
            IGameModel gameModel,
            ArkanoidControls controls,
            GameMenuView gameMenuView)
        {
            _entityViewSpawner = entityViewSpawner;
            _gameModel = gameModel;
            _controls = controls;
            _gameMenuView = gameMenuView;
        }
        
        private void Awake()
        {
            _gameModel.EntityManager.OnEntitySpawned += OnEntitySpawned;
            _controls.Game.Pause.performed += HandlePauseAction;
            _controls.UI.Pause.performed += HandlePauseAction;
            
            _gameModel.StartGame();
        }

        private void FixedUpdate()
        {
            if (_isPause)
            {
                return;
            }
            
            _gameModel.TickUpdate();
        }

        private void OnEntitySpawned(IEntity entity)
        {
            _entityViewSpawner.SpawnEntity(entity);
        }

        private void HandlePauseAction(InputAction.CallbackContext context)
        {
            IsPause = !IsPause;
        }
    }
}