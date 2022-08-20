using System;

namespace ArkanoidModel.Core
{
    public interface ILevelStateManager : IUpdatable
    {
        event Action OnLoseLevel;
        event Action OnWinLevel;

        bool IsLevelEnded { get; }
    }
}