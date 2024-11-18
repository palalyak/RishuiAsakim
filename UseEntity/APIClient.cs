using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using Infrastructure.Auth;
using NUnit.Framework;
using FluentAssertions;
using System.Net;
using Infrastructure.Utility;
using Infrastructure.ModelsAPI.Response;
using System.Reflection;
using Infrastructure.ModelsAPI.Request;
using Bogus;


namespace Infrastructure
{
    public class APIClient : IAPIClient, IDisposable
    {
        readonly RestClient client;
        private RestResponse _response;
        //static string accessToken = ConfigurationManager.AppSettings.Get("ApiKey");
        static string accessToken = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6IjNQYUs0RWZ5Qk5RdTNDdGpZc2EzWW1oUTVFMCJ9.eyJhdWQiOiI0YzRjNThkNS01OGI2LTQzNzYtOGQyOS1iYzY1YTc5MTVkZTgiLCJpc3MiOiJodHRwczovL2xvZ2luLm1pY3Jvc29mdG9ubGluZS5jb20vYWE2NDBmMTAtOTVmOC00ZjA1LTk2ZjEtNTI5ZGJiYzExODk3L3YyLjAiLCJpYXQiOjE3MzE5MTQ4ODQsIm5iZiI6MTczMTkxNDg4NCwiZXhwIjoxNzMxOTE5MTgzLCJhaW8iOiJBWVFBZS84WUFBQUF2NThSWXhlOXFVaWdBWGIxZkExWjd0MGxYR1NpYmhsTTg5dklLcTMxTHVNQ2tmbmk0ajd2dzdOMHZiOUkvYjY4eGRiQWpKQ3ljM0cxT0d1RjVmNVYvc0k5ZDM4VDkvQWZrUUJVampJbWh6cUpueHE4Q1lkc0F0OWowV243aWFhSDhrYTZ2NEJFek9jbmJqUW5vc0FjVXJPY1QyRVJGYVBteWxsNnQwWTQycDA9IiwiYXpwIjoiNTkzZTVkMDgtMGI3ZS00NWNkLWJhM2YtNzdlNDU1YTA0OWVmIiwiYXpwYWNyIjoiMCIsImdyb3VwcyI6WyIxY2UzMjQxMC1iZGZlLTQ5NGItYmY3NC1hN2JjY2NkN2YwZDEiLCI3ZjU4NzExNS1kYjMxLTQzNGMtYWVhYy0xOTFjOTZmNDQ3NzkiLCIwZmQzZjkxNS03N2UwLTRlMzgtYjVlNC00MTliMDQxZjM4NDkiLCIzMjBjOTExOC0xOTU5LTQ5M2YtOWVjZS1lN2VlZTZmMTAzYjAiLCI3NDFkNzkxOS02MjVjLTRiNjktYWVkYy04Y2Y0ODI2YWFkYzUiLCJhNGM5ZjQxYS0xMzg2LTQ3MzItYTU2My1mZDIzYjc2MDk0NWIiLCJlNDkzZjAxYy0yMTUyLTRhYzQtOTRjMy05OTZlNGNjMTU1MWIiLCJhYjM2OGIxZi04NzRkLTQ0OTUtOWQ1ZC0yNjIwZDg1ZjNjZWYiLCI1MWZjYzUyMS1mMGY4LTQ2MzktYjViNi1hMjMwMWM1YTkyMmQiLCIwNWQ5NjYyMi0zMzZjLTQ0ZWItYmQ3Yy1kZDZkNDM0ZDMxMDQiLCIwODE0YzgyZC0yZDk0LTQzODktYjllNy0zN2U3MzY0NGY0OTQiLCI0OWViNmEyZS03ZjJiLTQ0NWItYjE3OC04ZDQxOTNmM2JlYzgiLCI3NWI2MGQzMi0xY2M4LTRjNmYtYjNkNi0xMzdlNTI2NWUyOWEiLCIwM2MzMmUzOS1kZjJmLTRlZjgtOTUyZS0xMzJlYWUxODJkYTkiLCIyOTc2NTIzZC1iZjliLTQ4ZTEtODBlMi0zZTQ3ZDgwZjk2NjAiLCJkZjZjNTc0MC1jOWRmLTRmZjAtOTk2OS00Njk2YmY5MTc3YjYiLCI1NzA1MDQ0ZC0yMjBiLTQ4MTctYjE3YS1hOTMwZWFjMzg3ZGYiLCJmN2EzN2I1NC1iNjA4LTRiYmUtYjMyMS03ZmQ3YzRmOTU0YTciLCIyMzg5NDE1Ni1hNzIxLTRjMmQtYWI1MS05MTAyOGQ4MWYyZWQiLCJmYmE2YzU2Mi05MmYwLTQyMGQtYjk2Yi05ZDgwYjBjNGE0YjciLCJmNWY5OTc2ZC1mYTUzLTQxZmYtYjVhMi0zM2FkNGZjZGMxMTMiLCJkMjVhMGU3OS03ZDk2LTQzYjktOTE2MS00NDUzOTliOWQ2OGIiLCJiNjdkOGI3YS02NTAzLTQ3ZmYtYjZkNi00YTYzMWUxZDI1ZGMiLCI4NDU2M2U3Yi1iYjUyLTQ5ZDAtYjEzZC1mMWFlYmY2ZTAxMWEiLCIxN2E1OGY3ZC0wY2NiLTQ1MTMtODE1MC00ODJmNDA2MTRiMTAiLCJhYzRmMWY4MS02ZjdkLTQ0MGYtOWNjZi0wMjliM2Y2YjUyNDIiLCIwYzUxNjU4MS0xOWJkLTQyMGUtYTVlZC0wNzViMmJkOTgyYjMiLCI1N2NmMDg4NC01ZTU0LTQ1MzgtYTQ4NC02ZDI2YzVkYWZkMzEiLCJiYzkwYTU4NC1hZmUyLTQwOTQtYjBlMS1kMDQzMGFmNjI0MzIiLCJiMmY3MTA4Ni0zOGUwLTQzYWItOGIzMS1mNTljMmQ1OWJjODciLCI1OWVlMjY4Zi1hODFkLTQzZGItODM3My03YjYyMGU1NzI1NzkiLCIzZjkwNTVhNi1mZjM0LTQ2MGItOTBiYi0xM2QzY2ExY2E5ZDEiLCJjNzFlYjBhNy1iZWZlLTQ2NzctOGU1NS1iNjIwNjE4ZDEzODMiLCI3ZGE1MTJhOC02MmFmLTRiNDYtYTQwNy1jNTQ4NTRhNWFlMjQiLCIyNGRiZDNhOC1iZWZlLTQzYjEtOTQ4Yy1kODIwYTY2NmZiZmYiLCJlMDMzZmFhYy0xYzczLTQ4ODMtODQyZC1kZWE4YTMxMjExMGYiLCIwNjU5YTNhZC04YzZhLTQ0NWQtYTNiMi0zZjE1MjQwZWE1NGQiLCI5OWVmZDZiMi0zNjE3LTQ5ZWMtODMzNy0yMGEyMzFiYjBmZTEiLCJhYzE2ZTViMy01NDdiLTQyZmEtOWY2OC03YWFlNDZkNmRlMzciLCJhZTcyZGNiYS05ZjIxLTRlNTYtYTA5YS0zYmMxNjY0Njk0MGEiLCI5MWVkZjRiYi03ZjkyLTQ2N2ItODNjOC05NTQwNmE2ZjVhNmQiLCJhNzhmNjljMi02NWUxLTQyM2UtOTliOS1iZTQ1ZmNiOWVlNmEiLCJmZmE1NGRjMy1jYWFhLTRjYmYtYWVlMS0wNTczYzEyYmI3MDEiLCI5ZjFhNTdkOC01NjA0LTQ2YTQtOGViMS1mZDdhNDY4MGEwOGYiLCIyMzZhNTllNS1kNjQ1LTQ1ZGYtOGVkMC1jM2Q1MjRhOWFiMzAiLCIxMzc2NWRlNS1kOGU4LTQ1NjItYjIyOC1iMDExMTIzZDFjYzIiLCJjZDhiODVmMi1hYzY2LTRjZTYtYTEyYS1hOGQ5MzdkOGU5YTMiLCJlODBlMGJkZC04YmRlLTQxNGItODVjYi1hNWZhOWRkNGQ2MTEiLCIzOGYzOTE0Zi0yMjQ4LTQ2ODEtOGNkOC0yZTYyMWE0YzVkNGEiLCJiMGQ4OGQwNi0yOGNlLTQ0ZjQtODRiNy0wNDQ2ODgzMGI1OGUiLCI4M2E4NGZkMC1lOWU1LTQyZjYtYTJiYi1mOTAwMzQxNWYwYWEiLCJjYjM1YjUwNi03NzQzLTRmNjctYWE3Ni1mNzg0Nzk2NzA4MzciXSwibmFtZSI6IteQ15zXm9eh16DXk9eoINek15zXpteZ16bXp9eZIC0g15HXldeT16cg16rXldeb16DXlCIsIm9pZCI6Ijg3NDk3M2ZjLTVhMGItNDFmMy1hZmRlLWRjM2UzNjZiZmRlMCIsInByZWZlcnJlZF91c2VybmFtZSI6ImMyMTY4OTEwQHRlbC1hdml2Lmdvdi5pbCIsInJoIjoiMS5BU1VBRUE5a3F2aVZCVS1XOFZLZHU4RVlsOVZZVEV5MldIWkRqU204WmFlUlhlZ2xBQzRsQUEuIiwic2NwIjoiYWNjZXNzX2FzX3VzZXIgZGVmYXVsdCIsInN1YiI6Ii1wNS0tbEQ2bUlTd2E4V1lWT2FTYzN0akI2a2VUMk91WHNMYXBRdXhJQXMiLCJ0aWQiOiJhYTY0MGYxMC05NWY4LTRmMDUtOTZmMS01MjlkYmJjMTE4OTciLCJ1dGkiOiJ1R0FTeTM5TkIwaU1NQ2FEcXFjbEFBIiwidmVyIjoiMi4wIiwid2lkcyI6WyJiNzlmYmY0ZC0zZWY5LTQ2ODktODE0My03NmIxOTRlODU1MDkiXX0.OGJaHfOyQ_Wy4ilj4DKzVGkEJ9KRgSps9AXaljvwW0CSGgU-H2QRa_YmaK-r9Jlab-fV70ksayfrrNIsxjsDOxsFOocGuz1j2CuUCR_pciH3SQ8wal0orHlEkE6eNabvPxSjydeuEE8OG0IRzlnU03WlcXHLy05gs9BvbpZyuFisxGtr3vbF4ZA0PKkNi7VrXSIVK6uFuLQPL8PYke_yFc1BFPb2C8Zlvmq11JDsUMz3V1C3tZoSEXztv26APNaTPHoKns5fMv0u3P-ER200GcAt31GVOpHRqFC3viU34t6EoH12MRRtQ_Cm2uk7MBCUrR_WS-xABohist3pSQ1Z5Q";
        public APIClient(string BaseURL)
        {

            var authenticator = new JwtAuthenticator("sdcscd");
            var options = new RestClientOptions(BaseURL)
            {
                Authenticator = authenticator
            };
            client = new RestClient(BaseURL);
        }

