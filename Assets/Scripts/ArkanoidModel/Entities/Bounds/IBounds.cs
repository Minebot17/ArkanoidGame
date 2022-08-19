using UnityEngine;

namespace ArkanoidModel.Entities.Bounds
{
    public interface IBounds
    {
        bool IsPointInside(Vector2 point);
    }
}