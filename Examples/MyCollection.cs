using Core.MyCollections;

namespace Examples
{
    public static class MyCollection
    {
        public static void UseMyList()
        {
            MyList<int> data = new MyList<int>();
            data.Add(15);
            data.Add(25);
            data.Add(35);
            data.Add(55);
            data.Insert(45, 3);

            if (data.Contains(25))
            {
                data.Remove(25);
            }


            Console.WriteLine(data[3]);
            foreach (int item in data)
            {
                Console.WriteLine(item);
            }

            data.Clearn();
        }
        public static void UseMyDictionary()
        {
            var data = new MyDictionary<int, string>();
            data.Add(15, "15");
            data.Add(25, "25");
            data.Add(35, "35");
            data.Add(55, "55");

            if (data.ContainsKey(25))
            {
                data.Remove(25);
            }

            data[15] = "85";
            Console.WriteLine(data[15]);
            foreach (var item1 in data)
            {
                Console.WriteLine(item1.Value);
            }

            data.Clearn();
        }
        public static void UseMyLinkedList()
        {

            var item = new MyLinkedList<int>(new int[] { 1, 2, 3, 4, 5, 6 });

            item.Append(7);
            item.AddFirst(0);
            item.AddLast(8);

            item.Remove(5);
            item.RemoveFirst();
            item.RemoveLast();
            var t = item.First;
            foreach (var item1 in item)
            {
                Console.WriteLine(item1);
            }
        }
        public static void UseMyQueue()
        {
            MyQueue<int> data = new MyQueue<int>();
            data.Enqueue(15);
            data.Enqueue(25);
            data.Enqueue(35);
            data.Enqueue(45);

            Console.WriteLine(data.Dequeue());

            data.Enqueue(55);
            data.Dequeue();
            data.Enqueue(77);


            Console.WriteLine(data.Contains(25));

            Console.WriteLine(data.Peek());
            foreach (int item in data)
            {
                Console.WriteLine(item);
            }

            data.Clear();
        }
        public static void UseMySteck()
        {
            MyStack<int> data = new MyStack<int>();
            data.Push(15);
            data.Push(25);
            data.Push(35);
            data.Push(45);

            Console.WriteLine(data.Pop());

            data.Push(55);
            data.Pop();
            data.Push(77);


            Console.WriteLine(data.Contains(25));

            Console.WriteLine(data.Peek());
            foreach (int item in data)
            {
                Console.WriteLine(item);
            }

            data.Clear();
        }
    }
}
