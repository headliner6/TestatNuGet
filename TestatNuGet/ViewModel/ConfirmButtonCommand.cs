using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestatNuGet.Model;

namespace TestatNuGet.ViewModel
{
    public class ConfirmButtonCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private LogentriesViewModel _logentriesViewModel;
        public ConfirmButtonCommand(LogentriesViewModel lvm)
        {
            this._logentriesViewModel = lvm;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            LogentriesModel lm = (LogentriesModel)parameter;
            _logentriesViewModel.ConfirmLogentries(lm.Id);
            _logentriesViewModel.LoadLogentries();
        }
    }
}
