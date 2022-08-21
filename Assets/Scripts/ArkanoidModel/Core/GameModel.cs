using System.Collections.Generic;
using ArkanoidModel.Entities;
using ArkanoidModel.Map;
using ArkanoidModel.Utils;

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

        public GameModel(IGameSettings settings)
        {
            EntityManager = new EntityManager();
            ScoreManager = new ScoreManager(EntityManager);
            MapSizeManager = new MapSizeManager(settings.MapSize);
            LevelStateManager = new LevelStateManager(MapSizeManager, EntityManager);
            _ball = new BallEntity(settings.BallSize, settings.BallMoveSpeed, settings.MaxDegreesBallBoundingFromPlayer);
            _player = new PlayerEntity(MapSizeManager, _ball, 
                settings.PlayerSize, settings.PlayerYOffset, settings.PlayerMoveSpeed, settings.MaxDegreesBallStartFire);
            _bricksSpawner = new BricksSpawner(EntityManager, MapSizeManager, settings.BrickRowsToSpawn,
                settings.BricksSpawnOffset, settings.BricksOffset, settings.BricksSize, settings.BricksScore);
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