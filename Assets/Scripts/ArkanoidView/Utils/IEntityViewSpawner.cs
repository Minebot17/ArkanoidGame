using System;
using ArkanoidModel.Entities;
using ArkanoidView.EntityViews;

namespace ArkanoidView.Utils
{
    public interface IEntityViewSpawner
    {
        event Action<IEntityView> OnEntityViewSpawned;
        
        void SpawnEntity(IEntity entity);
    }
}