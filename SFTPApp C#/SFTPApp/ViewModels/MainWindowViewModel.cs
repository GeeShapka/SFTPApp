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
        public ICommand ChangeDirectoryCommand { get; }

        //events
        public event PropertyChangedEventHandler? PropertyChanged;


        //constructor
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
            ChangeDirectoryCommand = new RelayCommand(ChangeDirectory);
        }



        /// <summary>
        /// connects to the remote machine
        /// </summary>
        /// <param name="o"></param>
        private void ConnectToRemoteComputer(object o)
        {
            if(_networkWorker == null)
            {
                try
                {
                    _networkWorker = new NetworkWorker(IpAddress, Username, Password, _connectionTimeout);
                    IEnumerable<ISftpFile> list = new List<ISftpFile>();
                    list = _networkWorker.GetCurrentDirectory();
                    UpdateFileOptions(list);
                }
                catch (Exception ex)
                {
                    UserCommunication.DisplayError(ex.Message);
                }
            }
        }



        /// <summary>
        /// updates the file options observable collection
        /// </summary>
        /// <param name="list"></param>
        private void UpdateFileOptions(IEnumerable<ISftpFile> list)
        {
            FileOptions.Clear();
            foreach (ISftpFile file in list)
            {
                string dir = string.Empty;
                if (file.IsDirectory) { dir = "■"; }
                FileOptions.Add(new RemoteFileInfo(file.Name, dir));
            }
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="o"></param>
        private void ChangeDirectory(object o)
        {
            if(o is string inputDir)
            {
                try
                {
                    if (_networkWorker != null)
                    {
                        IEnumerable<ISftpFile> list = new List<ISftpFile>();
                        list = _networkWorker.ChangeDirectory(inputDir);
                        UpdateFileOptions(list);
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



        /// <summary>
        /// handles cleaning up resourses
        /// </summary>
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