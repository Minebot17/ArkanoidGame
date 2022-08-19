using System;
using UnityEngine;

namespace ArkanoidModel.Entities
{
    public abstract class Entity : IEntity
    {
        public event Action OnMarkedToDestroy;
        public event Action OnDestroyed;

        public Vector2 Position { get; set; }
        public float RotationAngle { get; set; }
        
        public abstract void TickUpdate();
        protected abstract bool IsCanDestroyedBy(IEntity other);
        
        public void OnCollision(IEntity other)
        {
            if (IsCanDestroyedBy(other))
            {
                Destroy();
            }
        }

        protected virtual void Destroy()
        {
            OnMarkedToDestroy?.Invoke();
        }
        
        public virtual void Destroyed()
        {
            OnDestroyed?.Invoke();
        }
    }
}