﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TestatNuGet.ViewModel
{
    public class AddButtonCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private LogentriesViewModel _logentriesViewModel;
        public AddButtonCommand(LogentriesViewModel lvm)
        {
            this._logentriesViewModel = lvm;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            _logentriesViewModel.ShowLogMessageAddView();
        }
    }
}
