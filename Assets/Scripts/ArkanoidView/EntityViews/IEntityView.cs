using ArkanoidModel.Entities;

namespace ArkanoidView.EntityViews
{
    public interface IEntityView
    {
        IEntity EntityModel { get; set; }
    }
}