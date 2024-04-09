using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Infrastructure.ModelsDB;
using Infrastructure.ServicesDB;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;


namespace Infrastructure.Utility
{
    public class HandleContent
    {

   
        public static T GetContent<T>(RestResponse response)
        {
            var content = response.Content;
            return JsonConvert.DeserializeObject<T>(content);
        }

        public static List<T> GetContentList<T>(RestResponse response)
        {
            var content = response.Content;
            if (string.IsNullOrWhiteSpace(content) || content == "[]")
            {
                return new List<T>();
            }
            else
            {
                return JsonConvert.DeserializeObject<List<T>>(content);
            }
        }



        public static T ParseJSON<T>(string file)
        {
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(file));
        }

        public static T ExtractValueFromJson<T>(string jsonResponse, string elementName)
        {
            try
            {
                var jsonObject = JObject.Parse(jsonResponse);
                var value = jsonObject.SelectToken(elementName).Value<T>();
                return value;
            }
            catch (JsonReaderException ex)
            {
                Console.WriteLine($"Error json parsing JSON: {ex.Message}");
                return default(T); 
            }
        }

        public static string ExtractValueFromJsonString(string myString, string elementName)
        {
            string pattern = $"\"{elementName}\":\\s*([^\"]*?)(,|{Regex.Escape("}")}|{Regex.Escape("]")})";


            Match match = Regex.Match(myString, pattern);

            if (match.Success)
            {
                return match.Groups[1].Value.Trim();
            }

            throw new ArgumentException($"Element with name '{elementName}' not found in the JSON string.");
        }

        public static List<string> ExtractValuesFromJsonString(string jsonString, string elementName)
        {
            string pattern = $"\"{elementName}\":\\s*([^\"]*?)(,|{Regex.Escape("}")}|{Regex.Escape("]")})";

            MatchCollection matches = Regex.Matches(jsonString, pattern);

            if (matches.Count > 0)
            {
                List<string> values = new List<string>();
                foreach (Match match in matches)
                {
                    values.Add(match.Groups[1].Value.Trim());
                }
                return values;
            }

            throw new ArgumentException($"No elements with name '{elementName}' found in the JSON string.");
        }

        public static string GetFilePath(string name)
        {
            //string path = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory));
            //string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string path = Directory.GetCurrentDirectory();
            return Path.Combine(path, "TestData", name);
        }

        public static void PrintObjectProperties(object obj)
        {
            Type type = obj.GetType();
            PropertyInfo[] properties = type.GetProperties();

            Console.WriteLine($"Properties of {type.Name}:");

            foreach (var property in properties)
            {
                object value = property.GetValue(obj);
                Console.WriteLine($"{property.Name}: {value}");
            }
            Console.WriteLine(new string('=', 20));
        }
        public static long GetRandomNumber(long minValue, long maxValue)
        {
            if (minValue > maxValue)
            {
                throw new ArgumentException("The minimum value cannot be greater than the maximum");
            }
            Random random = new Random();
            int randomNumber = random.Next((int)minValue, (int)(maxValue + 1));

            return Math.Abs(randomNumber);
        }

        public static DateTime CalculateTimeSet(string timePattern, DateTime? currentTime)
        {
            //  1/18/2024 3:21:29 AM subtract 01 years | 13 months | 1 days | 25 hours | 0 min
            // input format = min 2 number, max 3 number
           
            char sign = timePattern[0]; // Extract the sign (+ or -)
            timePattern = timePattern.Substring(1); // Remove the sign from the input string
            string operation = (sign == '-') ? "subtract" : "add";

            string pattern = @"^\d{1,2}-\d{1,2}-\d{1,2}T\d{1,2}:\d{1,2}$";
            bool validFormat = System.Text.RegularExpressions.Regex.IsMatch(timePattern, pattern);

            if (!validFormat)
            {
                throw new FormatException("The argument must be in the format YY-MM-ddTHH:mm or YYY-MMM-dddTHHH:mmm with + or - before");
            }


            string[] parts = timePattern.Split(new[] { '-', 'T', ':' });
            
            int years = int.Parse(parts[0]);
            int months = int.Parse(parts[1]);
            int days = int.Parse(parts[2]);
            int hours = int.Parse(parts[3]);
            int minutes = int.Parse(parts[4]);

            DateTime currentDate = currentTime ?? DateTime.Today;
            DateTime resultDate = (sign == '-') ? currentDate.AddYears(-years).AddMonths(-months).AddDays(-days).AddHours(-hours).AddMinutes(-minutes)
                : currentDate.AddYears(years).AddMonths(months).AddDays(-days).AddHours(-hours).AddMinutes(-minutes);


            string result = resultDate.ToString("yyyy-MM-ddTHH:mm:ss.fff");   
            Console.WriteLine($"\n<< Time now: {currentDate} {operation}\n " +
                $"<< {years} years | {months} months | {days} days | {hours} hours | {minutes} min equals\n " +
                $"<< {DateTime.Parse(result)} >>\n ");

            return resultDate;
        }



    }
}
