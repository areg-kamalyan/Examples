using Core.MyCollections;

namespace UnitTests.xUint
{
    public class MyCollection
    {

        public static IEnumerable<object[]> GetData()
        {
            yield return new object[] { new int[] { 15, 25, 35, 55 }, 45 };
            //yield return new object[] { new List<int> { "4", "5", "6" } };
        }

        [Theory]
        [MemberData(nameof(GetData))]
        public void TestMyList(int[] initData, int inputData)
        {
            var items = new MyList<int>();

            foreach (var item in initData)
            {
                items.Add(item);
            }

            if (items.Count != initData.Length)
            {
                Xunit.Assert.Fail();
            }

            items.Insert(3, inputData);
            if (items[3] != inputData)
            {
                Xunit.Assert.Fail();
            }

            if (!items.Contains(initData[1]))
            {
                Xunit.Assert.Fail();
            }

            items.Remove(initData[1]);

            if (items[1] == initData[1])
            {
                Xunit.Assert.Fail();
            }

            items.Clearn();
            if (items.Count != 0)
            {
                Xunit.Assert.Fail();
            }
        }

        [Theory]
        [MemberData(nameof(GetData))]
        public void UseMyDictionary(int[] initData, int inputData)
        {
            var items = new MyDictionary<int, string>();

            foreach (var item in initData)
            {
                items.Add(item, item.ToString());
            }

            if (items.Count != initData.Length)
            {
                Xunit.Assert.Fail();
            }

            items[initData[0]] = inputData.ToString();
            if (items[initData[0]] != inputData.ToString())
            {
                Xunit.Assert.Fail();
            }

            if (!items.ContainsKey(initData[1]))
            {
                Xunit.Assert.Fail();
            }

            items.Remove(initData[1]);

            if (items.ContainsKey(initData[1]))
            {
                Xunit.Assert.Fail();
            }

            items.Clearn();
            if (items.Count != 0)
            {
                Xunit.Assert.Fail();
            }
        }

        [Theory]
        [MemberData(nameof(GetData))]
        public void UseMyLinkedList(int[] initData, int inputData)
        {

            var items = new MyLinkedList<int>(initData);


            if (items.Count != initData.Length)
            {
                Xunit.Assert.Fail();
            }

            items.Append(inputData);
            if (items.Last.Value != inputData)
            {
                Xunit.Assert.Fail();
            }

            items.AddFirst(initData[1]);

            if (items.First.Value != initData[1])
            {
                Xunit.Assert.Fail();
            }

            items.AddLast(initData[2]);
            if (items.Last.Value != initData[2])
            {
                Xunit.Assert.Fail();
            }

            if (!items.Contains(initData[3]))
            {
                Xunit.Assert.Fail();
            }

            items.Remove(initData[3]);
            if (items.Contains(initData[3]))
            {
                Xunit.Assert.Fail();
            }

            int temp = items.First.Value;
            items.RemoveFirst();
            if (temp == items.First.Value)
            {
                Xunit.Assert.Fail();
            }

            temp = items.Last.Value;
            items.RemoveLast();
            if (temp == items.Last.Value)
            {
                Xunit.Assert.Fail();
            }
        }

        [Theory]
        [MemberData(nameof(GetData))]
        public void UseMyQueue(int[] initData, int inputData)
        {
            var items = new MyQueue<int>();
            foreach (var item in initData)
            {
                items.Enqueue(item);
            }

            if (items.Count != initData.Length)
            {
                Xunit.Assert.Fail();
            }

            if (items.Contains(inputData))
            {
                Xunit.Assert.Fail();
            }

            items.Enqueue(inputData);

            if (!items.Contains(inputData))
            {
                Xunit.Assert.Fail();
            }

            var temp = items.Dequeue();
            if (temp != initData[0] || items.Count != initData.Length)
            {
                Xunit.Assert.Fail();
            }

            temp = items.Peek();
            if (temp != initData[1])
            {
                Xunit.Assert.Fail();
            }

            items.Clear();
            if (items.Count != 0)
            {
                Xunit.Assert.Fail();
            }
        }

        [Theory]
        [MemberData(nameof(GetData))]
        public void UseMySteck(int[] initData, int inputData)
        {
            var items = new MyStack<int>();
            foreach (var item in initData)
            {
                items.Push(item);
            }

            if (items.Count != initData.Length)
            {
                Xunit.Assert.Fail();
            }

            if (items.Contains(inputData))
            {
                Xunit.Assert.Fail();
            }

            items.Push(inputData);

            if (!items.Contains(inputData))
            {
                Xunit.Assert.Fail();
            }

            var temp = items.Pop();
            if (temp != inputData || items.Count != initData.Length) 
            {
                Xunit.Assert.Fail();
            }

            temp = items.Peek();
            if (temp != initData[^1])
            {
                Xunit.Assert.Fail();
            }

            items.Clear();
            if (items.Count != 0)
            {
                Xunit.Assert.Fail();
            }
        }
    }
}
