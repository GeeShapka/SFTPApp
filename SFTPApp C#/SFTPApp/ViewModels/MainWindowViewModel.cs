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
        private UserPresets _userPresets;
        private UserPreset _currentPreset = new UserPreset();
        public UserPreset CurrentPreset
        {
            get { return _currentPreset; }
            set
            {
                _currentPreset = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentPreset)));
            }
        }
        public ObservableCollection<RemoteFileInfo> RemoteFileOptions { get; }
        public ObservableCollection<string> RemotePathPresets { get; }
        public ObservableCollection<string> UserPresetNames 
        { 
            get;
            set;
        }

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
        private string _presetName = string.Empty;
        public string PresetName
        {
            get { return _presetName; }
            set
            {
                _presetName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PresetName)));
            }
        }
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
        public ICommand ChangeRemoteDirectoryCommand { get; }
        public ICommand SaveCurrentPresetCommand { get; }

        //events
        public event PropertyChangedEventHandler? PropertyChanged;


        //constructor
        public MainWindowViewModel()
        {
            try
            {
                _userPresets = UserPresets.InitializeUserPresets();
            }
            catch (Exception ex)
            {
                UserCommunication.DisplayError(ex.Message);
            }
            finally
            {
                if (_userPresets == null)
                {
                    _userPresets = new UserPresets();
                }
            }

            RemoteFileOptions = new ObservableCollection<RemoteFileInfo>();

            RemotePathPresets = new ObservableCollection<string>();

            UserPresetNames = _userPresets.GetPresetNames();

            CurrentPreset = _userPresets.Presets[0];

            //user info
            PresetName = CurrentPreset.PresetName;
            Username = CurrentPreset.UserName;
            Password = CurrentPreset.Password;
            IpAddress = CurrentPreset.IpAddress;

            //commands
            ConnectToRemoteComputerCommand = new RelayCommand(ConnectToRemoteComputer);
            ChangeRemoteDirectoryCommand = new RelayCommand(ChangeRemoteDirectory);
            SaveCurrentPresetCommand = new RelayCommand(SaveCurrentPreset);
        }



        /// <summary>
        /// connects to the remote machine
        /// </summary>
        /// <param name="o"></param>
        private void ConnectToRemoteComputer(object o)
        {
            if (_networkWorker == null)
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
            RemoteFileOptions.Clear();
            foreach (ISftpFile file in list)
            {
                string dir = string.Empty;
                if (file.IsDirectory) { dir = "■"; }
                RemoteFileOptions.Add(new RemoteFileInfo(file.Name, dir));
            }
        }


        private void SaveCurrentPreset(object o)//--------------------------------------------------------------------------------------------------------------------------fix
        {
            UserPreset edit = new UserPreset(PresetName, Username, Password, IpAddress);
            _userPresets.EditPreset(CurrentPreset.Id, edit);
            Serializer.SerializeUserPresets(_userPresets, UserPresets.UserPresetsFilePath);
            UserPresetNames = _userPresets.GetPresetNames();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(UserPresetNames)));
            CurrentPreset = edit;
        }




        /// <summary>
        /// This method is used to navigate through the remote machines files
        /// </summary>
        /// <param name="o"></param>
        private void ChangeRemoteDirectory(object o)
        {
            if (o is string inputDir)
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



        private void SelectLocalFile(object o)
        {
            try
            {

            }
            catch (Exception ex)
            {
                UserCommunication.DisplayError(ex.Message);
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