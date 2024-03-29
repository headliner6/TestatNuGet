﻿using System;
using System.Linq;
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
            if (parameter != null)
            {
                System.Collections.IList sellectedItems = (System.Collections.IList)parameter;
                var sellectedItemscollection = sellectedItems.Cast<LogentriesModel>().ToList();
                foreach (var lm in sellectedItemscollection)
                {
                    _logentriesViewModel.ConfirmLogentries(lm.Id);
                    _logentriesViewModel.LoadLogentries();
                }
            }
        }
    }
}
