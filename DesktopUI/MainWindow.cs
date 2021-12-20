using DesktopUI.Library;
using DesktopUI.Library.Models;
using DesktopUI.Library.Workers;
using System;
using System.Windows.Forms;

namespace DesktopUI
{
    public partial class MainWindow : Form
    {
        private const int _maxListViewItemCount = 20;
        private const int _minThreadCount = 2;
        private const int _maxThreadCount = 15;

        private readonly DataGenerator _dataGenerator;
        private readonly Func<DataGenerator, DataGenerationWorker> _dataGenerationWorkerFactory;
        private ThreadManager _threadManager;

        public MainWindow(DataGenerator dataGenerator, Func<DataGenerator, DataGenerationWorker> dataGenerationWorkerFactory)
        {
            InitializeComponent();

            threadNumberNumericUpDown.Minimum = _minThreadCount;
            threadNumberNumericUpDown.Maximum = _maxThreadCount;

            FormClosing += Stop;

            _dataGenerator = dataGenerator;
            _dataGenerationWorkerFactory = dataGenerationWorkerFactory;
            _dataGenerator.DataGenerated += AddDataToListView;
        }

        private void Start(object sender, EventArgs e)
        {
            startButton.Enabled = false;
            startButton.Text = "Running";
            stopButton.Enabled = true;

            int threadCount = (int)threadNumberNumericUpDown.Value;
            DataGenerationWorker worker = _dataGenerationWorkerFactory(_dataGenerator);

            _threadManager = new ThreadManager(threadCount, worker);
            _threadManager.Start();
        }

        private void Stop(object sender, EventArgs e)
        {
            _threadManager?.Stop();

            stopButton.Enabled = false;
            startButton.Text = "Start";
            startButton.Enabled = true;
        }

        private void AddDataToListView(GeneratedDataModel data)
        {
            ListViewItem item = new ListViewItem(data.ThreadId);
            item.SubItems.Add(data.Data);

            resultListView.Invoke((MethodInvoker)delegate ()
            {
                if (resultListView.Items.Count >= _maxListViewItemCount)
                {
                    resultListView.Items.RemoveAt(_maxListViewItemCount - 1);
                }
                resultListView.Items.Insert(0, item);
            });
        }
    }
}
