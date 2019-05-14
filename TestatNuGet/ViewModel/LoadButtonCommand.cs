using System;
using System.Windows.Input;

namespace TestatNuGet.ViewModel
{
    public class LoadButtonCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private LogentriesViewModel _logentriesViewModel;
        public LoadButtonCommand(LogentriesViewModel lvm)
        {
            this._logentriesViewModel = lvm;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            _logentriesViewModel.LoadLogentries();
        }
    }
}
