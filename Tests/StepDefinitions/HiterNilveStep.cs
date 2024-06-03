using System;
using System.Globalization;
using System.Net;
using Bogus;
using Infrastructure;
using Infrastructure.ContextDB;
using Infrastructure.Models;
using Infrastructure.ModelsAPI.Request;
using Infrastructure.ModelsAPI.Response;
using Infrastructure.ModelsDB;
using Infrastructure.ServicesDB;
using Infrastructure.Utility;
using Microsoft.Extensions.Configuration;
using RestSharp;
using TechTalk.SpecFlow;

namespace Tests.StepDefinitions
{
    [Binding]
    public class HiterNilveStep
    {
        private APIClient _api;
        private RestResponse _response;
        DataQueryService query;
        private readonly ScenarioContext _scenarioContext;
        private RisTBakashaLheiterNilve _bakashaLheiterNilveModel;
        private List<int> _bakashatHiter;
        private RisTHeiterNilve _hiterNilveModel;
        private RisTTachanaMeasheret _tachanaMeasheretModel;
        private FakeDataGenerator fakeDataGenerator;
#if (DEBUG)
        string baseEnv = "APIDev";


#else
        string baseEnv = "APITest";
#endif

        public HiterNilveStep(ScenarioContext scenarioContext)
        {
            _bakashatHiter = new List<int>();
            _scenarioContext = scenarioContext;
            query = new DataQueryService();
            fakeDataGenerator = new FakeDataGenerator(new Faker());
            _api = new APIClient($"http://iispreprod01/TlvServices/Tlv.BusinessRegistration/{baseEnv}/");
        }


        [Given(@"run Ser(?:.*?) create additional permit with parameters: (.*), (.*), (.*), (.*)")]
        public void GivenRunSerCreateAdditionalPermitWithParameters(int sugIter, int sibatBakasha, double requestArea, int NumOfIters)
        {
            var essekID = _scenarioContext["EssekID"];
            var paritID = _scenarioContext["KodMahutRashit"];


            for (int i = 0; i < NumOfIters; i++)
            {
                DateTime currentTime = DateTime.Now;
                string parsedTime = currentTime.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");

                DateTime validityDate = currentTime.AddYears(1);

                CreateAdditionalPermitReq _additionalPermitModel = new Faker<CreateAdditionalPermitReq>()
                    .RuleFor(r => r.requestAdditionalPermit, f => new Requestadditionalpermit
                    {

                        id = 0,
                        businessId = (int)essekID,
                        requestItemId = (int)paritID,
                        additionalPermitTypeId = (i == 0) ? sugIter : ((i == 1) ? 3 : 0),
                        quantityTable = 4,
                        quantityBarTable = 16,
                        quantityChairs = 20,
                        isOnBeach = true,
                        requestDistanceSidewalk = 2,
                        determinedDistanceSidewalk = 2,
                        indicationOpenAreaSidewalk = true,
                        indicationBuildingAreaDetail = true,
                        statusDate = currentTime,   
                        closeDay = "א",
                      

                        isRequestRenew = (sibatBakasha == 45),
                        submissionDate = currentTime,
                        requestValidityStartDate = currentTime,
                        determinedValidityStartDate = currentTime,

                        requestValidityEndDate = currentTime.AddYears(1),
                        determinedValidityEndDate = currentTime.AddYears(1),

                        requestStartHour = currentTime.ToString("HH:mm"),
                        determinedStartHour = currentTime.ToString("HH:mm"),

                        //requestEndHour = currentTime.AddHours(10).ToString("HH:mm"),
                        requestEndHour = "01:45",
                        //determinedEndHour = currentTime.AddHours(1).ToString("HH:mm"),
                        determinedEndHour = "01:45",

                        requestArea = (int)requestArea,
                        determinedArea = (int)requestArea,
                        statusId = 1
                    })
            .Generate();

                _response = _api.CreateAdditionalPermitRequest(_additionalPermitModel);
                string content = HandleContent.ExtractValueFromJsonString(_response.Content, "id");

                int codBakashatIter = int.Parse(content);
                _bakashatHiter.Add(codBakashatIter);
                _scenarioContext["CodBakashatIter"] = codBakashatIter;
                _scenarioContext["CodBakashatIters"] = _bakashatHiter;
            }
        }

        [Given(@"update status Hiter to: (.*)")]
        public void GivenUpdateStatusHiterTo(int StatusIter)
        {
            int codBakashatIter = (int)_scenarioContext["CodBakashatIter"];
            _hiterNilveModel = query.GetHeiterNilveByBakasha(codBakashatIter);
            _hiterNilveModel.FkStatusHeiterNilve = StatusIter;
            _hiterNilveModel = query.UpdateHeiterNilve(_hiterNilveModel);
        }

