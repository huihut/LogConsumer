using System;
using System.Threading;

namespace HuiHut.LogConsumer
{
    class LogConsumerTest
    {
        static void Main(string[] args)
        {
            // Create 10 threads to test LogConsumer.
            for (int i = 0; i < 10; i++)
            {
                ThreadPool.QueueUserWorkItem(Test, i);
            }

            // The main thread waits working threads for 1 second.
            Thread.Sleep(1000);

            Console.WriteLine("[ Main ] Finished test.");
            Environment.Exit(0);
        }
        
        static void Test(object obj)
        {
            // Thread id
            int id = int.Parse(obj.ToString());

            // Each thread writes 10 logs.
            for (int i = 0; i < 10; i++)
            {
                WriteLog("[ " + id + " ] index = " + i);
            }

            // Each thread writes a finished log.
            WriteLog("[ " + id + " ] Thread is finished.");
        }

        // Write the log and output it to the console.
        static void WriteLog(string logContent)
        {
            LogConsumer.Instance.Write(logContent);
            Console.WriteLine(logContent);
        }
    }
}
