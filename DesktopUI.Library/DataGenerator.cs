using DesktopUI.Library.Models;
using System;
using System.Text;
using System.Threading;

namespace DesktopUI.Library
{
    /// <summary>
    /// Provides generating of <see cref="GeneratedDataModel"/>s
    /// </summary>
    public class DataGenerator
    {
        private const int _minStringLength = 5;
        private const int _maxStringLength = 10;

        private readonly Random _random;

        public delegate void DataGeneratedEventHandler(GeneratedDataModel data);
        public event DataGeneratedEventHandler DataGenerated;

        public DataGenerator(Random random)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }

            _random = random;
        }

        public virtual GeneratedDataModel GenerateData()
        {
            GeneratedDataModel data = new GeneratedDataModel()
            {
                ThreadId = Thread.CurrentThread.Name,
                Data = GenerateRandomString(),
                Time = DateTime.UtcNow
            };

            OnDataGenerated(data);

            return data;
        }

        private string GenerateRandomString()
        {
            StringBuilder str = new StringBuilder();
            int stringLength = _random.Next(_minStringLength, _maxStringLength);

            for (int i = 0; i < stringLength; i++)
            {
                str.Append((char)_random.Next(33, 126));
            }

            return str.ToString();
        }

        protected virtual void OnDataGenerated(GeneratedDataModel data)
        {
            DataGenerated?.Invoke(data);
        }
    }
}
