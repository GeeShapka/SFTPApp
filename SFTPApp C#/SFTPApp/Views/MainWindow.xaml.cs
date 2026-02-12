using Microsoft.Win32;
using Renci.SshNet;
using SFTPApp.Models;
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

        }//end of method

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(MessageBox.Show("U Sure Bro?", "Are You Sure About That", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }//end of method



        /// <summary>
        /// handles closing and disposing of everything
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        }//end of method


        /// <summary>
        /// handles what happens when user double clicks a row.<br/>
        /// in this case, it changed directorys
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender is DataGridRow row)
            {
                if (row.Item is RemoteFileInfo rfi)
                {
                    if(!rfi.Directory.Equals("■"))
                    {
                        UserCommunication.DisplayError("Cannot Open Files");
                    }
                    else if(_vm != null)
                    {
                        _vm.ChangeDirectoryCommand.Execute(rfi.Name);
                    }
                }
            }
        }//end of method

        private void btnRemoteRootDirectory_Click(object sender, RoutedEventArgs e)
        {
            _vm.ChangeDirectoryCommand.Execute("/");
        }
    }//end of class
}