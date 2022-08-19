using System;
using System.Collections.Generic;
using ArkanoidModel.Core;
using ArkanoidModel.Entities;
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
        
        public override void InstallBindings()
        {
            var controls = new ArkanoidControls();
            controls.Game.Enable();
            Container.BindInstance(controls).AsSingle();
            Container.Bind<IEntityViewSpawner>().FromInstance(ConstructEntitySpawner()).AsSingle();
            Container.Bind<IGameModel>().FromInstance(new GameModel()).AsSingle();
        }
        
        private IEntityViewSpawner ConstructEntitySpawner()
        {
            var entityWithPrefabs = new HashSet<(Type Type, GameObject Prefab)>
            {
                (typeof(PlayerEntity), _playerPrefab),
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