using DesktopUI.Library.Data;
using DesktopUI.Library.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DesktopUI.Library.Workers
{
    /// <summary>
    /// An <see cref="IWorker"/> implementation that provides creation of <see cref="GeneratedDataModel"/>s and adding them to an <see cref="IRepository"/>
    /// </summary>
    public class DataGenerationWorker : IWorker
    {
        private const int _minSleepTime = 500;
        private const int _maxSleepTime = 2000;

        private readonly Random _random;
        private readonly DataGenerator _dataGenerator;
        private readonly IRepository _repository;

        public DataGenerationWorker(Random random, DataGenerator dataGenerator, IRepository repository)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }
            if (dataGenerator is null)
            {
                throw new ArgumentNullException(nameof(dataGenerator));
            }
            if (repository is null)
            {
                throw new ArgumentNullException(nameof(repository));
            }

            _random = random;
            _dataGenerator = dataGenerator;
            _repository = repository;
        }

        public void Work()
        {
            Thread.Sleep(_random.Next(_minSleepTime, _maxSleepTime));

            GeneratedDataModel data = _dataGenerator.GenerateData();

            Task.Run(() => _repository.AddDataModel(data));
        }
    }
}
