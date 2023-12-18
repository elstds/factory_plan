using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable table = new DataTable();

                string querrystring = $"SELECT username, password, access_level FROM dbo.users WHERE username='{username}' and password='{password}' and access_level='{access_level}'";
                SqlCommand command = new SqlCommand(querrystring, factory_db.getConnection());
                adapter.SelectCommand = command;
                adapter.Fill(table);
                if (access_level == 2 &&  table.Rows.Count == 1)
                {
                    Admin admin_window = new Admin();
                    admin_window.Show();
                    Hide();
                    
                } else if (access_level == 1 && table.Rows.Count == 1) {
                    Loader loader_window = new Loader();
                    loader_window.Show();
                    Hide();
                } else
                {
                    MessageBox.Show("Учетная запись не найдена.");
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
