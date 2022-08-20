using ArkanoidModel.Map;
using UnityEngine;
using Zenject;

namespace ArkanoidView
{
    public class MapBordersView : MonoBehaviour
    {
        [SerializeField]
        private LineRenderer _lineRenderer;
        
        private IMapSizeManager _mapSizeManager;
        
        [Inject]
        public void Construct(IMapSizeManager mapSizeManager)
        {
            _mapSizeManager = mapSizeManager;
        }

        private void Start()
        {
            var halfSize = _mapSizeManager.MapSize / 2f;
            _lineRenderer.SetPositions(new []
            {
                new Vector3(-halfSize.x, -halfSize.y),
                new Vector3(-halfSize.x, halfSize.y),
                new Vector3(halfSize.x, halfSize.y),
                new Vector3(halfSize.x, -halfSize.y),
            });

            const float colliderDepth = 0.1f;
            var leftCollider = gameObject.AddComponent<BoxCollider2D>();
            leftCollider.size = new Vector2(colliderDepth, _mapSizeManager.MapSize.y);
            leftCollider.offset = new Vector2(-_mapSizeManager.MapSize.x / 2, 0);
            
            var rightCollider = gameObject.AddComponent<BoxCollider2D>();
            rightCollider.size = new Vector2(colliderDepth, _mapSizeManager.MapSize.y);
            rightCollider.offset = new Vector2(_mapSizeManager.MapSize.x / 2, 0);
            
            var topCollider = gameObject.AddComponent<BoxCollider2D>();
            topCollider.size = new Vector2(_mapSizeManager.MapSize.x, colliderDepth);
            topCollider.offset = new Vector2(0, _mapSizeManager.MapSize.y / 2f);
            
            var bottomCollider = gameObject.AddComponent<BoxCollider2D>();
            bottomCollider.size = new Vector2(_mapSizeManager.MapSize.x, colliderDepth);
            bottomCollider.offset = new Vector2(0, -_mapSizeManager.MapSize.y / 2f);
            bottomCollider.isTrigger = true;
        }
    }
}