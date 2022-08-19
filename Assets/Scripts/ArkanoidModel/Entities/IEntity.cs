using System;
using ArkanoidModel.Core;
using UnityEngine;

namespace ArkanoidModel.Entities
{
    public interface IEntity : IUpdatable
    {
        event Action OnMarkedToDestroy;
        event Action OnDestroyed;
        
        Vector2 Position { get; set; }

        void Destroyed();
        
        void OnCollision(IEntity other);
    }
}