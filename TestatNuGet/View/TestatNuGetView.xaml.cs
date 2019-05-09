using System.Windows;
using System.Windows.Controls;
using TestatNuGet.ViewModel;

namespace TestatNuGet.View
{
    public partial class TestatNuGetView : UserControl
    {
        public TestatNuGetView()
        {
            InitializeComponent();
        }

        private void Button_load_Click(object sender, RoutedEventArgs e)
        {
            FrameworkElement fe = sender as FrameworkElement;
            ((LogentriesViewModel)fe.DataContext).LoadLogentries();
        }
    }
}
