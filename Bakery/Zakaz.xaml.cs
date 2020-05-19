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
    /// Interaction logic for Zakaz.xaml
    /// </summary>
    public partial class Zakaz : Window
    {
        public Zakaz()
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
                DBConnection.qrZakaz = qr;
                connection.ZakazFill();
                connection.Dependency.OnChange += Dependency_OnChange;
                dgZakaz.ItemsSource = connection.dtZakaz.DefaultView;
                dgZakaz.Columns[0].Visibility = Visibility.Collapsed;
            };

            Dispatcher.Invoke(action);
        }

        private void cbFill()
        {
            DBConnection connection = new DBConnection();
            connection.qrStatus_Zakaza__for_cbFill();
            cb_Sostiyanie_Zakaza.ItemsSource = connection.dtStatus_Zakaza_for_cb.DefaultView;
            cb_Sostiyanie_Zakaza.SelectedValuePath = "ID_Status_Zakaza";
            cb_Sostiyanie_Zakaza.DisplayMemberPath = "Sostiyanie_Zakaza";
        }


        private void bt_Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow ps2 = new MainWindow();
            ps2.Show();
            Hide();
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            QR = DBConnection.qrZakaz;
            dgFill(QR);
            cbFill();
            cbFill1();
            cbFill2();
            cbFill3();

            string path = @"C:\111.txt";
            string text = File.ReadAllText(path);
            if (DBConnection.Key == "False")
            {
                bt_Insert_Zakaz.IsEnabled = false;
                bt_Update_Zakaz.IsEnabled = false;
                bt_Delete_Zakaz.IsEnabled = false;
            }

            if (DBConnection.Key == "True")
            {
                bt_Insert_Zakaz.IsEnabled = true;
                bt_Update_Zakaz.IsEnabled = true;
                bt_Delete_Zakaz.IsEnabled = true;
            }
        }

        private void bt_Cancel_Click(object sender, RoutedEventArgs e)
        {
            Zakaz ps2 = new Zakaz();
            ps2.Show();
            Hide();
        }

        private void dgZakaz_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            switch (e.Column.Header)
            {
                case ("Number_Zakaz"):
                    e.Column.Header = "Номер заказа";
                    break;
                case ("Kolichestvo"):
                    e.Column.Header = "Количество";
                    break;
                case ("Summa"):
                    e.Column.Header = "Сумма";
                    break;
                case ("Date_Prodaji"):
                    e.Column.Header = "Дата продажи";
                    break;
                case ("Sostiyanie_Zakaza"):
                    e.Column.Header = "Состояние заказа";
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
            }
        }

        private void bt_Insert_Zakaz_Click(object sender, RoutedEventArgs e)
        {
            procedures.Zakaz_Insert(Convert.ToInt32(tb_Number_Zakaz.Text.ToString()), 
           Convert.ToInt32(tb_Kolichestvo.Text.ToString()), Convert.ToDecimal(tb_Summa.Text.ToString()), 
           dp_Date_Prodaji.Text.ToString(), Convert.ToInt32(cb_Sostiyanie_Zakaza.SelectedValue.ToString()), 
           Convert.ToInt32(cb_Sotrudnik_Info.SelectedValue.ToString()), Convert.ToInt32(cb_Klient_Info.SelectedValue.ToString()), 
           Convert.ToInt32(cb_Name_Tovar.SelectedValue.ToString()));
            dgFill(QR);

            Zakaz ps2 = new Zakaz();
            ps2.Show();
            Hide();
        }

        private void bt_Update_Zakaz_Click(object sender, RoutedEventArgs e)
        {
            DataRowView ID = (DataRowView)dgZakaz.SelectedItems[0];
            procedures.Zakaz_Update(Convert.ToInt32(ID["ID_Zakaz"]), Convert.ToInt32(tb_Number_Zakaz.Text.ToString()), Convert.ToInt32(tb_Kolichestvo.Text.ToString()), Convert.ToDecimal(tb_Summa.Text.ToString()), dp_Date_Prodaji.Text.ToString(), Convert.ToInt32(cb_Sostiyanie_Zakaza.SelectedValue.ToString()), Convert.ToInt32(cb_Sotrudnik_Info.SelectedValue.ToString()), Convert.ToInt32(cb_Klient_Info.SelectedValue.ToString()), Convert.ToInt32(cb_Name_Tovar.SelectedValue.ToString()));

        }

        private void bt_Delete_Zakaz_Click(object sender, RoutedEventArgs e)
        {
            DataRowView ID = (DataRowView)dgZakaz.SelectedItems[0];
            procedures.Zakaz_Delete(Convert.ToInt32(ID["ID_Zakaz"]));
            dgFill(QR);

        }

        private void bt_Search_Click(object sender, RoutedEventArgs e)
        {
            foreach (DataRowView dataRow in (DataView)dgZakaz.ItemsSource)
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
                   dataRow.Row.ItemArray[11].ToString() == tb_Search.Text ||
                    dataRow.Row.ItemArray[12].ToString() == tb_Search.Text)
                {
                    dgZakaz.SelectedItem = dataRow;
                }
            }
        }
    }
}
