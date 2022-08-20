using ArkanoidModel.Map;

namespace ArkanoidModel.Core
{
    public interface IGameModel : IUpdatable
    {
        IEntityManager EntityManager { get; }
        IScoreManager ScoreManager { get; }
        IMapSizeManager MapSizeManager { get; }
        ILevelStateManager LevelStateManager { get; }
        
        void StartGame();
    }
}