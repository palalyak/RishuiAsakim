using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace TestProject2
{
    public class HaarachatMoedLemahutDB
    {
        private static string connectionString = "Data Source=SQLDEV1902;Initial Catalog=db950_re;User Id=db950_d;Password=h#649950;TrustServerCertificate=True;";
        public static List<string> haarachatMoedLemahutList = new List<string>();

        public static string Get(List<int> code_parit)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                if (connection.State == System.Data.ConnectionState.Open)
                {
                    Console.WriteLine("The connection was successfully opened.");
                }

                string parameters = string.Join(",", code_parit.Select((_, index) => $"@param{index}"));

                string selectQuery = $"SELECT fk_code_parit, fk_code_shalav, kamut_yemi_haaracha, mispar_haaracha, CreatedDate " +
                                     $"FROM ris_t_haarachat_moed_lemahut " +
                                     $"WHERE fk_code_parit IN ({parameters})";

                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    for (int i = 0; i < code_parit.Count; i++)
                    {
                        command.Parameters.AddWithValue($"@param{i}", code_parit[i]);
                    }

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            HaarachatMoedLemahutData data = new HaarachatMoedLemahutData
                            {
                                FkCodeParit = Convert.ToInt32(reader["fk_code_parit"]),
                                FkCodeShalav = Convert.ToInt32(reader["fk_code_shalav"]),
                                KamutYemiHaaracha = Convert.ToInt32(reader["kamut_yemi_haaracha"]),
                                MisparHaaracha = Convert.ToInt32(reader["mispar_haaracha"]),
                                CreatedDate = Convert.ToDateTime(reader["CreatedDate"])
                            };

                            haarachatMoedLemahutList.Add(data.ToString());

                            Console.WriteLine($"fk_code_parit: {data.FkCodeParit}, fk_code_shalav: {data.FkCodeShalav}, kamut_yemi_haaracha: {data.KamutYemiHaaracha}, mispar_haaracha: {data.MisparHaaracha}, CreatedDate: {data.CreatedDate}");
                        }

                        if (haarachatMoedLemahutList.Count == 0)
                        {
                            haarachatMoedLemahutList.Add($"No record found");
                        }
                    }
                }
            }

            return string.Join(Environment.NewLine, haarachatMoedLemahutList);
        }
        public static string Delete(List<int> code_parit)
    {
            haarachatMoedLemahutList.Add("== Clean [ris_t_haarachat_moed_lemahut] ==");
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            if (connection.State == System.Data.ConnectionState.Open)
            {
                haarachatMoedLemahutList.Add("The connection to DB was successfully opened.");
            }

            string parameters = string.Join(",", code_parit.Select((_, index) => $"@param{index}"));

            string deleteQuery = $"DELETE FROM ris_t_haarachat_moed_lemahut WHERE fk_code_parit IN ({parameters})";


            using (SqlCommand command = new SqlCommand(deleteQuery, connection))
            {
                for (int i = 0; i < code_parit.Count; i++)
                {
                    command.Parameters.AddWithValue($"@param{i}", code_parit[i]);
                }

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    haarachatMoedLemahutList.Add($"{rowsAffected} rows successfully deleted.");
                }
                else
                {
                    Console.WriteLine("No rows found for deletion.");
                }
            }
                if (haarachatMoedLemahutList.Count == 1)
                {
                    haarachatMoedLemahutList.Add($"No record found");
                }
                return string.Join(Environment.NewLine, haarachatMoedLemahutList); 
            }
    }
}

    public class HaarachatMoedLemahutData
    {
        public int FkCodeParit { get; set; }
        public int FkCodeShalav { get; set; }
        public int KamutYemiHaaracha { get; set; }
        public int MisparHaaracha { get; set; }
        public DateTime CreatedDate { get; set; }

        public override string ToString()
        {
            return $"FkCodeParit: {FkCodeParit}, FkCodeShalav: {FkCodeShalav}, KamutYemiHaaracha: {KamutYemiHaaracha}, MisparHaaracha: {MisparHaaracha}, CreatedDate: {CreatedDate}";
        }
    }
}
