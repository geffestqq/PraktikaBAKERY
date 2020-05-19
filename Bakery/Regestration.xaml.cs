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
using System.Windows.Shapes;

namespace Bakery
{
    /// <summary>
    /// Interaction logic for Regestration.xaml
    /// </summary>
    public partial class Regestration : Window
    {
        DBProcedures procedures = new DBProcedures();

        public Regestration()
        {
            InitializeComponent();
        }

        private void bt_Cancel_Click(object sender, RoutedEventArgs e)
        {
            AuthorizationPage ps2 = new AuthorizationPage();
            ps2.Show();
            Hide();
        }

        private void bt_Reg_Sotr_Click(object sender, RoutedEventArgs e)
        {
            procedures.Regestration(tb_Familiya_Sotrudnik.Text.ToString(), tb_Name_Sotrudnik.Text.ToString(), tb_Otchestvo_Sotrudnik.Text.ToString(), tb_LoginS.Text.ToString(), tb_PasswordS.Text.ToString());
            MessageBox.Show("Не забудте дозаполнить данные о новом сотруднике");
            AuthorizationPage ps2 = new AuthorizationPage();
            ps2.Show();
            Hide();
        }
    }
}
