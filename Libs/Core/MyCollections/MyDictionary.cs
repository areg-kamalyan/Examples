using System;

namespace Core.MyCollections
{


    public class MyDictionary<_Key, _Value>
    {
        public class MyKeyValuePair
        {
            public required _Key Key { set; get; }
            public required _Value Value { set; get; }

            public MyKeyValuePair? Next;
        }

        private MyKeyValuePair[] _buckets;
        uint Count;

        public MyDictionary()
        {
            _buckets = new MyKeyValuePair[4];
        }

        private void Resize()
        {

            var TempArr = new MyKeyValuePair[_buckets.Length * 2];
            foreach (MyKeyValuePair entry in _buckets)
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
            _buckets = TempArr;
        }

        // Хеш-функция
        private int GetHashCode(_Key key)
        {
            return key.GetHashCode() & 0x7FFFFFFF;  // Обеспечиваем положительный хеш
        }

        private int GetIndex(_Key key)
        {
            int hashCode = GetHashCode(key);
            return hashCode % _buckets.Length;
        }

        public void Add(_Key key, _Value value)
        {
            int index = GetIndex(key);

            // Проверка на коллизии
            var current = _buckets[index];
            while (current != null)
            {
                if (current.Key.Equals(key))
                {
                    throw new ArgumentException("Duplicate key");
                }
                current = current.Next;
            }

            // Создаем новую запись
            var newEntry = new MyKeyValuePair{ Key = key, Value = value };
            newEntry.Next = _buckets[index];
            _buckets[index] = newEntry;
            Count++;

            // Перераспределение массива при превышении порога
            if (Count > _buckets.Length * 0.75)
            {
                Resize();
            }
        }

        public bool Contains(_Key key)
        {
            int index = GetIndex(key);

            // Проверка на коллизии
            var current = _buckets[index];
            while (current != null)
            {
                if (current.Key.Equals(key))
                {
                   return true;
                }
                current = current.Next;
            }
            return false;
        }

        public void Remove(_Key key)
        {
            int index = GetIndex(key);

            // Проверка на коллизии
            var current = _buckets[index];
            MyKeyValuePair old = null;
            while (current != null)
            {
                if (current.Key.Equals(key))
                {
                    if (old == null)
                    {
                        if (_buckets[index].Next == null)
                        {
                            _buckets[index] = default;
                        }
                        else
                        {
                            _buckets[index] = _buckets[index].Next;
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
                int index = GetIndex(key);
                // Проверка на коллизии
                var current = _buckets[index];
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
                int index = GetIndex(key);
                // Проверка на коллизии
                var current = _buckets[index];
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
            for (int i = 0; i < _buckets.Length; i++)
            {
                var current = _buckets[i];
                while (current != null)
                {
                    yield return current;

                    current = current.Next;
                }
            }
        }

        public void Clearn()
        {
            _buckets = new MyKeyValuePair[4];
            Count = 0;
        }
    }
}
