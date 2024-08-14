using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using Infrastructure;
using Infrastructure.ContextDB;
using Infrastructure.Models;
using Infrastructure.ModelsAPI.Request;
using Infrastructure.ModelsDB;
using Infrastructure.ServicesDB;
using Infrastructure.Utility;
using Microsoft.Extensions.Configuration;
using RestSharp;

namespace Tests.StepDefinitions
{
    [Binding]
    public class CreateLicenseSteps
    {
        private APIClient _api;
        private RestResponse _response;
        private readonly ScenarioContext _scenarioContext;
        private RisTSeruv _seruvModel;
        private RisTxSeruvLetachana _seruvLaTahanaModel;
        private RisTxSeruvToTotzaatSeruv _seruvToTotzahaModel;
        private RisTRishayonLeesek _rishayonModel;
        private RisTMautBrishayonLeesek _mautBeRishayonModel;
        private RisTBakasha _bakashaModel;
        DataQueryService query;
        private FakeDataGenerator fakeDataGenerator;
#if (DEBUG)
        string baseEnv = "APIDev";


#else
        string baseEnv = "APITest";
#endif
        public CreateLicenseSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            query = new DataQueryService();
            _seruvModel = new RisTSeruv();
            _seruvLaTahanaModel = new RisTxSeruvLetachana();
            fakeDataGenerator = new FakeDataGenerator(new Faker());
            _api = new APIClient($"http://iispreprod01/TlvServices/Tlv.BusinessRegistration/{baseEnv}/");
        }


        [When(@"create draft license with parameters: (.*), ""([^""]*)"", ""([^""]*)"", (.*)")]
        public void WhenCreateDraftLicenseWithParameters(int fileType, string startLicenseDate, string endLicenseDate, int licenseItemType)
        {

            CreateLicenseReq licenseDraftModel = new CreateLicenseReq
            {
                requestId = (int)_scenarioContext["BakashaCode"],
                fileType = fileType,
                generateType = 1,
                licenseItems = new Licenseitem[1]
                 {
            new Licenseitem
            {
                requestItemId = (int)_scenarioContext["CodeParit"],
                startLicenseDate = startLicenseDate,
                endLicenseDate = endLicenseDate,
                licenseItemType = licenseItemType
            }
                 }
            };

            var response = _api.CreateDraftLicense(licenseDraftModel);
            _scenarioContext["LicenseCode"] = response.Content;
            HandleContent.PrintObjectProperties(licenseDraftModel);
        }


        [When(@"create seruv in DB with parameters: (.*)")]
        public void WhenCreateSeruvInDBWithParameters(int sugSeruv)
        {
            _seruvModel = fakeDataGenerator.GenerateFakeClassData<RisTSeruv>();
            var taarich = _api.CalcWorksDays("45", true);
            _seruvModel.Code = 0;
            _seruvModel.SugSeruv = sugSeruv;
            _seruvModel.TaarichLebitulRishayon = taarich;
            _seruvModel.TaarichIdkunAcharon = DateTime.Now;
            _seruvModel = query.CreateSeruv(_seruvModel);
            _scenarioContext["SeruvLicense"] = _seruvModel;

            _seruvLaTahanaModel = fakeDataGenerator.GenerateFakeClassData<RisTxSeruvLetachana>();
            _seruvLaTahanaModel.Code = 0;
            RisTTachanaMeasheret tahanaMeasheret = (RisTTachanaMeasheret)_scenarioContext["TahanaModel"];
            _seruvLaTahanaModel.FkSeruv = _seruvModel.Code;
            _seruvLaTahanaModel.FkTachanaMeasheret = tahanaMeasheret.PkCodeTachana;
            _seruvLaTahanaModel = query.CreateSeruvLaTahana(_seruvLaTahanaModel);
        }



        [When(@"update Refuse Scheduled Hearing with parameters: ""([^""]*)"", (.*)")]
        public void WhenUpdateRefuseScheduledHearingWithParametersFalse(string contactDate, bool teumShimua)
        {
            var seruvModel = (RisTSeruv)_scenarioContext["SeruvLicense"];
            int seruvCode = seruvModel.Code;
            int codeTozzatTeumShimua = teumShimua ? 1 : 2;

            UpdateRefuseScheduledHearing scheduledHearing = new UpdateRefuseScheduledHearing
            {
                id = seruvCode,
                contactDateTime = contactDate,
                hearingCoordinationResultId = codeTozzatTeumShimua,
                secondPartyTypeId = 1,
                secondPartyName = "Alex",
                recorderUserId = 8

            };

            var response = _api.UpdateRefuseScheduledHearing(scheduledHearing);
        }


        [When(@"cancel refuse license")]
        public void WhenCancelRefuseLicense()
        {
            var seruvModel = (RisTSeruv)_scenarioContext["SeruvLicense"];
            int seruvCode = seruvModel.Code;
            string json = $"{{\"Id\": {seruvCode},\"ResultIds\":[1]}}";
            _api.CancelRefuseLicense(json);

           _seruvModel = (RisTSeruv)_scenarioContext["SeruvLicense"];
           _seruvModel.TaarichLebitulRishayon = DateTime.Now;

            _seruvToTotzahaModel =  fakeDataGenerator.GenerateFakeClassData<RisTxSeruvToTotzaatSeruv>();
            _seruvToTotzahaModel.FkCodeSeruv = seruvCode;
            _seruvToTotzahaModel.AimMeyuadLebitul = true;
            _seruvToTotzahaModel.Code = 0;
            query.UpdateSeruvToTotzaatSeruv(_seruvToTotzahaModel);
        }


        [When(@"create license in DB: (.*), (.*), (.*),  ""([^""]*)"", ""([^""]*)""")]
        public void WhenCreateLicenseInDB(int statusRishayon, int sugTofes, int sugRishayon, string startLicenseDate, string endLicenseDate)
        {
            _rishayonModel = fakeDataGenerator.GenerateFakeClassData<RisTRishayonLeesek>();
            _rishayonModel.PkRishiunEsek = 0;
            _rishayonModel.FkCodeEssek = (int)_scenarioContext["EssekID"];
            _rishayonModel.FkCodeBakasha = (int)_scenarioContext["BakashaCode"];
            _rishayonModel.FkSugTufes = sugTofes;
            _rishayonModel.FkStatusRishayun = statusRishayon;
            _rishayonModel = query.CreateLicense(_rishayonModel);

            _mautBeRishayonModel = fakeDataGenerator.GenerateFakeClassData<RisTMautBrishayonLeesek>();
            _mautBeRishayonModel.PkMautRisahyunEsek = 0;
            _mautBeRishayonModel.FkRishyunEsek = _rishayonModel.PkRishiunEsek;
            _mautBeRishayonModel.FkMautBakasha = (int)_scenarioContext["BakashaCode"];
            _mautBeRishayonModel.SugRishayon = sugRishayon;
            _mautBeRishayonModel.TaarichTchilatTokefHarishaion = DateTime.TryParse(startLicenseDate, out DateTime parsedDate) ? parsedDate : (DateTime?)null;
            _mautBeRishayonModel.TaarichSyumTokefHarishaion = DateTime.TryParse(endLicenseDate, out DateTime parsedDate2) ? parsedDate2 : (DateTime?)null;
            _mautBeRishayonModel = query.AddMahutToLicense(_mautBeRishayonModel);
        }





    }
}
