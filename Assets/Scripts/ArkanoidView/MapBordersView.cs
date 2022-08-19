using System;
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
        }
    }
}