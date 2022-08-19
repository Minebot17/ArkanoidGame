using System;
using System.Collections.Generic;
using ArkanoidModel.Entities;
using UnityEngine;
using ArkanoidView.EntityViews;
using Object = UnityEngine.Object;

namespace ArkanoidView.Utils
{
    public class EntityViewSpawner : IEntityViewSpawner
    {
        public event Action<IEntityView> OnEntityViewSpawned;
        
        private readonly Dictionary<Type, GameObject> _entityPrefabs = new();

        public void RegisterEntityPrefab(Type entityType, GameObject prefab)
        {
            _entityPrefabs.Add(entityType, prefab);
        }

        public void SpawnEntity(IEntity entity)
        {
            if (!_entityPrefabs.ContainsKey(entity.GetType()))
            {
                Debug.LogError("Entity type not registered");
                return;
            }
            
            var entityView = Object.Instantiate(_entityPrefabs[entity.GetType()]).GetComponent<IEntityView>();
            if (entityView == null)
            {
                Debug.LogError("EntityView not found");
                return;
            }

            entityView.EntityModel = entity;
            OnEntityViewSpawned?.Invoke(entityView);
        }
    }
}