        [Given(@"update tahanot of Hiter to status: (.*)")]
        public void GivenUpdateTahanotOfHiterToStatus(int statusId)
        {
            _bakashatHiter.Count.Should().NotBe(0);
            for (int i = 0; i < _bakashatHiter.Count; i++)
            {
                List<RisTTachanaMeasheret> _tachanotNilveModel = query.GetTahanotOfHiter(_bakashatHiter[i]);
                for (int j = 0; j < _tachanotNilveModel.Count; j++)
                {
                    _tachanotNilveModel[j].StatusAcharon = statusId;
                    UpdateTahanaOfHiter(_tachanotNilveModel[j]);
                }
            }
        }

        [Given(@"run Ser(?:.*?) permit update with parameters: (.*)")]
        public void GivenRunSerPermitUpdateWithParameters(int StatusIter)
        {
            UpdateRequestAdditionalPermitReq additionalPermit = new UpdateRequestAdditionalPermitReq();
            _bakashatHiter.Count.Should().NotBe(0);

            for (int i = 0; i < _bakashatHiter.Count; i++)
            {

                additionalPermit.additionalPermitRequestId = _bakashatHiter[i];
                additionalPermit.statusId = StatusIter;

                HandleContent.PrintObjectProperties(additionalPermit);
                _response = _api.UpdateRequestAdditionalPermit(additionalPermit);
            }

        }

        [When(@"run Ser(.*) FeeCalculation with parameters: <hiterStartDate>, <hiterEndDate>")]
        public void WhenRunSerFeeCalculationWithParametersHiterStartDateHiterEndDate(int p0)
        {
            //_api.FeeCalculation();
        }

        [When(@"push back HiterNilve creation date by (?:.*?) to (?:.*?)days and run Ser(?:.*?)")]
        public void WhenPushBackHiterNilveCreationDateByToDaysAndRunSer()
        {
            // Get bakasha & tahanot of HiterNilve by bakasha id > push back creation date > run ser058

            int codBakashatIter = (int)_scenarioContext["CodBakashatIter"];

            _bakashaLheiterNilveModel = query.GetBakashaLheiterNilve(codBakashatIter);

            for (int i = 1; i < 11; i++)
            {
                string dayNum = i.ToString();
                DateTime calculationDate = _api.CalcWorksDays(dayNum);
                _bakashaLheiterNilveModel.TarichHagashatBakashaHeiterNilve = calculationDate;
                _bakashaLheiterNilveModel.CreatedDate = calculationDate;
                HandleContent.PrintObjectProperties(_bakashaLheiterNilveModel);
                query.UpdateHiterBakasha(_bakashaLheiterNilveModel);

                List<RisTTachanaMeasheret> _tachanotNilveModel = query.GetTahanotOfHiter(codBakashatIter);
                for (int j = 0; j < _tachanotNilveModel.Count; j++)
                {
                    _tachanotNilveModel[j].TaarichIdkunAcharon = calculationDate;
                    _tachanotNilveModel[j].CreatedDate = calculationDate;
                    UpdateTahanaOfHiter(_tachanotNilveModel[j]);
                }

                //RunSer058ManageTahanotOfHiterNilve();

            }
        }
        [Given(@"update status of hiter bakasha to: (.*)")]
        public void GivenUpdateStatusOfHiterBakashaTo(int param)
        {
            int codBakashatIter = (int)_scenarioContext["CodBakashatIter"];
            _bakashaLheiterNilveModel = query.GetBakashaLheiterNilve(codBakashatIter);
            _bakashaLheiterNilveModel.FkStatusBakasha = param;
            query.UpdateHiterBakasha(_bakashaLheiterNilveModel);
        }
        private void UpdateTahanaOfHiter(RisTTachanaMeasheret risTTachanaMeasheret)
        {
            query.UpdateTahanot(risTTachanaMeasheret);
        }
        private void RunSer058ManageTahanotOfHiterNilve()
        {
            _api.ManageAdditionalPermitsStationsProcess();
        }

        [Then(@"Ser(?:.*?) response description should be '([^']*)'")]
        public void ThenSerResponseDescriptionShouldBe(string param)
        {
            var content = HandleContent.GetContent<CodeRes>(_response);
            content.Should().NotBeNull();

            string description = content.result.description as string;
            if (param.Equals("null"))
            {
                description.Should().BeNull();
                _scenarioContext["CodHiter"] = content.data;
            }
            else
            {
                description.Should().Contain(param);
            }

        }

