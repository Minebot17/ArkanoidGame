using ArkanoidModel.Entities;
using UnityEngine;

namespace ArkanoidView.EntityViews
{
    public class BricksView : EntityView<BrickEntity>
    {
        protected override void Start()
        {
            base.Start();
            transform.localScale = new Vector3(Entity.Size.x, Entity.Size.y, 1);
        }
    }
}