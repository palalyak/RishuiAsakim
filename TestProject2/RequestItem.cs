using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject2
{
    public class RequestItem
    {
        private static string connectionString = "Data Source=SQLDEV1902;Initial Catalog=db950_re;User Id=db950_d;Password=h#649950;TrustServerCertificate=True;";

        public static List<int> GetCodeParit_DB(int bakashaId)
        {
            List<int> codeParitList = new List<int>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                if (connection.State == System.Data.ConnectionState.Open)
                {
                    Console.WriteLine("The connection was successfully opened.");
                }

                string selectQuery = $"SELECT FK_code_parit FROM ris_tx_mahuiot_bebakashot WHERE Fk_bakasha = {bakashaId}";

                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Читаем значение из результата запроса
                            int codeParit = Convert.ToInt32(reader["FK_code_parit"]);
                            codeParitList.Add(codeParit);
                            Console.WriteLine($"FK_code_parit value for Fk_bakasha = {bakashaId}: {codeParit}");
                        }

                        if (codeParitList.Count == 0)
                        {
                            Console.WriteLine($"Records with Fk_bakasha = {bakashaId} not found.");
                        }
                    }
                }
            }

            return codeParitList;
        }
    }

}
