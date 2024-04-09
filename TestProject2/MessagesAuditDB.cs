using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject2
{
    public class MessagesAuditDB
    {
        private static string connectionString = "Data Source=SQLDEV1902;Initial Catalog=db950_tashtit;User Id=db950_d;Password=h#649950;TrustServerCertificate=True;";

        public static string Get()
        {
            List<string> messages = new List<string>();
            string currentDate = DateTime.Now.ToString("yyyy-MM-dd");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                if (connection.State == System.Data.ConnectionState.Open)
                {
                    Console.WriteLine("The connection was successfully opened.");
                }

                // SQL-запрос для получения значений полей
                string selectQuery = $"SELECT [Id], [message_type], [Status], [Message], [To], [Subject], [CreatedDate] FROM ris_t_channel_messages_audit WHERE CreatedDate LIKE '{currentDate}%'";

                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Проверяем, есть ли результаты
                        while (reader.Read())
                        {
                            // Читаем значения из результата запроса
                            int id = Convert.ToInt32(reader["Id"]);
                            string messageType = Convert.ToString(reader["message_type"]);
                            string status = Convert.ToString(reader["Status"]);
                            string message = Convert.ToString(reader["Message"]);
                            string to = Convert.ToString(reader["To"]);
                            string subject = Convert.ToString(reader["Subject"]);
                            DateTime createdDate = Convert.ToDateTime(reader["CreatedDate"]);

                            // Создаем объект MessageAudit и добавляем его в список
                            MessageAudit audit = new MessageAudit
                            {
                                Id = id,
                                MessageType = messageType,
                                Status = status,
                                Message = message,
                                To = to,
                                Subject = subject,
                                CreatedDate = createdDate
                            };

                            messages.Add(audit.ToString());

                            Console.WriteLine($"Message retrieved - Id: {id}, MessageType: {messageType}, Status: {status}, Message: {message}, To: {to}, Subject: {subject}, CreatedDate: {createdDate}");
                        }

                        if (messages.Count == 0)
                        {
                            Console.WriteLine($"No messages found for the date: {currentDate}");
                            messages.Add($"No messages found for the date: {currentDate}");
                        }
                    }
                }
            }

            return string.Join(Environment.NewLine, messages);
        }

    }
    public class MessageAudit
    {
        public int Id { get; set; }
        public string MessageType { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public DateTime CreatedDate { get; set; }
    public override string ToString()
    {
        return $"Id: {Id}, MessageType: {MessageType}, Status: {Status}, Message: {Message}, To: {To}, Subject: {Subject}, CreatedDate: {CreatedDate}";
    }
    }

}
