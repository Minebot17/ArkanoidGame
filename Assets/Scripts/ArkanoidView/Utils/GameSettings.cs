using System;
using ArkanoidModel.Utils;
using UnityEngine;

namespace ArkanoidView.Utils
{
    [Serializable]
    [CreateAssetMenu(fileName = "GameSettingsAsset", menuName = "ScriptableObjects/GameSettingsAsset")]
    public class GameSettings : ScriptableObject, IGameSettings
    {
        [Header("Player")] 
        [SerializeField] private Vector2 _playerSize = new (2, 0.2f);
        [SerializeField] private float _playerYOffset = 0.5f;
        [SerializeField] private float _playerMoveSpeed = 0.2f;
        [SerializeField] private float _maxDegreesBallStartFire = 20f;
        [SerializeField] private float _maxDegreesBallBoundingFromPlayer = 60f;
        
        [Header("Ball")] 
        [SerializeField] private Vector2 _ballSize = new (0.25f, 0.25f);
        [SerializeField] private float _ballMoveSpeed = 0.125f;
        
        [Header("Map")]
        [SerializeField] private Vector2 _mapSize = new (10f, 10f);
        [SerializeField] private int _brickRowsToSpawn = 2;
        [SerializeField] private Vector2 _bricksSpawnOffset = new (0.5f, 0.5f);
        [SerializeField] private Vector2 _bricksOffset = new (1.1f, 0.6f);
        [SerializeField] private Vector2 _bricksSize = new (1f, 0.5f);
        [SerializeField] private int _bricksScore = 1;

        public Vector2 PlayerSize => _playerSize;
        public float PlayerYOffset => _playerYOffset;
        public float PlayerMoveSpeed => _playerMoveSpeed;
        public float MaxDegreesBallStartFire => _maxDegreesBallStartFire;
        public float MaxDegreesBallBoundingFromPlayer => _maxDegreesBallBoundingFromPlayer;

        public Vector2 BallSize => _ballSize;
        public float BallMoveSpeed => _ballMoveSpeed;

        public Vector2 MapSize => _mapSize;
        public int BrickRowsToSpawn => _brickRowsToSpawn;
        public Vector2 BricksSpawnOffset => _bricksSpawnOffset;
        public Vector2 BricksOffset => _bricksOffset;
        public Vector2 BricksSize => _bricksSize;
        public int BricksScore => _bricksScore;
    }
}