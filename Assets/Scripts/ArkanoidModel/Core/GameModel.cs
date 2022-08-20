using System.Collections.Generic;
using ArkanoidModel.Entities;
using ArkanoidModel.Entities.Bounds;
using ArkanoidModel.Map;
using UnityEngine;

namespace ArkanoidModel.Core
{
    public class GameModel : IGameModel
    {
        private readonly List<IUpdatable> _updatables = new();
        private readonly IEntity _player;
        private readonly IBricksSpawner _bricksSpawner;
        
        public IEntityManager EntityManager { get; }
        public IScoreManager ScoreManager { get; }
        public IMapSizeManager MapSizeManager { get; }

        public GameModel()
        {
            EntityManager = new EntityManager();
            ScoreManager = new ScoreManager(EntityManager);
            MapSizeManager = new MapSizeManager(new Vector2(10, 10));
            _player = new PlayerEntity(MapSizeManager, new Vector2(2f, 0.2f), 0.5f, 0.2f);
            _bricksSpawner = new BricksSpawner(EntityManager, MapSizeManager, 3,
                new Vector2(0.5f, 0.5f), 
                new Vector2(1.25f, 0.75f),
                new RectangleBounds(new Vector2(1f, 0.5f)));
        }

        public void StartGame()
        {
            _bricksSpawner.SpawnBricks();
            EntityManager.SpawnEntity(_player);

            _updatables.Add(EntityManager);
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