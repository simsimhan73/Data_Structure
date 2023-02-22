namespace DataStructure
{
    internal class Node<T>
    {
        public T Data { get; set; }
        internal Node<T>? Next;
        internal Node<T>? Prev;
        public Node(T data)

        {
            this.Data = data;
            Next = null;
            Prev = null;
        }

    }

    class LinkedList<T>
    {
        private Node<T> head;
        private Node<T>? tail;

        public LinkedList(T data)
        {
            head = new Node<T>(data);
        }

        public void Add(T data)
        {
            if (tail == null)
            {
                tail = new Node<T>(data);
                head.Next = tail;
                tail.Prev = head;
            }
            else
            {
                Node<T> End = tail;
                tail = new Node<T>(data);
                tail.Prev = End;
            }
        }

        public void Add(T data, int index)
        {   
            Node<T> current = head;
            while(current != null && --index >= 0)
            {
                current = current.Next;
            }

            if(current != null && current.Next == null)
            {
                current.Next = new Node<T>(data);
                current.Next.Prev = current;
            }
            else if(current != null && current.Next != null)
            {
                Node<T> NewNode = new Node<T>(data);
                Node<T> NextNode = current.Next;
                NextNode.Prev = NewNode;
                current.Next = NewNode;
                current.Next.Next = NextNode;
                current.Next.Prev = current;
            }
        }

        public void RemoveAt(int index)
        {
            Node<T> current = head;
            while(current != null && --index >= 0)
            {
                current = current.Next;
            }

            if(current != null && current.Next != null)
            {
                current.Next.Prev = current.Prev;
                current.Prev.Next = current.Next;
            } 
            else if(current != null && current.Next == null)
            {
                current.Prev.Next = null;
            } 
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void Remove(Node<T> node)
        {
            Node<T> current = head;
            while (current != null && current != node)
            {
                current = current.Next;
            }

            if(current == node && current.Next != null)
            {
                current.Next.Prev = current.Prev;
                current.Prev.Next = current.Next;
            }
            else if (current == node && current.Next == null)
            {
                current.Prev.Next = null;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public void Remove(T data)
        {
            Node<T> current = head;
            Comparer<T> comparer = Comparer<T>.Default;

            while (current != null && comparer.Compare(current.Data, data) != 0)
            {
                current = current.Next;
            }

            if (comparer.Compare(current.Data, data) == 0 && current.Next != null)
            {
                current.Next.Prev = current.Prev;
                current.Prev.Next = current.Next;
            }
            else if (comparer.Compare(current.Data, data) == 0 && current.Next == null)
            {
                current.Prev.Next = null;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public bool Contains(Node<T> node)
        {
            Node<T> current = head;

            while(current != null && current != node)
            {
                current= current.Next;
            }


            return current == node ? true : false;
        }

        public bool Contains(T data)
        {
            Node<T> current = head;
            Comparer<T> comparer = Comparer<T>.Default;

            while (current != null && comparer.Compare(current.Data, data) != 0)
            {
                current = current.Next;
            }


            return current != null && comparer.Compare(current.Data, data) == 0 ? true : false;
        }
    }
}

namespace Program
{
    class Structure
    {
        static void Main(string[] args)
        {
            DataStructure.LinkedList<string> list = new DataStructure.LinkedList<string>("12");
            list.Add("a");
            Console.WriteLine(list.Contains("a"));
        }
    }
}