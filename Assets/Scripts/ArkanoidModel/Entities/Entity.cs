using System;
using ArkanoidModel.Entities.Bounds;
using UnityEngine;

namespace ArkanoidModel.Entities
{
    public abstract class Entity : IEntity
    {
        public event Action OnMarkedToDestroy;
        public event Action OnDestroyed;
        
        public Vector2 Position { get; set; }
        public virtual bool IsPhysicsDynamicEntity => false;
        public abstract IBounds Bounds { get; }

        protected virtual void Destroy()
        {
            OnMarkedToDestroy?.Invoke();
        }

        public virtual void Destroyed()
        {
            OnDestroyed?.Invoke();
        }
        
        public abstract void TickUpdate();
    }
}