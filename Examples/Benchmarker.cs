using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Toolchains.NativeAot;
using Core.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples
{
    public class Benchmarker
    {
        public static void Run()
        {
            var summary = BenchmarkRunner.Run<TasksBenchmarker>();
        }
    }
       
    

    [MemoryDiagnoser]
    [SimpleJob(launchCount: 1, warmupCount: 1)]
    public class TasksBenchmarker
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
        public void Queue()
        {
            var students = Core.Generator.Generate<Student>(TotalCount);

            var list = new Queue<Student>();

            for (int i = 0; i < TotalCount; i++)
            {
                list.Enqueue(students[i]);
                list.Enqueue(students[i]);
                list.Dequeue();
            }
        }
    }
}
