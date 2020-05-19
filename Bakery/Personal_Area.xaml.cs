using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for Personal_Area.xaml
    /// </summary>
    public partial class Personal_Area : Window
    {
        public Personal_Area()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lbl_FIO_2.Content = DBConnection.FIO;
        }

        private void bt_Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow ps2 = new MainWindow();
            ps2.Show();
            Hide();
        }

        private void bt_Update_Click(object sender, RoutedEventArgs e)
        {

            DBProcedures procedures = new DBProcedures();
            
            procedures.Login_Password_Update(DBConnection.ID_Sotrudnik, tb_Login.Text.ToString(), tb_Password.Text.ToString());
            DBConnection.Log = tb_Login.Text.ToString();
            DBConnection.Pass = tb_Password.Text.ToString();



        }
    }
}
