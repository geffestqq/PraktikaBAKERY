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
    /// Interaction logic for Doljnost.xaml
    /// </summary>
    public partial class Doljnost : Window
    {
        public Doljnost()
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
                DBConnection.qrDoljnost = qr;
                connection.DoljnostFill();
                connection.Dependency.OnChange += Dependency_OnChange;
                dgDolgnost.ItemsSource = connection.dtDoljnost.DefaultView;
                dgDolgnost.Columns[0].Visibility = Visibility.Collapsed;
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
            QR = DBConnection.qrDoljnost;
            dgFill(QR);

            string path = @"C:\111.txt";
            string text = File.ReadAllText(path);
            if (DBConnection.Key == "False")
            {
                bt_Insert_Dolgnost.IsEnabled = false;
                bt_Update_Dolgnost.IsEnabled = false;
                bt_Delete_Dolgnost.IsEnabled = false;
            }

            if (DBConnection.Key == "True")
            {
                bt_Insert_Dolgnost.IsEnabled = true;
                bt_Update_Dolgnost.IsEnabled = true;
                bt_Delete_Dolgnost.IsEnabled = true;
            }
        }

        private void dgDolgnost_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            switch (e.Column.Header)
            {
                case ("Name_Doljnost"):
                    e.Column.Header = "Название должности";
                    break;
                case ("Oklad"):
                    e.Column.Header = "Оклад";
                    break;
            }
        }

        private void bt_Cancel_Click(object sender, RoutedEventArgs e)
        {
            Doljnost ps2 = new Doljnost();
            ps2.Show();
            Hide();
        }

        private void bt_Insert_Dolgnost_Click(object sender, RoutedEventArgs e)
        {
            procedures.Doljnost_Insert(tb_Name_Doljnost.Text.ToString(), Convert.ToDecimal(tb_Oklad.Text.ToString()));
            dgFill(QR);

            Doljnost ps2 = new Doljnost();
            ps2.Show();
            Hide();
        }

        private void bt_Update_Dolgnost_Click(object sender, RoutedEventArgs e)
        {
            DataRowView ID = (DataRowView) dgDolgnost.SelectedItems[0];
            procedures.Doljnost_Update(Convert.ToInt32(ID["ID_Doljnost"]), tb_Name_Doljnost.Text.ToString(), Convert.ToDecimal(tb_Oklad.Text.ToString()));

        }

        private void bt_Delete_Dolgnost_Click(object sender, RoutedEventArgs e)
        {
            DataRowView ID = (DataRowView)dgDolgnost.SelectedItems[0];
            procedures.Doljnost_Delete(Convert.ToInt32(ID["ID_Doljnost"]));
            dgFill(QR);
        }

        private void bt_Search_Click(object sender, RoutedEventArgs e)
        {
            foreach (DataRowView dataRow in (DataView)dgDolgnost.ItemsSource)
            {
                if (dataRow.Row.ItemArray[1].ToString() == tb_Search.Text ||
                    dataRow.Row.ItemArray[2].ToString() == tb_Search.Text)
                {
                    dgDolgnost.SelectedItem = dataRow;
                }
            }
        }
    }
}
