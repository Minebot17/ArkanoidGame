using System.Collections.Generic;
using ArkanoidModel.Entities;
using ArkanoidModel.Map;
using UnityEngine;

namespace ArkanoidModel.Core
{
    public class GameModel : IGameModel
    {
        private readonly List<IUpdatable> _updatables = new();
        private readonly IEntity _player;
        private readonly IBricksSpawner _bricksSpawner;
        private readonly BallEntity _ball;
        
        public IEntityManager EntityManager { get; }
        public IScoreManager ScoreManager { get; }
        public IMapSizeManager MapSizeManager { get; }
        public ILevelStateManager LevelStateManager { get; }

        public GameModel()
        {
            EntityManager = new EntityManager();
            ScoreManager = new ScoreManager(EntityManager);
            MapSizeManager = new MapSizeManager(new Vector2(10, 10));
            LevelStateManager = new LevelStateManager(MapSizeManager, EntityManager);
            _ball = new BallEntity(new Vector2(0.25f, 0.25f), 0.15f);
            _player = new PlayerEntity(MapSizeManager, _ball, new Vector2(2f, 0.2f), 0.5f, 0.2f);
            _bricksSpawner = new BricksSpawner(EntityManager, MapSizeManager, 2,
                new Vector2(0.5f, 0.5f), 
                new Vector2(1.1f, 0.6f),
                new Vector2(1f, 0.5f));
        }

        public void StartGame()
        {
            _bricksSpawner.SpawnBricks();
            EntityManager.SpawnEntity(_ball);
            EntityManager.SpawnEntity(_player);

            _updatables.Add(EntityManager);
            _updatables.Add(LevelStateManager);
        }
        
        public void TickUpdate()
        {
            foreach (var updatable in _updatables)
            {
                updatable.TickUpdate();
            }
        }
    }
}