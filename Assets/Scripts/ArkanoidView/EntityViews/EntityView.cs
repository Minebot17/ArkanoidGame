using ArkanoidModel.Entities;
using UnityEngine;
using ArkanoidView.Utils;

namespace ArkanoidView.EntityViews
{
    public class EntityView<T> : MonoBehaviour, IEntityView
        where T : IEntity
    {
        private IEntity _entityModel;
        private ITransformEntityMapper _transformEntityMapper;
        
        public IEntity EntityModel
        {
            get => _entityModel;
            set
            {
                if (value is not T)
                {
                    Debug.LogError($"Wrong entity model type. " +
                                   $"EntityViewType: {typeof(T)} EntityModelType: {value.GetType()}");
                }
                
                _entityModel = value;
                Entity = (T) value;
            }
        }

        public T Entity { get; private set; }

        protected virtual void Start()
        {
            _transformEntityMapper = new TransformEntityMapper(transform, EntityModel);
            EntityModel.OnDestroyed += () => Destroy(gameObject);
            transform.position = EntityModel.Position;
        }

        protected void Update()
        {
            _transformEntityMapper.MapTransformFromEntity();
        }
    }
}