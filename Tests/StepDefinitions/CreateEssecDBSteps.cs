using System;

using System.Net;
using System.Reflection;
using Bogus;
using Infrastructure;
using Infrastructure.Auth;
using Infrastructure.ContextDB;
using Infrastructure.Models;
using Infrastructure.ModelsAPI.Request;
using Infrastructure.ServicesDB;
using Infrastructure.Utility;
using Microsoft.Extensions.Configuration;
using RestSharp;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Tests.StepDefinitions
{
    [Binding]
    public class CreateEssecDBSteps
    {
        private RisTEssek _tikEssecModel;
        private RisTKtovetEssek _ktovetEssekModel;
        private RisTBakasha _bakashaModel;
        private List<RisTBakasha> _bakashaModelList;
        private RisTxMahuiotLebakasha _mahutLeBakashaModel;
        private List<RisTxMahuiotLebakasha> _mahutLeBakashaModelList;
        private RisTxMahuiotBebakashot _mahutBeBakashaModel;
        private RisTTachanaMeasheret _taachanaMeasheretModel;
        private List<RisTTachanaMeasheret> _taachanaMeasheretModelList;
        private RisTBaaleyInyan _baaleyInyanModel;
        private List<RisTBaaleyInyan> _baaaleyInyanList;
        private RisTxBaaleyInyanBtik _baaleyInyanBeTikModel;
        private List<RisTxBaaleyInyanBtik> _baaleyInyanBetikList;
        private RisTxBaaleyInyanLebakasha _baaleyInyanLebakashaModel;
        private List<int> _sugBaalInyan = new List<int> { 1, 2, 3, 4, 5 }; //There are 5 types of stakeholders   
        private FakeDataGenerator fakeDataGenerator;
        DataQueryService query;
        private ScenarioContext scenarioContext;
        private APIClient _api;
        private RestResponse _response;
        private List<int> _bakashotHiterCode;
#if (DEBUG)
        string baseEnv = "APIDev";


#else
        string baseEnv = "APITest";
#endif


        public CreateEssecDBSteps(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
            query = new DataQueryService();
            _baaaleyInyanList = new List<RisTBaaleyInyan>();
            _bakashotHiterCode = new List<int>();
            _baaleyInyanBetikList = new List<RisTxBaaleyInyanBtik>();
            _bakashaModelList = new List<RisTBakasha>();
            _mahutLeBakashaModelList = new List<RisTxMahuiotLebakasha>();
            _taachanaMeasheretModelList = new List<RisTTachanaMeasheret>();
            fakeDataGenerator = new FakeDataGenerator(new Faker());
            _api = new APIClient($"http://iispreprod01/TlvServices/Tlv.BusinessRegistration/{baseEnv}/");

        }

        [Given(@"valid access token")]
        public void GivenValidAccessToken()
        {
            _api.CalcWorksDays("0");
        }


        public void NewEssekWithParameters(decimal areaSize = 10, bool aImMukpa = false, int rechov = 1, int bait = 1)
        {
            _tikEssecModel = fakeDataGenerator.GenerateFakeClassData<RisTEssek>();
            _ktovetEssekModel = fakeDataGenerator.GenerateFakeClassData<RisTKtovetEssek>();
             
            var randomNum = HandleContent.GetRandomNumber(111111111111, 9999999999999).ToString();
            _tikEssecModel.MisRishuiEsek = HandleContent.GetRandomNumber(1000000, 999999999).ToString();
            _tikEssecModel.CreatedBy = 1;
            _tikEssecModel.PkCodeEssek = 0;

            _tikEssecModel.MisparHeshbonArnona = randomNum;
            _tikEssecModel.MsCheshbonChoze = "4193226304252";
            _tikEssecModel.Mukpaa = aImMukpa;
            _tikEssecModel.SugGishaLesek = 2;
            //_tikEssecModel.KodMerkazMischari = (int)HandleContent.GetRandomNumber(1, 2);
            _tikEssecModel.MisparMekomotChanaya = 100;
            _tikEssecModel.MisparMekomotChanayaNechim = 10;
            _tikEssecModel.MisparAnashim = 300;
            //_tikEssecModel.FkTikMishtaraAlfa = (int)HandleContent.GetRandomNumber(1, 999999999);
            _tikEssecModel.ShetachHaessekBaarnona = areaSize;
            _tikEssecModel.ShetachHaessekHamadud = areaSize;
            _tikEssecModel.ShetachHaessekHameduvach = areaSize;
            _tikEssecModel.ShetachShulhanot = 0;
            _tikEssecModel.ShetachPargod = 0;
            _tikEssecModel.LoTaonRishoi = false;

            HandleContent.PrintObjectProperties(_tikEssecModel);

            _tikEssecModel = query.CreateEssec(_tikEssecModel);

            string taDoarNum = HandleContent.GetRandomNumber(1, 5).ToString();
            for (int i = 1; i < 3; i++)
            {
                // add physical address and postal address 
                _ktovetEssekModel.PkCodeKtovetEssek = -1;
                _ktovetEssekModel.PkCodeEssek = _tikEssecModel.PkCodeEssek;
                _ktovetEssekModel.SugKtovet = i;
                _ktovetEssekModel.SemelRechov = i == 1 ? 3675 : rechov;
                _ktovetEssekModel.KodBait = bait;
                _ktovetEssekModel.Knisa = "א";
                _ktovetEssekModel.KodKoma = 1;
                _ktovetEssekModel.MisparShchuna = 1;
                _ktovetEssekModel.Dira = "666";
                _ktovetEssekModel.Gush = 1;
                _ktovetEssekModel.Helka = 1;

                _ktovetEssekModel.TaDoar = taDoarNum;
                HandleContent.PrintObjectProperties(_ktovetEssekModel);
                _ktovetEssekModel = query.AddKtovetEssek(_ktovetEssekModel);
            }

            scenarioContext["EssekID"] = _tikEssecModel.PkCodeEssek;
            scenarioContext["EssekModel"] = _tikEssecModel;
            scenarioContext["EssekKtovetModel"] = _ktovetEssekModel;

        }

        [When(@"bakasha with parameters: (.*), (.*)")]
        public void WhenBakashaWithParameters(int daysBack = 0, int kodStatusBakasha = 1)
        {
            var dateCreation = _api.CalcWorksDays(daysBack.ToString());
            _bakashaModel = fakeDataGenerator.GenerateFakeClassData<RisTBakasha>();
            _bakashaModel.PkCodeBakasha = 0;
            _bakashaModel.TaarichHagashatHabakasha = dateCreation;
            _bakashaModel.CreatedDate = dateCreation;
            _bakashaModel.KodStatusHabakasha = kodStatusBakasha;
            _bakashaModel.PkCodeEssek = _tikEssecModel.PkCodeEssek;

            _bakashaModelList.Add(_bakashaModel);
            _bakashaModel = query.CreateBakasha(_bakashaModel);
            scenarioContext["BakashaModel"] = _bakashaModel;
            scenarioContext["BakashaCode"] = _bakashaModel.PkCodeBakasha;
            HandleContent.PrintObjectProperties(_bakashaModel);

            _tikEssecModel.MisparBakashaAchrona = _bakashaModel.PkCodeBakasha;
            query.UpdateEssec(_tikEssecModel); // add bakasha ahrona to essec
        }

        [When(@"cancel the bakasha ""([^""]*)""")]
        public void WhenCancelTheBakasha(string param)
        {
            if (!param.Equals("no", StringComparison.OrdinalIgnoreCase))
            {
                _bakashaModel = (RisTBakasha)scenarioContext["BakashaModel"];
                _bakashaModel.Mvutal = true;
                _bakashaModel = query.UpdateBakashaToLicenseDB(_bakashaModel);
                HandleContent.PrintObjectProperties(_bakashaModel);
            }
        }


        [When(@"(.*) mahuyot lebakasha with parameters: (.*), (.*)")]
        public void WhenMahuyotLebakashaWithParameters(int numOfEntity = 1, int kodMaslul = 2, int kodMahutRashit = 9)
        {
            for (int m = 0; m < numOfEntity; m++)
            {
                _mahutLeBakashaModel = fakeDataGenerator.GenerateFakeClassData<RisTxMahuiotLebakasha>();
                _mahutLeBakashaModel.PkCodeParit = 0;
                _mahutLeBakashaModel.CreatedDate = _bakashaModel.CreatedDate;
                _mahutLeBakashaModel.KodParit = m + 1;

                if (m == 0)
                {
                    _mahutLeBakashaModel.MahutRashit = true; // if num of mahuyot > 1 then first mahut = MahutRashit                 
                    if (kodMahutRashit != 0)
                    {
                        _mahutLeBakashaModel.KodParit = kodMahutRashit;
                    }
                }
                _mahutLeBakashaModel.IsActive = true;
                _mahutLeBakashaModel.KodMaslul = kodMaslul;
                _mahutLeBakashaModel.PkCodeEssek = _tikEssecModel.PkCodeEssek;
                HandleContent.PrintObjectProperties(_mahutLeBakashaModel);
                _mahutLeBakashaModelList.Add(_mahutLeBakashaModel);
                _mahutLeBakashaModel = query.CreateMahutLeBakasha(_mahutLeBakashaModel);

                if (m == 0)
                {
                    scenarioContext["KodMahutRashit"] = _mahutLeBakashaModel.PkCodeParit;
                }
                scenarioContext["CodeParit"] = _mahutLeBakashaModel.PkCodeParit;
                scenarioContext["MahutLeBakashaModel"] = _mahutLeBakashaModel;

                _mahutBeBakashaModel = fakeDataGenerator.GenerateFakeClassData<RisTxMahuiotBebakashot>();
                _mahutBeBakashaModel.PkKesherMaut = 0;
                _mahutBeBakashaModel.CreatedDate = _bakashaModel.CreatedDate;
                _mahutBeBakashaModel.FkCodeParit = _mahutLeBakashaModel.PkCodeParit;

                _mahutBeBakashaModel.FkBakasha = _bakashaModel.PkCodeBakasha;
                query.CreateMahutBeBakasha(_mahutBeBakashaModel);
                HandleContent.PrintObjectProperties(_mahutBeBakashaModel);
            }
        }

        [When(@"tahananot meashrot for all mahuyot with parameter: (.*)")]
        public void WhenTahananotMeashrotForAllMahuyotWithParameter(int daysBack = 0)
        {
            var dateCreation = _api.CalcWorksDays(daysBack.ToString());

            for (int i = 0; i < _mahutLeBakashaModelList.Count; i++)
            {
                for (int s = 0; s < 2; s++)
                {
                    /*
                     * create tahana pnimit and tahana hizonit for all mahuyot.
                     * if maslul = tatsir or mezuraz alef then status tahana hizonit = לידיעה 
                     */
                    _taachanaMeasheretModel = fakeDataGenerator.GenerateFakeClassData<RisTTachanaMeasheret>();
                    _taachanaMeasheretModel.PkCodeTachana = 0;
                    _taachanaMeasheretModel.PkCodeEssek = _tikEssecModel.PkCodeEssek;
                    _taachanaMeasheretModel.PkCodeMautBebakasha = _mahutLeBakashaModelList[i].PkCodeParit;
                    _taachanaMeasheretModel.TarichStatusAcharon = dateCreation;
                    _taachanaMeasheretModel.TaarichIdkunAcharon = dateCreation;
                    _taachanaMeasheretModel.CreatedDate = dateCreation;

                    _taachanaMeasheretModel.SugTachana = s == 0 ? 1 : 61;
                    _taachanaMeasheretModel.StatusAcharon = s == 0 ? 1 :
                        (_mahutLeBakashaModel.KodMaslul == 1 || _mahutLeBakashaModel.KodMaslul == 2) ? 8 : 1;

                    HandleContent.PrintObjectProperties(_taachanaMeasheretModel);
                    _taachanaMeasheretModel = query.CreateTahanaMeasheret(_taachanaMeasheretModel);
                    _taachanaMeasheretModelList.Add(_taachanaMeasheretModel);
                    scenarioContext["TahanaModel"] = _taachanaMeasheretModel;
                }
            }
        }

        [When(@"update status of tahanot meashrot to (.*)")]
        public void WhenUpdateStatusOfTahanotMeashrotTo(int statusTahanot)
        {
            for (int i = 0; i < _taachanaMeasheretModelList.Count; i++)
            {
                _taachanaMeasheretModelList[i].StatusAcharon = statusTahanot;
                query.UpdateTahanaMeasheret(_taachanaMeasheretModelList[i]);
            }
        }


        [When(@"(.*) set of all types of Baaley Inyan")]
        public void WhenSetOfAllTypesOfBaaleyInyan(int num = 1)
        {
            for (int i = 0; i < num; i++)
            {
                for (int b = 0; b < _sugBaalInyan.Count; b++)
                {
                    _baaleyInyanModel = fakeDataGenerator.GenerateFakeClassData<RisTBaaleyInyan>();
                    _baaleyInyanModel = query.CreateBaalInyan(_baaleyInyanModel);
                    _baaaleyInyanList.Add(_baaleyInyanModel);
                }
            }

            AddsBaaleyInyanBetikEssek();
            AddsBaaleyInyanToBakasha();
            scenarioContext["BaaleInyanListModel"] = _baaaleyInyanList;
        }

        private void AddsBaaleyInyanBetikEssek()
        {
            for (int i = 0; i < _baaaleyInyanList.Count; i++)
            {
                _baaleyInyanBeTikModel = fakeDataGenerator.GenerateFakeClassData<RisTxBaaleyInyanBtik>();
                _baaleyInyanBeTikModel.FkCodeEssek = _tikEssecModel.PkCodeEssek;
                _baaleyInyanBeTikModel.PkBaaleyInyanBtik = 0;
                _baaleyInyanBeTikModel.CreatedDate = _bakashaModel.CreatedDate;
                _baaleyInyanBeTikModel.FkMezaheBaalInyan = _baaaleyInyanList[i].PkMezaheBaalInyan;

                if (_baaaleyInyanList.Count == 1)
                {
                    _baaleyInyanBeTikModel.FkSugBaalInyan = 4;
                }
                else
                {
                    int index = i % _sugBaalInyan.Count;
                    _baaleyInyanBeTikModel.FkSugBaalInyan = _sugBaalInyan[index];
                }

                _baaleyInyanBeTikModel.DoarElectroni = $"test_bi_{_baaaleyInyanList[i].ShemMispaha}_" +
                    $"{_baaleyInyanBeTikModel.FkSugBaalInyan}@gmail.com";

                _baaleyInyanBetikList.Add(_baaleyInyanBeTikModel);
                _baaleyInyanBeTikModel = query.CreateBaalInyanBeTik(_baaleyInyanBeTikModel);
                HandleContent.PrintObjectProperties(_baaleyInyanBeTikModel);

            }
        }
        private void AddsBaaleyInyanToBakasha()
        {
            for (int i = 0; i < _baaleyInyanBetikList.Count; i++)
            {
                _baaleyInyanLebakashaModel = fakeDataGenerator.GenerateFakeClassData<RisTxBaaleyInyanLebakasha>();
                _baaleyInyanLebakashaModel.PkCodeBaaleyInyanLebakasha = 0;
                _baaleyInyanLebakashaModel.FkCodeBaaleyInyanBtik = _baaleyInyanBetikList[i].PkBaaleyInyanBtik;
                _baaleyInyanLebakashaModel.FkCodeBakasha = _bakashaModel.PkCodeBakasha;
                _baaleyInyanLebakashaModel = query.CreateBaaleyInyanLebakasha(_baaleyInyanLebakashaModel);

            }
        }

        [Given(@"default tik rishuy")]
        public void GivenDefaultTikRishuy()
        {
            NewEssekWithParameters();
            WhenBakashaWithParameters();
            WhenMahuyotLebakashaWithParameters(1,3,10);
            WhenTahananotMeashrotForAllMahuyotWithParameter();
            WhenSetOfAllTypesOfBaaleyInyan();
        }
        [Given(@"default tik rishuy with parameters for mahut: (.*), (.*), (.*), (.*), (.*)")]
        public void GivenDefaultTikRishuyWithParametersForMahut(int numOfEntity = 1, int kodMaslul = 3, int kodMahutRashit = 0, int daysBack = 0, int areaSize = 10)
        {
            NewEssekWithParameters(areaSize);
            WhenBakashaWithParameters(daysBack);
            WhenMahuyotLebakashaWithParameters(numOfEntity, kodMaslul, kodMahutRashit);
            WhenTahananotMeashrotForAllMahuyotWithParameter(daysBack);
            WhenSetOfAllTypesOfBaaleyInyan();
        }

        [Given(@"tik rishuy for GIS: (.*), (.*), (.*), (.*), (.*), (.*)")]
        public void GivenTikRishuyForGISAlef(int sugHaeter, string ezorYafo, string kvuzatMahut, bool haImLefiGIS, int mediniutLayla, bool haImEssekTaunRishuy)
        {
            // [ris_t_chokim_leiter_laila] קובע שעת התחלה של היתר לילה
            // [ris_t_shcavot_GIS_ironi] קובע שעת סיום היתר לילה אם נדרש
            // [ris_tt_maarechet_parameter].[NightPermitMaxEndHour] קובע שעת סיום היתר לילה אם נדרש
            // NightPermitMaxEndHour - 05:00

            decimal areaSize = 0;
            int numOfEntity = 1;
            int kodMaslul = 3;           
            int rechov = 0, bait = 0;

            int codKvuzatMahut = kvuzatMahut == "לא כללית" ? 104200 :
                             kvuzatMahut == "כללית" ? 104102 :
                             throw new Exception("wrong kvuzat mahut");

            switch (sugHaeter)
            {
                // היתר לילה
                case 1: 
                    if (mediniutLayla == 1)
                    {
                        rechov = 2; bait = 27; // לבדיקת שעת סיום ומהות לבדיקת שעת התחלה
                    }
                    else if (mediniutLayla == 2)
                    {
                        rechov = 1; bait = 1;
                    }
                    else if (mediniutLayla == 3)
                    {
                        rechov = 40; bait = 31;
                    }
                    else if (mediniutLayla == 4)
                    {
                        rechov = 2; bait = 125;
                    }
                    else if (mediniutLayla == 5)
                    {
                        rechov = 2; bait = 162;
                    }
                    else if (mediniutLayla == 6)
                    {
                        rechov = 5; bait = 1;
                    }

                    break;


                // היתר שבת יפה
                case 7:
                    if (ezorYafo == "alef")
                    {
                        rechov = 1; bait = 1;
                    }
                    else if (ezorYafo == "bet")
                    {
                        rechov = 1; bait = 2;
                    }
                    break;
            }

                NewEssekWithParameters(areaSize, false, rechov, bait);
                WhenBakashaWithParameters();
                WhenMahuyotLebakashaWithParameters(numOfEntity, kodMaslul, codKvuzatMahut);
                WhenTahananotMeashrotForAllMahuyotWithParameter();
                WhenSetOfAllTypesOfBaaleyInyan();

            if (haImEssekTaunRishuy)
            {
                _tikEssecModel.LoTaonRishoi = false;
                query.UpdateEssec(_tikEssecModel);
            }

            scenarioContext["EssekStreet"] = rechov;
            scenarioContext["EssekHouseNumber"] = bait;
        }




        [Given(@"update objects creation date '([^']*)', '([^']*)'")]
        public void GivenUpdateObjectsCreationDate(string timeSet, string objectType)
        {
            switch (objectType.ToLower())
            {

                case "essek":
                    {
                        foreach (var model in _bakashaModelList)
                        {
                            model.TaarichHagashatHabakasha = HandleContent.CalculateTimeSet(timeSet, model.TaarichHagashatHabakasha);
                            model.CreatedDate = HandleContent.CalculateTimeSet(timeSet, model.CreatedDate);
                            query.UpdateBakashaToLicenseDB(model);
                        }
                        foreach (var model in _taachanaMeasheretModelList)
                        {
                            model.TaarichIdkunAcharon = HandleContent.CalculateTimeSet(timeSet, model.TaarichIdkunAcharon);
                            model.TarichStatusAcharon = HandleContent.CalculateTimeSet(timeSet, model.TarichStatusAcharon);
                            model.CreatedDate = HandleContent.CalculateTimeSet(timeSet, model.CreatedDate);
                            query.UpdateTahanaMeasheret(model);
                        }
                    }
                    break;
                case "hiter_nilve":
                    {
                        _bakashotHiterCode = (List<int>)scenarioContext["CodBakashatIters"];
                        _bakashotHiterCode.Count.Should().NotBe(0);

                        UpdateTimeHiterBakashot(timeSet, _bakashotHiterCode);
                        for (int i = 0; i < _bakashotHiterCode.Count; i++)
                        {
                            List<RisTTachanaMeasheret> _tachanotNilveModel = query.GetTahanotOfHiter(_bakashotHiterCode[i]);
                            foreach (var model in _tachanotNilveModel)
                            {
                                model.TarichStatusAcharon = HandleContent.CalculateTimeSet(timeSet, model.TarichStatusAcharon);
                                model.TaarichIdkunAcharon = HandleContent.CalculateTimeSet(timeSet, model.TaarichIdkunAcharon);
                                model.CreatedDate = HandleContent.CalculateTimeSet(timeSet, model.CreatedDate);
                                query.UpdateTahanot(model);
                            }

                            RisTHeiterNilve _hiterNilveModel = query.GetHeiterNilveByBakasha(_bakashotHiterCode[i]);
                            _hiterNilveModel.CreatedDate = HandleContent.CalculateTimeSet(timeSet, _hiterNilveModel.CreatedDate);
                            _hiterNilveModel.TaarichMin = HandleContent.CalculateTimeSet(timeSet, _hiterNilveModel.TaarichMin);
                            _hiterNilveModel.TaarichMax = HandleContent.CalculateTimeSet(timeSet, _hiterNilveModel.TaarichMax);
                            _hiterNilveModel.CreatedDate = HandleContent.CalculateTimeSet(timeSet, _hiterNilveModel.CreatedDate);
                            query.UpdateHeiterNilve(_hiterNilveModel);
                        }
                        break;
                    }
                case "hiter_bakasha":
                    {
                        _bakashotHiterCode = (List<int>)scenarioContext["CodBakashatIters"];
                        _bakashotHiterCode.Count.Should().NotBe(0);
                        UpdateTimeHiterBakashot(timeSet, _bakashotHiterCode);
                    }

                    break;
                default:
                    {

                        throw new FormatException($"wrong agument: {objectType}");
                    }
            }

        }

        private void UpdateTimeHiterBakashot(string timeSet, List<int> bakashotHiterCode)
        {
            for (int i = 0; i < bakashotHiterCode.Count; i++)
            {
                RisTBakashaLheiterNilve _bakashaHiter = query.GetBakashaLheiterNilve(_bakashotHiterCode[i]);
                _bakashaHiter.TarichStatusBakasha = HandleContent.CalculateTimeSet(timeSet, _bakashaHiter.TarichStatusBakasha);
                _bakashaHiter.TaarichMaxDrisha = HandleContent.CalculateTimeSet(timeSet, _bakashaHiter.TaarichMaxDrisha);
                _bakashaHiter.TarichHagashatBakashaHeiterNilve = HandleContent.CalculateTimeSet(timeSet, _bakashaHiter.TarichHagashatBakashaHeiterNilve);
                _bakashaHiter.CreatedDate = HandleContent.CalculateTimeSet(timeSet, _bakashaHiter.CreatedDate);

                query.UpdateHiterBakasha(_bakashaHiter);
            }
        }


        [When(@"update status of bakasha to: (.*)")]
        public void WhenUpdateStatusOfBakashaTo(int param)
        {
            _bakashaModel = (RisTBakasha)scenarioContext["BakashaModel"];
            _bakashaModel.KodStatusHabakasha = param;
            _bakashaModel = query.UpdateBakashaToLicenseDB(_bakashaModel);
            HandleContent.PrintObjectProperties(_bakashaModel);
        }

        [When(@"run Ser(?:.*?) get business data")]
        public void WhenRunSerGetBusinessData()
        {
            int essekId = (int)scenarioContext["EssekID"];

            GetBusinessData payload = new Faker<GetBusinessData>()
    .RuleFor(r => r.filter, f => new Filter
    {
        businessId = Convert.ToInt32(essekId)
    })
    .RuleFor(p => p.Params, f => new Params
    {
        validityDate = "2014-02-11T15:12:55.352Z",
        withAddress = true,
        withMailAddress = true,
        withItems = true,
        withLicense = true,
        withAdditionalPermit = true,
        withStakeholders = true,
        withWarnings = true,
        addressParams = new AddressParams
        {
            withStreetDesc = true,
            neighborhoodDesc = true,
            addressType = 1

        }
    })
    .Generate();
            HandleContent.PrintObjectProperties(payload);
            _response = _api.GetBusinessData(payload);
        }


        [When(@"execute Ser(?:.*?)")]
        public void WhenExecuteSer()
        {
            _response = _api.ManagerStationsWorkingProcess();
        }

        [When(@"update the creation date of objects in a loop: '([^']*)', (.*)")]
        public void WhenUpdateTheCreationDateOfObjectsInALoop(string sign, int days)
        {
            for (int i = 1; i < days; i++)
            {
                string myDate = $"{sign}00-00-{i}T00:00";
                GivenUpdateObjectsCreationDate(myDate, "essek");

                if (_bakashotHiterCode.Count != 0)
                {
                    GivenUpdateObjectsCreationDate(myDate, "hiter_nilve");
                }
                //WhenExecuteSer();
                Console.WriteLine("");
            }
        }


        /*
         * Examples for table and JSON:         
          
        [Given(@"essec payload ""([^""]*)""")]
        public void GivenEssecPayload(string fileName)
        {
            string file = HandleContent.GetFilePath(fileName); // Get JSON payload path
            var payload = HandleContent.ParseJSON<RisTEssek>(file); // Deserialize JSON
            scenarioContext.Add("create_business_payload", payload); // Share deserialize payload with other steps
        }

        [When(@"user creates a new essec in DB")]
        public void WhenUserCreatseANewEssecInDB()
        {
            // Get deserialize payload from other step
            var jsonClass = scenarioContext.Get<RisTEssek>("create_business_payload"); 
        }

        [When(@"user creates bakasha")]
        public void WhenUserCreatesBakasha(Table table)
        {
            var daysBack = table.Rows[0]["DaysBack"];
            var kodStatusHabakasha = table.Rows[0]["kod_status_habakasha"];
        }

         */
    }


}
