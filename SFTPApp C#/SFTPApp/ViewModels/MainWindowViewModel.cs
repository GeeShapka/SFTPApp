using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
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
	public class MainWindowViewModel : INotifyPropertyChanged
    {
		private NetworkWorker? _networkWorker;
		public ObservableCollection<RemoteFileInfo> FileOptions { get; }

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
		public ICommand ConnectToRemoteComputerCommand {  get; }

		//events
		public event PropertyChangedEventHandler? PropertyChanged;

		public MainWindowViewModel()
		{
			FileOptions = new ObservableCollection<RemoteFileInfo>();
			ICollectionView view = CollectionViewSource.GetDefaultView(FileOptions);
            view.SortDescriptions.Add(new SortDescription("IsDirectory", ListSortDirection.Ascending));//work on this----------------------------------------------------------------
            view.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));//work on this----------------------------------------------------------------

            //user info
            Username = "george";
			Password = "2395";
			IpAddress = "100.108.227.107";

			//commands
			ConnectToRemoteComputerCommand = new RelayCommand(ConnectToRemoteComputer);
		}

		private void ConnectToRemoteComputer()//work on this----------------------------------------------------------------
		{
			_networkWorker = new NetworkWorker(IpAddress, Username, Password);
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
	}//end of MainWindowViewModel
}