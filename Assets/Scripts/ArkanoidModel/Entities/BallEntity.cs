using System;
using ArkanoidModel.Utils;
using UnityEngine;

namespace ArkanoidModel.Entities
{
    public class BallEntity : Entity
    {
        private readonly float _moveSpeed;
        private readonly float _maxDegreesBallBounding;

        public Vector2 VelocityDirection { get; set; }

        public BallEntity(Vector2 size, float moveSpeed, float maxDegreesBallBounding)
        {
            Size = size;
            _moveSpeed = moveSpeed;
            _maxDegreesBallBounding = maxDegreesBallBounding;
        }

        public override void TickUpdate()
        {
            Position += VelocityDirection * _moveSpeed;
        }

        public void OnCollision(Vector2 collisionNormal, IEntity entity)
        {
            if (entity is PlayerEntity player)
            {
                var relativeDeltaFromCenter = Math.Abs(Position.x - player.Position.x) / (player.Size.x / 2f);
                var newDegrees = relativeDeltaFromCenter * _maxDegreesBallBounding 
                                                         * (player.Position.x > Position.x ? 1 : -1);
                VelocityDirection = Vector2.up.Rotate(newDegrees);
            }
            else
            {
                VelocityDirection = Vector2.Reflect(VelocityDirection, collisionNormal);

                if (entity is BrickEntity brick)
                {
                    brick.OnCollideWithBall();
                }
            }
        }
    }
}