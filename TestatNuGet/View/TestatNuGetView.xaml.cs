using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TestatNuGet.ViewModel;

namespace TestatNuGet.View
{
    /// <summary>
    /// Interaction logic for TestatNuGetView.xaml
    /// </summary>
    public partial class TestatNuGetView : UserControl
    {
        private LogentriesViewModel lvm;
        public TestatNuGetView()
        {
            InitializeComponent();
            lvm = new LogentriesViewModel();
            this.DataContext = lvm;
        }

        private void Button_load_Click(object sender, RoutedEventArgs e)
        {
            FrameworkElement fe = sender as FrameworkElement;
            ((LogentriesViewModel)fe.DataContext).LoadLogentries();
        }
    }
}
