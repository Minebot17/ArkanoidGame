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
            return point.x > -Size.x / 2f
                   && point.y > -Size.y / 2f
                   && point.x < Size.x / 2f
                   && point.x < Size.y / 2f;
        }
    }
}