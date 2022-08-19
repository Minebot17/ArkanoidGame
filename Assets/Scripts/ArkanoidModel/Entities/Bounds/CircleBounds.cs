using UnityEngine;

namespace ArkanoidModel.Entities.Bounds
{
    public class CircleBounds : IBounds
    {
        public float Radius { get; }

        private readonly float _sqrRadius;

        public CircleBounds(float radius)
        {
            Radius = radius;
            _sqrRadius = radius * radius;
        }
        
        public bool IsPointInside(Vector2 point)
        {
            return point.sqrMagnitude < _sqrRadius;
        }
    }
}