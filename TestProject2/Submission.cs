using System;
using System.Data.SqlClient;
using System.Resources;


namespace TestProject2
{
    public class Submission
    {
        private static string connectionString = "Data Source=SQLDEV1902;Initial Catalog=db950_re;User Id=db950_d;Password=h#649950;TrustServerCertificate=True;";

        public static void UpdateSubmissionDate_DB(int bakashaId, DateTime newDate)
        {
        
            Console.WriteLine("new start day for submission  - " + newDate.ToString("yyyy-MM-ddTHH:mm:ss.fffffff"));
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                if (connection.State == System.Data.ConnectionState.Open)
                {
                    Console.WriteLine("The connection was successfully opened.");
                }

                string updateQuery = $"UPDATE ris_t_bakasha SET taarich_hagashat_habakasha = '{newDate:yyyy-MM-ddTHH:mm:ss.fffffff}', CreatedDate = '{newDate:yyyy-MM-ddTHH:mm:ss.fffffff}' WHERE PK_code_bakasha = {bakashaId}";


                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.Add("@taarich_hagashat_habakasha", System.Data.SqlDbType.DateTime2).Value = newDate;

                    command.Parameters.Add("@CreatedDate", System.Data.SqlDbType.DateTime2).Value = newDate;

                    command.Parameters.Add("@BakashaId", System.Data.SqlDbType.Int).Value = bakashaId;



                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine($"Value successfully updated for PK_code_bakasha = {bakashaId}");
                    }
                    else
                    {
                        Console.WriteLine($"The value has not been updated. The entry with PK_code_bakasha = {bakashaId} may not have been found.");
                    }


                }
             

            }

        }
    }
}
