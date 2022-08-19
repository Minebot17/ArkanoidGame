﻿using System;
using System.Collections.Generic;
using ArkanoidModel.Core;
using ArkanoidModel.Entities;
using ArkanoidModel.Map;
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
        
        public override void InstallBindings()
        {
            var gameModel = new GameModel();
            var controls = new ArkanoidControls();
            controls.Game.Enable();
            
            Container.BindInstance(controls).AsSingle();
            Container.Bind<IEntityViewSpawner>().FromInstance(ConstructEntitySpawner()).AsSingle();
            Container.Bind<IGameModel>().FromInstance(gameModel).AsSingle();
            Container.Bind<MapBordersView>().FromInstance(_mapBorderView).AsSingle();
            Container.Bind<IMapSizeManager>().FromInstance(gameModel.MapSizeManager).AsSingle();
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