        public async Task<RestResponse> CreateBusiness<T>(T payload) where T : class
        {
            var request = new RestRequest(Endpoints.CREATE_BUSINESS, Method.Post);
            request.AddHeader("Authorization", $"Bearer {accessToken}");
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(payload);

            Console.WriteLine($"Request Resource: {client.BuildUri(request)}");
            return await client.ExecuteAsync<T>(request);
        }
        public async Task<RestResponse> UpdateBusiness<T>(T payload) where T : class
        {
            var request = new RestRequest(Endpoints.Update_BUSINESS, Method.Post);
            request.AddHeader("Authorization", $"Bearer {accessToken}");
            request.AddBody(payload);
            return await client.ExecuteAsync<T>(request);
        }
        public async Task<RestResponse> SearchBusiness<T>(T searchCriteria) where T : class
        {
            var request = new RestRequest(Endpoints.SEARCH_BUSINESS, Method.Post);
            request.AddHeader("Authorization", $"Bearer {accessToken}");
            request.AddBody(searchCriteria);
            return await client.ExecuteAsync<T>(request);
        }
        public RestResponse GetBusinessById(int id)
        {
            var request = new RestRequest(Endpoints.GET_BUSINESS, Method.Get);
            request.AddHeader("Authorization", $"Bearer {accessToken}");
            request.AddQueryParameter("businessId", id);
            Console.WriteLine("Request URI: " + client.BuildUri(request));

            _response = client.Execute(request);
            _response.StatusCode.Should().Be(HttpStatusCode.OK);
            return _response;

        }
        public RestResponse ManagerStationsWorkingProcess()
        {
            var request = new RestRequest(Endpoints.MANAGE_STATIONS_WORKING_PROCESS, Method.Post);
            request.AddHeader("Authorization", $"Bearer {accessToken}");
            Console.WriteLine("Request URI: " + client.BuildUri(request));

            var _response = client.Execute(request);
            _response.StatusCode.Should().Be(HttpStatusCode.OK, $"Post request failed");

            return _response;
        }

