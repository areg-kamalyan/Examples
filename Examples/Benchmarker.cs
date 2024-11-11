using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Core.Entitys;
using Core.MyCollections;

namespace Examples
{
    public class Benchmarker
    {
        public static void Run()
        {
            var summary = BenchmarkRunner.Run<CollectionBenchmarker>();
        }
    }



    [MemoryDiagnoser]
    [SimpleJob(launchCount: 1, warmupCount: 1)]
    public class CollectionBenchmarker
    {
        [Params(1000, 10000)]
        public int TotalCount { get; set; }

        [Benchmark]
        public void List()
        {
            var students = Core.Generator.Generate<Student>(TotalCount);

            var list = new List<Student>();

            for (int i = 0; i < TotalCount; i++)
            {
                list.Add(students[i]);
                list.Add(students[i]);
                list.Remove(students[i]);
            }
        }

        [Benchmark]
        public void MyList()
        {
            var students = Core.Generator.Generate<Student>(TotalCount);

            var list = new MyList<Student>();

            for (int i = 0; i < TotalCount; i++)
            {
                list.Add(students[i]);
                list.Add(students[i]);
                list.Remove(students[i]);
            }
        }

        [Benchmark]
        public void Queue()
        {
            var students = Core.Generator.Generate<Student>(TotalCount);

            var queue = new Queue<Student>();

            for (int i = 0; i < TotalCount; i++)
            {
                queue.Enqueue(students[i]);
                queue.Enqueue(students[i]);
                queue.Dequeue();
            }
        }

        [Benchmark]
        public void MyQueue()
        {
            var students = Core.Generator.Generate<Student>(TotalCount);

            var queue = new MyQueue<Student>();

            for (int i = 0; i < TotalCount; i++)
            {
                queue.Enqueue(students[i]);
                queue.Enqueue(students[i]);
                queue.Dequeue();
            }
        }

        [Benchmark]
        public void Dictionary()
        {
            var students = Core.Generator.Generate<Student>(TotalCount);

            var dictionary = new Dictionary<string, Student>();

            for (int i = 0; i < TotalCount; i++)
            {
                var key = i.ToString();
                dictionary.Add(key, students[i]);
                if (i % 5 == 0)
                    dictionary.Remove(key);
            }
        }

        [Benchmark]
        public void MyDictionary()
        {
            var students = Core.Generator.Generate<Student>(TotalCount);

            var dictionary = new MyDictionary<string, Student>();

            for (int i = 0; i < TotalCount; i++)
            {
                var key = i.ToString();
                dictionary.Add(key, students[i]);
                if (i % 5 == 0)
                    dictionary.Remove(key);
            }
        }


    }
}
