using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject2
{
    public class StationsDB
    {
        private static string connectionString = "Data Source=SQLDEV1902;Initial Catalog=db950_re;User Id=db950_d;Password=h#649950;TrustServerCertificate=True;";

        public static List<int> Get(List<int> codeMautBebakasha)
        {
            List<int> codeStationList = new List<int>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                if (connection.State == System.Data.ConnectionState.Open)
                {
                    Console.WriteLine("The connection was successfully opened.");
                }

                // Генерируем параметры для SQL-запроса
                string parameters = string.Join(",", codeMautBebakasha.Select((_, index) => $"@param{index}"));

                // SQL-запрос для получения значения поля
                string selectQuery = $"SELECT PK_code_tachana FROM ris_t_tachana_measheret WHERE PK_code_maut_bebakasha IN ({parameters})";

                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    // Добавляем параметры к запросу
                    for (int i = 0; i < codeMautBebakasha.Count; i++)
                    {
                        command.Parameters.AddWithValue($"@param{i}", codeMautBebakasha[i]);
                    }

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Проверяем, есть ли результат
                        while (reader.Read())
                        {
                            // Читаем значение из результата запроса
                            int codeTahana = Convert.ToInt32(reader["PK_code_tachana"]);
                            codeStationList.Add(codeTahana);
                            Console.WriteLine($"PK_code_tachana value: {codeTahana}");
                        }

                        if (codeStationList.Count == 0)
                        {
                            Console.WriteLine($"Records not found.");
                        }
                    }
                }
            }

            return codeStationList;
        }


        public static void UpdateStations_DB(List<int> codeStations, DateTime newDate)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                if (connection.State == System.Data.ConnectionState.Open)
                {
                    Console.WriteLine("The connection was successfully opened.");
                }

                foreach (int codeStation in codeStations)
                {
                    // SQL-запрос для обновления значений полей
                    string updateQuery = $"UPDATE ris_t_tachana_measheret " +
                                         $"SET taarich_idkun_acharon = '{newDate:yyyy-MM-ddTHH:mm:ss.fffffff}', " +
                                         $"CreatedDate = '{newDate:yyyy-MM-ddTHH:mm:ss.fffffff}', " +
                                         $"tarich_status_acharon = '{newDate:yyyy-MM-ddTHH:mm:ss.fffffff}' " +
                                         $"WHERE PK_code_tachana = {codeStation}";

                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        // Добавляем параметры к запросу (если они нужны)
                        command.Parameters.Add("@taarich_idkun_acharon", System.Data.SqlDbType.DateTime2).Value = newDate;
                        command.Parameters.Add("@CreatedDate", System.Data.SqlDbType.DateTime2).Value = newDate;
                        command.Parameters.Add("@tarich_status_acharon", System.Data.SqlDbType.DateTime2).Value = newDate;
                        command.Parameters.Add("@CodeStation", System.Data.SqlDbType.Int).Value = codeStation;

                        int rowsAffected = command.ExecuteNonQuery();

                        // Проверяем успешность выполнения запроса
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine($"Values successfully updated for PK_code_tachana = {codeStation}");
                        }
                        else
                        {
                            Console.WriteLine($"The values have not been updated. The entry with PK_code_tachana = {codeStation} may not have been found.");
                        }
                    }
                }

                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    Console.WriteLine("Соединение успешно закрыто.");
                }
                else
                {
                    Console.WriteLine("Соединение не закрыто.");
                }
            }
        }


    }
}
