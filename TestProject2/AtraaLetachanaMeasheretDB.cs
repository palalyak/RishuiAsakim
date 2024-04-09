using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace TestProject2
{
    public class AtraaLetachanaMeasheretDB
    {
        private static string connectionString = "Data Source=SQLDEV1902;Initial Catalog=db950_re;User Id=db950_d;Password=h#649950;TrustServerCertificate=True;";
        private static List<string> atraaList = new List<string>();
        public static string Get(List<int> codeTahana)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                if (connection.State == System.Data.ConnectionState.Open)
                {
                    Console.WriteLine("The connection was successfully opened.");
                }

                string parameters = string.Join(",", codeTahana.Select((_, index) => $"@param{index}"));

                string selectQuery = $"SELECT fk_code_tachana, shalav, maslul, aaracha, atraa, sug_atraa, CreatedDate, UpdatedDate " +
                                     $"FROM ris_t_atraa_letachana_measheret " +
                                     $"WHERE fk_code_tachana IN ({parameters})";

                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    for (int i = 0; i < codeTahana.Count; i++)
                    {
                        command.Parameters.AddWithValue($"@param{i}", codeTahana[i]);
                    }

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Read values from the query result
                            AtraaLetachanaMeasheretData data = new AtraaLetachanaMeasheretData
                            {
                                FkCodeTachana = Convert.ToInt32(reader["fk_code_tachana"]),
                                Shalav = reader["shalav"].ToString(),
                                Maslul = reader["maslul"].ToString(),
                                Aaracha = reader["aaracha"].ToString(),
                                Atraa = reader["atraa"].ToString(),
                                SugAtraa = reader["sug_atraa"].ToString(),
                                CreatedDate = Convert.ToDateTime(reader["CreatedDate"]),
                                UpdatedDate = Convert.ToDateTime(reader["UpdatedDate"])
                            };

                            atraaList.Add(data.ToString());

                            Console.WriteLine($"fk_code_tachana: {data.FkCodeTachana}, shalav: {data.Shalav}, maslul: {data.Maslul}, aaracha: {data.Aaracha}, atraa: {data.Atraa}, sug_atraa: {data.SugAtraa}, CreatedDate: {data.CreatedDate}, UpdatedDate: {data.UpdatedDate}");
                        }

                        if (atraaList.Count == 0)
                        {
                            atraaList.Add($"No record found");
                        }
                    }
                }
            }

            return string.Join(Environment.NewLine, atraaList);
        }
    public static string Delete(List<int> codeTahana)
    {

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            if (connection.State == System.Data.ConnectionState.Open)
            {
                Console.WriteLine("The connection was successfully opened.");
            }

            string parameters = string.Join(",", codeTahana.Select((_, index) => $"@param{index}"));

            string deleteQuery = $"DELETE FROM ris_t_atraa_letachana_measheret WHERE fk_code_tachana IN ({parameters})";

            using (SqlCommand command = new SqlCommand(deleteQuery, connection))
            {
                for (int i = 0; i < codeTahana.Count; i++)
                {
                    command.Parameters.AddWithValue($"@param{i}", codeTahana[i]);
                }

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine($"{rowsAffected} rows successfully deleted.");
                }
                else
                {
                    Console.WriteLine("No rows found for deletion.");
                    }
                }
                return "== Clean [ris_t_atraa_letachana_measheret] ==";
            }
    }
}



    public class AtraaLetachanaMeasheretData
    {
        public int FkCodeTachana { get; set; }
        public string Shalav { get; set; }
        public string Maslul { get; set; }
        public string Aaracha { get; set; }
        public string Atraa { get; set; }
        public string SugAtraa { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public override string ToString()
        {
            return $"FkCodeTachana: {FkCodeTachana}, Shalav: {Shalav}, Maslul: {Maslul}, Aaracha: {Aaracha}, Atraa: {Atraa}, SugAtraa: {SugAtraa}, CreatedDate: {CreatedDate}, UpdatedDate: {UpdatedDate}";
        }
    }
}
