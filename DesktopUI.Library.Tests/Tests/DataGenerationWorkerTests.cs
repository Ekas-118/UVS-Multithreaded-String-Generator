using DesktopUI.Library.Data;
using DesktopUI.Library.Models;
using DesktopUI.Library.Workers;
using Moq;
using NUnit.Framework;
using System;

namespace DesktopUI.Library.Tests.Tests
{
    [TestFixture]
    class DataGenerationWorkerTests
    {
        private readonly Random _random;

        public DataGenerationWorkerTests()
        {
            _random = new Random();
        }

        [Test]
        public void DataGenerationWorker_WhenInitializedWithNullValues_ThrowsException()
        {
            Mock<DataGenerator> dataGeneratorMock = new Mock<DataGenerator>(_random);
            Mock<IRepository> repoMock = new Mock<IRepository>();

            Assert.Throws<ArgumentNullException>(() => new DataGenerationWorker(null, dataGeneratorMock.Object, repoMock.Object));
            Assert.Throws<ArgumentNullException>(() => new DataGenerationWorker(_random, null, repoMock.Object));
            Assert.Throws<ArgumentNullException>(() => new DataGenerationWorker(_random, dataGeneratorMock.Object, null));
        }

        [Test]
        public void DataGenerationWorker_Work_CallsGenerateDataMethod()
        {
            Mock<IRepository> repositoryMock = new Mock<IRepository>();
            Mock<DataGenerator> dataGeneratorMock = new Mock<DataGenerator>(_random);
            var dataGenerationWorker = new DataGenerationWorker(_random, dataGeneratorMock.Object, repositoryMock.Object);
            dataGeneratorMock.Setup(x => x.GenerateData());

            dataGenerationWorker.Work();

            dataGeneratorMock.Verify(x => x.GenerateData(), Times.Once);
        }

        [Test]
        public void DataGenerationWorker_Work_SavesGeneratedData()
        {
            Mock<IRepository> repositoryMock = new Mock<IRepository>();
            Mock<DataGenerator> dataGeneratorMock = new Mock<DataGenerator>(_random);
            var dataGenerationWorker = new DataGenerationWorker(_random, dataGeneratorMock.Object, repositoryMock.Object);
            repositoryMock.Setup(x => x.AddDataModel(It.IsAny<GeneratedDataModel>()));

            dataGenerationWorker.Work();

            repositoryMock.Verify(x => x.AddDataModel(It.IsAny<GeneratedDataModel>()), Times.Once);
        }
    }
}
