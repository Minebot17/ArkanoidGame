using System.Linq;
using ArkanoidModel.Entities;
using UnityEngine;

namespace ArkanoidView.EntityViews
{
    public class BallView : EntityView<BallEntity>
    {
        private void OnCollisionEnter2D(Collision2D col)
        {
            col.collider.TryGetComponent(out IEntityView entityView);
            Entity.OnCollision(col.contacts.Select(c => c.normal).ToArray(), 
                col.contactCount == 1 ? entityView?.EntityModel : null);
        }
    }
}