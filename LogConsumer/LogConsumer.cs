using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;

namespace HuiHut.LogConsumer
{
    public class LogItem
    {
        public string time;
        public string module;
        public string content;
    }

    public class LogConsumer
    {
        // 日志文件流
        private string logFileName = "LogConsumer-" + System.DateTime.Now.ToString("yyyyMMdd") + ".txt";
        private FileStream logFileStream;
        private StreamWriter logStreamWriter;

        // 产品队列缓存
        private Queue<LogItem> queue = new Queue<LogItem>();
        static readonly int BUFFER_SIZE = 10;

        // 同步标记
        private Semaphore fillCount = new Semaphore(0, BUFFER_SIZE);
        private Semaphore emptyCount = new Semaphore(BUFFER_SIZE, BUFFER_SIZE);
        private Mutex bufferMutex = new Mutex();

        // 消费线程：写日志
        private Thread consumerThread;

        // 单例
        private static LogConsumer instance = new LogConsumer();
        public static LogConsumer Instance
        {
            get { return instance; }
            private set { }
        }

        private LogConsumer()
        {
            // 打开文件流
            OpenFileStream();
            
            // 日志消费者
            consumerThread = new Thread(Consumer);
            consumerThread.Start();
        }
        ~LogConsumer()
        {
            CloseFileStream();
        }

        // 打开文件流
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

        // 关闭文件流
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

        /// <summary>
        /// 生产者：写日志。其他模块通过调用此方法写日志
        /// </summary>
        /// <param name="content">日志内容</param>
        public void Write(string content)
        {
            // 日志项的时间
            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            // 调用本方法的模块（命名空间:类.方法）
            StackTrace trace = new StackTrace();
            StackFrame frame = trace.GetFrame(1);
            MethodBase method = frame.GetMethod();
            string namespaceName = method.ReflectedType.Namespace;
            string className = method.ReflectedType.Name;
            string methodName = method.Name;
            string module = namespaceName + ":" + className + "." + methodName;

            // 生产日志项
            var item = ProduceItem(time, module, content);

            // 还有生产权限时，进入下面的代码
            emptyCount.WaitOne();
            bufferMutex.WaitOne();

            // 将产品放入buffer中
            putItemIntoBuffer(item);
            bufferMutex.ReleaseMutex();

            // 释放一个拿去权限
            fillCount.Release();
        }

        // 消费者
        private void Consumer()
        {
            while (true)
            {
                // 等待一个拿去权限
                fillCount.WaitOne();
                bufferMutex.WaitOne();

                // 移除一个物品
                var item = removeItemFromBuffer();
                bufferMutex.ReleaseMutex();

                // 释放一个生产权限
                emptyCount.Release();

                // 消费：写日志
                WriteLog(item);
            }
        }

        // 将产品放入缓存中
        private void putItemIntoBuffer(LogItem item)
        {
            queue.Enqueue(item);
        }

        // 从缓存中获取产品
        private LogItem removeItemFromBuffer()
        {
            var item = queue.Peek();
            queue.Dequeue();
            return item;
        }

        // 生产产品
        private LogItem ProduceItem(string logTime, string logModule, string logContent)
        {
            LogItem item = new LogItem() { time = logTime, module = logModule, content = logContent };
            return item;
        }

        // 写日志到文件
        private void WriteLog(LogItem logItem)
        {
            if (logStreamWriter == null)
                OpenFileStream();
            logStreamWriter.WriteLine(logItem.time + "  " + logItem.module + "  " + logItem.content);
            logStreamWriter.Flush();
        }
    }
}
