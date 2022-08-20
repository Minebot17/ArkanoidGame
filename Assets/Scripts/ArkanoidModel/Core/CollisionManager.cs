using System.Collections.Generic;
using ArkanoidModel.Entities;

namespace ArkanoidModel.Core
{
    public class CollisionManager : IUpdatable
    {
        private HashSet<IEntity> _collidableEntities = new();
        private HashSet<IEntity> _physicsDynamicEntities = new();

        public CollisionManager(IEntityManager entityManager)
        {
            entityManager.OnEntitySpawned += OnEntitySpawned;
            entityManager.OnEntityDestroyed += OnEntityDestroyed;
        }
        
        public void TickUpdate()
        {
            foreach (var dynamicEntity in _physicsDynamicEntities)
            {
                
            }
        }

        private void OnEntitySpawned(IEntity entity)
        {
            if (entity.Bounds == null)
            {
                return;
            }
            
            _collidableEntities.Add(entity);
            if (!entity.IsPhysicsDynamicEntity)
            {
                return;
            }

            _physicsDynamicEntities.Add(entity);
        }

        private void OnEntityDestroyed(IEntity entity)
        {
            _collidableEntities.Remove(entity);
            _physicsDynamicEntities.Remove(entity);
        }
    }
}