        public RestResponse ManageAdditionalPermitsStationsProcess()
        {
            var request = new RestRequest(Endpoints.MANAGE_ADDITIONAL_PERMITS_STATIONS_PROCESS, Method.Post);
            request.AddHeader("Authorization", $"Bearer {accessToken}");
            request.AddParameter("application/x-www-form-urlencoded", "jobs[]=ManageAdditionalPermitsStationsProcess", ParameterType.RequestBody);
            Console.WriteLine("Request URI: " + client.BuildUri(request));

            var _response = client.Execute(request);
            _response.StatusCode.Should().Be(HttpStatusCode.OK, $"Post request failed");

            return _response;
        }

        public RestResponse CreateAdditionalPermitRequest<T>(T payload) where T : class
        {
            var request = new RestRequest(Endpoints.CREATE_ADDITIONAL_PERMIT_REQUEST, Method.Post);
            request.AddHeader("Authorization", $"Bearer {accessToken}");
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(payload);
            Console.WriteLine("Request URI: " + client.BuildUri(request));
            Console.WriteLine("Request Body: " + Newtonsoft.Json.JsonConvert.SerializeObject(payload));

            var _response = client.Execute(request);
            _response.StatusCode.Should().Be(HttpStatusCode.OK, $"Post request failed");
            _response.Should().NotBeNull();
            Console.WriteLine($"Ser 028 response: {_response.Content}");

            return _response;
        }
        public DateTime CalcWorksDays(string dayNum, bool future = false)
        {
            DateTime startDate = DateTime.Now;
            DateTime endDate = DateTime.Now;
            DateTime calulatedDay = DateTime.Now;
            while (true)
            {
                var request = new RestRequest(Endpoints.CALCULATE_WORKS_DAYS, Method.Get);
                request.AddHeader("Authorization", $"Bearer {accessToken}");
                request.AddParameter("start", $"{startDate.Month}/{startDate.Day}/{startDate.Year}", ParameterType.QueryString);
                request.AddParameter("end", $"{endDate.Month}/{endDate.Day}/{endDate.Year}", ParameterType.QueryString);
                _response = client.Execute(request);
                Console.WriteLine("Request URI: " + client.BuildUri(request));
               _response.StatusCode.Should().Be(HttpStatusCode.OK, $"Post request failed");

                if (_response.Content == dayNum)
                {
                    break;
                }

                if (future)
                {
                    endDate = endDate.AddDays(1); // Add a day to startDate
                    calulatedDay = endDate;
                }
                else
                {
                    startDate = startDate.AddDays(-1); // Subtract a day from startDate
                    calulatedDay = startDate;
                }
            }
            return calulatedDay;
        }


