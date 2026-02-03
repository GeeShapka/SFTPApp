using System.Collections.ObjectModel;
using System.IO;
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
	public class MainWindowViewModel
	{
		public ObservableCollection<RemoteFileInfo> FileOptions { get; }
		public MainWindowViewModel()
		{
			FileOptions = new ObservableCollection<RemoteFileInfo>();
			FileOptions.Add(new RemoteFileInfo("file1"));
			FileOptions.Add(new RemoteFileInfo("file2"));
			FileOptions.Add(new RemoteFileInfo("file3"));
		}
	}//end of MainWindowViewModel
}