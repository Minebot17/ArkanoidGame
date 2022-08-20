using ArkanoidModel.Core;
using ArkanoidModel.Map;
using UnityEngine;

namespace ArkanoidModel.Entities
{
    public class BricksSpawner : IBricksSpawner
    {
        private readonly IEntityManager _entityManager;
        private readonly IMapSizeManager _mapSizeManager;
        private readonly int _rowsToSpawn;
        private readonly Vector2 _spawnOffset;
        private readonly Vector2 _bricksOffset;
        private readonly Vector2 _bricksSize;

        public BricksSpawner(
            IEntityManager entityManager, 
            IMapSizeManager mapSizeManager, 
            int rowsToSpawn,
            Vector2 spawnOffset, 
            Vector2 bricksOffset,
            Vector2 bricksSize)
        {
            _entityManager = entityManager;
            _mapSizeManager = mapSizeManager;
            _rowsToSpawn = rowsToSpawn;
            _spawnOffset = spawnOffset;
            _bricksOffset = bricksOffset;
            _bricksSize = bricksSize;
        }
        
        public void SpawnBricks()
        {
            var freeSpace = _mapSizeManager.MapSize.x - _spawnOffset.x * 2f;
            var bricksCount = (int) (freeSpace / _bricksOffset.x);
            var globalOffset = new Vector2(
                (freeSpace - bricksCount * _bricksOffset.x) / 2f + _spawnOffset.x + _bricksOffset.x / 2f, 
                -_spawnOffset.y - _bricksOffset.y / 2f);

            for (var y = 0; y < _rowsToSpawn; y++)
            {
                for (var x = 0; x < bricksCount; x++)
                {
                    var brick = new BrickEntity(_bricksSize)
                    {
                        Position = globalOffset 
                                   + new Vector2(_bricksOffset.x * x, -_bricksOffset.y * y)
                                   + new Vector2(-_mapSizeManager.MapSize.x / 2f, _mapSizeManager.MapSize.y / 2f)
                    };
                    
                    _entityManager.SpawnEntity(brick);
                }
            }
        }
    }
}