using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore
{
    interface IReader<T>
    {
        List<T> Read();
    }
}
