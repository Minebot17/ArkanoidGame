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

        protected T Entity { get; private set; }

        protected virtual void Start()
        {
            _transformEntityMapper = new TransformEntityMapper(transform, EntityModel);
            EntityModel.OnDestroyed += () => Destroy(gameObject);
            transform.position = EntityModel.Position;
            transform.localScale = new Vector3(EntityModel.Size.x, EntityModel.Size.y, 1);
        }

        protected void Update()
        {
            _transformEntityMapper.MapTransformFromEntity();
        }
    }
}