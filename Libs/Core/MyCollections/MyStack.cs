namespace Core.MyCollections
{
    public class MyStack<T>
    {
        private T[] arr;
        int index;

        public int Count { get { return index; } }

        public MyStack()
        {
            arr = new T[4];
        }

        public void Clear()
        {
            arr = new T[4];
            index = 0;
        }

        public bool Contains(T data)
        {
            foreach (T item in arr)
            {
                if (item.Equals(data))
                {
                    return true;
                }
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                yield return arr[i];
            }
        }

        public T Peek()
        {
            return arr[index == 0 ? 0 : index - 1];
        }

        public T Pop()
        {
            if (index == 0)
                throw new IndexOutOfRangeException();

            index--;
            T iterm = arr[index];
            arr[index] = default;
           
            return iterm;
        }

        public void Push(T Item)
        {
            if (index == arr.Length)
            {
                T[] NewArr = new T[arr.Length * 2];
                Array.Copy(arr, NewArr, arr.Length);
                arr = NewArr;
            }

            arr[index] = Item;
            index++;
        }
    }
}
