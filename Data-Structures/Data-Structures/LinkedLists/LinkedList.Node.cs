namespace DataStructures
{
    public partial class LinkedList<T>
    {
        public class Node
        {
            public Node(T value)
            {
                Value = value;
            }

            public void Link(Node next)
            {
                Next = next;
            }

            public Node Next { get; set; }

            public bool HasNext => Next != null;

            public T Value { get; set; }
        }
    }
}
