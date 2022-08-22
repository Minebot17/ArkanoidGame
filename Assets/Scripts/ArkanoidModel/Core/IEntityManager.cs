using System;
using System.Collections.Generic;
using ArkanoidModel.Entities;

namespace ArkanoidModel.Core
{
    public interface IEntityManager : IUpdatable
    {
        event Action<IEntity> OnEntitySpawned;
        event Action<IEntity> OnEntityDestroyed;

        void SpawnEntity(IEntity entity);
        void DestroyEntity(IEntity entity, bool immediate = false);
    }
}