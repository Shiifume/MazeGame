using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Maze
{
    internal class OrderedSet<T> : ICollection<T>
    {
        private readonly List<T> items = new();
        private readonly HashSet<T> set = new();

        public int Count => items.Count();

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(T item)
        {
           if(!set.Contains(item))
           {
                set.Add(item);
                items.Add(item);
           }
        }

        public void Clear()
        {
            items.Clear();
            set.Clear();
        }

        public bool Contains(T item)
        {
            return set.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            items.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        public bool Remove(T item)
        {
            if(set.Contains(item))
            {
                items.Remove(item);
                set.Remove(item);
                return true;
            }
            return false;

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public T this[int index] { get => items[index]; }
       
        public void AddRange(IEnumerable<T> collectionToAdd)
        {
            foreach(T item in collectionToAdd)
            {
                this.Add(item);
            }
        }

        public int IndexOf(T item)
        {
            return items.IndexOf(item);
        }
    }
}
