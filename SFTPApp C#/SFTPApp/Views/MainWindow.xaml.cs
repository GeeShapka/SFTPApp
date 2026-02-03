using Microsoft.Win32;
using Renci.SshNet;
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
        public MainWindow()
        {
            DataContext = new ViewModels.MainWindowViewModel();
            InitializeComponent();
        }

        private void btnLocalFile_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnRemoteFile_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}