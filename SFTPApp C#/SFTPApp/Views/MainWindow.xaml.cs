using Microsoft.Win32;
using Renci.SshNet;
using SFTPApp.ViewModels;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SFTPApp.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel? _vm;
        public MainWindow()
        {
            InitializeComponent();
            _vm = new MainWindowViewModel();
            DataContext = _vm;
            this.Closed += MainWindow_Closed;
        }

        private void btnLocalFile_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(MessageBox.Show("U Sure Bro?", "Are You Sure About That", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }
        private void MainWindow_Closed(object? sender, EventArgs e)
        {
            // Call the Dispose method when the window is closed
            if (_vm != null)
            {
                _vm.Dispose();
                _vm = null;
            }
            // Unsubscribe from the closed event itself
            this.Closed -= MainWindow_Closed;
        }

    }
}