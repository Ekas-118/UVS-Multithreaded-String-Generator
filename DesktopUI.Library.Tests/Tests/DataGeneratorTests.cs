using DesktopUI.Library.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DesktopUI.Library.Tests.Tests
{
    [TestFixture]
    class DataGeneratorTests
    {
        private readonly Random _random;

        public DataGeneratorTests()
        {
            _random = new Random();
        }

        [Test]
        public void DataGenerator_WhenInitializedWithNullRandom_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => new DataGenerator(null));
        }

        [Test]
        public void DataGenerator_GeneratesRandomStrings()
        {
            var dataGenerator = new DataGenerator(_random);

            string first = dataGenerator.GenerateData().Data;
            string second = dataGenerator.GenerateData().Data;
            string third = dataGenerator.GenerateData().Data;

            bool areNotEqual = !string.Equals(first, second) || !string.Equals(first, third);

            Assert.True(areNotEqual);
        }

        [TestCase("test")]
        [TestCase("thread")]
        public void DataGenerator_GeneratesCorrectThreadID(string id)
        {
            var dataGenerator = new DataGenerator(_random);
            string threadName = id;
            GeneratedDataModel data = new GeneratedDataModel();

            var thread = new Thread(() =>
            {
                data = dataGenerator.GenerateData();
            })
            { Name = threadName };

            thread.Start();
            thread.Join();

            Assert.AreEqual(threadName, data.ThreadId);
        }

        [Test]
        public void DataGenerator_GeneratesCorrectTime()
        {
            var dataGenerator = new DataGenerator(_random);

            var data = dataGenerator.GenerateData();

            Assert.That(data.Time, Is.EqualTo(DateTime.UtcNow).Within(10).Seconds);
        }

        [Test]
        public void DataGenerator_GenerateData_RaisesDataGeneratedEvent()
        {
            var dataGenerator = new DataGenerator(_random);
            dataGenerator.DataGenerated += (x) => Assert.Pass();

            dataGenerator.GenerateData();

            Assert.Fail();
        }

        [Test]
        public void DataGenerator_GenerateData_SendsCorrectDataThroughEvent()
        {
            var dataGenerator = new DataGenerator(_random);
            GeneratedDataModel eventData = null;
            dataGenerator.DataGenerated += (data) => eventData = data;

            var generatedData = dataGenerator.GenerateData();

            Assert.AreEqual(generatedData, eventData);
        }
    }
}
