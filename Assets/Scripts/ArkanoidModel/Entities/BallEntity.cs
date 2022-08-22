using System;
using System.Collections.Generic;
using ArkanoidModel.Utils;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ArkanoidModel.Entities
{
    public class BallEntity : Entity
    {
        private readonly float _moveSpeed;
        private readonly float _maxDegreesBallBounding;
        private readonly float _maxDegreesBallStartFire;

        private Vector2 _velocityDirection;

        public BallEntity(Vector2 size, float moveSpeed, float maxDegreesBallBounding, float maxDegreesBallStartFire)
        {
            Size = size;
            _moveSpeed = moveSpeed;
            _maxDegreesBallBounding = maxDegreesBallBounding;
            _maxDegreesBallStartFire = maxDegreesBallStartFire;
        }

        public override void TickUpdate()
        {
            Position += _velocityDirection * _moveSpeed;
        }

        public void FireOnStart()
        {
            _velocityDirection = Vector2.up
                .Rotate(Random.Range(-_maxDegreesBallStartFire, _maxDegreesBallStartFire));
        }

        public void OnCollision(IEnumerable<Vector2> collisionsNormals, IEntity entity)
        {
            if (entity is PlayerEntity player)
            {
                var relativeDeltaFromCenter = Math.Abs(Position.x - player.Position.x) / (player.Size.x / 2f);
                var newDegrees = relativeDeltaFromCenter 
                                 * _maxDegreesBallBounding 
                                 * (player.Position.x > Position.x ? 1 : -1);
                
                _velocityDirection = Vector2.up.Rotate(newDegrees);
            }
            else
            {
                foreach (var normal in collisionsNormals)
                {
                    _velocityDirection = Vector2.Reflect(_velocityDirection, normal);
                }
                
                if (entity is BrickEntity brick)
                {
                    brick.OnCollideWithBall();
                }
            }
        }
    }
}