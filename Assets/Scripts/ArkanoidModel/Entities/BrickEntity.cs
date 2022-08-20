using ArkanoidModel.Core;
using UnityEngine;

namespace ArkanoidModel.Entities
{
    public class BrickEntity : Entity, IScoreSource
    {
        public int Score { get; }
        
        public BrickEntity(Vector2 size, int score)
        {
            Size = size;
            Score = score;
        }
        
        public override void TickUpdate()
        {
            
        }

        public void OnCollideWithBall()
        {
            Destroy();
        }
    }
}