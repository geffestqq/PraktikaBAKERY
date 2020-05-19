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
using Crypt_Library;


namespace Bakery
{
    /// <summary>
    /// Interaction logic for Sotrudnik.xaml
    /// </summary>
    public partial class Sotrudnik : Window
    {
        public Sotrudnik()
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
                DBConnection.qrSotrudnik = qr;
                connection.SotrudnikFill();
                connection.Dependency.OnChange += Dependency_OnChange;
                dgSotrudnik.ItemsSource = connection.dtSotrudnik.DefaultView;
                dgSotrudnik.Columns[0].Visibility = Visibility.Collapsed;
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
            QR = DBConnection.qrSotrudnik;
            dgFill(QR);
            cbFill();
            cbFill1();

            string path = @"C:\111.txt";
            string text = File.ReadAllText(path);
            if (DBConnection.Key == "False")
            {
                bt_Insert_Sotrudnik.IsEnabled = false;
                bt_Update_Sotrudnik.IsEnabled = false;
                bt_Delete_Sotrudnik.IsEnabled = false;
            }

            if (DBConnection.Key == "True")
            {
                bt_Insert_Sotrudnik.IsEnabled = true;
                bt_Update_Sotrudnik.IsEnabled = true;
                bt_Delete_Sotrudnik.IsEnabled = true;
            }
        }

        private void cbFill()
        {
            DBConnection connection = new DBConnection();
            connection.qrDoljnost_for_cbFill();
            cb_Name_Doljnost.ItemsSource = connection.dtDoljnost_for_cb.DefaultView;
            cb_Name_Doljnost.SelectedValuePath = "ID_Doljnost";
            cb_Name_Doljnost.DisplayMemberPath = "Name_Doljnost";
        }

        private void cbFill1()
        {
            DBConnection connection = new DBConnection();
            connection.qrDocuments_for_cbFill();
            cb_Name_Normativnie_Documenti.ItemsSource = connection.dtDocuments_for_cb.DefaultView;
            cb_Name_Normativnie_Documenti.SelectedValuePath = "ID_Normativnie_Documenti";
            cb_Name_Normativnie_Documenti.DisplayMemberPath = "Name_Normativnie_Documenti";
        }

        private void dgSotrudnik_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            switch (e.Column.Header)
            {
                case ("Familiya_Sotrudnik"):
                    e.Column.Header = "Фамилия сотрудника";
                    break;
                case ("Name_Sotrudnik"):
                    e.Column.Header = "Имя сотрудника";
                    break;
                case ("Otchestvo_Sotrudnik"):
                    e.Column.Header = "Отчество сотрудника";
                    break;
                case ("Date_Rojdeniya"):
                    e.Column.Header = "Дата рождения";
                    break;
                case ("Seriya_Pasporta"):
                    e.Column.Header = "Серия паспорта";
                    break;
                case ("Number_Pasporta"):
                    e.Column.Header = "Номер паспорта";
                    break;
                case ("LoginS"):
                    e.Column.Header = "Логин";
                    break;
                case ("PasswordS"):
                    e.Column.Header = "Пароль";
                    break;
                case ("Name_Doljnost"):
                    e.Column.Header = "Название должности";
                    break;
                case ("Name_Normativnie_Documenti"):
                    e.Column.Header = "Название документ";
                    break;     
            }
        }

        private void bt_Cancel_Click(object sender, RoutedEventArgs e)
        {
            Sotrudnik ps2 = new Sotrudnik();
            ps2.Show();
            Hide();
        }

        private void bt_Insert_Sotrudnik_Click(object sender, RoutedEventArgs e)
        {
            //string value = tb_Number_Pasporta.Text.ToString();
            //tb_Number_Pasporta.Text = Class1.Code_Message(value);

            


            procedures.Sotrudnik_Insert(tb_Familiya_Sotrudnik.Text.ToString(), tb_Name_Sotrudnik.Text.ToString(), tb_Otchestvo_Sotrudnik.Text.ToString(), dp_Date_Rojdeniya.Text.ToString(), tb_Seriya_Pasporta.Text.ToString(), tb_Number_Pasporta.Text.ToString(), tb_LoginS.Text.ToString(), tb_PasswordS.Text.ToString(), Convert.ToInt32(cb_Name_Doljnost.SelectedValue.ToString()), Convert.ToInt32(cb_Name_Normativnie_Documenti.SelectedValue.ToString()));
            dgFill(QR);
            Sotrudnik ps2 = new Sotrudnik();
            ps2.Show();
            Hide();
        }

        private void bt_Search_Click(object sender, RoutedEventArgs e)
        {
            foreach (DataRowView dataRow in (DataView)dgSotrudnik.ItemsSource)
            {
                if (dataRow.Row.ItemArray[1].ToString() == tb_Search.Text ||
                    dataRow.Row.ItemArray[2].ToString() == tb_Search.Text ||
                    dataRow.Row.ItemArray[3].ToString() == tb_Search.Text ||
                    dataRow.Row.ItemArray[4].ToString() == tb_Search.Text ||
                    dataRow.Row.ItemArray[5].ToString() == tb_Search.Text ||
                    dataRow.Row.ItemArray[6].ToString() == tb_Search.Text ||
                    dataRow.Row.ItemArray[7].ToString() == tb_Search.Text ||
                    dataRow.Row.ItemArray[8].ToString() == tb_Search.Text ||
                    dataRow.Row.ItemArray[9].ToString() == tb_Search.Text ||
                    dataRow.Row.ItemArray[10].ToString() == tb_Search.Text)
                {
                    dgSotrudnik.SelectedItem = dataRow;
                }
            }
        }

        private void bt_Update_Sotrudnik_Click(object sender, RoutedEventArgs e)
        {
            DataRowView ID = (DataRowView)dgSotrudnik.SelectedItems[0];
            procedures.Sotrudnik_Update(Convert.ToInt32(ID["ID_Sotrudnik"]), tb_Familiya_Sotrudnik.Text.ToString(), tb_Name_Sotrudnik.Text.ToString(), tb_Otchestvo_Sotrudnik.Text.ToString(), dp_Date_Rojdeniya.Text.ToString(), tb_Seriya_Pasporta.Text.ToString(), tb_Number_Pasporta.Text.ToString(), tb_LoginS.Text.ToString(), tb_PasswordS.Text.ToString(), Convert.ToInt32(cb_Name_Doljnost.SelectedValue.ToString()), Convert.ToInt32(cb_Name_Normativnie_Documenti.SelectedValue.ToString()));

        }

        private void bt_Delete_Sotrudnik_Click(object sender, RoutedEventArgs e)
        {
            DataRowView ID = (DataRowView)dgSotrudnik.SelectedItems[0];
            procedures.Sotrudnik_Delete(Convert.ToInt32(ID["ID_Sotrudnik"]));
            dgFill(QR);
        }

        private void bt_Shifr_Click(object sender, RoutedEventArgs e)
        {
            string value = tb_Shifr.Text.ToString();
            tb_Shifr.Text = Class1.Code_Message(value);
        }
    }
}
