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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Database factory_db = new Database();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(AccessCombobox.SelectedIndex == 1 || AccessCombobox.SelectedIndex == 2) {
                UserNameTextbox.IsEnabled = true;
                PassBox.IsEnabled = true;
            } 
            if (AccessCombobox.SelectedIndex == 0)
            {
                UserNameTextbox.IsEnabled = false;
                PassBox.IsEnabled = false;
            }
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            if (AccessCombobox.SelectedIndex == 1 || AccessCombobox.SelectedIndex == 2) {
                int access_level = AccessCombobox.SelectedIndex;
                string username = UserNameTextbox.Text;
                string password = PassBox.Password;
                if (access_level == 2 &&  username =="admin" && password == "admin")
                {
                    Admin admin_window = new Admin();
                    admin_window.Show();
                    Hide();
                    
                } else if (access_level == 1 &&  username =="loader" && password == "1234") {
                    Loader loader_window = new Loader();
                    loader_window.Show();
                    Hide();
                } 
            }
            else if (AccessCombobox.SelectedIndex == 0)
            {
                View view_window = new View();
                view_window.Show();
                Hide();
            }
        }
    }
}
