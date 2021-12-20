using DesktopUI.Library.Data;
using DesktopUI.Library.Models;
using DesktopUI.Library.Workers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DesktopUI.Library
{
    /// <summary>
    /// Provides multithreaded execution of work
    /// </summary>
    public class ThreadManager
    {
        private readonly List<Thread> _threads = new List<Thread>();

        private readonly int _threadCount;
        private readonly IWorker _worker;

        /// <param name="threadCount">The amount of threads to create on start</param>
        /// <param name="worker">The object which will be doing the work</param>
        public ThreadManager(int threadCount, IWorker worker)
        {
            if (threadCount < 1)
            {
                throw new ArgumentException(nameof(threadCount));
            }
            if (worker is null)
            {
                throw new ArgumentNullException(nameof(worker));
            }

            _threadCount = threadCount;
            _worker = worker;
        }

        /// <summary>
        /// Creates and starts all threads
        /// </summary>
        public void Start()
        {
            for (int i = 1; i <= _threadCount; i++)
            {
                var thread = new Thread(() =>
                {
                    while (true)
                    {
                        _worker.Work();
                    }
                });

                thread.Name = i.ToString();

                _threads.Add(thread);
            }

            Parallel.ForEach(_threads, thread => thread.Start());
        }

        /// <summary>
        /// Stops all active threads
        /// </summary>
        public void Stop()
        {
            Parallel.ForEach(_threads, thread => thread.Abort());
            _threads.Clear();
        }
    }
}
