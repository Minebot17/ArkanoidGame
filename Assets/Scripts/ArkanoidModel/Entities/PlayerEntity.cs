using ArkanoidModel.Map;
using UnityEngine;

namespace ArkanoidModel.Entities
{
    public class PlayerEntity : Entity
    {
        private readonly IMapSizeManager _mapSizeManager;
        private readonly float _movingSpeed;
        private readonly BallEntity _ball;

        private MovingState _currentMovingState;
        private bool _ballGripped;

        public PlayerEntity(
            IMapSizeManager mapSizeManager, 
            BallEntity ball, 
            Vector2 size, 
            float platformOffset, 
            float movingSpeed)
        {
            _mapSizeManager = mapSizeManager;
            _ball = ball;
            _movingSpeed = movingSpeed;

            Size = size;
            Position = new Vector2(0, platformOffset - mapSizeManager.MapSize.y / 2f);
            _ballGripped = true;
        }

        public override void TickUpdate()
        {
            if (_currentMovingState != MovingState.Stay)
            {
                var xDirection = _currentMovingState == MovingState.MoveLeft ? -1 : 1;
                var newPosition = Position + new Vector2(_movingSpeed * xDirection, 0);
                
                if (newPosition.x - Size.x / 2f > -_mapSizeManager.MapSize.x / 2f
                    && newPosition.x + Size.x / 2f < _mapSizeManager.MapSize.x / 2f)
                {
                    Position = newPosition;
                }
            }

            if (_ballGripped)
            {
                _ball.Position = Position + new Vector2(0, Size.y / 2f + _ball.Size.y / 2f);
            }
        }

        public void TryFire()
        {
            if (!_ballGripped)
            {
                return;
            }

            _ball.FireOnStart();
            _ballGripped = false;
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