using System.Collections.Generic;

namespace BookStore
{
    interface IWriter<T>
    {
        void Write(List<T> obj);
    }
}
