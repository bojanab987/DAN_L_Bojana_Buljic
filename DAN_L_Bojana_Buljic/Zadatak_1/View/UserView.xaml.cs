using System.Windows;
using Zadatak_1.Model;
using Zadatak_1.ViewModel;

namespace Zadatak_1.View
{
    /// <summary>
    /// Interaction logic for UserView.xaml
    /// </summary>
    public partial class UserView : Window
    {
        public UserView(vwUser user)
        {
            InitializeComponent();
            this.DataContext = new UserViewModel(this, user);
        }
    }
}
