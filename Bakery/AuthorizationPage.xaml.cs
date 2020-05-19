using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace Bakery
{
    /// <summary>
    /// Interaction logic for AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Window
    {
       

        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void bt_Enter_Click(object sender, RoutedEventArgs e)
        {
            string path = @"C:\111.txt";
            string text = File.ReadAllText(path);

            if (text == "0")
            {
                DBConnection.Key = "False";
            }

            if (text == "123")
            {
                DBConnection.Key = "True";
            }


            DBProcedures procedures = new DBProcedures();
            Int32 ID_Record = procedures.Authorization(tbEnterLogin.Password.ToString(), tbEnterPassword.Password.ToString());
            
            if (ID_Record == 0)
            {
                tbEnterLogin.Clear();
                tbEnterPassword.Clear();
                MessageBox.Show("Не верно введён логин или пароль! " +
                    "\n Повторите попытку ввода!", "Пекарня+",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                DBConnection.IDuser = ID_Record;
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Visibility = Visibility.Collapsed;
            }
            
        
        }

        private void bt_Regestration_Click(object sender, RoutedEventArgs e)
        {
            Regestration ps2 = new Regestration();
            ps2.Show();
            Hide();
        }
    }
}
