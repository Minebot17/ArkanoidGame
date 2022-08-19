using UnityEngine;

namespace ArkanoidModel.Entities.Bounds
{
    public class RectangleBounds : IBounds
    {
        public Vector2 Size { get; }

        public RectangleBounds(Vector2 size)
        {
            Size = size;
        }

        public bool IsPointInside(Vector2 point)
        {
            var halfSize = Size / 2f;
            return point.x > -halfSize.x
                   && point.y > -halfSize.y
                   && point.x < halfSize.x
                   && point.x < halfSize.y;
        }
    }
}