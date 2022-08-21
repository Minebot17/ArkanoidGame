using ArkanoidModel.Core;
using ArkanoidModel.Entities;
using ArkanoidModel.Map;
using Zenject;

namespace ArkanoidModel.Utils
{
    public class ModelContainerConstructor
    {
        public DiContainer Container { get; } = new ();

        public ModelContainerConstructor(IGameSettings settings)
        {
            Container.Bind<IEntityManager>().To<EntityManager>().AsSingle();
            Container.Bind<IScoreManager>().To<ScoreManager>().AsSingle();
            Container.Bind<IMapSizeManager>().To<MapSizeManager>().AsSingle().WithArguments(settings.MapSize);
            Container.Bind<ILevelStateManager>().To<LevelStateManager>().AsSingle();
            Container.Bind<IBricksSpawner>().To<BricksSpawner>().AsSingle().WithArguments(
                settings.BrickRowsToSpawn, settings.BricksSpawnOffset, 
                settings.BricksOffset, settings.BricksSize, settings.BricksScore);
            
            Container.Bind<BallEntity>().AsSingle().WithArguments(
                settings.BallSize, settings.BallMoveSpeed, settings.MaxDegreesBallBoundingFromPlayer);
            Container.Bind<PlayerEntity>().AsSingle().WithArguments(
                settings.PlayerSize, settings.PlayerYOffset, settings.PlayerMoveSpeed, settings.MaxDegreesBallStartFire);
        }
    }
}