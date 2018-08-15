using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace AsyncVoidThread
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            UIthread.Text = $"UI Thread {Thread.CurrentThread.ManagedThreadId}";
        }

        private void Method1Btn_Click(object sender, RoutedEventArgs e)
        {
            Method1Log.Text = "";
            Method1Log.Text = $"* Method1Btn_Click Start (Thread :{Thread.CurrentThread.ManagedThreadId})";
            AsyncVoid();
            Method1Log.Text += $"{Environment.NewLine}* Method1Btn_Click Complete (Thread :{Thread.CurrentThread.ManagedThreadId})";
        }

        private async void AsyncVoid()
        {
            Method1Log.Text += $"{Environment.NewLine}+ AsyncVoid Start (Thread :{Thread.CurrentThread.ManagedThreadId})";
            await Task.Delay(2000);
            Method1Log.Text += $"{Environment.NewLine}+ AsyncVoid Complete (Thread :{Thread.CurrentThread.ManagedThreadId})";
        }

        private async void Method2Btn_Click(object sender, RoutedEventArgs e)
        {
            Method2Log.Text = "";
            Method2Log.Text = $"* Method2Btn_Click Start (Thread :{Thread.CurrentThread.ManagedThreadId})";
            await AsyncTask();
            Method2Log.Text += $"{Environment.NewLine}* Method2Btn_Click Complete (Thread :{Thread.CurrentThread.ManagedThreadId})";
        }

        private async Task AsyncTask()
        {
            Method2Log.Text += $"{Environment.NewLine}+ AsyncTask Start (Thread :{Thread.CurrentThread.ManagedThreadId})";
            await Task.Delay(2000);
            Method2Log.Text += $"{Environment.NewLine}+ AsyncTask Complete (Thread :{Thread.CurrentThread.ManagedThreadId})";
        }

        private async void Method3Btn_Click(object sender, RoutedEventArgs e)
        {
            Method3Log.Text = "";
            Method3Log.Text = $"* Method3Btn_Click Start (Thread :{Thread.CurrentThread.ManagedThreadId})";
            await AsyncTaskConfigureAwait();
            Method3Log.Text += $"{Environment.NewLine}* Method3Btn_Click Complete (Thread :{Thread.CurrentThread.ManagedThreadId})";
        }

        private async Task AsyncTaskConfigureAwait()
        {
            Method3Log.Text += $"{Environment.NewLine}+ AsyncTaskConfigureAwait Start (Thread :{Thread.CurrentThread.ManagedThreadId})";
            await Task.Delay(2000).ConfigureAwait(false);
            string fooMessage = $"{Environment.NewLine}+ AsyncTaskConfigureAwait Complete (Thread :{Thread.CurrentThread.ManagedThreadId})";
            Dispatcher.Invoke(() =>
            {
                Method3Log.Text += fooMessage;
            });
        }

        private void Method4Btn_Click(object sender, RoutedEventArgs e)
        {
            Method4Log.Text = "";
            Method4Log.Text = $"* Method4Btn_Click Start (Thread :{Thread.CurrentThread.ManagedThreadId})";
            AsyncTaskNoAwait();
            Method4Log.Text += $"{Environment.NewLine}* Method4Btn_Click Complete (Thread :{Thread.CurrentThread.ManagedThreadId})";
        }

        private async Task AsyncTaskNoAwait()
        {
            Method4Log.Text += $"{Environment.NewLine}+ AsyncTaskNoAwait Start (Thread :{Thread.CurrentThread.ManagedThreadId})";
            await Task.Delay(2000);
            Method4Log.Text += $"{Environment.NewLine}+ AsyncTaskNoAwait Complete (Thread :{Thread.CurrentThread.ManagedThreadId})";
        }

        private void Method5Btn_Click(object sender, RoutedEventArgs e)
        {
            Method5Log.Text = "";
            Method5Log.Text = $"* Method4Btn_Click Start (Thread :{Thread.CurrentThread.ManagedThreadId})";
            SyncVoid();
            Method5Log.Text += $"{Environment.NewLine}* Method4Btn_Click Complete (Thread :{Thread.CurrentThread.ManagedThreadId})";
        }

        private void SyncVoid()
        {
            Method5Log.Text += $"{Environment.NewLine}+ AsyncTaskNoAwait Start (Thread :{Thread.CurrentThread.ManagedThreadId})";
            Thread.Sleep(2000);
            Method5Log.Text += $"{Environment.NewLine}+ AsyncTaskNoAwait Complete (Thread :{Thread.CurrentThread.ManagedThreadId})";
        }
    }
}
