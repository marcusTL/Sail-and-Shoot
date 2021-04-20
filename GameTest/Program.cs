using System;

namespace GameTest
{
    class Program
    {
        static void Main(string[] args)
        {
            TestWorker tw = new TestWorker();
            tw.Start();

            Console.ReadLine();
        }
    }
}
