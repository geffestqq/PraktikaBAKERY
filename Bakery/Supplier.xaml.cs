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
    /// Interaction logic for Supplier.xaml
    /// </summary>
    public partial class Supplier : Window
    {
        public Supplier()
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
                DBConnection.qrPostavhik = qr;
                connection.PostavhikFill();
                connection.Dependency.OnChange += Dependency_OnChange;
                dgSupplier.ItemsSource = connection.dtPostavhik.DefaultView;
                dgSupplier.Columns[0].Visibility = Visibility.Collapsed;
            };

            Dispatcher.Invoke(action);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            QR = DBConnection.qrPostavhik;
            dgFill(QR);
            cbFill();

            string path = @"C:\111.txt";
            string text = File.ReadAllText(path);
            if (DBConnection.Key == "False")
            {
                bt_Insert_Supplier.IsEnabled = false;
                bt_Update_Supplier.IsEnabled = false;
                bt_Delete_Supplier.IsEnabled = false;
            }

            if (DBConnection.Key == "True")
            {
                bt_Insert_Supplier.IsEnabled = true;
                bt_Update_Supplier.IsEnabled = true;
                bt_Delete_Supplier.IsEnabled = true;
            }
        }

        private void cbFill()
        {
            DBConnection connection = new DBConnection();
            connection.DocumentsFill();
            cbName_Normativnie_Documenti.ItemsSource = connection.dtDocuments.DefaultView;
            cbName_Normativnie_Documenti.SelectedValuePath = "ID_Normativnie_Documenti";
            cbName_Normativnie_Documenti.DisplayMemberPath = "Name_Normativnie_Documenti";
        }

        private void dgSupplier_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            switch (e.Column.Header)
            {
                case ("Familiya_Postavhik"):
                    e.Column.Header = "Фамилия поставщика";
                    break;
                case ("Name_Postavhik"):
                    e.Column.Header = "Имя поставщика";
                    break;
                case ("Otchestvo_Postavhik"):
                    e.Column.Header = "Отчество поставщика";
                    break;
                case ("Name_Normativnie_Documenti"):
                    e.Column.Header = "Название документа";
                    break;
            }
        }

        private void bt_Insert_Supplier_Click(object sender, RoutedEventArgs e)
        {
            procedures.Postavhik_Insert(tb_Familiya_Postavhik.Text.ToString(), tb_Name_Postavhik.Text.ToString(), tb_Otchestvo_Postavhik.Text.ToString(), Convert.ToInt32(cbName_Normativnie_Documenti.SelectedValue.ToString()));
             
            dgFill(QR);
            cbFill();
            Supplier ps2 = new Supplier();
            ps2.Show();
            Hide();
        }

        private void bt_Search_Click(object sender, RoutedEventArgs e)
        {
            foreach (DataRowView dataRow in (DataView)dgSupplier.ItemsSource)
            {
                if (dataRow.Row.ItemArray[1].ToString() == tb_Search.Text ||
                    dataRow.Row.ItemArray[2].ToString() == tb_Search.Text ||
                    dataRow.Row.ItemArray[3].ToString() == tb_Search.Text ||
                    dataRow.Row.ItemArray[4].ToString() == tb_Search.Text)
                {
                    dgSupplier.SelectedItem = dataRow;
                }
            }
        }

        private void bt_Cancel_Click(object sender, RoutedEventArgs e)
        {
            Supplier ps2 = new Supplier();
            ps2.Show();
            Hide();
        }

        private void bt_Update_Supplier_Click(object sender, RoutedEventArgs e)
        {
            DataRowView ID = (DataRowView) dgSupplier.SelectedItems[0];
            procedures.Postavhik_Update(Convert.ToInt32(ID["ID_Postavhik"]), tb_Familiya_Postavhik.Text.ToString(), tb_Name_Postavhik.Text.ToString(), tb_Otchestvo_Postavhik.Text.ToString(), Convert.ToInt32(cbName_Normativnie_Documenti.SelectedValue.ToString()));
        }

        private void bt_Delete_Supplier_Click(object sender, RoutedEventArgs e)
        {
            DataRowView ID = (DataRowView) dgSupplier.SelectedItems[0];
            procedures.Postavhik_Delete(Convert.ToInt32(ID["ID_Postavhik"]));
            dgFill(QR);
        }
    }
}
