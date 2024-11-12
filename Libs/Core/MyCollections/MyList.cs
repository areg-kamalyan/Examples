namespace Core.MyCollections
{
    public class MyList<T>
    {
        private T[] arr;
        uint index;
        public MyList()
        {
            arr = new T[4];
        }

        void Resize()
        {
            if (index == arr.Length)
            {
                T[] TempArr = new T[arr.Length * 2];
                Array.Copy(arr, TempArr, arr.Length);
                arr = TempArr;
            }
        }

        public void Add(T item)
        {
            Resize();
            arr[index++] = item;
        }
        public void Clearn()
        {
            arr = new T[4];
            index = 0;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public void Remove(T item)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Equals(item))
                {

                    arr[i] = default;
                    index--;
                    Array.Copy(arr, i + 1, arr, i, index - i);
                    return;
                }
            }
        }

        public void Insert(int position, T item)
        {
            Resize();

            Array.Copy(arr, position, arr, position + 1, index - position);
            arr[position] = item;
            index++;
        }


        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < arr.Length; i++) 
            {
                yield return arr[i];
            }
        }

        public T this[uint _index]
        {
            get 
            {
                return arr[_index];
            }
            set 
            { 
                arr[_index] = value;
            }
        }
    }
}
