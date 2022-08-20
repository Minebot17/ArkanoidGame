using System;

namespace ArkanoidModel.Core
{
    public interface IScoreManager
    {
        event Action<int> OnScoreChanged;
        
        int Score { get; }
    }
}