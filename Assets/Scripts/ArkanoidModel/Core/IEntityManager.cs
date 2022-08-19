﻿using System;
using System.Collections.Generic;
using ArkanoidModel.Entities;

namespace ArkanoidModel.Core
{
    public interface IEntityManager : IUpdatable
    {
        event Action<IEntity> OnEntitySpawned;
        event Action<IEntity> OnEntityDestroyed;
        
        IEnumerable<IEntity> Entities { get; }
        
        void SpawnEntity(IEntity entity);
        void DestroyEntity(IEntity entity, bool immediate = false);
    }
}