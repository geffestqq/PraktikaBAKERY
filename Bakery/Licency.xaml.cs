using System;
using System.Collections.Generic;
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
using System.IO;

namespace Bakery
{
    /// <summary>
    /// Логика взаимодействия для Licency.xaml
    /// </summary>
    public partial class Licency : Window
    {
        public Licency()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string path = @"C:\111.txt";
            string text = File.ReadAllText(path);


            if (text == "1")
            {
                 lb1.Content = "Вы уже активировали программный продукт";
                 lb1.FontSize=20;
                 tb1.Visibility= Visibility.Hidden;
                 bt1.Visibility = Visibility.Hidden;

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow ps2 = new MainWindow();
            ps2.Show();
            Hide();
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string path = @"C:\111.txt";
            string text = File.ReadAllText(path);

            if (text == "1")
            {
                MessageBox.Show("Вы успешно активировали программный продукт");
                MainWindow ps2 = new MainWindow();
                ps2.Show();
                Hide();
            }

            if (tb1.Text == "123")
            {
                using (StreamWriter sw = new StreamWriter(@"C:\111.txt"))
                {
                    sw.Write("1");
                    DBConnection.Key = "True";
                }
            }

            if (text == "")
            {
                DBConnection.Key = "False";
                MessageBox.Show("Файл пуст!");
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
