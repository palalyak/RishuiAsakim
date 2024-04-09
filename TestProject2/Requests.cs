using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using RestSharp;

namespace TestProject2
{
    public class Requests
    {

        string baseUrl = "https://iispreprodlb.tlv.gov.il/TlvServices/Tlv.BusinessRegistration/APIDev/ManagementApi/api";

        public RestResponse Get(string accessToken, string subdomain="")
        {
            RestClient client = new RestClient($"{baseUrl}/{subdomain}");
            RestRequest restRequest = new RestRequest($"{baseUrl}/{subdomain}", Method.Get);
            restRequest.AddHeader("Authorization", $"Bearer {accessToken}");
            RestResponse restResponse = client.Execute(restRequest);
            restResponse.StatusCode.Should().Be(HttpStatusCode.OK, $"Get request failed: {baseUrl}/{subdomain}");

            Console.WriteLine($"Request Resource: {client.BuildUri(restRequest)}");

            return restResponse;
        }
        public RestResponse Post(string accessToken, string subdomain = "")
        {
            RestClient client = new RestClient($"{baseUrl}/{subdomain}");
            RestRequest restRequest = new RestRequest($"{baseUrl}/{subdomain}", Method.Post);
            restRequest.AddHeader("Authorization", $"Bearer {accessToken}");
            RestResponse restResponse = client.Execute(restRequest);

            restResponse.StatusCode.Should().Be(HttpStatusCode.OK, $"Post request failed: {baseUrl}/{subdomain}");
            Console.WriteLine($"Request Resource: {client.BuildUri(restRequest)}");
          
            return restResponse;
        }




        public RestResponse PostFakeApiRequest()
        {
            RestClient client = new RestClient(baseUrl);
            var body = BuildBodyRequest();
            RestRequest restRequest = new RestRequest(baseUrl, Method.Post);
            restRequest.AddBody(body, ContentType.Json);

            RestResponse restResponse = client.Execute(restRequest);

            return restResponse;
        }

        public RestResponse PutFakeApiRequest(int id)
        {
            RestClient client = new RestClient(baseUrl);
            var body = BuildBodyRequest(id);
            RestRequest restRequest = new RestRequest($"{baseUrl}/{id}", Method.Put);
            restRequest.AddBody(body, ContentType.Json);

            RestResponse restResponse = client.Execute(restRequest);

            return restResponse;
        }

        public RestResponse DeleteFakeApiRequest(int id)
        {
            RestClient client = new RestClient(baseUrl);
            var body = BuildBodyRequest(id);
            RestRequest restRequest = new RestRequest($"{baseUrl}/{id}", Method.Delete);
            restRequest.AddBody(body, ContentType.Json);

            RestResponse restResponse = client.Execute(restRequest);

            return restResponse;
        }


        public static FakeApiEntities BuildBodyRequest()
        {
            return new FakeApiEntities
            {
                Id = 100,
                Title = "Test Book",
                Description = "Mussum Ipsum, cacilds vidis litro abertis.  Quem num gosta di mim que vai caçá sua turmis!",
                Excerpt = "uem num gosta di mim que vai caçá sua turmis!",
                PageCount = 100,
                PublishDate = "2023-09-03T13:50:32.6884665+00:00"
            };
        }

        public static FakeApiEntities BuildBodyRequest(int? id = null)
        {
            return new FakeApiEntities
            {
                Id = id ?? 100,
                Title = "Test Book",
                Description = "Mussum Ipsum, cacilds vidis litro abertis.  Quem num gosta di mim que vai caçá sua turmis!",
                Excerpt = "uem num gosta di mim que vai caçá sua turmis!",
                PageCount = 100,
                PublishDate = "2023-09-03T13:50:32.6884665+00:00"
            };
        }


    }
}