        public RestResponse CreateDraftLicense<T>(T payload) where T : class
        {
            var request = new RestRequest(Endpoints.CREATE_LICENSE, Method.Post);
            request.AddHeader("Authorization", $"Bearer {accessToken}");
            request.AddJsonBody(payload);
            Console.WriteLine("Request URI: " + client.BuildUri(request));
            Console.WriteLine("Request Body: " + Newtonsoft.Json.JsonConvert.SerializeObject(payload));

            _response = client.Execute(request);
            _response.StatusCode.Should().Be(HttpStatusCode.OK, $"Post request failed");

            return _response;
        }


        public RestResponse UpdateRefuseScheduledHearing<T>(T payload) where T : class
        {
            var request = new RestRequest(Endpoints.UPDATE_REFUSE_SHEUDULED_HEARNING, Method.Post);
            request.AddHeader("Authorization", $"Bearer {accessToken}");
            request.AddJsonBody(payload);
            Console.WriteLine("Request URI: " + client.BuildUri(request));
            Console.WriteLine("Request Body: " + Newtonsoft.Json.JsonConvert.SerializeObject(payload));

            _response = client.Execute(request);
            _response.StatusCode.Should().Be(HttpStatusCode.OK, $"Post request failed");
            return _response;
        }

        public RestResponse CancelRefuseLicense<T>(T jsonPayload) where T : class
        {
            var request = new RestRequest(Endpoints.CANCEL_REFUSE_LICENSE, Method.Post);
            request.AddHeader("Authorization", $"Bearer {accessToken}");
            request.AddParameter("application/json", jsonPayload, ParameterType.RequestBody);
            Console.WriteLine("Request URI: " + client.BuildUri(request));

            _response = client.Execute(request);
            _response.StatusCode.Should().Be(HttpStatusCode.OK, $"Post request failed");
            return _response;
        }


