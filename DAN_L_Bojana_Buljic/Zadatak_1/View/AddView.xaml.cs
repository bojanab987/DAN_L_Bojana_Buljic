using System.Windows;

namespace Zadatak_1.View
{
    /// <summary>
    /// Interaction logic for AddView.xaml
    /// </summary>
    public partial class AddView : Window
    {
        public AddView()
        {
            InitializeComponent();
            this.DataContext = new AddSongViewModel(this, user);
        }
    }
}
