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

namespace Bakery
{
    /// <summary>
    /// Interaction logic for Settings_Folder.xaml
    /// </summary>
    public partial class Settings_Folder : Window
    {
        public Settings_Folder()
        {
            InitializeComponent();
        }

        private void bt_Accept_Click(object sender, RoutedEventArgs e)
        {
            DBConnection.FolderZ = tb_Folder.Text.ToString();
            MessageBox.Show("Путь успешно сохранен! " +
                    "\n Готово", "Пекарня+",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            
        }

        private void bt_Home_Click(object sender, RoutedEventArgs e)
        {
            MainWindow ps2 = new MainWindow();
            ps2.Show();
            Hide();
        }
    }
}
