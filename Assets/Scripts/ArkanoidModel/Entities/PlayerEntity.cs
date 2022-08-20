using ArkanoidModel.Entities.Bounds;
using ArkanoidModel.Map;
using UnityEngine;

namespace ArkanoidModel.Entities
{
    public class PlayerEntity : Entity
    {
        private readonly IMapSizeManager _mapSizeManager;
        private readonly float _movingSpeed;
        
        private MovingState _currentMovingState;

        public RectangleBounds RectangleBounds { get; }
        public override IBounds Bounds => RectangleBounds;

        public PlayerEntity(IMapSizeManager mapSizeManager, Vector2 platformSize, float platformOffset, float movingSpeed)
        {
            _mapSizeManager = mapSizeManager;
            _movingSpeed = movingSpeed;

            RectangleBounds = new RectangleBounds(platformSize);
            Position = new Vector2(0, platformOffset - mapSizeManager.MapSize.y / 2f);
        }

        public override void TickUpdate()
        {
            if (_currentMovingState != MovingState.Stay)
            {
                var xDirection = _currentMovingState == MovingState.MoveLeft ? -1 : 1;
                var newPosition = Position + new Vector2(_movingSpeed * xDirection, 0);
                
                if (newPosition.x - RectangleBounds.Size.x / 2f > -_mapSizeManager.MapSize.x / 2f
                    && newPosition.x + RectangleBounds.Size.x / 2f < _mapSizeManager.MapSize.x / 2f)
                {
                    Position = newPosition;
                }
            }
        }

        public void SetMovingState(MovingState movingState)
        {
            _currentMovingState = movingState;
        }
        
        public enum MovingState
        {
            Stay, MoveLeft, MoveRight
        }
    }
}