        [Then(@"Ser(?:.*?) response should be: '([^']*)'")]
        public void ThenSerResponseShouldBeResponseResult(string param)
        {
            var content = HandleContent.GetContent<CodeRes>(_response);
            string description = content.result.description as string;
            description.Should().Contain(param);
            //if (param == false)
            //{
            //    content.data.Should().BeNull();
            //}
            //else if (param == true)
            //{
            //    content.Should().NotBeNull();
            //    content.data.additionalPermitPossibility.Should().Be(param);

            //}
        }


        [Then(@"shovar tashlum for Hiter created in DB: '([^']*)'")]
        public void ThenShovarTashlumForHiterCreatedInDB(string param)
        {
            _bakashatHiter.Count.Should().NotBe(0);
            for (int i = 0; i < _bakashatHiter.Count; i++)
            {
                RisTShovarTashlumRishayon shovarModel = query.GetShovarTashlumHiterByBakasha(_bakashatHiter[i], new RisTShovarTashlumRishayon());

                if (param.ToLower().Equals("no"))
                {
                    shovarModel.Should().BeNull();
                }
                else
                {
                    shovarModel.Should().NotBeNull();
                }
            }
        }


        [Then(@"status of HiterNilve in DB: (.*)")]
        public void ThenStatusOfHiterNilveInDB(int param)
        {
            _bakashatHiter.Count.Should().NotBe(0);
            for (int i = 0; i < _bakashatHiter.Count; i++)
            {
                _hiterNilveModel = query.GetHeiterNilveByBakasha(_bakashatHiter[i]);
                _hiterNilveModel.FkStatusHeiterNilve.Should().Be(param);
            }
        }


        [Then(@"hiter nilve created in DB: '([^']*)'")]
        public void ThenHiterNilveCreatedInDB(string param)
        {
            _bakashatHiter.Count.Should().NotBe(0);
            for (int i = 0; i < _bakashatHiter.Count; i++)
            {
                _hiterNilveModel = query.GetHeiterNilveByBakasha(_bakashatHiter[i]);

                if (param.ToLower().Equals("yes"))
                {
                    _hiterNilveModel.Should().NotBeNull();
                }
                else
                {
                    _hiterNilveModel.Should().BeNull();
                }
            }
        }


        //public void GivenParametersOfHiterNilve()
        //{
        //    string paramName = "AdditionalPermitFeeRateDays";
        //    string paramValue = "TarichSiomOnatHiter";

        //    object fetchedParam = null;

        //    var paramTable = query.GetHiterNilveParameters(paramName);

        //    switch (paramTable)
        //    {
        //        case RisTtSugHeiterNilve sugHeiter:

        //            fetchedParam = sugHeiter?.GetType().GetProperty(paramValue)?.GetValue(sugHeiter, null);


        //            break;
        //        case RisTtMaarechetParameter maarechetParameter:
        //            fetchedParam = maarechetParameter?.GetType().GetProperty(paramValue)?.GetValue(maarechetParameter, null);
        //            break;
        //        default:
        //            break;
        //    }
        //    Console.WriteLine($"Parameter name: {paramName} / Parameter value: {paramValue} = {fetchedParam?.ToString() ?? "null"}");

        //}

        private void GetHiterTeken(string sugHiter, string param)
        {
            string paramName = "ìéìä";
            string paramValue = "TkufatHiterMaxd";

            var paramTable = DataQueryService.GetSystemParametersContentDB(sugHiter, param);

        }


        [Then(@"status of bakasha for HiterNilve in DB: (.*), (.*)")]
        public void ThenStatusOfBakashaForHiterNilveInDB(int paramStatusHiterBakasha, int numOfHiterBakasha)
        {
            int codBakashatIter = (int)_scenarioContext["CodBakashatIter"];
            _bakashaLheiterNilveModel = query.GetBakashaLheiterNilve(codBakashatIter);
            _bakashaLheiterNilveModel.Should().NotBeNull();
            _bakashaLheiterNilveModel.FkStatusBakasha.Should().Be(paramStatusHiterBakasha);
            _bakashatHiter.Count.Should().Be(numOfHiterBakasha);
        }

        [Then(@"status of tahanot for HiterNilve in DB: (.*), (.*)")]
        public void ThenStatusOfTahanotForHiterNilveInDB(int statusHiterTahana, int numOfHiterTahana)
        {
            _bakashatHiter.Count.Should().NotBe(0);

            for (int i = 0; i < _bakashatHiter.Count; i++)
            {
                List<RisTTachanaMeasheret> _tachanotNilveModel = query.GetTahanotOfHiter(_bakashatHiter[i]);

                if (numOfHiterTahana > 0)
                {
                    _tachanotNilveModel.Count.Should().BeGreaterThan(0);

                    for (int j = 0; j < _tachanotNilveModel.Count; j++)
                    {
                        _tachanotNilveModel[j].StatusAcharon.Should().Be(statusHiterTahana);
                    }
                }
                else _tachanotNilveModel.Count.Should().Be(0);

            }
        }

