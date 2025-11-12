namespace Core.MyCollections
{
    public class MyLinkedList<T>
    {
        public int Count { get; private set; }
        public MyLinkedListNode<T> First { get; private set; }
        public MyLinkedListNode<T> Last { get; private set; }

        public MyLinkedList()
        {
            var curent = new MyLinkedListNode<T>(default);
            First = curent;
            Last = curent;
        }
        public MyLinkedList(IEnumerable<T> values)
        {
            var curent = new MyLinkedListNode<T>(default);
            First = curent;
            Last = curent;
            foreach (var item in values)
            {
                if (Count == 0) 
                {
                    curent.Value = item;
                }
                else
                {
                    curent.Next = new MyLinkedListNode<T>(item)
                    {
                        Previous = curent
                    };
                    curent = curent.Next;
                }


                Last = curent;
                Count++;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var tempNod = First;
            for (var i = 0; i < Count; i++)
            {
                yield return tempNod.Value;
                tempNod = tempNod.Next;
            }
        }

        public bool Contains(T item)
        {
            var enumerator = GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (EqualityComparer<T>.Default.Equals(enumerator.Current, item))
                    return true;
            }
            return false;
        }

        public void Append(T value) => AddLast(value);
        public void AddFirst(T value)
        {
            var temp = new MyLinkedListNode<T>(value)
            {
                Next = First
            };
            First.Previous = temp;
            First = temp;
            Count++;
        }
        public void AddLast(T value)
        {
            var temp = new MyLinkedListNode<T>(value)
            {
                Previous = Last
            };
            Last.Next = temp;
            Last = temp;
            Count++;
        }
        public void Remove(T value)
        {

            var tempNod = First;
            for (var i = 0; i < Count; i++)
            {
                if (tempNod.Value is not null && tempNod.Value.Equals(value))
                {
                    if (tempNod.Previous is not null)
                    tempNod.Previous.Next = tempNod.Next;
                    if (tempNod.Next is not null)
                        tempNod.Next.Previous = tempNod.Previous;
                    Count--;
                    return;
                }
                tempNod = tempNod.Next;
            }
        }
        public void RemoveFirst()
        {
            if (First.Next == null)
                return;
            First = First.Next;
            First.Previous = null;
            Count--;
        }
        public void RemoveLast()
        {
            if (Last.Previous == null)
                return;
            Last = Last.Previous;
            Last.Next = null;
            Count--;
        }


    }

    public class MyLinkedListNode<T>
    {
        public MyLinkedListNode<T>? Next { internal set; get; }
        public MyLinkedListNode<T>? Previous { internal set; get; }

        public T Value { set; get; }

        public MyLinkedListNode(T value)
        {
            Value = value;
        }
    }
}
