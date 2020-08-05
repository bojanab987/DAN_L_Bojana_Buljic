using System.Windows;
using Zadatak_1.Model;
using Zadatak_1.ViewModel;

namespace Zadatak_1.View
{
    /// <summary>
    /// Interaction logic for AddView.xaml
    /// </summary>
    public partial class AddView : Window
    {
        public AddView(vwUser user)
        {
            InitializeComponent();
            this.DataContext = new AddViewModel(this, user);
        }
    }
}