        [Then(@"bakasha laTipul tahanot: (.*), (.*)")]
        public void ThenBakashaLaTipulTahanot(bool param, int tab)
        {
            GetPermitRequestsForStationTreatmentReq getPermit = new GetPermitRequestsForStationTreatmentReq();
            getPermit.tab = tab;
            getPermit.fromRequestDate = DateTime.Now.AddYears(-1);
            _response = _api.GetPermitRequestsForStationTreatment(getPermit);

            var content = HandleContent.ExtractValuesFromJsonString(_response.Content, "requestNumber");
            _bakashatHiter.Count.Should().NotBe(0);

            List<int> getAdditionalPermit = new List<int>();
            foreach (var stringValue in content)
            {
                if (int.TryParse(stringValue, out int intValue))
                {
                    getAdditionalPermit.Add(intValue);
                }
                else
                {
                    Console.WriteLine($"Could not parse '{stringValue}' as int.");
                }
            }

            foreach (var bakashaHiterItem in _bakashatHiter)
            {
                getAdditionalPermit.Should().Contain(bakashaHiterItem, $"Value {bakashaHiterItem} is missing in getAdditionalPermit");
            }
        }

        [Given(@"run Ser(?:.*?) check additional permit possibility with parameters: (.*)")]
        public void GivenRunSerCheckAdditionalPermitPossibilityWithParameters(int sugHiter)
        {
            int essekId = (int)_scenarioContext["EssekID"];

            CheckAdditionalPermitPossibilityReq possibilityReq = new CheckAdditionalPermitPossibilityReq();
            possibilityReq.businessId = essekId;
            possibilityReq.additionalPermitType = sugHiter;
            _response = _api.CheckAdditionalPermitPossibility(possibilityReq);
            Console.WriteLine(_response.Content);
        }

        [When(@"run Ser(?:.*?) renew additional permit '([^']*)', '([^']*)', (.*)")]
        public void WhenRunSerRenewAdditionalPermit(string requestEndHour, string requestEndDate, float requestArea)
        {
            /* renew additional permit */

            int codHiter = (int)_scenarioContext["CodHiter"];
            int codEssec = (int)_scenarioContext["EssekID"];

            _hiterNilveModel = query.GetHeiterNilve(codHiter);
            _hiterNilveModel.Should().NotBeNull();
            _hiterNilveModel.TaarichMax.Should().NotBeNull(); // æä úàøéê ñéåí úå÷ó äéúø
            DateTime taarichMax = (DateTime)_hiterNilveModel.TaarichMax;

            RenewAdditionalPermitReq model = new RenewAdditionalPermitReq();

            model.additionalPermitId = codHiter;
            model.requestEndHour = requestEndHour;
            model.requestValidityStartDate = taarichMax.AddDays(1);
            model.requestValidityEndDate = HandleContent.CalculateTimeSet(requestEndDate, model.requestValidityStartDate);
            model.requestPargodArea = requestArea;
            _api.RenewAdditionalPermit(model);
        }

        [Then(@"validate hiter nilve: (.*)")]
        public void ThenValidateHiterNilve(int numOfHiters)
        {
            int codEssec = (int)_scenarioContext["EssekID"];

            _response = _api.GetBusinessAdditionalPermits(codEssec);
            var permits = HandleContent.GetContentList<GetBusinessAdditionalPermitsRes>(_response);

            Console.WriteLine("=========================================== Get hiters response =======================");
            foreach (var permit in permits)
            {
                Console.WriteLine($"Id: {permit.id}, Type: {permit.additionalPermitTypeDesc}, " +
                    $"Validity Start Date: {permit.validityStartDate}, Validity End Date: {permit.validityEndDate}");
            }

            permits.Count.Should().Be(numOfHiters);
        }

        [When(@"run ischur hiter nilve (.*) times")]
        public void WhenRunIschurHiterNilveTimes(int numOfApproves)
        {
            for (int i = 0; i < numOfApproves; i++)
            {
                ApproveAdditionalPermitReq model = new ApproveAdditionalPermitReq();
                model.additionalPermitId = (int)_scenarioContext["CodHiter"];
                model.statusId = 2;
                _api.ApproveAdditionalPermit(model);
            }
        }





















    }
}
