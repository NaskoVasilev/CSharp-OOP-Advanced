using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
    public interface IBox<T>
    {
        int Count { get; }

        void Add(T element);

        T Remove();
    }
}
