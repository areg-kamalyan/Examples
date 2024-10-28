namespace Core.Collections
{
    public class MyLinkedList<T>
    {
        public int count;
        public MyLinkedListNode<T> First { get; private set; }
        public MyLinkedListNode<T> Last { get; private set; }

        public MyLinkedList()
        {
        }
        public MyLinkedList(IEnumerable<T> values)
        {
            MyLinkedListNode<T>? curent = null;
            foreach (var item in values)
            {
                if (curent == null)
                {
                    curent = new MyLinkedListNode<T>(item);
                }
                else
                {
                    curent.Next = new MyLinkedListNode<T>(item);
                    curent.Next.Previous = curent;
                    curent = curent.Next;
                }

                if (First == null)
                    First = curent;

                Last = curent;
                count++;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var tempNod = First;
            for (var i = 0; i < count; i++)
            {
                yield return tempNod.Value;
                tempNod = tempNod.Next;
            }
        }

        public void Append(T value) => AddLast(value);
        public void AddFirst(T value)
        {
            var temp = new MyLinkedListNode<T>(value);
            temp.Next = First;
            First.Previous = temp;
            First = temp;
            count++;
        }
        public void AddLast(T value)
        {
            var temp = new MyLinkedListNode<T>(value);
            temp.Previous = Last;
            Last.Next = temp;
            Last = temp;
            count++;
        }
        public void Remove(T value)
        {

            var tempNod = First;
            for (var i = 0; i < count; i++)
            {
                if (tempNod.Value.Equals(value))
                {
                    tempNod.Previous.Next = tempNod.Next;
                    tempNod.Next.Previous = tempNod.Previous;
                    count--;
                    return;
                }
                tempNod = tempNod.Next;
            }
        }
        public void RemoveFirst()
        {
            First = First.Next;
            First.Previous = null;
            count--;
        }
        public void RemoveLast()
        {
            Last = Last.Previous;
            Last.Next = null;
            count--;
        }


    }

    public class MyLinkedListNode<T>
    {
        public MyLinkedListNode<T> Next { internal set; get; }
        public MyLinkedListNode<T> Previous { internal set; get; }

        public T Value { set; get; }

        public MyLinkedListNode(T value) 
        {
            Value = value;
        }
    }
}
