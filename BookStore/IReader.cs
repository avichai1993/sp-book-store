using System.Collections.Generic;

namespace BookStore
{
    interface IReader<T>
    {
        List<T> Read();
    }
}
