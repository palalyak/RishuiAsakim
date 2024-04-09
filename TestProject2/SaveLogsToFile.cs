using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject2
{
    internal class SaveLogsToFile
    {
        public static void SaveLog(List<string> logs)
        {
            string relativePath = "log.txt";

            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // Полный путь к файлу
            string filePath = Path.Combine(baseDirectory, relativePath);

            // Создаем текстовый файл
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine($"=== Start Logs / Test time: {DateTime.Now} ===");

                // Записываем логи в файл
  
                for (int i = 0; i < logs.Count; i++)
                {
                    writer.WriteLine($"{i}. {logs[i]}");
                }

                writer.WriteLine("==== END LOG ====");
                writer.WriteLine(" ");
            }
        }
    }
}
