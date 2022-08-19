using System.Collections.Generic;
using ArkanoidModel.Entities;
using ArkanoidModel.Map;
using UnityEngine;

namespace ArkanoidModel.Core
{
    public class GameModel : IGameModel
    {
        private readonly List<IUpdatable> _updatables = new();
        private readonly PlayerEntity _player;
        
        public IEntityManager EntityManager { get; }
        public IScoreManager ScoreManager { get; }
        public IMapSizeManager MapSizeManager { get; }

        public GameModel()
        {
            EntityManager = new EntityManager();
            ScoreManager = new ScoreManager(EntityManager);
            MapSizeManager = new MapSizeManager(new Vector2(10, 10));
            _player = new PlayerEntity(MapSizeManager, new Vector2(2f, 0.2f), 0.5f, 0.2f);
        }

        public void StartGame()
        {
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