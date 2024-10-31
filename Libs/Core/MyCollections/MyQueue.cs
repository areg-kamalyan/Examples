using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.MyCollections
{
    public class MyQueue<T>
    {
        private T[] arr;
        int head;
        int tail;
        int size;
        public MyQueue()
        {
            arr = new T[4];
        }
        void Resize()
        {
            T[] NewArr = new T[arr.Length * 2];
            if (head < tail)
            {
                Array.Copy(arr, NewArr, arr.Length);
            }
            else
            {
                Array.Copy(arr, head, NewArr, 0, arr.Length - head);
                Array.Copy(arr, 0, NewArr, arr.Length - head, tail);
            }
            arr = NewArr;
            head = 0;
            tail = size;
        }

        public void Enqueue(T Item)
        {
            if (size == arr.Length)
            {
                Resize();
            }

            arr[tail] = Item;
            tail = (tail + 1) % arr.Length;
            size++;
        }

        public T Dequeue()
        {
            T data = arr[head];
            arr[head] = default;
            head = (head + 1) % arr.Length;
            size--;
            return data;
        }

        public T Peek()
        {
            return arr[head];
        }

        public void Clear()
        {
            arr = new T[4];
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
    }
}
