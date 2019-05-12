using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TestatNuGet.ViewModel
{
    public class NavigationViewModel : INotifyPropertyChanged
    {
        public ICommand LoadLogentriesView { get; set; }
        public ICommand LoadLogMessageView { get; set; }
        private object selectedViewModel;
        public object SelectedViewModel
        {
            get { return selectedViewModel; }
            set { selectedViewModel = value; OnPropertyChanged("SelectedViewModel"); }
        }
        public NavigationViewModel()
        {
            SelectedViewModel = new LogentriesViewModel(OpenLogMessageAddView);
        }
        private void OpenLogMessageAddView(object obj)
        {
            if (obj.ToString() == "LogMessageAddView")
            {
                LogentriesViewModel lvm = (LogentriesViewModel)selectedViewModel;
                SelectedViewModel = new LogMessageAddViewModel(OpenLogentriesView);
                LogMessageAddViewModel lmavm = (LogMessageAddViewModel)selectedViewModel;
                lmavm.ConnectionString = lvm.ConnectionString;
            }
        }
        private void OpenLogentriesView(object obj)
        {
            if (obj.ToString() == "LogentriesView")
            {
                LogMessageAddViewModel lmavm = (LogMessageAddViewModel)selectedViewModel;
                SelectedViewModel = new LogentriesViewModel(OpenLogMessageAddView);
                LogentriesViewModel lvm = (LogentriesViewModel)selectedViewModel;
                lvm.ConnectionString = lmavm.ConnectionString;
                lvm.LoadLogentries();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }


        public class BaseCommand : ICommand
        {
            private Predicate<object> _canExecute;
            private Action<object> _method;
            public event EventHandler CanExecuteChanged;

            public BaseCommand(Action<object> method)
                : this(method, null)
            {
            }

            public BaseCommand(Action<object> method, Predicate<object> canExecute)
            {
                _method = method;
                _canExecute = canExecute;
            }

            public bool CanExecute(object parameter)
            {
                if (_canExecute == null)
                {
                    return true;
                }

                return _canExecute(parameter);
            }

            public void Execute(object parameter)
            {
                _method.Invoke(parameter);
            }
        }
    }
}
