using System;
using ArkanoidModel.Entities;

namespace ArkanoidModel.Core
{
    public class ScoreManager : IScoreManager
    {
        public event Action<int> OnScoreChanged;
        public int Score { get; private set; }
        
        public ScoreManager(IEntityManager entityManager)
        {
            entityManager.OnEntityDestroyed += OnEntityDestroyed;
        }

        private void OnEntityDestroyed(IEntity entity)
        {
            if (entity is IScoreSource scoreSource)
            {
                Score += scoreSource.Score;
                OnScoreChanged?.Invoke(scoreSource.Score);
            }
        }
    }
}