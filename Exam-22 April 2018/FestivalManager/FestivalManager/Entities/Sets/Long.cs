using System;

namespace FestivalManager.Entities.Sets
{
    class Long : Set
    {
        public Long(string name)
            : base(name, new TimeSpan(0, 60, 0))
        {
        }
    }
}
