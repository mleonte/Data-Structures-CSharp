using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
    public partial class LinkedList<T> : ICollection<T>, IList<T>
    {
        public LinkedList()
        {
        }

        public LinkedList(IEnumerable<T> elements)
        {
            foreach (var e in elements)
            {
                Add(e);
            }
        }

        public Node Head { get; set; }

        private Node FindAtIndex(int index)
        {
            if (Head == null)
                throw new IndexOutOfRangeException();

            var enumerator = new Enumerator(this);
            for (int i = 0; i <= index; i++)
            {
                if (!enumerator.MoveNext())
                    throw new IndexOutOfRangeException();
            }
            return enumerator.CurrentNode;
        }

        public T this[int index] 
        { 
            get 
            {
                return FindAtIndex(index).Value;
            }
            set
            {
                FindAtIndex(index).Value = value;
            }
        }

        public int Count {
            get
            {
                var count = 0;
                foreach (var e in this)
                {
                    count++;
                }
                return count;
            }
        }

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            if (Head == null)
            {
                Head = new Node(item);
            }
            else
            {
                var last = FindAtIndex(Count - 1);
                last.Link(new Node(item));
            }
        }

        public void Clear()
        {
            Head = null;
        }

        public bool Contains(T item)
        {
            foreach (var e in this)
            {
                if (e.Equals(item))
                    return true;
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            var count = 0;
            foreach (var e in this)
            {
                array[count] = e;
                count++;
            }
        }

        public IEnumerator<T> GetEnumerator() => new Enumerator(this);

        public bool Remove(T item)
        {
            var enumerator = new Enumerator(this);
            Node prev = null;
            while (enumerator.MoveNext())
            {
                if (enumerator.Current.Equals(item))
                {
                    if (prev == null) //The first node
                    {
                        Head.Next = null;
                        Head = enumerator.CurrentNode.Next;
                        return true;
                    }
                    else
                    {
                        prev.Next = enumerator.CurrentNode.Next;
                        return true;
                    }
                }
                prev = enumerator.CurrentNode;
            }
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public int IndexOf(T item)
        {
            var count = 0;
            foreach (var e in this)
            {
                if (e.Equals(item))
                    return count;
                count++;
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            var node = new Node(item);
            if (index == 0)
            {
                node.Next = Head;
                Head = node;
            }
            else
            {
                var prev = FindAtIndex(index - 1);
                node.Next = prev.Next;
                prev.Next = node;
            }
        }

        public void RemoveAt(int index)
        {
            if (index == 0)
            {
                if (Head != null)
                    Head = Head.Next;
            }
            else
            {
                var prev = FindAtIndex(index - 1);
                prev.Next = prev.Next?.Next;
            }
        }
    }
}
