using Microsoft.Office.Interop.Excel;
using Microsoft.Win32;
using SharpDX.WIC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Office.Interop.Word;
using DataGrid = System.Windows.Controls.DataGrid;
using Clipboard = System.Windows.Forms.Clipboard;
using DataFormats = System.Windows.Forms.DataFormats;
using SaveFileDialog = System.Windows.Forms.SaveFileDialog;


namespace Bakery
{
    /// <summary>
    /// Interaction logic for Documents.xaml
    /// </summary>
    public partial class Documents : System.Windows.Window
    {
        public Documents()
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
            System.Action action = () =>
            {
                DBConnection connection = new DBConnection();
                DBConnection.qrDocuments = qr;
                connection.DocumentsFill();
                connection.Dependency.OnChange += Dependency_OnChange;
                dgDocuments.ItemsSource = connection.dtDocuments.DefaultView;
                dgDocuments.Columns[0].Visibility = Visibility.Collapsed;
            };

            Dispatcher.Invoke(action);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            QR = DBConnection.qrDocuments;
            dgFill(QR);

            string path = @"C:\111.txt";
            string text = File.ReadAllText(path);
            if (DBConnection.Key == "False")
            {
                bt_Insert_Documents.IsEnabled = false;
                bt_Update_Documents.IsEnabled = false;
                bt_Delete_Documents.IsEnabled = false;
            }

            if (DBConnection.Key == "True")
            {
                bt_Insert_Documents.IsEnabled = true;
                bt_Update_Documents.IsEnabled = true;
                bt_Delete_Documents.IsEnabled = true;
            }
        }

        private void dgDocuments_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            switch (e.Column.Header)
            {
                case ("Name_Normativnie_Documenti"):
                    e.Column.Header = "Название документа";
                    break;
                case ("Srok_Deistviya"):
                    e.Column.Header = "Срок действия";
                    break;
            }
        }

        private void bt_Search_Click(object sender, RoutedEventArgs e)
        {
            foreach (DataRowView dataRow in (DataView)dgDocuments.ItemsSource)
            {
                if (dataRow.Row.ItemArray[1].ToString() == tb_Search.Text ||
                    dataRow.Row.ItemArray[2].ToString() == tb_Search.Text)
                {
                    dgDocuments.SelectedItem = dataRow;
                }
            }
        }

        private void bt_Insert_Documents_Click(object sender, RoutedEventArgs e)
        {

            switch (tb_Name_Normativnie_Documenti.Text == "")
            {
                case true:
                    tb_Name_Normativnie_Documenti.Background = Brushes.Red;
                    switch (dp_Srok_Deistviya.Text == "")
                    {
                        case true:
                            dp_Srok_Deistviya.Background = Brushes.Red;
                            break;
                    }
                    break;
                case false:
                    procedures.Documents_Insert(tb_Name_Normativnie_Documenti.Text.ToString(), dp_Srok_Deistviya.Text.ToString());
                    dgFill(QR);

                    Documents ps2 = new Documents();
                    ps2.Show();
                    Hide();
                    break;

            }

        }

        private void bt_Cancel_Click(object sender, RoutedEventArgs e)
        {
            Documents ps2 = new Documents();
            ps2.Show();
            Hide();
        }

        private void bt_Update_Documents_Click(object sender, RoutedEventArgs e)
        {
            DataRowView ID = (DataRowView)dgDocuments.SelectedItems[0];
            procedures.Documents_Update(Convert.ToInt32(ID["ID_Normativnie_Documenti"]), tb_Name_Normativnie_Documenti.Text.ToString(), dp_Srok_Deistviya.Text.ToString());

        }

        private void bt_Delete_Documents_Click(object sender, RoutedEventArgs e)
        {
            DataRowView ID = (DataRowView)dgDocuments.SelectedItems[0];
            procedures.Documents_Delete(Convert.ToInt32(ID["ID_Normativnie_Documenti"]));
            dgFill(QR);
        }

        private void bt_Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow ps2 = new MainWindow();
            ps2.Show();
            Hide();
        }

        private void bt_Settings_Click(object sender, RoutedEventArgs e)
        {
            Settings ps2 = new Settings();
            ps2.Show();
            Hide();
        }

        private void bt_Export_Excel_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application app = null;
            Microsoft.Office.Interop.Excel.Workbook wb = null;
            Microsoft.Office.Interop.Excel.Worksheet ws = null;
            var process = Process.GetProcessesByName("EXCEL");

            Microsoft.Win32.SaveFileDialog openDlg = new Microsoft.Win32.SaveFileDialog();
            openDlg.FileName = "Заявка №";
            openDlg.Filter = "Excel (.xls)|*.xls |Excel (.xlsx)|*.xlsx |All files (*.*)|*.*";
            openDlg.FilterIndex = 2;
            openDlg.RestoreDirectory = true;
            string path = openDlg.FileName;

            if (openDlg.ShowDialog() == true)
            {
                app = new Microsoft.Office.Interop.Excel.Application();
                app.Visible = true;
                app.DisplayAlerts = false;
                wb = app.Workbooks.Add();
                ws = wb.ActiveSheet;
                dgDocuments.SelectAllCells();
                dgDocuments.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
                ApplicationCommands.Copy.Execute(null, dgDocuments);
                ws.Paste();
                ws.Range["A1", "G1"].Font.Bold = true;
                int number1 = ws.UsedRange.Rows.Count;
                Microsoft.Office.Interop.Excel.Range myRange = ws.Range["A1", "G" + number1];
                myRange.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                myRange.WrapText = false;
                ws.Columns.EntireColumn.AutoFit();
                wb.SaveAs(path);


            }
        }
        private void bt__Click(object sender, RoutedEventArgs e)
        {

            DataGrid dg = dgDocuments;
            dg.SelectAllCells();
            dg.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
            ApplicationCommands.Copy.Execute(null, dg);
            dg.UnselectAllCells();

            String result = (string)Clipboard.GetData(DataFormats.Text);
            
                string a, b;
                b = "@";

                a = (DBConnection.FolderZ.ToString());

                StreamWriter sw = new StreamWriter(a);

                sw.WriteLine(result);
                sw.Close();




                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.ShowDialog();
                File.WriteAllText(saveFileDialog.FileName, result);
                


        }




    }
}
