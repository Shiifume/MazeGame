using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Maze
{
    internal class CustomBagCollection<T> : ICollection<T>
    {
        private T[] _items;

        public int Count { private set; get; }

        public bool IsReadOnly { get; }

        public CustomBagCollection()
        {
            Count = 0;
        }
        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
