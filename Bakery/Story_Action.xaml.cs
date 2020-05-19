using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Interaction logic for Story_Action.xaml
    /// </summary>
    public partial class Story_Action : Window
    {
        public Story_Action()
        {
            InitializeComponent();
        }

        private string QR = "";
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
                DBConnection.qrHistory = qr;
                connection.HistoryFill();
                connection.Dependency.OnChange += Dependency_OnChange;
                dg_History.ItemsSource = connection.dtHistory.DefaultView;
                dg_History.Columns[0].Visibility = Visibility.Collapsed;
            };

            Dispatcher.Invoke(action);
        }



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            QR = DBConnection.qrHistory;
            dgFill(QR);
        }

        private void bt_Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow ps2 = new MainWindow();
            ps2.Show();
            Hide();
        }

        private void dg_History_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            switch (e.Column.Header)
            {
                case ("ProductId"):
                    e.Column.Header = "Номер опкрации";
                    break;
                case ("Operation"):
                    e.Column.Header = "Операция";
                    break;
                case ("CreateAt"):
                    e.Column.Header = "Дата проведения";
                    break;
            }
        }
    }
}