        public RestResponse UpdateRequestAdditionalPermit<T>(T payload) where T : class
        {
            var request = new RestRequest(Endpoints.UPDATE_REQUEST_ADDITIONAL_PERMIT, Method.Post);
            request.AddHeader("Authorization", $"Bearer {accessToken}");
            request.AddJsonBody(payload);
            Console.WriteLine("Request URI: " + client.BuildUri(request));
            Console.WriteLine("Request Body: " + Newtonsoft.Json.JsonConvert.SerializeObject(payload));

            _response = client.Execute(request);
            Console.WriteLine($"Ser 029 response: {_response.Content}");
            _response.StatusCode.Should().Be(HttpStatusCode.OK, $"Post request failed");
            return _response;
        }

        public RestResponse FeeCalculation<T>(T payload) where T : class
        {
            var request = new RestRequest(Endpoints.FREE_CALCULATION_FOR_ADDITIONAL_PERMIT, Method.Post);
            request.AddHeader("Authorization", $"Bearer {accessToken}");
            request.AddJsonBody(payload);
            Console.WriteLine("Request URI: " + client.BuildUri(request));
            Console.WriteLine("Request Body: " + Newtonsoft.Json.JsonConvert.SerializeObject(payload));

            _response = client.Execute(request);
            _response.StatusCode.Should().Be(HttpStatusCode.OK, $"Post request failed");
            return _response;
        }

        public void Dispose()
        {
            client?.Dispose();
            GC.SuppressFinalize(this);
        }

        public RestResponse CheckAdditionalPermitPossibility<T>(T payload) where T : class
        {
            var request = new RestRequest(Endpoints.CHECK_ADDITIONAL_PERMIT_POSSIBILITY, Method.Post);
            request.AddHeader("Authorization", $"Bearer {accessToken}");
            request.AddJsonBody(payload);
            Console.WriteLine("Request URI: " + client.BuildUri(request));
            Console.WriteLine("Request Body: " + Newtonsoft.Json.JsonConvert.SerializeObject(payload));

            _response = client.Execute(request);
            _response.StatusCode.Should().Be(HttpStatusCode.OK, $"Post request failed");
            return _response;
        }

        public RestResponse GetPermitRequestsForStationTreatment<T>(T payload) where T : class
        {
            var request = new RestRequest(Endpoints.GET_PERMIT_REQUESTS_FOR_STATION_THREATMENT, Method.Post);
            request.AddHeader("Authorization", $"Bearer {accessToken}");
            request.AddJsonBody(payload);
            Console.WriteLine("Request URI: " + client.BuildUri(request));
            Console.WriteLine("Request Body: " + Newtonsoft.Json.JsonConvert.SerializeObject(payload));

            _response = client.Execute<RestResponse<List<T>>>(request);
            _response.StatusCode.Should().Be(HttpStatusCode.OK, $"Post request failed");

            return _response;
        }

        public RestResponse RenewAdditionalPermit<T>(T payload) where T : class
        {
            var request = new RestRequest(Endpoints.RENEW_ADDITIONAL_PERMIT, Method.Post);
            request.AddHeader("Authorization", $"Bearer {accessToken}");
            request.AddJsonBody(payload);
            Console.WriteLine("Request URI: " + client.BuildUri(request));
            Console.WriteLine("Request Body: " + Newtonsoft.Json.JsonConvert.SerializeObject(payload));

            _response = client.Execute<RestResponse<List<T>>>(request);
            _response.StatusCode.Should().Be(HttpStatusCode.OK, $"Post request failed");
            Console.WriteLine($"Response for {MethodBase.GetCurrentMethod()}: {_response.Content}");

            return _response;
        }

