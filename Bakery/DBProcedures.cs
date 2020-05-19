using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Bakery
{
    class DBProcedures
    {
        private SqlCommand command = new SqlCommand("", DBConnection.connection);
        private SqlCommand command1 = new SqlCommand("", DBConnection.connection);
        private SqlCommand command2 = new SqlCommand("", DBConnection.connection);


        private void commandConfig(string config)
        {
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "[dbo].[" + config + "]";
            command.Parameters.Clear();
        }

        public void Documents_Insert(string Name_Normativnie_Documenti, string Srok_Deistviya)
        {
            commandConfig("Documents_Insert");
            command.Parameters.AddWithValue("@Name_Normativnie_Documenti", Name_Normativnie_Documenti);
            command.Parameters.AddWithValue("@Srok_Deistviya", Srok_Deistviya);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void Regestration(string Familiya_Sotrudnik, string Name_Sotrudnik, string Otchestvo_Sotrudnik, string LoginS, string PasswordS)
        {
            commandConfig("Regestration");
            command.Parameters.AddWithValue("@Familiya_Sotrudnik", Familiya_Sotrudnik);
            command.Parameters.AddWithValue("@Name_Sotrudnik", Name_Sotrudnik);
            command.Parameters.AddWithValue("@Otchestvo_Sotrudnik", Otchestvo_Sotrudnik);
            command.Parameters.AddWithValue("@LoginS", LoginS);
            command.Parameters.AddWithValue("@PasswordS", PasswordS);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public Int32 Authorization(string User_Login, string User_Password)
        {
            Int32 ID_record = 0;
            //Int32 ID_Sotrudnik = 0;
            //string FIO;
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT count(*) FROM [dbo].[Sotrudnik]" +
               " where [LoginS] = '" + User_Login + "' and [PasswordS] = '" +
               User_Password + "'";
            command1.CommandText = "SELECT Familiya_Sotrudnik + ' ' + Name_Sotrudnik + ' ' + Otchestvo_Sotrudnik from [dbo].[Sotrudnik] where LoginS = '" + User_Login + "' and PasswordS = '" + User_Password + "'";
            command2.CommandText = "SELECT ID_Sotrudnik  from [dbo].[Sotrudnik] where LoginS = '" + User_Login + "' and PasswordS = '" + User_Password + "'";
            DBConnection.Log = User_Login;
            DBConnection.Pass = User_Password;
            DBConnection.connection.Open();

            //FIO = command1.ExecuteScalar().ToString();

            //ID_Sotrudnik = Convert.ToInt32(command2.ExecuteScalar().ToString());
            //DBConnection.ID_Sotrudnik = ID_Sotrudnik;

            //DBConnection.FIO = FIO;
            ID_record = Convert.ToInt32(command.ExecuteScalar().ToString());
            DBConnection.connection.Close();
            return (ID_record);
        }

        public Int32 Authorization2(string User_Login, string User_Password)
        {
            Int32 ID_Sotrudnik = 0;
            string FIO;
            command1.CommandText = "SELECT Familiya_Sotrudnik + ' ' + Name_Sotrudnik + ' ' + Otchestvo_Sotrudnik from [dbo].[Sotrudnik] where LoginS = '" + User_Login + "' and PasswordS = '" + User_Password + "'";
            command2.CommandText = "SELECT ID_Sotrudnik  from [dbo].[Sotrudnik] where LoginS = '" + User_Login + "' and PasswordS = '" + User_Password + "'";

            DBConnection.connection.Open();

            FIO = command1.ExecuteScalar().ToString();

            ID_Sotrudnik = Convert.ToInt32(command2.ExecuteScalar().ToString());
            DBConnection.ID_Sotrudnik = ID_Sotrudnik;

            DBConnection.FIO = FIO;
            DBConnection.ID_Sotrudnik = ID_Sotrudnik;
            DBConnection.connection.Close();
            return (ID_Sotrudnik);
        }

        public void Documents_Update(Int32 ID_Normativnie_Documenti, string Name_Normativnie_Documenti, string Srok_Deistviya)
        {
            commandConfig("Documents_Update");
            command.Parameters.AddWithValue("@ID_Normativnie_Documenti", ID_Normativnie_Documenti);
            command.Parameters.AddWithValue("@Name_Normativnie_Documenti", Name_Normativnie_Documenti);
            command.Parameters.AddWithValue("@Srok_Deistviya", Srok_Deistviya);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void Documents_Delete(Int32 ID_Normativnie_Documenti)
        {
            commandConfig("Documents_Delete");
            command.Parameters.AddWithValue("@ID_Normativnie_Documenti", ID_Normativnie_Documenti);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        ///

        public void Postavhik_Insert(string Familiya_Postavhik, string Name_Postavhik, string Otchestvo_Postavhik, Int32 Normativnie_Documenti_ID)
        {
            commandConfig("Postavhik_Insert");
            command.Parameters.AddWithValue("@Familiya_Postavhik", Familiya_Postavhik);
            command.Parameters.AddWithValue("@Name_Postavhik", Name_Postavhik);
            command.Parameters.AddWithValue("@Otchestvo_Postavhik", Otchestvo_Postavhik);
            command.Parameters.AddWithValue("@Normativnie_Documenti_ID", Normativnie_Documenti_ID);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void Postavhik_Update(Int32 ID_Postavhik, string Familiya_Postavhik, string Name_Postavhik, string Otchestvo_Postavhik, Int32 Normativnie_Documenti_ID)
        {
            commandConfig("Postavhik_Update");
            command.Parameters.AddWithValue("@ID_Postavhik", ID_Postavhik);
            command.Parameters.AddWithValue("@Familiya_Postavhik", Familiya_Postavhik);
            command.Parameters.AddWithValue("@Name_Postavhik", Name_Postavhik);
            command.Parameters.AddWithValue("@Otchestvo_Postavhik", Otchestvo_Postavhik);
            command.Parameters.AddWithValue("@Normativnie_Documenti_ID", Normativnie_Documenti_ID);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void Postavhik_Delete(Int32 ID_Postavhik)
        {
            commandConfig("Postavhik_Delete");
            command.Parameters.AddWithValue("@ID_Postavhik", ID_Postavhik);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        ///

        public void Sirie_Insert(string Name_Sirie, string Date_Postavki, Int32 Postavhik_ID)
        {
            commandConfig("Sirie_Insert");
            command.Parameters.AddWithValue("@Name_Sirie", Name_Sirie);
            command.Parameters.AddWithValue("@Date_Postavki", Date_Postavki);
            command.Parameters.AddWithValue("@Postavhik_ID", Postavhik_ID);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void Sirie_Update(Int32 ID_Sirie, string Name_Sirie, string Date_Postavki, Int32 Postavhik_ID)
        {
            commandConfig("Sirie_Update");
            command.Parameters.AddWithValue("@ID_Sirie", ID_Sirie);
            command.Parameters.AddWithValue("@Name_Sirie", Name_Sirie);
            command.Parameters.AddWithValue("@Date_Postavki", Date_Postavki);
            command.Parameters.AddWithValue("@Postavhik_ID", Postavhik_ID);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void Sirie_Delete(Int32 ID_Sirie)
        {
            commandConfig("Sirie_Delete");
            command.Parameters.AddWithValue("@ID_Sirie", ID_Sirie);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        ///

        public void Doljnost_Insert(string Name_Doljnost, decimal Oklad)
        {
            commandConfig("Doljnost_Insert");
            command.Parameters.AddWithValue("@Name_Doljnost", Name_Doljnost);
            command.Parameters.AddWithValue("@Oklad", Oklad);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void Doljnost_Update(Int32 ID_Doljnost, string Name_Doljnost, decimal Oklad)
        {
            commandConfig("Doljnost_Update");
            command.Parameters.AddWithValue("@ID_Doljnost", ID_Doljnost);
            command.Parameters.AddWithValue("@Name_Doljnost", Name_Doljnost);
            command.Parameters.AddWithValue("@Oklad", Oklad);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void Doljnost_Delete(Int32 ID_Doljnost)
        {
            commandConfig("Doljnost_Delete");
            command.Parameters.AddWithValue("@ID_Doljnost", ID_Doljnost);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        ///

        public void Klient_Insert(string Familiya_Klient, string Name_Klient, string Otchestvo_Klient)
        {
            commandConfig("Klient_Insert");
            command.Parameters.AddWithValue("@Familiya_Klient", Familiya_Klient);
            command.Parameters.AddWithValue("@Name_Klient", Name_Klient);
            command.Parameters.AddWithValue("@Otchestvo_Klient", Otchestvo_Klient);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void Klient_Update(Int32 ID_Klient, string Familiya_Klient, string Name_Klient, string Otchestvo_Klient)
        {
            commandConfig("Klient_Update");
            command.Parameters.AddWithValue("@ID_Klient", ID_Klient);
            command.Parameters.AddWithValue("@Familiya_Klient", Familiya_Klient);
            command.Parameters.AddWithValue("@Name_Klient", Name_Klient);
            command.Parameters.AddWithValue("@Otchestvo_Klient", Otchestvo_Klient);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void Klient_Delete(Int32 ID_Klient)
        {
            commandConfig("Klient_Delete");
            command.Parameters.AddWithValue("@ID_Klient", ID_Klient);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        ///

        public void Sotrudnik_Insert(string Familiya_Sotrudnik, string Name_Sotrudnik, string Otchestvo_Sotrudnik, string Date_Rojdeniya, string Seriya_Pasporta, string Number_Pasporta, string LoginS, string PasswordS, Int32 Doljnost_ID, Int32 Normativnie_Documenti_ID)
        {
            commandConfig("Sotrudnik_Insert");
            command.Parameters.AddWithValue("@Familiya_Sotrudnik", Familiya_Sotrudnik);
            command.Parameters.AddWithValue("@Name_Sotrudnik", Name_Sotrudnik);
            command.Parameters.AddWithValue("@Otchestvo_Sotrudnik", Otchestvo_Sotrudnik);
            command.Parameters.AddWithValue("@Date_Rojdeniya", Date_Rojdeniya);
            command.Parameters.AddWithValue("@Seriya_Pasporta", Seriya_Pasporta);
            command.Parameters.AddWithValue("@Number_Pasporta", Number_Pasporta);
            command.Parameters.AddWithValue("@LoginS", LoginS);
            command.Parameters.AddWithValue("@PasswordS", PasswordS);
            command.Parameters.AddWithValue("@Doljnost_ID", Doljnost_ID);
            command.Parameters.AddWithValue("@Normativnie_Documenti_ID", Normativnie_Documenti_ID);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void Sotrudnik_Update(Int32 ID_Sotrudnik, string Familiya_Sotrudnik, string Name_Sotrudnik, string Otchestvo_Sotrudnik, string Date_Rojdeniya, string Seriya_Pasporta, string Number_Pasporta, string LoginS, string PasswordS, Int32 Doljnost_ID, Int32 Normativnie_Documenti_ID)
        {
            commandConfig("Sotrudnik_Update");
            command.Parameters.AddWithValue("@ID_Sotrudnik", ID_Sotrudnik);
            command.Parameters.AddWithValue("@Familiya_Sotrudnik", Familiya_Sotrudnik);
            command.Parameters.AddWithValue("@Name_Sotrudnik", Name_Sotrudnik);
            command.Parameters.AddWithValue("@Otchestvo_Sotrudnik", Otchestvo_Sotrudnik);
            command.Parameters.AddWithValue("@Date_Rojdeniya", Date_Rojdeniya);
            command.Parameters.AddWithValue("@Seriya_Pasporta", Seriya_Pasporta);
            command.Parameters.AddWithValue("@Number_Pasporta", Number_Pasporta);
            command.Parameters.AddWithValue("@LoginS", LoginS);
            command.Parameters.AddWithValue("@PasswordS", PasswordS);
            command.Parameters.AddWithValue("@Doljnost_ID", Doljnost_ID);
            command.Parameters.AddWithValue("@Normativnie_Documenti_ID", Normativnie_Documenti_ID);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void Sotrudnik_Delete(Int32 ID_Sotrudnik)
        {
            commandConfig("Sotrudnik_Delete");
            command.Parameters.AddWithValue("@ID_Sotrudnik", ID_Sotrudnik);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        ///

        public void Tovar_Insert(string Name_Tovar, Int32 Kolichestvo_Tovar, decimal Cena, string Data_Proisvodstva, Int32 Sirie_ID, Int32 Sotrudnik_ID, Int32 Type_Tovar_ID)
        {
            commandConfig("Tovar_Insert");
            command.Parameters.AddWithValue("@Name_Tovar", Name_Tovar);
            command.Parameters.AddWithValue("@Kolichestvo_Tovar", Kolichestvo_Tovar);
            command.Parameters.AddWithValue("@Cena", Cena);
            command.Parameters.AddWithValue("@Data_Proisvodstva", Data_Proisvodstva);
            command.Parameters.AddWithValue("@Sirie_ID", Sirie_ID);
            command.Parameters.AddWithValue("@Sotrudnik_ID", Sotrudnik_ID);
            command.Parameters.AddWithValue("@Type_Tovar_ID", Type_Tovar_ID);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void Tovar_Update(Int32 ID_Tovar, string Name_Tovar, Int32 Kolichestvo_Tovar, decimal Cena, string Data_Proisvodstva, Int32 Sirie_ID, Int32 Sotrudnik_ID, Int32 Type_Tovar_ID)
        {
            commandConfig("Tovar_Update");
            command.Parameters.AddWithValue("@ID_Tovar", ID_Tovar);
            command.Parameters.AddWithValue("@Name_Tovar", Name_Tovar);
            command.Parameters.AddWithValue("@Kolichestvo_Tovar", Kolichestvo_Tovar);
            command.Parameters.AddWithValue("@Cena", Cena);
            command.Parameters.AddWithValue("@Data_Proisvodstva", Data_Proisvodstva);
            command.Parameters.AddWithValue("@Sirie_ID", Sirie_ID);
            command.Parameters.AddWithValue("@Sotrudnik_ID", Sotrudnik_ID);
            command.Parameters.AddWithValue("@Type_Tovar_ID", Type_Tovar_ID);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void Tovar_Delete(Int32 ID_Tovar)
        {
            commandConfig("Tovar_Delete");
            command.Parameters.AddWithValue("@ID_Tovar", ID_Tovar);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        ///

        public void Zakaz_Insert(Int32 Number_Zakaz, Int32 Kolichestvo, decimal Summa, string Date_Prodaji, Int32 Status_Zakaza_ID, Int32 Sotrudnik_ID, Int32 Klient_ID, Int32 Tovar_ID)
        {
            commandConfig("Zakaz_Insert");
            command.Parameters.AddWithValue("@Number_Zakaz", Number_Zakaz);
            command.Parameters.AddWithValue("@Kolichestvo", Kolichestvo);
            command.Parameters.AddWithValue("@Summa", Summa);
            command.Parameters.AddWithValue("@Date_Prodaji", Date_Prodaji);
            command.Parameters.AddWithValue("@Status_Zakaza_ID", Status_Zakaza_ID);
            command.Parameters.AddWithValue("@Sotrudnik_ID", Sotrudnik_ID);
            command.Parameters.AddWithValue("@Klient_ID", Klient_ID);
            command.Parameters.AddWithValue("@Tovar_ID", Tovar_ID);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void Zakaz_Update(Int32 ID_Zakaz, Int32 Number_Zakaz, Int32 Kolichestvo, decimal Summa, string Date_Prodaji, Int32 Status_Zakaza_ID, Int32 Sotrudnik_ID, Int32 Klient_ID, Int32 Tovar_ID)
        {
            commandConfig("Zakaz_Update");
            command.Parameters.AddWithValue("@ID_Zakaz", ID_Zakaz);
            command.Parameters.AddWithValue("@Number_Zakaz", Number_Zakaz);
            command.Parameters.AddWithValue("@Kolichestvo", Kolichestvo);
            command.Parameters.AddWithValue("@Summa", Summa);
            command.Parameters.AddWithValue("@Date_Prodaji", Date_Prodaji);
            command.Parameters.AddWithValue("@Status_Zakaza_ID", Status_Zakaza_ID);
            command.Parameters.AddWithValue("@Sotrudnik_ID", Sotrudnik_ID);
            command.Parameters.AddWithValue("@Klient_ID", Klient_ID);
            command.Parameters.AddWithValue("@Tovar_ID", Tovar_ID);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void Zakaz_Delete(Int32 ID_Zakaz)
        {
            commandConfig("Zakaz_Delete");
            command.Parameters.AddWithValue("@ID_Zakaz", ID_Zakaz);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        ///

        public void Chek_Insert(Int32 Number_Chek, string Date_Pechat, Int32 Sotrudnik_ID, Int32 Klient_ID, Int32 Tovar_ID, Int32 Type_Zakaz_ID)
        {
            commandConfig("Chek_Insert");
            command.Parameters.AddWithValue("@Number_Chek", Number_Chek);
            command.Parameters.AddWithValue("@Date_Pechat", Date_Pechat);
            command.Parameters.AddWithValue("@Sotrudnik_ID", Sotrudnik_ID);
            command.Parameters.AddWithValue("@Klient_ID", Klient_ID);
            command.Parameters.AddWithValue("@Tovar_ID", Tovar_ID);
            command.Parameters.AddWithValue("@Type_Zakaz_ID", Type_Zakaz_ID);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void Chek_Update(Int32 ID_Chek, Int32 Number_Chek, string Date_Pechat, Int32 Sotrudnik_ID, Int32 Klient_ID, Int32 Tovar_ID, Int32 Type_Zakaz_ID)
        {
            commandConfig("Chek_Update");
            command.Parameters.AddWithValue("@ID_Chek", ID_Chek);
            command.Parameters.AddWithValue("@Number_Chek", Number_Chek);
            command.Parameters.AddWithValue("@Date_Pechat", Date_Pechat);
            command.Parameters.AddWithValue("@Sotrudnik_ID", Sotrudnik_ID);
            command.Parameters.AddWithValue("@Klient_ID", Klient_ID);
            command.Parameters.AddWithValue("@Tovar_ID", Tovar_ID);
            command.Parameters.AddWithValue("@Type_Zakaz_ID", Type_Zakaz_ID);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void Chek_Delete(Int32 ID_Chek)
        {
            commandConfig("Chek_Delete");
            command.Parameters.AddWithValue("@ID_Chek", ID_Chek);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }



        public void Login_Password_Update(Int32 ID_Sotrudnik, string LoginS, string PasswordS)
        {
            commandConfig("Login_Password_Update");
            command.Parameters.AddWithValue("@ID_Sotrudnik", ID_Sotrudnik);
            command.Parameters.AddWithValue("@LoginS", LoginS);
            command.Parameters.AddWithValue("@PasswordS", PasswordS);
            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

    }
}
