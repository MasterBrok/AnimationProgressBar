using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

// this Background Worker 
using System.ComponentModel;

namespace AnimationProgressBar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += Worker_DoWork;
            worker.ProgressChanged += Worker_ProgressChanged;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            worker.RunWorkerAsync();
        }

        private void Worker_RunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Finish " + prog.thisValue);
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            prog.thisValue = e.ProgressPercentage;
        }

        double sum = 0;
        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 1000; i++)
            {
                this.Dispatcher.Invoke(() =>
                {
                    //var re = (prog.Width / 100);
                    sum += 0.5;
                });
                (sender as BackgroundWorker).ReportProgress((int)sum);

                // Code here
                System.Threading.Thread.Sleep(11);
            }
        }
    }
}