        public RestResponse GetBusinessAdditionalPermits<T>(T id)
        {
            var request = new RestRequest(Endpoints.GET_BUSINESS_ADDITIONAL_PERMITS, Method.Post);
            request.AddHeader("Authorization", $"Bearer {accessToken}");
            request.AddQueryParameter("businessId", Convert.ToInt32(id));
            Console.WriteLine("Request URI: " + client.BuildUri(request));

            _response = client.Execute<RestResponse<List<T>>>(request);
            _response.StatusCode.Should().Be(HttpStatusCode.OK, $"Post request failed");
            Console.WriteLine($"Response for {MethodBase.GetCurrentMethod()}: {_response.Content}");

            return _response;
        }

        public RestResponse GetBusinessData<T>(T payload) where T : class
        {
            var request = new RestRequest(Endpoints.GET_BUSINESS_DATA, Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"Bearer {accessToken}");
            request.AddJsonBody(payload);
           

            Console.WriteLine("Request URI: " + client.BuildUri(request));
            Console.WriteLine("Request Body: " + Newtonsoft.Json.JsonConvert.SerializeObject(payload));

            _response = client.Execute(request);
            Console.WriteLine($"Response for {MethodBase.GetCurrentMethod()}: {_response.Content}");
            _response.StatusCode.Should().Be(HttpStatusCode.OK, $"Post request failed");

            return _response;
        }

        public RestResponse GetGISLayer<T>(T payload) where T : class
        {
            var request = new RestRequest(Endpoints.GET_GIS_LAYER, Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"Bearer {accessToken}");
            request.AddJsonBody(payload);

            Console.WriteLine("Request URI: " + client.BuildUri(request));
            Console.WriteLine("Request Body: " + Newtonsoft.Json.JsonConvert.SerializeObject(payload));

            _response = client.Execute(request);
            Console.WriteLine($"Response for {MethodBase.GetCurrentMethod()}: {_response.Content}");
            _response.StatusCode.Should().Be(HttpStatusCode.OK, $"Post request failed");

            return _response;
        }

        public RestResponse ApproveAdditionalPermit<T>(T payload) where T : class
        {
            var request = new RestRequest(Endpoints.APPROVE_ADDITIONAL_PERMIT, Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"Bearer {accessToken}");
            request.AddJsonBody(payload);

            Console.WriteLine("Request URI: " + client.BuildUri(request));
            Console.WriteLine("Request Body: " + Newtonsoft.Json.JsonConvert.SerializeObject(payload));

            _response = client.Execute(request);
            Console.WriteLine($"Response for {MethodBase.GetCurrentMethod()}: {_response.Content}");
            _response.StatusCode.Should().Be(HttpStatusCode.OK, $"Post request failed");

            return _response;
        }

        public RestResponse CreateRequestItemReq<T>(T payload) where T : class
        {
            var request = new RestRequest(Endpoints.CREATE_REQUEST_ITEM, Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"Bearer {accessToken}");
            request.AddJsonBody(payload);

            Console.WriteLine("Request URI: " + client.BuildUri(request));
            Console.WriteLine("Request Body: " + Newtonsoft.Json.JsonConvert.SerializeObject(payload));

            _response = client.Execute(request);
            Console.WriteLine($"Response for {MethodBase.GetCurrentMethod()}: {_response.Content}");
            _response.StatusCode.Should().Be(HttpStatusCode.OK, $"Post request failed");

            return _response;
        }

        public RestResponse CreateApprovingStartion<T>(T payload) where T : class
        {
            var request = new RestRequest(Endpoints.CREATE_APPROVING_STATION, Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"Bearer {accessToken}");
            request.AddJsonBody(payload);

            Console.WriteLine("Request URI: " + client.BuildUri(request));
            Console.WriteLine("Request Body: " + Newtonsoft.Json.JsonConvert.SerializeObject(payload));

            _response = client.Execute(request);
            Console.WriteLine($"Response for {MethodBase.GetCurrentMethod()}: {_response.Content}");
            _response.StatusCode.Should().Be(HttpStatusCode.OK, $"Post request failed");

            return _response;
        }
    }

}
