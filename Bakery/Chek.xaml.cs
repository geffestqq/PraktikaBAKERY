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
    /// Interaction logic for Chek.xaml
    /// </summary>
    public partial class Chek : Window
    {
        public Chek()
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
                DBConnection.qrChek = qr;
                connection.ChekFill();
                connection.Dependency.OnChange += Dependency_OnChange;
                dgChek.ItemsSource = connection.dtChek.DefaultView;
                dgChek.Columns[0].Visibility = Visibility.Collapsed;
            };

            Dispatcher.Invoke(action);
        }
        private void cbFill1()
        {
            DBConnection connection = new DBConnection();
            connection.qrSotrudnik_for_cbFill();
            cb_Sotrudnik_Info.ItemsSource = connection.dtSotrudnik_for_cb.DefaultView;
            cb_Sotrudnik_Info.SelectedValuePath = "ID_Sotrudnik";
            cb_Sotrudnik_Info.DisplayMemberPath = "Sotrudnik_Info";
        }

        private void cbFill2()
        {
            DBConnection connection = new DBConnection();
            connection.qrKlient_for_cbFill();
            cb_Klient_Info.ItemsSource = connection.dtKlient_for_cb.DefaultView;
            cb_Klient_Info.SelectedValuePath = "ID_Klient";
            cb_Klient_Info.DisplayMemberPath = "Klient_Info";
        }

        private void cbFill3()
        {
            DBConnection connection = new DBConnection();
            connection.qrTovar_for_cbFill();
            cb_Name_Tovar.ItemsSource = connection.dtTovar_for_cb.DefaultView;
            cb_Name_Tovar.SelectedValuePath = "ID_Tovar";
            cb_Name_Tovar.DisplayMemberPath = "Name_Tovar";
        }

        private void cbFill4()
        {
            DBConnection connection = new DBConnection();
            connection.qrType_Zakaz_for_cbFill();
            cb_Name_Type_Zakaz.ItemsSource = connection.dtType_Zakaz_for_cb.DefaultView;
            cb_Name_Type_Zakaz.SelectedValuePath = "ID_Type_Zakaz";
            cb_Name_Type_Zakaz.DisplayMemberPath = "Name_Type_Zakaz";
        }

        private void bt_Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow ps2 = new MainWindow();
            ps2.Show();
            Hide();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            QR = DBConnection.qrChek;
            dgFill(QR);
            cbFill1();
            cbFill2();
            cbFill3();
            cbFill4();

            string path = @"C:\111.txt";
            string text = File.ReadAllText(path);
            if (DBConnection.Key == "False")
            {
                bt_Insert_Chek.IsEnabled = false;
                bt_Update_Chek.IsEnabled = false;
                bt_Delete_Chek.IsEnabled = false;
            }

            if (DBConnection.Key == "True")
            {
                bt_Insert_Chek.IsEnabled = true;
                bt_Update_Chek.IsEnabled = true;
                bt_Delete_Chek.IsEnabled = true;
            }
        }

        private void dgChek_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            switch (e.Column.Header)
            {
                case ("Number_Chek"):
                    e.Column.Header = "Номер чека";
                    break;
                case ("Date_Pechat"):
                    e.Column.Header = "Дата печати";
                    break;
                case ("Familiya_Sotrudnik"):
                    e.Column.Header = "Фамилия сотрудника";
                    break;
                case ("Name_Sotrudnik"):
                    e.Column.Header = "Имя сотрудника";
                    break;
                case ("Otchestvo_Sotrudnik"):
                    e.Column.Header = "Отчество сотрудника";
                    break;
                case ("Familiya_Klient"):
                    e.Column.Header = "Фамилия клинета";
                    break;
                case ("Name_Klient"):
                    e.Column.Header = "Имя клиента";
                    break;
                case ("Otchestvo_Klient"):
                    e.Column.Header = "Отчество клиента";
                    break;
                case ("Name_Tovar"):
                    e.Column.Header = "Название товара";
                    break;
                case ("Name_Type_Zakaz"):
                    e.Column.Header = "Тип заказа";
                    break;
            }
        }

        private void bt_Insert_Chek_Click(object sender, RoutedEventArgs e)
        {
            procedures.Chek_Insert(Convert.ToInt32(tb_Number_Chek.Text.ToString()), tb_Date_Pechat.Text.ToString(), Convert.ToInt32(cb_Sotrudnik_Info.SelectedValue.ToString()), Convert.ToInt32(cb_Klient_Info.SelectedValue.ToString()), Convert.ToInt32(cb_Name_Tovar.SelectedValue.ToString()), Convert.ToInt32(cb_Name_Type_Zakaz.SelectedValue.ToString()));
            dgFill(QR);
            Chek ps2 = new Chek();
            ps2.Show();
            Hide();
        }

        private void bt_Update_Chek_Click(object sender, RoutedEventArgs e)
        {
            DataRowView ID = (DataRowView)dgChek.SelectedItems[0];
            procedures.Chek_Update(Convert.ToInt32(ID["ID_Chek"]), Convert.ToInt32(tb_Number_Chek.Text.ToString()), tb_Date_Pechat.Text.ToString(), Convert.ToInt32(cb_Sotrudnik_Info.SelectedValue.ToString()), Convert.ToInt32(cb_Klient_Info.SelectedValue.ToString()), Convert.ToInt32(cb_Name_Tovar.SelectedValue.ToString()), Convert.ToInt32(cb_Name_Type_Zakaz.SelectedValue.ToString()));
            Chek ps2 = new Chek();
            ps2.Show();
            Hide();
        }

        private void bt_Delete_Chek_Click(object sender, RoutedEventArgs e)
        {
            DataRowView ID = (DataRowView)dgChek.SelectedItems[0];
            procedures.Chek_Delete(Convert.ToInt32(ID["ID_Chek"]));
            dgFill(QR);
        }

        private void bt_Cancel_Click(object sender, RoutedEventArgs e)
        {
            Chek ps2 = new Chek();
            ps2.Show();
            Hide();
        }

        private void bt_Search_Click(object sender, RoutedEventArgs e)
        {
            foreach (DataRowView dataRow in (DataView)dgChek.ItemsSource)
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
                   dataRow.Row.ItemArray[10].ToString() == tb_Search.Text ||
                    dataRow.Row.ItemArray[11].ToString() == tb_Search.Text)
                {
                    dgChek.SelectedItem = dataRow;
                }
            }
        }
    }
}
