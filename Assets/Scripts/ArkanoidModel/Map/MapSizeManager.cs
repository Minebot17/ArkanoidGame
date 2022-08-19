using UnityEngine;

namespace ArkanoidModel.Map
{
    public class MapSizeManager : IMapSizeManager
    {
        public Vector2 MapSize { get; }
        
        public MapSizeManager(Vector2 mapSize)
        {
            MapSize = mapSize;
        }
    }
}