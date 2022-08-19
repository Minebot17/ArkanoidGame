using System.Collections.Generic;
using ArkanoidModel.Entities;
using ArkanoidModel.Map;
using UnityEngine;

namespace ArkanoidModel.Core
{
    public class GameModel : IGameModel
    {
        private readonly List<IUpdatable> _updatables = new();
        private readonly IMapSizeManager _mapSizeManager;
        private readonly PlayerEntity _player;
        
        public IEntityManager EntityManager { get; }
        public IScoreManager ScoreManager { get; }

        public GameModel()
        {
            EntityManager = new EntityManager();
            ScoreManager = new ScoreManager(EntityManager);
            _mapSizeManager = new MapSizeManager(new Vector2(10, 10));
            _player = new PlayerEntity(_mapSizeManager, new Vector2(2f, 0.2f), 0.5f, 0.2f);
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