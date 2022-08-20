using ArkanoidModel.Entities;
using UnityEngine;

namespace ArkanoidView.EntityViews
{
    public class BallView : EntityView<BallEntity>
    {
        protected override void Start()
        {
            base.Start();
            transform.localScale = new Vector3(Entity.CircleBounds.Radius, Entity.CircleBounds.Radius, 1);
        }
    }
}