using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SummerPractice
{
    public static class DataBase
    {
        static MySqlConnection conn;
        public static void Connect()
        {
            string connectionString = "Server = sql8.freesqldatabase.com; Database = sql8504692; " +
                    "port = 3306; User Id = sql8504692; password = ALe5X5ee9k; CharSet = utf8";
            try
            {
                conn = new MySqlConnection(connectionString);
                conn.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static DataTable GetFilters(int type)
        {
            Connect();
            MySqlCommand myCommand = new MySqlCommand();
            myCommand.Connection = conn;
            string typeFilter;
            switch (type)
            {
                case 0: myCommand.Parameters.AddWithValue("@a", "Вакуумный барабанный");
                    typeFilter =  "барабанный";
                    myCommand.Parameters.AddWithValue("@type", typeFilter);
                    break;
                case 1: myCommand.Parameters.AddWithValue("@a", "Вакуумный ленточный");
                    myCommand.Parameters.AddWithValue("@type", "ленточный");
                    break;
            }
            if (type == -1)
            myCommand.CommandText = "SELECT * FROM `фильтры`";
            else myCommand.CommandText = "select * from `фильтры` f inner join `доппараметры` d on f.`ID_Фильтра` = d.`ID_Фильтра`" +
            " where d.`Тип фильтра` = @a";
            /*  myCommand.CommandText = "Amount";
              myCommand.CommandType = CommandType.StoredProcedure;*/
            myCommand.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(myCommand);
            adapter.Fill(dt);
            conn.Close();
            return dt;
        }

        public static DataTable GetFilters2(string type, string  chosenManifactures, 
            int minWeight, int maxWeight, string chosenRawMaterials, int amountRawMat, int minLength, 
            int maxLength, int minWidth, int maxWidth, int minHeight, int maxHeight,
            float minPressure,  float maxPressure, float minPower, float maxPower,
            int minSquare, int maxSquare, int minWeightSingle, int maxWeightSingle,
            string chosenMaterials, int maxPrice, int minPrice, int minLen, int maxLen, 
            int minDiam, int maxDiam, float minFr, float maxFr)
        {
            Connect();
            MySqlCommand myCommand = new MySqlCommand();
            myCommand.Connection = conn;
            myCommand.Parameters.AddWithValue("@FilterType", type);
            myCommand.Parameters.AddWithValue("@производители", chosenManifactures);
            myCommand.Parameters.AddWithValue("@min_Масса", minWeight);
            myCommand.Parameters.AddWithValue("@max_Масса", maxWeight);
            myCommand.Parameters.AddWithValue("@сырья", chosenRawMaterials);
            myCommand.Parameters.AddWithValue("@min_длина", minLength);
            myCommand.Parameters.AddWithValue("@max_длина", maxLength);
            myCommand.Parameters.AddWithValue("@min_ширина", minWidth);
            myCommand.Parameters.AddWithValue("@max_ширина", maxWidth);
            myCommand.Parameters.AddWithValue("@min_высота", minHeight);
            myCommand.Parameters.AddWithValue("@max_высота", maxHeight);
            myCommand.Parameters.AddWithValue("@min_давление", minPressure);
            myCommand.Parameters.AddWithValue("@max_давление", maxPressure);
            myCommand.Parameters.AddWithValue("@min_мощность", minPower);
            myCommand.Parameters.AddWithValue("@max_мощность", maxPower);
            myCommand.Parameters.AddWithValue("@min_площадь", minSquare);
            myCommand.Parameters.AddWithValue("@max_площадь", maxSquare);
            myCommand.Parameters.AddWithValue("@min_массаНаЕдиницу", minWeightSingle);
            myCommand.Parameters.AddWithValue("@max_массаНаЕдиницу", maxWeightSingle);
            myCommand.Parameters.AddWithValue("@материалИзготовления", chosenMaterials);
            myCommand.Parameters.AddWithValue("@min_цена", minPrice);
            myCommand.Parameters.AddWithValue("@max_цена", maxPrice);
            myCommand.Parameters.AddWithValue("@количествоСырья", amountRawMat);
            myCommand.Parameters.AddWithValue("@min_дли", minLen);
            myCommand.Parameters.AddWithValue("@max_дли", maxLen);
            myCommand.Parameters.AddWithValue("@min_диам", minDiam);
            myCommand.Parameters.AddWithValue("@max_диам", maxDiam);
            myCommand.Parameters.AddWithValue("@min_час", minFr);
            myCommand.Parameters.AddWithValue("@max_час", maxFr);
            myCommand.Parameters.AddWithValue("@min_ширл", 2);
            myCommand.Parameters.AddWithValue("@max_ширл", 1);
            myCommand.Parameters.AddWithValue("@min_скоростьЛенты", 2);
            myCommand.Parameters.AddWithValue("@max_скоростьЛенты", 1);
            myCommand.Parameters.AddWithValue("@min_диамДиск", 2);
            myCommand.Parameters.AddWithValue("@max_диамДиск", 1);
            myCommand.Parameters.AddWithValue("@min_колвоДиск", 2);
            myCommand.Parameters.AddWithValue("@max_колвоДиск", 1);
            myCommand.Parameters.AddWithValue("@min_колвоСектДиск", 2);
            myCommand.Parameters.AddWithValue("@max_колвоСектДиск", 1);
            myCommand.CommandText = "SelectAllOfType";
              myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(myCommand);
            adapter.Fill(dt);
            conn.Close();
            return dt;
        }

        public static List<String> GetManifactures()
        {
            Connect();
            MySqlCommand myCommand = new MySqlCommand();
            myCommand.Connection = conn;
            myCommand.CommandText = "ВсеПроизводители";
            myCommand.ExecuteNonQuery();
            List<String> list = new List<String>();
            using (var reader = myCommand.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        list.Add(reader.GetString(0));
                    }
                }
            }
            conn.Close();
            return list;
        }
        public static List<String> GetMaterials()
        {
            Connect();
            MySqlCommand myCommand = new MySqlCommand();
            myCommand.Connection = conn;
            myCommand.CommandText = "ВсеМатериалыИзготовления";
            myCommand.ExecuteNonQuery();
            List<String> list = new List<String>();
            using (var reader = myCommand.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        list.Add(reader.GetString(0));
                    }
                }
            }
            conn.Close();
            return list;
        }

        public static List<String> GetRawMaterial(string type)
        {
            Connect();
            MySqlCommand myCommand = new MySqlCommand();
            myCommand.Connection = conn;
            myCommand.Parameters.AddWithValue("@FilterType", type);
            myCommand.CommandText = "сырьёДляТипа";
            myCommand.CommandType = CommandType.StoredProcedure; 
            List <String> list = new List<String>();
            using (var reader = myCommand.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        list.Add(reader.GetString(0));
                    }
                }
            }
            conn.Close();
            return list;
        }


    }
}
