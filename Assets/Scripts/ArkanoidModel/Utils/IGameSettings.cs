using UnityEngine;

namespace ArkanoidModel.Utils
{
    public interface IGameSettings
    {
        Vector2 PlayerSize { get; }
        float PlayerYOffset { get; }
        float PlayerMoveSpeed { get; }
        float MaxDegreesBallStartFire { get; }
        float MaxDegreesBallBoundingFromPlayer { get; }
        
        Vector2 BallSize { get; }
        float BallMoveSpeed { get; }
        
        Vector2 MapSize { get; }
        int BrickRowsToSpawn { get; }
        Vector2 BricksSpawnOffset { get; }
        Vector2 BricksOffset { get; }
        Vector2 BricksSize { get; }
        int BricksScore { get; }
    }
}