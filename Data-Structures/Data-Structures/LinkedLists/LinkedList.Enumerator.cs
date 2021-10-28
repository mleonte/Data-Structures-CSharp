using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
    public partial class LinkedList<T>
    {
        public class Enumerator : IEnumerator<T>
        {
            public Enumerator(LinkedList<T> lst)
            {
                LinkedList = lst;
                Began = false;
            }
            
            private bool Began { get; set; }

            private LinkedList<T> LinkedList { get; set; }

            public T Current => CurrentNode.Value;

            public Node CurrentNode { get; set; }

            object IEnumerator.Current => CurrentNode.Value;

            public void Dispose()
            {
                ;
            }

            public bool MoveNext()
            {
                if (!Began)
                {
                    Began = true;
                    CurrentNode = LinkedList.Head;
                    return CurrentNode != null;
                }
                else if (CurrentNode?.HasNext ?? false)
                {
                    CurrentNode = CurrentNode.Next;
                    return true;
                }
                return false;
            }

            public void Reset()
            {
                CurrentNode = LinkedList.Head;
            }
        }
    }
}
