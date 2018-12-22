using System;
using System.Collections.Generic;
using System.Text;

namespace KingGambit.Contracts
{
    public interface IBoss : IAttackable
    {
        IReadOnlyCollection<IMortal> Subordinates { get; }

        void AddSubordinate(IMortal subordinate);

        void RemoveSubordinate(IMortal subordinate);
    }
}
