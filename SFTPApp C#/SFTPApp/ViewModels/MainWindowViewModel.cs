using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using Renci.SshNet.Sftp;
using SFTPApp.Models;

namespace SFTPApp.ViewModels
{
    /*
	* FILE : MainWindowViewModel.cs
	* PROJECT :
	* PROGRAMMER : George Shapka
	* FIRST VERSION : 2/2/2026 7:13:54 PM
	*/

    /*
	* NAME : MainWindowViewModel
	* PURPOSE :
	*/
    public class MainWindowViewModel : INotifyPropertyChanged, IDisposable
    {
        private NetworkWorker? _networkWorker;
        public ObservableCollection<RemoteFileInfo> FileOptions { get; }
        private TimeSpan _connectionTimeout = new TimeSpan(0, 0, 5);//timeout for connections set to 5 seconds

        private bool _shutdown;
        public bool Shutdown
        {
            get { return _shutdown; }
            set
            {
                _shutdown = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Shutdown)));
            }
        }

        //user info
        private string _username = string.Empty;
        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Username)));
            }
        }
        private string _password = string.Empty;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Password)));
            }
        }
        private string _ipAddress = string.Empty;
        public string IpAddress
        {
            get { return _ipAddress; }
            set
            {
                _ipAddress = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IpAddress)));
            }
        }

        //commands
        public ICommand ConnectToRemoteComputerCommand { get; }
        public ICommand GoToParentDirectoryCommand { get; }

        //events
        public event PropertyChangedEventHandler? PropertyChanged;

        public MainWindowViewModel()
        {
            FileOptions = new ObservableCollection<RemoteFileInfo>();
            ICollectionView view = CollectionViewSource.GetDefaultView(FileOptions);

            //user info
            Username = "george";
            Password = "2395";
            IpAddress = "100.108.227.107";

            //commands
            ConnectToRemoteComputerCommand = new RelayCommand(ConnectToRemoteComputer);
            GoToParentDirectoryCommand = new RelayCommand(GoToParentDirectory);
        }

        private void ConnectToRemoteComputer(object o)//work on this----------------------------------------------------------------
        {
            try
            {
                _networkWorker = new NetworkWorker(IpAddress, Username, Password, _connectionTimeout);
                FileOptions.Clear();
                IEnumerable<ISftpFile> list = new List<ISftpFile>();
                list = _networkWorker.GetCurrentDirectory();
                foreach (ISftpFile file in list)
                {
                    string dir = string.Empty;
                    if (file.IsDirectory) { dir = "■"; }
                    FileOptions.Add(new RemoteFileInfo(file.Name, dir));
                }
            }
            catch (Exception ex)
            {
                UserCommunication.DisplayError(ex.Message);
            }
        }

        private void GoToParentDirectory(object o)
        {
            if(o is string inputDir)
            {
                try
                {
                    if (_networkWorker != null)
                    {
                        FileOptions.Clear();
                        IEnumerable<ISftpFile> list = new List<ISftpFile>();
                        list = _networkWorker.ChangeDirectory(inputDir);
                        foreach (ISftpFile file in list)
                        {
                            string dir = string.Empty;
                            if (file.IsDirectory) { dir = "■"; }
                            FileOptions.Add(new RemoteFileInfo(file.Name, dir));
                        }
                    }
                    else
                    {
                        throw new Exception("Remote Machine Not Connected");
                    }
                }
                catch (Exception ex)
                {
                    UserCommunication.DisplayError(ex.Message);
                }
            }
        }

        public void Dispose()
        {
            try
            {
                if (_networkWorker != null)
                {
                    _networkWorker.Disconnect();
                }
            }
            catch (Exception ex)
            {
                UserCommunication.DisplayError(ex.Message);
            }
        }
    }//end of MainWindowViewModel
}