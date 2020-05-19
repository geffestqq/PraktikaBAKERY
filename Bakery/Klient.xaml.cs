using Crypt_Library;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Interaction logic for Klient.xaml
    /// </summary>
    public partial class Klient : Window
    {
        public Klient()
        {
            InitializeComponent();
        }

        private string QR = "";
        DBProcedures procedures = new DBProcedures();

        private void Dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Info != SqlNotificationInfo.Invalid)
                dgFill(QR);
        }

        private void dgFill(string qr)
        {
            Action action = () =>
            {
                DBConnection connection = new DBConnection();
                DBConnection.qrKlient = qr;
                connection.KlientFill();
                connection.Dependency.OnChange += Dependency_OnChange;
                dgKlient.ItemsSource = connection.dtKlient.DefaultView;
                dgKlient.Columns[0].Visibility = Visibility.Collapsed;
            };

            Dispatcher.Invoke(action);
        }

        private void bt_Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow ps2 = new MainWindow();
            ps2.Show();
            Hide();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            

            QR = DBConnection.qrKlient;
            dgFill(QR);
            string path = @"C:\111.txt";
            string text = File.ReadAllText(path);
            if (DBConnection.Key == "False")
            {
                bt_Insert_Klient.IsEnabled = false;
                bt_Update_Klient.IsEnabled = false;
                bt_Delete_Klient.IsEnabled = false;
            }

            if (DBConnection.Key == "True")
            {
                bt_Insert_Klient.IsEnabled = true;
                bt_Update_Klient.IsEnabled = true;
                bt_Delete_Klient.IsEnabled = true;
            }

        }

        private void dgKlient_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            switch (e.Column.Header)
            {
                case ("Familiya_Klient"):
                    e.Column.Header = "Фамилия клинета";
                    break;
                case ("Name_Klient"):
                    e.Column.Header = "Имя клиента";
                    break;
                case ("Otchestvo_Klient"):
                    e.Column.Header = "Отчество клиента";
                    break;
            }
        }

        private void bt_Cancel_Click(object sender, RoutedEventArgs e)
        {
            Klient ps2 = new Klient();
            ps2.Show();
            Hide();
        }

        private void bt_Insert_Klient_Click(object sender, RoutedEventArgs e)
        {

            string Familiya_Klient = tb_Familiya_Klient.Text.ToString();
            tb_Familiya_Klient.Text = Class1.Code_Message(Familiya_Klient);
            string Name_Klient = tb_Name_Klient.Text.ToString();
            tb_Name_Klient.Text = Class1.Code_Message(Name_Klient);
            string Otchestvo_Klient = tb_Otchestvo_Klient.Text.ToString();
            tb_Otchestvo_Klient.Text = Class1.Code_Message(Otchestvo_Klient);


            procedures.Klient_Insert(tb_Familiya_Klient.Text.ToString(), tb_Name_Klient.Text.ToString(), tb_Otchestvo_Klient.Text.ToString());
            dgFill(QR);

            Klient ps2 = new Klient();
            ps2.Show();
            Hide();
        }

        private void bt_Update_Klient_Click(object sender, RoutedEventArgs e)
        {
            DataRowView ID = (DataRowView)dgKlient.SelectedItems[0];
            procedures.Klient_Update(Convert.ToInt32(ID["ID_Klient"]), tb_Familiya_Klient.Text.ToString(), tb_Name_Klient.Text.ToString(), tb_Otchestvo_Klient.Text.ToString());
        }

        private void bt_Delete_Klient_Click(object sender, RoutedEventArgs e)
        {
            DataRowView ID = (DataRowView)dgKlient.SelectedItems[0];
            procedures.Klient_Delete(Convert.ToInt32(ID["ID_Klient"]));
            dgFill(QR);
        }

        private void bt_Search_Click(object sender, RoutedEventArgs e)
        {
            foreach (DataRowView dataRow in (DataView)dgKlient.ItemsSource)
            {
                if (dataRow.Row.ItemArray[1].ToString() == tb_Search.Text ||
                    dataRow.Row.ItemArray[2].ToString() == tb_Search.Text ||
                    dataRow.Row.ItemArray[3].ToString() == tb_Search.Text)
                {
                    dgKlient.SelectedItem = dataRow;
                }
            }
        }

        private void bt_Shifr_Click(RoutedEventArgs e)
        {

        }

        private void bt_Shifr_Click(object sender, RoutedEventArgs e)
        {

            if (Pass.Text.ToString() == "12345")
            {
                string Familiya_Klient = tb_Familiya_Klient.Text.ToString();
                tb_Familiya_Klient.Text = Class1.Code_Message(Familiya_Klient);
                string Name_Klient = tb_Name_Klient.Text.ToString();
                tb_Name_Klient.Text = Class1.Code_Message(Name_Klient);
                string Otchestvo_Klient = tb_Otchestvo_Klient.Text.ToString();
                tb_Otchestvo_Klient.Text = Class1.Code_Message(Otchestvo_Klient);
                MessageBox.Show("Данные расшифрованны");
                Pass.Clear();
                
            }
            else
            {
                MessageBox.Show("Пароль расшифровки неверный!");

            }



            
        }
    }
}
