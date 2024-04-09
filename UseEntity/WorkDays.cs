using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using RestSharp;
using FluentAssertions;

namespace Infrastructure
{
    public class WorkDays
    {

        public static DateTime CalcWorksDays(string accessToken, int dayNumber)
        {
            string baseUrl = "http://iispreprod01/TlvServices/Tlv.BusinessRegistration/APIDev/LicenseService/api/License/GetWorkDays";
            RestClient client = new RestClient(baseUrl);


            DateTime currentDate = DateTime.Now;
            DateTime startDate = DateTime.Now;
            RestResponse response;
        
            
            while (true)
            {
                RestRequest request = new RestRequest(baseUrl, Method.Get);

                request.AddHeader("Authorization", $"Bearer {accessToken}");

                request.AddParameter("start", $"{startDate.Month}/{startDate.Day}/{startDate.Year}", ParameterType.QueryString);
                request.AddParameter("end", $"{currentDate.Month}/{currentDate.Day}/{currentDate.Year}", ParameterType.QueryString);

                Console.WriteLine($"Start day: {startDate.Month}/{startDate.Day}/{startDate.Year}");
                Console.WriteLine($"Request Resource: {client.BuildUri(request)}");

                response = client.Execute(request);
                response.StatusCode.Should().Be(HttpStatusCode.OK, $"Get request failed: {baseUrl}");
                Console.WriteLine($"Response Content: {response.Content}");

                if (response.Content == Convert.ToString(dayNumber))
                {
                    break;
                }

                startDate = startDate.AddDays(-1);
            }

            return startDate;

        }

     
    }
}
