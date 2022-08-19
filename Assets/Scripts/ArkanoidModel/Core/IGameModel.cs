namespace ArkanoidModel.Core
{
    public interface IGameModel : IUpdatable
    {
        IEntityManager EntityManager { get; }
        IScoreManager ScoreManager { get; }
        
        void StartGame();
    }
}