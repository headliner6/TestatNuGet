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

        /*
        private void Button_confirm_Click(object sender, RoutedEventArgs e)
        {
            FrameworkElement fe = sender as FrameworkElement;
            ((LogentriesViewModel)fe.DataContext).ConfirmLogentries();
        }
        private void Button_add_Click(object sender, RoutedEventArgs e)
        {
            FrameworkElement fe = sender as FrameworkElement;
            ((LogentriesViewModel)fe.DataContext).AddMessage();
        }
        */
    }
}
