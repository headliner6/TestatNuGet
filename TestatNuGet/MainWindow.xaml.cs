using System.Windows;
using TestatNuGet.ViewModel;

namespace TestatNuGet
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new NavigationViewModel();
        }
    }
}
