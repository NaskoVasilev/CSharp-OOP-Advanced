﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GenericBox
{
    public class Box<T>
    {
        public Box(T item)
        {
            this.Item = item;
        }

        public T Item { get; set; }

        public override string ToString()
        {
            return $"{this.Item.GetType().FullName}: {Item}";
        }
    }
}
