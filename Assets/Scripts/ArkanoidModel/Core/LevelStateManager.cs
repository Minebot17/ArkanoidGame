using System;
using ArkanoidModel.Entities;
using ArkanoidModel.Map;

namespace ArkanoidModel.Core
{
    public class LevelStateManager : ILevelStateManager
    {
        public event Action OnLoseLevel;
        public event Action OnWinLevel;
        
        public bool IsLevelEnded { get; private set; }

        private readonly float _minimumBallY;

        private BallEntity _ball;
        private int _currentBricksCount;

        public LevelStateManager(IMapSizeManager mapSizeManager, IEntityManager entityManager)
        { 
            entityManager.OnEntitySpawned += OnEntitySpawned;
            entityManager.OnEntityDestroyed += OnEntityDestroyed;

            _minimumBallY = -mapSizeManager.MapSize.y / 2f;
        }

        public void TickUpdate()
        {
            if (IsLevelEnded)
            {
                return;
            }
            
            if (_ball.Position.y < _minimumBallY)
            {
                OnLoseLevel?.Invoke();
                IsLevelEnded = true;
            }
        }

        private void OnEntitySpawned(IEntity entity)
        {
            if (entity is BallEntity ball)
            {
                _ball = ball;
            }

            if (entity is BrickEntity)
            {
                _currentBricksCount++;
            }
        }

        private void OnEntityDestroyed(IEntity entity)
        {
            if (entity is not BrickEntity || IsLevelEnded)
            {
                return;
            }
            
            _currentBricksCount--;
            if (_currentBricksCount == 0)
            {
                OnWinLevel?.Invoke();
                IsLevelEnded = true;
            }
        }
    }
}