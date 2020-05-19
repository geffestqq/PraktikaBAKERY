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
    /// Interaction logic for Sirie.xaml
    /// </summary>
    public partial class Sirie : Window
    {
        public Sirie()
        {
            InitializeComponent();
        }

        private void bt_Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow ps2 = new MainWindow();
            ps2.Show();
            Hide();
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
                DBConnection.qrSirie = qr;
                connection.SirieFill();
                connection.Dependency.OnChange += Dependency_OnChange;
                dgSirie.ItemsSource = connection.dtSirie.DefaultView;
                dgSirie.Columns[0].Visibility = Visibility.Collapsed;
            };

            Dispatcher.Invoke(action);
        }

        private void cbFill()
        {
            DBConnection connection = new DBConnection();
            connection.qrPostavhik_for_cbFill();
            cb_Info_Supplier.ItemsSource = connection.dtPostavhik_for_cb.DefaultView;
            cb_Info_Supplier.SelectedValuePath = "ID_Postavhik";
            cb_Info_Supplier.DisplayMemberPath = "Postavhik_Info";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            QR = DBConnection.qrSirie;
            dgFill(QR);
            cbFill();

            string path = @"C:\111.txt";
            string text = File.ReadAllText(path);
            if (DBConnection.Key == "False")
            {
                bt_Insert_Sirie.IsEnabled = false;
                bt_Update_Sirie.IsEnabled = false;
                bt_Delete_Sirie.IsEnabled = false;
            }

            if (DBConnection.Key == "True")
            {
                bt_Insert_Sirie.IsEnabled = true;
                bt_Update_Sirie.IsEnabled = true;
                bt_Delete_Sirie.IsEnabled = true;
            }
        }

        private void dgSirie_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            switch (e.Column.Header)
            {
                case ("Name_Sirie"):
                    e.Column.Header = "Название сырья";
                    break;
                case ("Date_Postavki"):
                    e.Column.Header = "Дата поставки";
                    break;
                case ("Familiya_Postavhik"):
                    e.Column.Header = "Фамилия поставщика";
                    break;
                case ("Name_Postavhik"):
                    e.Column.Header = "Имя поставщика";
                    break;
                case ("Otchestvo_Postavhik"):
                    e.Column.Header = "Отчество поставщика";
                    break;
            }
        }

        private void bt_Cancel_Click(object sender, RoutedEventArgs e)
        {
            Sirie ps2 = new Sirie();
            ps2.Show();
            Hide();
        }

        private void bt_Insert_Sirie_Click(object sender, RoutedEventArgs e)
        {
            procedures.Sirie_Insert(tb_Name_Sirie.Text.ToString(), dp_Date_Postavki.Text.ToString(), Convert.ToInt32(cb_Info_Supplier.SelectedValue.ToString()));
            dgFill(QR);
            cbFill();
            Sirie ps2 = new Sirie();
            ps2.Show();
            Hide();
        }

        private void bt_Search_Click(object sender, RoutedEventArgs e)
        {
            foreach (DataRowView dataRow in (DataView)dgSirie.ItemsSource)
            {
                if (dataRow.Row.ItemArray[1].ToString() == tb_Search.Text ||
                    dataRow.Row.ItemArray[2].ToString() == tb_Search.Text ||
                    dataRow.Row.ItemArray[3].ToString() == tb_Search.Text ||
                    dataRow.Row.ItemArray[4].ToString() == tb_Search.Text ||
                    dataRow.Row.ItemArray[5].ToString() == tb_Search.Text)
                {
                    dgSirie.SelectedItem = dataRow;
                }
            }
        }

        private void bt_Update_Sirie_Click(object sender, RoutedEventArgs e)
        {
            DataRowView ID = (DataRowView) dgSirie.SelectedItems[0];
            procedures.Sirie_Update(Convert.ToInt32(ID["ID_Sirie"]), tb_Name_Sirie.Text.ToString(), dp_Date_Postavki.Text.ToString(), Convert.ToInt32(cb_Info_Supplier.SelectedValue.ToString()));

        }

        private void bt_Delete_Sirie_Click(object sender, RoutedEventArgs e)
        {
            DataRowView ID = (DataRowView) dgSirie.SelectedItems[0];
            procedures.Sirie_Delete(Convert.ToInt32(ID["ID_Sirie"]));
            dgFill(QR);
        }
    }
}
