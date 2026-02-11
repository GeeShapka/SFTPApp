using System.Windows.Input;

namespace SFTPApp.Models
{
	/*
	* FILE : RelayCommand.cs
	* PROJECT :
	* PROGRAMMER : George Shapka
	* FIRST VERSION : 2/10/2026 11:02:13 AM
	*/

	/*
	* NAME : RelayCommand
	* PURPOSE : implements ICommand
	*/
	class RelayCommand : ICommand
	{
		private readonly Action _execute;
		private readonly Func<bool>? _canExecute;
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action execute, Func<bool>? canExecute = null)
		{
			_execute = execute;
			_canExecute = canExecute;
		}

		public bool CanExecute(object? parameter)
		{
			return _canExecute?.Invoke() ?? true;
		}
		public void Execute(object? parameter)
		{
			_execute();
			return;
		}
	}//end of RelayCommand
}