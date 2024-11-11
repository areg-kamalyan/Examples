using System;

namespace Core.MyCollections
{


    public class MyDictionary<_Key, _Value>
    {
        public class MyKeyValuePair
        {
            public _Key Key { set; get; }
            public _Value Value { set; get; }

            public MyKeyValuePair Next;
        }

        private MyKeyValuePair[] arr;
        uint Count;

        public MyDictionary()
        {
            arr = new MyKeyValuePair[4];
        }

        private void Resize()
        {

            var TempArr = new MyKeyValuePair[arr.Length * 2];
            foreach (MyKeyValuePair entry in arr)
            {
                var current = entry;
                while (current != null)
                {
                    int index = GetHashCode(current.Key) % TempArr.Length;
                    var next = current.Next;

                    current.Next = TempArr[index];
                    TempArr[index] = current;

                    current = next;
                }
            }
            arr = TempArr;
        }

        // Хеш-функция
        private int GetHashCode(_Key key)
        {
            return key.GetHashCode() & 0x7FFFFFFF;  // Обеспечиваем положительный хеш
        }

        public void Add(_Key Key, _Value Value)
        {
            int hashCode = GetHashCode(Key);
            int index = hashCode % arr.Length;

            // Проверка на коллизии
            var current = arr[index];
            while (current != null)
            {
                if (current.Key.Equals(Key))
                {
                    throw new ArgumentException("Duplicate key");
                }
                current = current.Next;
            }

            // Создаем новую запись
            var newEntry = new MyKeyValuePair{ Key = Key, Value = Value };
            newEntry.Next = arr[index];
            arr[index] = newEntry;
            Count++;

            // Перераспределение массива при превышении порога
            if (Count > arr.Length * 0.75)
            {
                Resize();
            }
        }

        public bool Contains(_Key _Key)
        {
            int hashCode = GetHashCode(_Key);
            int index = hashCode % arr.Length;

            // Проверка на коллизии
            var current = arr[index];
            while (current != null)
            {
                if (current.Key.Equals(_Key))
                {
                   return true;
                }
                current = current.Next;
            }
            return false;
        }

        public void Remove(_Key _Key)
        {
            int hashCode = GetHashCode(_Key);
            int index = hashCode % arr.Length;

            // Проверка на коллизии
            var current = arr[index];
            MyKeyValuePair old = null;
            while (current != null)
            {
                if (current.Key.Equals(_Key))
                {
                    if (old == null)
                    {
                        if (arr[index].Next == null)
                        {
                            arr[index] = default;
                        }
                        else
                        {
                            arr[index] = arr[index].Next;
                        }
                    }
                    else
                    {
                        old.Next = current.Next;
                    }
                    Count--;
                    break;
                }
                old = current;
                current = current.Next;
            }
        }

        public _Value this[_Key key]
        {
            get
            {
                int hashCode = GetHashCode(key);
                int index = hashCode % arr.Length;

                // Проверка на коллизии
                var current = arr[index];
                while (current != null)
                {
                    if (current.Key.Equals(key))
                    {
                        return current.Value;
                    }
                    current = current.Next;
                }
                throw new Exception("Key is not exist");
            }
            set
            {
                int hashCode = GetHashCode(key);
                int index = hashCode % arr.Length;

                // Проверка на коллизии
                var current = arr[index];
                while (current != null)
                {
                    if (current.Key.Equals(key))
                    {
                        current.Value = value;
                        return;
                    }
                    current = current.Next;
                }
                throw new Exception("Key is not exist");
            }
        }

        public IEnumerator<MyKeyValuePair> GetEnumerator()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                var current = arr[i];
                while (current != null)
                {
                    yield return current;

                    current = current.Next;
                }
            }
        }

        public void Clearn()
        {
            arr = new MyKeyValuePair[4];
            Count = 0;
        }
    }
}
