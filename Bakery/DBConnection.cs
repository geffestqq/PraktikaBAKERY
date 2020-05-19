using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Bakery
{
    class DBConnection
    {
        //Прослушивание сервера
        public SqlDependency Dependency = new SqlDependency();
        //Подключение к источнику данных

        public static SqlConnection connection = 
        new SqlConnection("Data Source = DESKTOP-T3ECMD0\\GEFFEST; Initial Catalog = Bakery; Persist Security Info = true; User ID = sa; Password = \"c2f5i4f53\"");
        
        public static Int32 IDrecord, IDuser;
        public static string FIO, FolderZ;
        public static Int32 ID_Sotrudnik;
        public static string Log, Pass;
        public static string Key;


        public DataTable dtDocuments = new DataTable("Documents");
        public DataTable dtChek = new DataTable("Chek");
        public DataTable dtHistory = new DataTable("History");
        public DataTable dtType_Zakaz = new DataTable("Type_Zakaz");
        public DataTable dtTovar_Zakaz = new DataTable("Tovar_Zakaz");
        public DataTable dtStatus_Zakaza = new DataTable("Status_Zakaza");
        public DataTable dtZakaz = new DataTable("Zakaz");
        public DataTable dtPostavhik = new DataTable("Postavhik");
        public DataTable dtSirie = new DataTable("Sirie");
        public DataTable dtDoljnost = new DataTable("Doljnost");
        public DataTable dtKlient = new DataTable("Klient");
        public DataTable dtSotrudnik = new DataTable("Sotrudnik");
        public DataTable dtTovar = new DataTable("Tovar");
        public DataTable dtType_Tovar = new DataTable("Type_Tovar");
        public DataTable dtPostavhik_for_cb = new DataTable("Postavhik_for_cb");
        public DataTable dtSotrudnik_for_cb = new DataTable("Sotrudnik_for_cb");
        public DataTable dtKlient_for_cb = new DataTable("Klient_for_cb");
        public DataTable dtSotrudnik_for_cb_2 = new DataTable("Sotrudnik_for_cb_2");
        public DataTable dtType_Tovar_for_cb = new DataTable("Type_Tovar_for_cb");
        public DataTable dtDoljnost_for_cb = new DataTable("Doljnost_for_cb");
        public DataTable dtDocuments_for_cb = new DataTable("Documents_for_cb");
        public DataTable dtSirie_for_cb = new DataTable("Sirie_for_cb");
        public DataTable dtStatus_Zakaza_for_cb= new DataTable("Status_Zakaza_for_cb");
        public DataTable dtTovar_for_cb = new DataTable("Tovar_for_cb");

        public DataTable dtType_Zakaz_for_cb = new DataTable("Type_Zakaz_for_cb");




        public static string
        qrSirie = "SELECT [ID_Sirie], [Name_Sirie], [Date_Postavki], [Familiya_Postavhik], [Name_Postavhik], [Otchestvo_Postavhik] FROM [dbo].[Sirie] inner join [dbo].[Postavhik] on [dbo].[Sirie].[Postavhik_ID] = [dbo].[Postavhik].[ID_Postavhik]",
        qrPostavhik = "SELECT [ID_Postavhik], [Familiya_Postavhik], [Name_Postavhik], [Otchestvo_Postavhik], [Name_Normativnie_Documenti] FROM [dbo].[Postavhik] " +
        " inner join [dbo].[Documents] on [dbo].[Postavhik].[Normativnie_Documenti_ID] = [dbo].[Documents].[ID_Normativnie_Documenti]",
        qrSotrudnik = "SELECT [ID_Sotrudnik], [Familiya_Sotrudnik], [Name_Sotrudnik], [Otchestvo_Sotrudnik], [Date_Rojdeniya], [Seriya_Pasporta], [Number_Pasporta], [LoginS], [PasswordS], [Name_Doljnost], [Name_Normativnie_Documenti] FROM [dbo].[Sotrudnik]" +
        " inner join [dbo].[Doljnost] on [dbo].[Sotrudnik].[Doljnost_ID] = [dbo].[Doljnost].[ID_Doljnost]" +
        " inner join [dbo].[Documents] on [dbo].[Sotrudnik].[Normativnie_Documenti_ID] = [dbo].[Documents].[ID_Normativnie_Documenti]",
        qrTovar = "SELECT [ID_Tovar], [Name_Tovar], [Kolichestvo_Tovar], [Cena], [Data_Proisvodstva], [Name_Sirie], [Familiya_Sotrudnik], [Name_Sotrudnik], [Otchestvo_Sotrudnik], [Name_Type_Tovar] FROM [dbo].[Tovar]" +
        " inner join [dbo].[Sirie] on [dbo].[Tovar].[Sirie_ID] = [dbo].[Sirie].[ID_Sirie] " +
        " inner join [dbo].[Sotrudnik] on [dbo].[Tovar].[Sotrudnik_ID] = [dbo].[Sotrudnik].[ID_Sotrudnik] " +
        " inner join [dbo].[Type_Tovar] on [dbo].[Tovar].[Type_Tovar_ID] = [dbo].[Type_Tovar].[ID_Type_Tovar] ",
        qrZakaz = "SELECT [ID_Zakaz], [Number_Zakaz], [Kolichestvo], [Summa], [Date_Prodaji], [Sostiyanie_Zakaza], [Familiya_Sotrudnik], [Name_Sotrudnik], [Otchestvo_Sotrudnik], [Familiya_Klient], [Name_Klient], [Otchestvo_Klient], [Name_Tovar] FROM [dbo].[Zakaz]" +
        " inner join [dbo].[Status_Zakaza] on [dbo].[Zakaz].[Status_Zakaza_ID] = [dbo].[Status_Zakaza].[ID_Status_Zakaza] " +
        " inner join [dbo].[Sotrudnik] on [dbo].[Zakaz].[Sotrudnik_ID] = [dbo].[Sotrudnik].[ID_Sotrudnik] " +
        " inner join [dbo].[Klient] on [dbo].[Zakaz].[Klient_ID] = [dbo].[Klient].[ID_Klient] " +
        " inner join [dbo].[Tovar] on [dbo].[Zakaz].[Tovar_ID] = [dbo].[Tovar].[ID_Tovar]",
        qrDocuments = "SELECT [ID_Normativnie_Documenti], [Name_Normativnie_Documenti], [Srok_Deistviya] FROM [dbo].[Documents]",
        qrDoljnost = "SELECT [ID_Doljnost], [Name_Doljnost], [Oklad] FROM [dbo].[Doljnost]",
        qrKlient = "SELECT [ID_Klient], [Familiya_Klient], [Name_Klient], [Otchestvo_Klient] FROM [dbo].[Klient]",
        qrStatus_Zakaza = "SELECT [ID_Status_Zakaza], [Sostiyanie_Zakaza] FROM [dbo].[Status_Zakaza]",
        qrType_Tovar = "SELECT [ID_Type_Tovar], [Name_Type_Tovar] FROM [dbo].[Type_Tovar]",
        qrSotrudnik_for_cb = "SELECT [ID_Sotrudnik], [Familiya_Sotrudnik] + ' ' + [Name_Sotrudnik] + ' ' + [Otchestvo_Sotrudnik] as Sotrudnik_Info FROM [dbo].[Sotrudnik]",
        qrPostavhik_for_cb = "SELECT [ID_Postavhik], [Familiya_Postavhik] + ' ' + [Name_Postavhik] + ' ' + [Otchestvo_Postavhik] as Postavhik_Info FROM [dbo].[Postavhik]",
        qrKlient_for_cb = "SELECT [ID_Klient], [Familiya_Klient] + ' ' + [Name_Klient] + ' ' + [Otchestvo_Klient] as Klient_Info FROM [dbo].[Klient]",

        qrHistory = "SELECT [ID_History], [ProductId], [Operation], [CreateAt] FROM [dbo].[History]",

        qrType_Zakaz = "SELECT [ID_Type_Zakaz], [Name_Type_Zakaz] FROM [dbo].[Type_Zakaz]",


        qrChek = "SELECT [ID_Chek], [Number_Chek], [Date_Pechat], [Familiya_Sotrudnik], [Name_Sotrudnik], [Otchestvo_Sotrudnik], [Familiya_Klient], [Name_Klient], [Otchestvo_Klient], [Name_Tovar], [Name_Type_Zakaz] FROM [dbo].[Chek]" +
        " inner join[dbo].[Sotrudnik] on[dbo].[Chek].[Sotrudnik_ID] = [dbo].[Sotrudnik].[ID_Sotrudnik]" +
        " inner join[dbo].[Klient] on[dbo].[Chek].[Klient_ID] = [dbo].[Klient].[ID_Klient]" +
        " inner join[dbo].[Tovar] on [dbo].[Chek].[Tovar_ID] = [dbo].[Tovar].[ID_Tovar]" +
        " inner join[dbo].[Type_Zakaz] on[dbo].[Chek].[Type_Zakaz_ID] = [dbo].[Type_Zakaz].[ID_Type_Zakaz]";





 

        private SqlCommand command = new SqlCommand("", connection);
        private void dtFill(DataTable table, string query)
        {
            command.CommandText = query;

            //Технология "Real Time"
            command.Notification = null;
            Dependency.AddCommandDependency(command);
            SqlDependency.Start(connection.ConnectionString);

            connection.Open();
            table.Load(command.ExecuteReader());
            connection.Close();
        }

       


        public void Type_ZakazFill()
        {
            dtFill(dtType_Zakaz, qrType_Zakaz);
        }
        public void HistoryFill()
        {
            dtFill(dtHistory, qrHistory);
        }

        public void ChekFill()
        {
            dtFill(dtChek, qrChek);
        }

        public void DocumentsFill()
        {
            dtFill(dtDocuments, qrDocuments);
        }

        public void Status_ZakazaFill()
        {
            dtFill(dtStatus_Zakaza, qrStatus_Zakaza);
        }

        public void PostavhikFill()
        {
            dtFill(dtPostavhik, qrPostavhik);
        }


        public void SirieFill()
        {
            dtFill(dtSirie, qrSirie);
        }
        public void DoljnostFill()
        {
            dtFill(dtDoljnost, qrDoljnost);
        }

        public void KlientFill()
        {
            dtFill(dtKlient, qrKlient);
        }

        public void ZakazFill()
        {
            dtFill(dtZakaz, qrZakaz);
        }

        public void SotrudnikFill()
        {
            dtFill(dtSotrudnik, qrSotrudnik);
        }

        public void Type_TovarFill()
        {
            dtFill(dtType_Tovar, qrType_Tovar);
        }

        public void TovarFill()
        {
            dtFill(dtTovar, qrTovar);
        }

        public void qrPostavhik_for_cbFill()
        {
            dtFill(dtPostavhik_for_cb, qrPostavhik_for_cb);
        }

        public void qrSotrudnik_for_cbFill()
        {
            dtFill(dtSotrudnik_for_cb, qrSotrudnik_for_cb);
        }

        public void qrKlient_for_cbFill()
        {
            dtFill(dtKlient_for_cb, qrKlient_for_cb);
        }

        public void qrDoljnost_for_cbFill()
        {
            dtFill(dtDoljnost_for_cb, qrDoljnost);
        }

        public void qrType_Zakaz_for_cbFill()
        {
            dtFill(dtType_Zakaz_for_cb, qrType_Zakaz);
        }



        public void qrDocuments_for_cbFill()
        {
            dtFill(dtDocuments_for_cb, qrDocuments);
        }

        public void qrSirie_for_cbFill()
        {
            dtFill(dtSirie_for_cb, qrSirie);
        }

        public void qrType_Tovar_for_cbFill()
        {
            dtFill(dtType_Tovar, qrType_Tovar);
        }

        

        public void qrStatus_Zakaza__for_cbFill()
        {
            dtFill(dtStatus_Zakaza_for_cb, qrStatus_Zakaza);
        }

        public void qrTovar_for_cbFill()
        {
            dtFill(dtTovar_for_cb, qrTovar);
        }

    }
}
