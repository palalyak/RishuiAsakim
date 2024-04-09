using System;
using System.Net;
using Infrastructure;
using Infrastructure.ModelsAPI.Request;
using Infrastructure.ModelsAPI.Response;
using Infrastructure.Utility;
using RestSharp;
using TechTalk.SpecFlow;

namespace Tests.StepDefinitions
{
    [Binding]
    public class CreateBusinessCaseStepDefinitions_old
    {
        private CreateBusinessReq createBusinessReq;
        private GetBusinessByIdRes getBusinessByIdRes;
        private ScenarioContext scenarioContext;
        private RestResponse response;
        private APIClient api;

        public CreateBusinessCaseStepDefinitions_old(CreateBusinessReq createBusinessReq, ScenarioContext scenarioContext)
        {
            this.createBusinessReq = createBusinessReq;
            this.scenarioContext = scenarioContext;
            api = new APIClient("http://iispreprod01/TlvServices/Tlv.BusinessRegistration/APITest/");
        }

        [Given(@"business case payload ""([^""]*)""")]
        public void GivenBusinessCasePayload(string fileName)
        {
            string file = HandleContent.GetFilePath(fileName); // Get JSON payload path
            var payload = HandleContent.ParseJSON<CreateBusinessReq>(file); // Deserialize JSON
            scenarioContext.Add("create_business_payload", payload); // Share deserialize payload with other steps
        }

        [When(@"send API request to create Business Case")]
        public async Task WhenSendAPIRequestToCreateBusinessCaseAsync()
        {
            createBusinessReq = scenarioContext.Get<CreateBusinessReq>("create_business_payload"); // Get deserialize payload from other step
            response = await api.CreateBusiness<CreateBusinessReq>(createBusinessReq); // Pass payload for request
            response.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
        }

        [Then(@"validate business case is created")]
        public void ThenValidateBusinessCaseIsCreated()
        {
           
            var content = HandleContent.GetContent<CreateBusinessRes>(response);
            //content.Should().NotBeNull();
            //createBusinessReq.name.Should().Be(content.name);

        }

        [Given(@"I have entered into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculatorAsync()
        {
            response = api.GetBusinessById(1);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }


    }
}
