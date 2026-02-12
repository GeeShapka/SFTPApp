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
		private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
		{
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
		}

		public bool CanExecute(object parameter)
		{
            return _canExecute == null || _canExecute(parameter);
        }
		public void Execute(object parameter)
		{
			_execute(parameter);
			return;
		}
	}//end of RelayCommand
}