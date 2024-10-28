namespace Core.Collections
{
    public class MyKeyValuePair<_Key, _Value>
    {
        public _Key? Key { set; get; }
        public _Value? Value { set; get; }

        public bool Equals(MyKeyValuePair<_Key, _Value>? obj)
        {
            if (obj == null) return false;
            if (Key.Equals(obj.Key) && Value.Equals(obj.Value)) return true;
            return false;
        }
    }

    public class MyDictionary<_Key, _Value>
    {
        private MyKeyValuePair<_Key, _Value>[] arr;
        uint index;

        public MyDictionary()
        {
            arr = new MyKeyValuePair<_Key, _Value>[4];
        }

        private void Resize()
        {
            if (index == arr.Length)
            {
                var Temp = new MyKeyValuePair<_Key, _Value>[arr.Length * 2];
                Array.Copy(arr, Temp, arr.Length);
                arr = Temp;
            }
        }

        private bool KeyExist(_Key key)
        {
            for (int i = 0; i < index; i++) 
            { 
                if (arr[i].Key.Equals(key))
                    return true;
            }
            return false;
        }

        public void Add(_Key Key, _Value Value)
        {
            if (KeyExist(Key))
                throw new Exception("Key is exist");
            Resize();
            arr[index] = new MyKeyValuePair<_Key, _Value> { Key = Key, Value = Value };
            index++;
        }

        public void Insert(_Key Key, _Value Value, uint position)
        {
            if (KeyExist(Key))
                throw new Exception("Key is exist");

            Resize();
            Array.Copy(arr, position, arr, position + 1, index - position);
            arr[position] = new MyKeyValuePair<_Key, _Value> { Key = Key, Value = Value };
            index++;
        }

        public bool Contains(MyKeyValuePair<_Key, _Value> item)
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

        public void Remove(MyKeyValuePair<_Key, _Value> item)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Equals(item))
                {
                    Array.Copy(arr, i + 1, arr, i, --index);
                    return;
                }
            }
        }

        public _Value this[_Key key]
        {
            get
            {
                for (int i = 0; i < index; i++)
                {
                    if (arr[i].Key.Equals(key))
                    {
                        return arr[i].Value;
                    }
                }

                throw new Exception("Key is not exist");
            }
            set
            {
                for (int i = 0; i < index; i++)
                {
                    if (arr[i].Key.Equals(key))
                    {
                        arr[i].Value = value;
                        return;
                    }
                }

                throw new Exception("Key is not exist");
            }
        }

        public IEnumerator<MyKeyValuePair<_Key, _Value>> GetEnumerator()
        {
            for (int i = 0; i < index; i++)
            {
                yield return arr[i];
            }
        }

        public void Clearn()
        {
            arr = new MyKeyValuePair<_Key, _Value>[4];
            index = 0;
        }
    }
}
