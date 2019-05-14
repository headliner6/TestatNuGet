using System;
using System.Windows.Input;

namespace TestatNuGet.ViewModel
{
    public class FindDuplicatesButtonCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private LogentriesViewModel _logentriesViewModel;
        public FindDuplicatesButtonCommand(LogentriesViewModel lvm)
        {
            this._logentriesViewModel = lvm;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            _logentriesViewModel.CheckForDuplicates();
        }
    }
}
