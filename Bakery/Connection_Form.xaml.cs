using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;
using Application = System.Windows.Forms.Application;
using Microsoft.Win32;

namespace Bakery
{
    /// <summary>
    /// Interaction logic for Connection_Form.xaml
    /// </summary>
    public partial class Connection_Form : Window
    {
        
        public Connection_Form()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            
            RegistryKey registry = Registry.CurrentUser;
            RegistryKey key = registry.CreateSubKey("Server_Configuration");

            RegistryKey a = registry.OpenSubKey("Server_Configuration");
            RegistryKey b = registry.OpenSubKey("Server_Configuration");

            string DS = a.GetValue("DS").ToString();
            string IC = b.GetValue("IC").ToString();

            if (DS == "")
            {
                //вызов класса конфигурации
                Configuration_class configuration = new Configuration_class();
                //присвоение event action событий
                configuration.server_Collection += Configuration_server_Collection;
                //
                Thread threadservers = new Thread(configuration.SQL_Server_Enumurator);
                //запуск потока
                threadservers.Start();
            }
            else
            {
                

                AuthorizationPage ps2 = new AuthorizationPage();
                ps2.Show();
                Hide();
            }



           
        }

        private void Configuration_server_Collection(DataTable obj)
        {
            //
            //Вызов делегата для присвоения в него фрагмента кода через лямбда выражение => в делегат присваивается код
            Action action = () =>
            {
                //для каждого строки таблицы в выпадающий список
                foreach (DataRow r in obj.Rows)
                {
                cb_Servers.Items.Add(string.Format(@"{0}\{1}", r[0], r[1]));
                }
                //присвоение фонового потока в основной
                
            };
            Dispatcher.Invoke(action);
        }

        private void cb_Servers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void Configuration_connection_checked(bool obj)
        {
            switch (obj)
            {
                //Если подключение выполнено верно то появляется сообщение
                case true:
                    System.Windows.MessageBox.Show("Проверка выполнена!");
                    Action action = () =>
                    {
                        //Повторение метода выбора
                        Configuration_class configuration_coll
                        = new Configuration_class();
                        configuration_coll.Data_Base_Collection
                        += Configuration_Data_Base_Collection;
                        Thread threadBases
                        = new Thread(configuration_coll.SQL_Data_Base_Collection);
                        threadBases.Start();
                       
                    };
                    Dispatcher.Invoke(action);
                    break;
                case false:
                    //Вслучае если нет подключения повторяем сбор данных
                    //о сервере
                    Configuration_class configuration
                    = new Configuration_class();
                    configuration.server_Collection
                    += Configuration_server_Collection;
                    Thread threadServers
                    = new Thread(configuration.SQL_Server_Enumurator);
                    threadServers.Start();
                    break;
            }
        }

        private void Configuration_Data_Base_Collection(DataTable obj)
        {
            Action action = () =>
            {
                foreach (DataRow r in obj.Rows)
                {
                    cb_bd.Items.Add(r[0]);
                }
               
            };
            Dispatcher.Invoke(action);
        }

        private void test_Click(object sender, RoutedEventArgs e)
        {
            Configuration_class configuration = new Configuration_class();
            configuration.ds = cb_Servers.SelectedItem.ToString();
            configuration.connection_checked += Configuration_connection_checked;
            Thread thread = new Thread(configuration.SQL_Data_Base_Checking);
            thread.Start();
        }

        private void test1_Click(object sender, RoutedEventArgs e)
        {
            switch (cb_bd.Text == "")
            {
                case true:
                    MessageBox.Show("Не выбрана нужная база данных!", "Bekary", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    cb_bd.Focus();
                    break;
                case false:
                    Configuration_class configuration = new Configuration_class();
                    configuration.SQL_Server_Configuration_Set(cb_Servers.Text, cb_bd.Text);
                    Program.connect = true;
                    Application.Restart();
                    break;

            }
        }
    }
}
