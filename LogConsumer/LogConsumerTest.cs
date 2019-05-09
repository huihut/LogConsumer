using System;
using System.Threading;

namespace HuiHut.LogConsumer
{
    class LogConsumerTest
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                ThreadPool.QueueUserWorkItem(Test, i);
            }
            Thread.Sleep(1000);

            Console.WriteLine("[ Main ] Finished test.");
            Environment.Exit(0);
        }

        static void Test(object obj)
        {
            int id = int.Parse(obj.ToString());
            for (int i = 0; i < 10; i++)
            {
                WriteLog("[ " + id + " ] index = " + i);
            }
            WriteLog("[ " + id + " ] Thread is finished.");
        }

        public static void WriteLog(string logContent)
        {
            LogConsumer.Instance.Write(logContent);
            Console.WriteLine(logContent);
        }
    }
}
