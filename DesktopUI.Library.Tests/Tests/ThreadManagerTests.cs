using DesktopUI.Library.Workers;
using Moq;
using NUnit.Framework;
using System;
using System.Threading;

namespace DesktopUI.Library.Tests.Tests
{
    [TestFixture]
    class ThreadManagerTests
    {
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-10)]
        public void ThreadManager_WhenInitializedWithInvalidThreadCount_ThrowsException(int threadCount)
        {
            Mock<IWorker> worker = new Mock<IWorker>();
            Assert.Throws<ArgumentException>(() => new ThreadManager(threadCount, worker.Object));
        }

        [Test]
        public void ThreadManager_WhenInitializedWithNullWorker_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => new ThreadManager(5, null));
        }

        [Test]
        public void ThreadManager_Stop_WorksWithoutStart()
        {
            Mock<IWorker> worker = new Mock<IWorker>();

            var threadManager = new ThreadManager(5, worker.Object);

            Assert.DoesNotThrow(() => threadManager.Stop());
        }

        [Test]
        public void ThreadManager_Start_ExecutesWorkerMethod()
        {
            Mock<IWorker> worker = new Mock<IWorker>();
            var threadManager = new ThreadManager(3, worker.Object);

            threadManager.Start();
            Thread.Sleep(50);
            threadManager.Stop();

            worker.Verify(x => x.Work(), Times.AtLeast(3));
        }
    }
}
