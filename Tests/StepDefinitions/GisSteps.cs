using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure;
using Infrastructure.ModelsAPI.Request;
using Infrastructure.ServicesDB;
using RestSharp;

namespace Tests.StepDefinitions
{

    [Binding]
    public class GisSteps
    {
         DataQueryService query;
        private APIClient _api;
        private RestResponse _response;
        private ScenarioContext _scenarioContext;
#if (DEBUG)
        string baseEnv = "APIDev";


#else
        string baseEnv = "APITest";
#endif

        public GisSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            query = new DataQueryService();
            _api = new APIClient($"http://iispreprod01/TlvServices/Tlv.BusinessRegistration/{baseEnv}/");

        }

        [Given(@"run GetGISLayer")]
        public void GivenRunGetGISLayer()
        {
           int rehov = (int)_scenarioContext["EssekStreet"];
           int bait = (int)_scenarioContext["EssekHouseNumber"];

            GetGISLayerReq model = new GetGISLayerReq();
            model.streetId = rehov;
            model.houseNumber = bait;
            _response = _api.GetGISLayer(model);
        }

    }
}
