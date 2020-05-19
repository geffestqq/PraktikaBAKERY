using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bakery
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            if (!this.isAllLibrariesIsThere())
            {
                MessageBox.Show("Ошибка. Не обнаружены библиотеки Crypt_Library " +
                    " Приложение будет закрыто", "Критическая ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                Environment.Exit(-1);
            }
            InitializeComponent();
        }
        private bool isAllLibrariesIsThere()
        {
            return File.Exists("Crypt_Library.dll");
        }
    

        private void bt_Entrance_Documents_Click(object sender, RoutedEventArgs e)
        {
            Documents ps2 = new Documents();
            ps2.Show();
            Hide();
        }

        private void bt_Entrance_Supplier_Click(object sender, RoutedEventArgs e)
        {
            Supplier ps2 = new Supplier();
            ps2.Show();
            Hide();
        }

        private void bt_Entrance_Sirie_Click(object sender, RoutedEventArgs e)
        {
            Sirie ps2 = new Sirie();
            ps2.Show();
            Hide();
        }

        private void bt_Entrance_Doljnost_Click(object sender, RoutedEventArgs e)
        {
            Doljnost ps2 = new Doljnost();
            ps2.Show();
            Hide();
        }

        private void bt_Entrance_Klient_Click(object sender, RoutedEventArgs e)
        {
            Klient ps2 = new Klient();
            ps2.Show();
            Hide();
        }

        private void bt_Entrance_Sotrudnik_Click(object sender, RoutedEventArgs e)
        {
            Sotrudnik ps2 = new Sotrudnik();
            ps2.Show();
            Hide();
        }

        private void bt_Entrance_Tovar_Click(object sender, RoutedEventArgs e)
        {
            Tovar ps2 = new Tovar();
            ps2.Show();
            Hide();
        }

        private void bt_Entrance_Zakaz_Click(object sender, RoutedEventArgs e)
        {
            Zakaz ps2 = new Zakaz();
            ps2.Show();
            Hide();
        }

        private void bt_Entrance_Chek_Click(object sender, RoutedEventArgs e)
        {
            Chek ps2 = new Chek();
            ps2.Show();
            Hide();
        }

        private void bt_Entrance_Supplier_Copy_Click(object sender, RoutedEventArgs e)
        {
            Settings ps2 = new Settings();
            ps2.Show();
            Hide();
        }

        private void bt_Entrance_Personal_Area_Click(object sender, RoutedEventArgs e)
        {
            DBProcedures procedures = new DBProcedures();
            procedures.Authorization2(DBConnection.Log, DBConnection.Pass);


            Personal_Area ps2 = new Personal_Area();
            ps2.Show();
            Hide();
        }

        private void bt_Entrance_Block_Click(object sender, RoutedEventArgs e)
        {
            AuthorizationPage ps2 = new AuthorizationPage();
            ps2.Show();
            Hide();
        }

        private void bt_Entrance_Supplier_Copy1_Click(object sender, RoutedEventArgs e)
        {
            Licency ps2 = new Licency();
            ps2.Show();
            Hide();
        }

        private void bt_Entrance_History_Action_Click(object sender, RoutedEventArgs e)
        {
            Story_Action ps2 = new Story_Action();
            ps2.Show();
            Hide();
        }

        private void cb1_Click(object sender, RoutedEventArgs e)
        {
            TextBox txt = new TextBox();
            if (cb1.IsChecked == true)
            {
                InitializeComponent();

                txt.Text = "Данный программный продукт разработан Бригадой №1";
                sp.Children.Add(txt);
                txt.Width = 222;
                txt.Background = Brushes.BlueViolet;
                txt.FontSize = 24;
                txt.TextWrapping = TextWrapping.Wrap;
                txt.TextAlignment = TextAlignment.Center;
                txt.IsReadOnly = true;
                txt.Height = 170;

            }
            else
            {
                MainWindow ps2 = new MainWindow();
                ps2.Show();
                Hide();
            }
        }
          

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void bt_Settings_Click(object sender, RoutedEventArgs e)
        {
            Settings_Folder ps2 = new Settings_Folder();
            ps2.Show();
            Hide();
        }
    }
}
