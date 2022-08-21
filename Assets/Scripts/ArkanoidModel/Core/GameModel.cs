using System.Collections.Generic;
using ArkanoidModel.Entities;
using ArkanoidModel.Map;
using ArkanoidModel.Utils;
using Zenject;

namespace ArkanoidModel.Core
{
    public class GameModel : IGameModel
    {
        private readonly List<IUpdatable> _updatables = new();
        private readonly DiContainer _container;

        public IEntityManager EntityManager { get; }
        public IScoreManager ScoreManager { get; }
        public IMapSizeManager MapSizeManager { get; }
        public ILevelStateManager LevelStateManager { get; }

        public GameModel(IGameSettings settings)
        {
            _container = new ModelContainerConstructor(settings).Container;
            
            EntityManager = _container.Resolve<IEntityManager>();
            ScoreManager = _container.Resolve<IScoreManager>();
            MapSizeManager = _container.Resolve<IMapSizeManager>();
            LevelStateManager = _container.Resolve<ILevelStateManager>();
        }

        public void StartGame()
        {
            _container.Resolve<IBricksSpawner>().SpawnBricks();
            EntityManager.SpawnEntity(_container.Resolve<BallEntity>());
            EntityManager.SpawnEntity(_container.Resolve<PlayerEntity>());

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