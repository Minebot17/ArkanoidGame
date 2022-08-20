using ArkanoidModel.Entities.Bounds;

namespace ArkanoidModel.Entities
{
    public class BrickEntity : Entity
    {
        public RectangleBounds RectangleBounds { get; }
        public override IBounds Bounds => RectangleBounds;
        
        public BrickEntity(RectangleBounds rectangleBounds)
        {
            RectangleBounds = rectangleBounds;
        }
        
        public override void TickUpdate()
        {
            
        }
    }
}