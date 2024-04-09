using System;
using System.Net;
using Infrastructure;
using Infrastructure.ModelsAPI.Request;
using Infrastructure.ModelsAPI.Response;
using Infrastructure.Utility;
using NUnit.Framework;
using RestSharp;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Tests.StepDefinitions
{
    public class EssecData
    {

        public int CodeEssek { get; set; }
        public int BakashaId { get; set; }
        public int NumOfMahuyotInEssek { get; set; }
        public int NumOfMahuyotInBakasha { get; set; }
        public int NumOfInnerTahanot { get; set; }
        public int NumOfOuterTahanot { get; set; }
        public string InnerTahanaName { get; set; }
        public string OuterTahanaName { get; set; }
        public string EmailInnerTahana { get; set; }
        public string EmailOuterTahana { get; set; }
        public string BaalInyanEmail { get; set; }
    }

    [Binding]
    public class Ser003_Mezuraz_Alef_One_Steps
    {
        private readonly ScenarioInfo _scenarioInfo;
        private readonly List<EssecData> scenarioDataList;
        private EssecData _essecData;
        private Object newData;
        private ScenarioContext scenarioContext;
        private RestResponse _response;
        private CreateBusinessReq _createBusinessReq;
        private GetBusinessByIdRes _getBusinessByIdRes;
        private APIClient _api;



        public Ser003_Mezuraz_Alef_One_Steps(ScenarioContext scenarioContext, ScenarioInfo scenarioInfo)
        {
            this.scenarioContext = scenarioContext;
            this.scenarioDataList = new List<EssecData>();
            _essecData = new EssecData();
            _scenarioInfo = scenarioInfo;
            _api = new APIClient("http://iispreprod01/TlvServices/Tlv.BusinessRegistration/APIDev/");
           
        }

        /*
          
        * Example of using scenarioContext * 
        * Add var to scenarioContext *

        [Given(@"tik essec is (.*) with bakasha (.*)")]
        public async Task GivenTikEssecIsWithBakashaAsync(int codeEssek, int bakashaId)
        {
            scenarioContext.Add("codeEssek", codeEssek);
            scenarioContext.Add("bakashaId", bakashaId);
        }

        * Get var from scenarioContext *
        
        [Given(@"tik essek matches input data")]
        public void GivenTikEssekMatchesInputDataAsync()
        {
            var rr = scenarioContext.Get<int>("codeEssek");
        }
        */



        [Given(@"tik essek identification")]
        public void GivenTikEssekIdentification(Table table)
        {
            var newData = table.CreateInstance<EssecData>();
            _essecData.CodeEssek = newData.CodeEssek;
            _essecData.BakashaId = newData.BakashaId;
   
        }

        [Given(@"tik essek data")]
        public void GivenTikEssekData(Table table)
        {
            var newData = table.CreateInstance<EssecData>();
            _essecData.NumOfMahuyotInBakasha = newData.NumOfMahuyotInBakasha;
            _essecData.NumOfMahuyotInEssek = newData.NumOfMahuyotInEssek;
        }

        [Given(@"tahanot in bakasha")]
        public void GivenTahanotInBakasha(Table table)
        {
            var newData = table.CreateInstance<EssecData>();
            _essecData.NumOfInnerTahanot = newData.NumOfInnerTahanot;
            _essecData.NumOfOuterTahanot = newData.NumOfOuterTahanot;
        }

        [Given(@"tahanot names in bakasha")]
        public void GivenTahanotNamesInBakasha(Table table)
        {
            var newData = table.CreateInstance<EssecData>();
            _essecData.InnerTahanaName = newData.InnerTahanaName;
            _essecData.OuterTahanaName = newData.OuterTahanaName;
        }

        [Given(@"tahanot emails")]
        public void GivenTahanotEmails(Table table)
        {
            var newData = table.CreateInstance<EssecData>();
            _essecData.EmailInnerTahana = newData.EmailInnerTahana;
            _essecData.EmailOuterTahana = newData.EmailOuterTahana;
        }

        [Given(@"baaley inyan in tik essek")]
        public void GivenBaaleyInyanInTikEssek(Table table)
        {
            _essecData.BaalInyanEmail = table.CreateInstance<EssecData>().BaalInyanEmail;
        }

        [Given(@"Calculate Works Days for day ""([^""]*)""")]
        public void GivenCalculateWorksDaysForDay(string dayNum)
        {
            var response = _api.CalcWorksDays(dayNum);
            Console.WriteLine($"Works Days = {response}");
        }


        [Given(@"ManagerStationsWorkingProcess executed")]
        public void GivenManagerStationsWorkingProcessExecuted()
        {
            var response = _api.ManagerStationsWorkingProcess();   

        }

        [Given(@"bakashot reset from \[ris_t_bakasha]")]
        public void GivenBakashotResetFromRis_T_Bakasha()
        {

        }

        [Given(@"tahanot reset from \[ris_t_tachana_measheret]")]
        public void GivenTahanotResetFromRis_T_Tachana_Measheret()
        {
 
        }

        [Given(@"tahanot deleted from \[ris_t_haarachat_moed_lemahut]")]
        public void GivenTahanotDeletedFromRis_T_Haarachat_Moed_Lemahut()
        {
 
        }

        [Given(@"atraa deleted from \[ris_t_atraa_letachana_measheret]")]
        public void GivenAtraaDeletedFromRis_T_Atraa_Letachana_Measheret()
        {

        }

        [Given(@"tahanot email deleted from \[ris_t_channel_messages_audit]")]
        public void GivenTahanotEmailDeletedFromRis_T_Channel_Messages_Audit()
        {
   
        }

        [Given(@"baaley inyan email deleted from \[ris_t_channel_messages_audit]")]
        public void GivenBaaleyInyanEmailDeletedFromRis_T_Channel_Messages_Audit()
        {
 
        }

        [Given(@"outer tahana updated to ""([^""]*)"", inner tahana updated to ""([^""]*)""")]
        public void GivenOuterTahanaUpdatedToInnerTahanaUpdatedTo(string לידיעה, string נשלח)
        {

        }


        [Given(@"tik essek in TlvClientsApps")]
        public void GivenTikEssekInTlvClientsApps()
        {
            int codeEssec = _essecData.CodeEssek;
            int bakashaId = _essecData.BakashaId;

            var response = _api.GetBusinessById(codeEssec);
            var content = HandleContent.GetContent<GetBusinessByIdRes>(response);

            Assert.IsNotNull(content);

            var bakasha = content.requests.FirstOrDefault(request => request.requestNumber == _essecData.NumOfMahuyotInEssek);
            int numOfMahuyotInBakasha = bakasha.items.Length;

            Assert.AreEqual(_essecData.NumOfMahuyotInBakasha, numOfMahuyotInBakasha, $"NumOfMahuyotInBakasha");
            Assert.AreEqual(_essecData.NumOfMahuyotInEssek, content.requestItems.Length, $"NumOfMahuyotInEssek");
        }

        [Then(@"tik essek in TlvClientsApps matches input data")]
        public void ThenTikEssekInTlvClientsAppsMatchesInputData()
        {
            string innerTahanaName = _essecData.InnerTahanaName;
            int numOfInnerTahanot = _essecData.NumOfInnerTahanot;
            int numOfMahuyotInBakasha = _essecData.NumOfMahuyotInBakasha;
            int codeEssek = _essecData.CodeEssek;

            //Assert.AreEqual(content.phone2, 10);

        }



        [When(@"update creation day of bakasha to (.*)")]
        public void WhenUpdateCreationDayOfBakashaTo(int p0)
        {
    
        }

        [When(@"update creation day of tahanot to (.*)")]
        public void WhenUpdateCreationDayOfTahanotTo(int p0)
        {

        }

        [When(@"execute ""([^""]*)""")]
        public void WhenExecute(string managerStationsWorkingProcess)
        {
 
        }

        [Then(@"(.*)inner tahana status should be לידיעה")]
        public void ThenInnerTahanaStatusShouldBeלידיעה(int p0)
        {

        }

        [Then(@"(.*)outer tahana status should be נשלח")]
        public void ThenOuterTahanaStatusShouldBeנשלח(int p0)
        {
  
        }

        [Then(@"(.*)""([^""]*)"" should be no_records")]
        public void ThenShouldBeNo_Records(int p0, string p1)
        {
       
        }

    }
}
