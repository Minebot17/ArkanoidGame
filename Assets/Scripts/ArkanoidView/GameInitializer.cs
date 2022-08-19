using ArkanoidModel.Core;
using ArkanoidModel.Entities;
using ArkanoidView.Utils;
using UnityEngine;
using Zenject;

namespace ArkanoidView
{
    public class GameInitializer : MonoBehaviour
    {
        private IGameModel _gameModel;
        private IEntityViewSpawner _entityViewSpawner;

        [Inject]
        public void Construct(IEntityViewSpawner entityViewSpawner, IGameModel gameModel)
        {
            _entityViewSpawner = entityViewSpawner;
            _gameModel = gameModel;
        }
        
        private void Awake()
        {
            _gameModel.EntityManager.OnEntitySpawned += OnEntitySpawned;
            _gameModel.StartGame();
        }

        private void FixedUpdate()
        {
            _gameModel.TickUpdate();
        }

        private void OnEntitySpawned(IEntity entity)
        {
            _entityViewSpawner.SpawnEntity(entity);
        }
    }
}