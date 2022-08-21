using System;
using System.Collections.Generic;
using ArkanoidModel.Core;
using ArkanoidModel.Entities;
using ArkanoidModel.Map;
using ArkanoidView.UI;
using ArkanoidView.Utils;
using UnityEngine;
using Zenject;

namespace ArkanoidView
{
    public class GameViewInstaller : MonoInstaller<GameViewInstaller>
    {
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private GameObject _brickPrefab;
        [SerializeField] private GameObject _ballPrefab;
        [SerializeField] private MapBordersView _mapBorderView;
        [SerializeField] private GameMenuView _gameMenuView;
        [SerializeField] private GameModelHandler _gameModelHandler;
        [SerializeField] private GameSettings _gameSettings;

        public GameSettings GameSettings
        {
            get => _gameSettings;
            set => _gameSettings = value;
        }

        public override void InstallBindings()
        {
            var gameModel = (IGameModel) new GameModel(_gameSettings);
            var controls = new ArkanoidControls();
            controls.Game.Enable();
            
            Container.BindInstance(controls).AsSingle();
            Container.Bind<IEntityViewSpawner>().FromInstance(ConstructEntitySpawner()).AsSingle();
            Container.Bind<IGameModel>().FromInstance(gameModel).AsSingle();
            Container.Bind<MapBordersView>().FromInstance(_mapBorderView).AsSingle();
            Container.Bind<GameMenuView>().FromInstance(_gameMenuView).AsSingle();
            Container.Bind<GameModelHandler>().FromInstance(_gameModelHandler).AsSingle();
            Container.Bind<IMapSizeManager>().FromInstance(gameModel.MapSizeManager).AsSingle();
            Container.Bind<IScoreManager>().FromInstance(gameModel.ScoreManager).AsSingle();
        }
        
        private IEntityViewSpawner ConstructEntitySpawner()
        {
            var entityWithPrefabs = new HashSet<(Type Type, GameObject Prefab)>
            {
                (typeof(PlayerEntity), _playerPrefab),
                (typeof(BrickEntity), _brickPrefab),
                (typeof(BallEntity), _ballPrefab)
            };
            
            var entitySpawner = new EntityViewSpawner(Container);
            foreach (var entityWithPrefab in entityWithPrefabs)
            {
                entitySpawner.RegisterEntityPrefab(entityWithPrefab.Type, entityWithPrefab.Prefab);
            }

            return entitySpawner;
        }
    }
}