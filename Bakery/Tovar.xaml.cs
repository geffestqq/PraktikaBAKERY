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
    /// Interaction logic for Tovar.xaml
    /// </summary>
    public partial class Tovar : Window
    {
        public Tovar()
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
                DBConnection.qrTovar = qr;
                connection.TovarFill();
                connection.Dependency.OnChange += Dependency_OnChange;
                dgTovar.ItemsSource = connection.dtTovar.DefaultView;
                dgTovar.Columns[0].Visibility = Visibility.Collapsed;
            };

            Dispatcher.Invoke(action);
        }

        private void cbFill()
        {
            DBConnection connection = new DBConnection();
            connection.qrSirie_for_cbFill();
            cb_Name_Sirie.ItemsSource = connection.dtSirie_for_cb.DefaultView;
            cb_Name_Sirie.SelectedValuePath = "ID_Sirie";
            cb_Name_Sirie.DisplayMemberPath = "Name_Sirie";
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
            connection.qrType_Tovar_for_cbFill();
            cb_Type_Tovar.ItemsSource = connection.dtType_Tovar.DefaultView;
            cb_Type_Tovar.SelectedValuePath = "ID_Type_Tovar";
            cb_Type_Tovar.DisplayMemberPath = "Name_Type_Tovar";
        }

        private void bt_Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow ps2 = new MainWindow();
            ps2.Show();
            Hide();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            QR = DBConnection.qrTovar;
            dgFill(QR);
            cbFill();
            cbFill1();
            cbFill2();

            string path = @"C:\111.txt";
            string text = File.ReadAllText(path);
            if (DBConnection.Key == "False")
            {
                bt_Insert_Tovar.IsEnabled = false;
                bt_Update_Tovar.IsEnabled = false;
                bt_Delete_Tovar.IsEnabled = false;
            }

            if (DBConnection.Key == "True")
            {
                bt_Insert_Tovar.IsEnabled = true;
                bt_Update_Tovar.IsEnabled = true;
                bt_Delete_Tovar.IsEnabled = true;
            }
        }

        private void dgTovar_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            switch (e.Column.Header)
            {
                case ("Name_Tovar"):
                    e.Column.Header = "Название товара";
                    break;
                case ("Kolichestvo_Tovar"):
                    e.Column.Header = "Кол-во товара";
                    break;
                case ("Cena"):
                    e.Column.Header = "Цена";
                    break;
                case ("Data_Proisvodstva"):
                    e.Column.Header = "Дата производства";
                    break;
                case ("Name_Sirie"):
                    e.Column.Header = "Название сырья";
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
                case ("Name_Type_Tovar"):
                    e.Column.Header = "Тип товара";
                    break;
            }
        }

        private void bt_Cancel_Click(object sender, RoutedEventArgs e)
        {
            Tovar ps2 = new Tovar();
            ps2.Show();
            Hide();
        }

        private void bt_Search_Click(object sender, RoutedEventArgs e)
        {
            foreach (DataRowView dataRow in (DataView)dgTovar.ItemsSource)
            {
                if (dataRow.Row.ItemArray[1].ToString() == tb_Search.Text ||
                    dataRow.Row.ItemArray[2].ToString() == tb_Search.Text ||
                    dataRow.Row.ItemArray[3].ToString() == tb_Search.Text ||
                    dataRow.Row.ItemArray[4].ToString() == tb_Search.Text ||
                    dataRow.Row.ItemArray[5].ToString() == tb_Search.Text ||
                    dataRow.Row.ItemArray[6].ToString() == tb_Search.Text ||
                    dataRow.Row.ItemArray[7].ToString() == tb_Search.Text ||
                    dataRow.Row.ItemArray[8].ToString() == tb_Search.Text ||
                    dataRow.Row.ItemArray[9].ToString() == tb_Search.Text)
                {
                    dgTovar.SelectedItem = dataRow;
                }
            }
        }

        private void bt_Insert_Tovar_Click(object sender, RoutedEventArgs e)
        {
            procedures.Tovar_Insert(tb_Name_Tovar.Text.ToString(), Convert.ToInt32(tb_Kolichestvo_Tovar.Text.ToString()), Convert.ToDecimal(tb_Cena.Text.ToString()), dp_Data_Proisvodstva.Text.ToString(), Convert.ToInt32(cb_Name_Sirie.SelectedValue.ToString()), Convert.ToInt32(cb_Sotrudnik_Info.SelectedValue.ToString()), Convert.ToInt32(cb_Type_Tovar.SelectedValue.ToString()));
            dgFill(QR);
          


            Tovar ps2 = new Tovar();
            ps2.Show();
            Hide();
        }

        private void bt_Update_Tovar_Click(object sender, RoutedEventArgs e)
        {
            DataRowView ID = (DataRowView)dgTovar.SelectedItems[0];
            procedures.Tovar_Update(Convert.ToInt32(ID["ID_Tovar"]), tb_Name_Tovar.Text.ToString(), Convert.ToInt32(tb_Kolichestvo_Tovar.Text.ToString()), Convert.ToDecimal(tb_Cena.Text.ToString()), dp_Data_Proisvodstva.Text.ToString(), Convert.ToInt32(cb_Name_Sirie.SelectedValue.ToString()), Convert.ToInt32(cb_Sotrudnik_Info.SelectedValue.ToString()), Convert.ToInt32(cb_Type_Tovar.SelectedValue.ToString()));

        }

        private void bt_Delete_Tovar_Click(object sender, RoutedEventArgs e)
        {
            DataRowView ID = (DataRowView)dgTovar.SelectedItems[0];
            procedures.Tovar_Delete(Convert.ToInt32(ID["ID_Tovar"]));
            dgFill(QR);
        }
    }
}
