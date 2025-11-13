namespace Examples
{
    internal class SemaphoreEX
    {
        public static void Run()
        {
            for (int i = 1; i < 6; i++)
            {
                var reader = new SemaphoreEX(i);
            }
        }

        // создаем семафор
        static Semaphore sem = new Semaphore(3, 3);
        Thread myThread;
        int count = 3;// счетчик чтения

        public SemaphoreEX(int i)
        {
            myThread = new Thread(Read)
            {
                Name = $"Читатель {i}"
            };
            myThread.Start();
        }

        public void Read()
        {
            while (count > 0)
            {
                sem.WaitOne();  // ожидаем, когда освободиться место

                Console.WriteLine($"{Thread.CurrentThread.Name} входит в библиотеку");

                Console.WriteLine($"{Thread.CurrentThread.Name} читает");
                Thread.Sleep(3000);

                Console.WriteLine($"{Thread.CurrentThread.Name} покидает библиотеку");

                sem.Release();  // освобождаем место

                count--;
                Thread.Sleep(1000);
            }
        }
    }
}
