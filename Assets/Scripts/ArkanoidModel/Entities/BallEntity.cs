using ArkanoidModel.Entities.Bounds;
using UnityEngine;

namespace ArkanoidModel.Entities
{
    public class BallEntity : Entity
    {
        private readonly float _moveSpeed;

        public Vector2 VelocityDirection { get; set; }
        public CircleBounds CircleBounds { get; }
        public override IBounds Bounds => CircleBounds;
        public override bool IsPhysicsDynamicEntity => true;

        public BallEntity(CircleBounds circleBounds, float moveSpeed)
        {
            CircleBounds = circleBounds;
            _moveSpeed = moveSpeed;
        }

        public override void TickUpdate()
        {
            Position += VelocityDirection * _moveSpeed;
        }
    }
}