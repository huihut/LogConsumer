using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;

namespace HuiHut.LogConsumer
{
    /// <summary>
    /// Structure of each log entry
    /// </summary>
    public class LogItem
    {
        public string time;
        public string module;
        public string content;
    }

    /// <summary>
    /// 
    /// summary:
    ///     Log consumer - A simple thread-safe log module that uses producer-consumer mode.
    /// 
    /// usage:
    ///     HuiHut.LogConsumer.LogConsumer.Instance.Write("your log content");
    ///     
    /// </summary>
    public class LogConsumer
    {
        // Log file path and file name such as: @"D:\Log.txt", @"../Log.txt", @"Log.txt"
        private string logFileName = @"LogConsumer-" + System.DateTime.Now.ToString("yyyyMMdd") + ".txt";
        private FileStream logFileStream;
        private StreamWriter logStreamWriter;

        // Log cache queue
        private Queue<LogItem> queue = new Queue<LogItem>();
        static readonly int BUFFER_SIZE = 10;

        // Semaphore and Mutex
        private Semaphore fillCount = new Semaphore(0, BUFFER_SIZE);
        private Semaphore emptyCount = new Semaphore(BUFFER_SIZE, BUFFER_SIZE);
        private Mutex bufferMutex = new Mutex();

        // Consumer thread: write log
        private Thread consumerThread;

        // Singleton
        private static LogConsumer instance = new LogConsumer();
        public static LogConsumer Instance
        {
            get { return instance; }
            private set { }
        }

        private LogConsumer()
        {
            // Open file stream
            OpenFileStream();

            // Log consumer
            consumerThread = new Thread(Consumer);
            consumerThread.Start();
        }
        ~LogConsumer()
        {
            CloseFileStream();
        }

        /// <summary>
        /// Producer: Write the log. 
        /// Other modules write logs by calling this method.
        /// </summary>
        /// <param name="content">Log content</param>
        public void Write(string content)
        {
            // Time of each log entry
            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            // Get the module that calls Write ( namespace:class.method )
            StackTrace trace = new StackTrace();
            StackFrame frame = trace.GetFrame(1);
            MethodBase method = frame.GetMethod();
            string namespaceName = method.ReflectedType.Namespace;
            string className = method.ReflectedType.Name;
            string methodName = method.Name;
            string module = namespaceName + ":" + className + "." + methodName;

            // Production log entry
            var item = ProduceItem(time, module, content);

            // Waiting for production Permission
            emptyCount.WaitOne();
            bufferMutex.WaitOne();

            // Put the product in the buffer
            putItemIntoBuffer(item);
            bufferMutex.ReleaseMutex();

            // Release one to take permission
            fillCount.Release();
        }

        // Open file stream
        private void OpenFileStream()
        {
            if (!string.IsNullOrEmpty(logFileName))
            {
                if (logFileStream == null)
                    logFileStream = new FileStream(logFileName, FileMode.Append);
                if (logStreamWriter == null)
                    logStreamWriter = new StreamWriter(logFileStream);
            }
        }

        // Close file stream
        private void CloseFileStream()
        {
            if (logStreamWriter != null)
            {
                logStreamWriter.Flush();
                logStreamWriter.Close();
                logStreamWriter = null;
            }
            if (logFileStream != null)
            {
                logFileStream.Close();
                logFileStream = null;
            }
        }
        
        // Consumer
        private void Consumer()
        {
            while (true)
            {
                // Waiting for a permission
                fillCount.WaitOne();
                bufferMutex.WaitOne();

                // Remove an item
                var item = removeItemFromBuffer();
                bufferMutex.ReleaseMutex();

                // Release a production permission
                emptyCount.Release();

                // Consumption: write a log
                WriteLog(item);
            }
        }

        // Put the product in the cache
        private void putItemIntoBuffer(LogItem item)
        {
            queue.Enqueue(item);
        }

        // Get products from the cache
        private LogItem removeItemFromBuffer()
        {
            var item = queue.Peek();
            queue.Dequeue();
            return item;
        }

        // Produce Item
        private LogItem ProduceItem(string logTime, string logModule, string logContent)
        {
            LogItem item = new LogItem() { time = logTime, module = logModule, content = logContent };
            return item;
        }

        // Write log to file
        private void WriteLog(LogItem logItem)
        {
            if (logStreamWriter == null)
                OpenFileStream();
            logStreamWriter.WriteLine(logItem.time + "  " + logItem.module + "  " + logItem.content);
            logStreamWriter.Flush();
        }
    }
}
