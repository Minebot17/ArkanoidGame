using System;
using ArkanoidModel.Core;
using ArkanoidModel.Entities.Bounds;
using UnityEngine;

namespace ArkanoidModel.Entities
{
    public interface IEntity : IUpdatable
    {
        event Action OnMarkedToDestroy;
        event Action OnDestroyed;
        
        Vector2 Position { get; set; }
        IBounds Bounds { get; }

        void Destroyed();
    }
}