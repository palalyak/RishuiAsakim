using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.ContextDB;
using Infrastructure.Models;
using Infrastructure.ModelsAPI.Request;
using Infrastructure.ModelsDB;
using Infrastructure.Utility;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.ServicesDB
{
    public class DataQueryService
    {


        public DataQueryService()
        {


        }

        public IQueryable<int> GetCodeParit(int bakashaId)
        {
            MahuiotBebakashotContext context = new MahuiotBebakashotContext();
            IQueryable<int> codeParitList = context.RisTxMahuiotBebakashots
            .Where(item => item.FkBakasha == bakashaId)
            .Select(item => item.FkCodeParit);
            return codeParitList;
        }
        public IQueryable<string> GetDoarElectroniForCodeBakasha(int codeBakasha)
        {
            BaaleyInyanBtikContext btikContext = new BaaleyInyanBtikContext();
            BaaleyInyanLebakashaContext lebakashaContext = new BaaleyInyanLebakashaContext();

            var query = from btik in btikContext.RisTxBaaleyInyanBtiks
                        join lebakasha in lebakashaContext.RisTxBaaleyInyanLebakashas
                            on btik.PkBaaleyInyanBtik equals lebakasha.FkCodeBaaleyInyanBtik
                        where lebakasha.FkCodeBakasha == codeBakasha
                        select btik.DoarElectroni;

            return query;
        }
        //public IQueryable<string> GetEmailTahanaInBakasha(string codeEssek)
        //{
        //    TachanaMeasheretContext tachanaMeasheretContext = new TachanaMeasheretContext();
        //    SugTachanaMeasheretContext sugTachanaMeasheretContext = new SugTachanaMeasheretContext();

        //    var query = from tachana in tachanaMeasheretContext.RisTTachanaMeasherets
        //                join sugTachana in sugTachanaMeasheretContext.RisTtSugTachanaMeasherets
        //                    on tachana.SugTachana equals sugTachana.Code
        //                where tachana.PkCodeEssek == codeEssek
        //                select sugTachana.Email;

        //    return query;
        //}
        public void UpdateTahanotCreationDay(int bakashaId, DateTime newDate)
        {
            BakashotContext context = new BakashotContext();

            var bakasha = context.RisTBakashas.SingleOrDefault(b => b.PkCodeBakasha == bakashaId);

            if (bakasha != null)
            {
                bakasha.TaarichHagashatHabakasha = newDate;
                bakasha.CreatedDate = newDate;

                context.SaveChanges();
            }

        }
        public void UpdateTahanot(IQueryable<int> codeStations, DateTime newDate)
        {
            TachanaMeasheretContext context = new TachanaMeasheretContext();

            foreach (int codeStation in codeStations)
            {
                var tachana = context.RisTTachanaMeasherets.SingleOrDefault(t => t.PkCodeTachana == codeStation);

                if (tachana != null)
                {
                    tachana.TaarichIdkunAcharon = newDate;
                    tachana.CreatedDate = newDate;
                    tachana.TarichStatusAcharon = newDate;

                    context.SaveChanges();
                }

            }
        }
        public IQueryable<int> GetTahanot(IQueryable<int> codeMautBebakasha)
        {
            TachanaMeasheretContext context = new TachanaMeasheretContext();
            IQueryable<int> codeStationQuery = context.RisTTachanaMeasherets
                .Where(item => codeMautBebakasha.Contains(item.PkCodeMautBebakasha))
                .Select(item => item.PkCodeTachana);
            return codeStationQuery;
        }

        public IQueryable<int> GetTahanotInBakasha(int bakashaId)
        {
            MahuiotBebakashotContext mahuiotContext = new MahuiotBebakashotContext();
            TachanaMeasheretContext tachanaContext = new TachanaMeasheretContext();

            var codeTachanaQuery = from mahuiot in mahuiotContext.RisTxMahuiotBebakashots
                                   join tachana in tachanaContext.RisTTachanaMeasherets
                                   on mahuiot.FkCodeParit equals tachana.PkCodeMautBebakasha
                                   where mahuiot.FkBakasha == bakashaId
                                   select tachana.PkCodeTachana;

            return codeTachanaQuery;
        }

        public RisTKtovetEssek AddKtovetEssek(RisTKtovetEssek ktovetEssekModel)
        {
            KtovetEssekContext context = new KtovetEssekContext();
            try
            {
                var realPrimaryKeyValue = context.Entry(ktovetEssekModel).Property(x => x.PkCodeKtovetEssek).CurrentValue;
                ktovetEssekModel.PkCodeKtovetEssek = realPrimaryKeyValue + 1;   
                context.RisTKtovetEsseks.Add(ktovetEssekModel);
                context.SaveChanges();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error when saving data to the database:" + ex.Message);
            }
            return ktovetEssekModel;
        }

        public RisTHeiterNilve UpdateHeiterNilve(RisTHeiterNilve hiterNilveModel)
        {
            HeiterNilveContext context = new HeiterNilveContext();
            try
            {
                context.RisTHeiterNilves.Update(hiterNilveModel);
                context.SaveChanges();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error when saving data to the database:" + ex.Message);
            }
            return hiterNilveModel;
        }

        public RisTHeiterNilve GetHeiterNilveByBakasha(int bakashaId)
        {
            HeiterNilveContext context = new HeiterNilveContext();
            try
            {
                RisTHeiterNilve heiterNilve = context.RisTHeiterNilves
                    .SingleOrDefault(t => t.FkBakashaLheiterNilve == bakashaId);

                if (heiterNilve != null)
                {
                    return heiterNilve;
                }
                else
                {
                    Console.WriteLine($"heiterNilve with bakasha ID {bakashaId} not found.");
                    return null;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error when querying data from the database:" + ex.Message);
                return null;
            }
        }

        public RisTHeiterNilve GetHeiterNilve(int codHiter)
        {
            HeiterNilveContext context = new HeiterNilveContext();

            try
            {
                RisTHeiterNilve heiterNilve = context.RisTHeiterNilves.Find(codHiter);

                if (heiterNilve != null)
                {
                    return heiterNilve;
                }
                else
                {
                    Console.WriteLine($"HeiterNilve with ID {heiterNilve} not found.");
                    return null;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error when querying data from the database:" + ex.Message);
                return null;
            }
        }
        public RisTRishayonLeesek CreateLicense(RisTRishayonLeesek rishayonModel)
        {
            try
            {
                RishayonLeesekContext context = new RishayonLeesekContext();
                context.RisTRishayonLeeseks.Add(rishayonModel);
                context.SaveChanges();
                HandleContent.PrintObjectProperties(rishayonModel);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error when saving data to the database:" + ex.Message);
            }

            return rishayonModel;
        }

        public RisTMautBrishayonLeesek AddMahutToLicense(RisTMautBrishayonLeesek mautBeRishayonModel)
        {
            try
            {
                MautBrishayonLeesekContext context = new MautBrishayonLeesekContext();
                context.RisTMautBrishayonLeeseks.Add(mautBeRishayonModel);
                context.SaveChanges();
                HandleContent.PrintObjectProperties(mautBeRishayonModel);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error when saving data to the database:" + ex.Message);
            }
            return mautBeRishayonModel;
        }

        public RisTEssek CreateEssec(RisTEssek _tikEssecModel)
        {
            EssecContext _context = new EssecContext();
            {

            };
            try
            {

                _context.RisTEsseks.Add(_tikEssecModel);
                _context.SaveChanges();
            }

            catch (SqlException ex)
            {
                Console.WriteLine("Error when saving data to the database:" + ex.Message);
            }

            return _tikEssecModel;
        }
        public RisTBakasha CreateBakasha(RisTBakasha bakashaModel)
        {
            BakashotContext context = new BakashotContext();
            try
            {
                context.RisTBakashas.Add(bakashaModel);
                context.SaveChanges();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error when saving data to the database:" + ex.Message);
            }
            return bakashaModel;
        }
        public RisTBakasha UpdateBakashaToLicenseDB(RisTBakasha bakashaModel)
        {
            BakashotContext context = new BakashotContext();
            try
            {
                context.RisTBakashas.Update(bakashaModel);
                context.SaveChanges();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error when saving data to the database:" + ex.Message);
            }
            return bakashaModel;
        }

        public RisTBakashaLheiterNilve GetBakashaLheiterNilve(int codBakashatIter)
        {
            BakashaLheiterNilveContext context = new BakashaLheiterNilveContext();

            try
            {
                RisTBakashaLheiterNilve bakashaLheiterNilve = context.RisTBakashaLheiterNilves.Find(codBakashatIter);

                if (bakashaLheiterNilve != null)
                {
                    return bakashaLheiterNilve;
                }
                else
                {
                    Console.WriteLine($"BakashaLheiterNilve with ID {codBakashatIter} not found.");
                    return null;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error when querying data from the database:" + ex.Message);
                return null;
            }
        }

        public List<RisTTachanaMeasheret> GetTahanotOfHiter(int codBakashatIter)
        {
            TachanaMeasheretContext context = new TachanaMeasheretContext();

            try
            {
                List<RisTTachanaMeasheret> foundTahanot = context.RisTTachanaMeasherets
                    .Where(t => t.FkBakashaLheiterNilve == codBakashatIter)
                    .ToList();

                Console.WriteLine($"Number of tahanot for HiterNilve: {foundTahanot.Count}");
                return foundTahanot;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error when querying data from the database:" + ex.Message);
                return new List<RisTTachanaMeasheret>();
            }
        }

        public RisTShovarTashlumRishayon GetShovarTashlumHiterByBakasha(int codeBakasha, RisTShovarTashlumRishayon shovarmodel)
        {
            ShovarTashlumRishayonContext context = new ShovarTashlumRishayonContext();
            try
            {
                shovarmodel = context.RisTShovarTashlumRishayons
                    .FirstOrDefault(s => s.FkCodeBakashaLeiterNilve == codeBakasha);

                return shovarmodel;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error when querying data from the database: " + ex.Message);
                return null;
            }

        }


        public RisTTachanaMeasheret UpdateTahanot(RisTTachanaMeasheret tachanaMeasheretModel)
        {
            TachanaMeasheretContext context = new TachanaMeasheretContext();
            try
            {
                HandleContent.PrintObjectProperties(tachanaMeasheretModel);
                context.RisTTachanaMeasherets.Update(tachanaMeasheretModel);
                context.SaveChanges();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error when saving data to the database:" + ex.Message);
            }
            return tachanaMeasheretModel;
        }

        public RisTBakashaLheiterNilve UpdateHiterBakasha(RisTBakashaLheiterNilve bakashaLheiterNilveModel)
        {
            BakashaLheiterNilveContext context = new BakashaLheiterNilveContext();
            try
            {
                context.RisTBakashaLheiterNilves.Update(bakashaLheiterNilveModel);
                context.SaveChanges();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error when saving data to the database:" + ex.Message);
            }
            return bakashaLheiterNilveModel;
        }



        public RisTxMahuiotLebakasha CreateMahutLeBakasha(RisTxMahuiotLebakasha mahutLebakasha)
        {
            MahuiotLebakashotContext context = new MahuiotLebakashotContext();
            try
            {
                context.RisTxMahuiotLebakashas.Add(mahutLebakasha);
                context.SaveChanges();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error when saving data to the database:" + ex.Message);
            }
            return mahutLebakasha;
        }
        public RisTxMahuiotBebakashot CreateMahutBeBakasha(RisTxMahuiotBebakashot mahutBebakasha)
        {
            MahuiotBebakashotContext context = new MahuiotBebakashotContext();
            try
            {
                context.RisTxMahuiotBebakashots.Add(mahutBebakasha);
                context.SaveChanges();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error when saving data to the database:" + ex.Message);
            }
            return mahutBebakasha;
        }
        public RisTTachanaMeasheret CreateTahanaMeasheret(RisTTachanaMeasheret taachanaMeasheretModel)
        {
            TachanaMeasheretContext context = new TachanaMeasheretContext();
            try
            {
                context.RisTTachanaMeasherets.Add(taachanaMeasheretModel);
                context.SaveChanges();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error when saving data to the database:" + ex.Message);
            }
            return taachanaMeasheretModel;
        }


        public static object GetSystemParametersContentDB(string paramName, string paramValue)
        {
            object paramTable = null;
            try
            {
                SugHeiterNilveContext hiterParameters = new SugHeiterNilveContext();
                var matchingItem1 = hiterParameters.RisTtSugHeiterNilves.Where(t => t.Teur == paramName).FirstOrDefault();

                if (matchingItem1 != null)
                {
                    var propertyInfo = matchingItem1.GetType().GetProperty(paramValue);

                    if (propertyInfo != null)
                    {
                        var param = propertyInfo.GetValue(matchingItem1);
                        Console.WriteLine($"Parameter name: {paramName} / Parameter value: {paramValue} = {param ?? "null"}");

                        return param;
                    }
                }

                MaarechetParameterContext maarahetParameters = new MaarechetParameterContext();
                var matchingItem2 = maarahetParameters.RisTtMaarechetParameters
                                 .Where(t => t.Name == paramName)                     
                                 .FirstOrDefault();

                if (matchingItem2 != null)
                {
                    var propertyInfo = matchingItem2.GetType().GetProperty(paramValue);

                    if (propertyInfo != null)
                    {
                        var param2 = propertyInfo.GetValue(matchingItem2);
                        Console.WriteLine($"Parameter name: {paramName} / Parameter value: {paramValue} = {param2 ?? "null"}");

                        return param2;
                    }
                }

                ShcavotGisIroniContext gisParameters = new ShcavotGisIroniContext();
                
                var matchingItem3 = gisParameters.RisTShcavotGisIronis
                    .Where(t => t.FkEzorYafo == 1)
                                 .FirstOrDefault();

                if (matchingItem3 != null)
                {
                    var propertyInfo = matchingItem3.GetType().GetProperty(paramValue);

                    if (propertyInfo != null)
                    {
                        var param3 = propertyInfo.GetValue(matchingItem3);
                        Console.WriteLine($"Parameter name: {paramName} / Parameter value: {paramValue} = {param3 ?? "null"}");

                        return param3;
                    }
                }


                throw new InvalidOperationException($"Column with name {paramValue} & {paramName} not found in RisTtSugHeiterNilve & SugHeiterNilveContext tables");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error when fetch data from database: {ex.Message}");
                throw;
            }
     

        }

        public RisTTachanaMeasheret UpdateTahanaMeasheret(RisTTachanaMeasheret taachanaMeasheretModel)
        {
            TachanaMeasheretContext context = new TachanaMeasheretContext();
            try
            {
                context.RisTTachanaMeasherets.Update(taachanaMeasheretModel);
                context.SaveChanges();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error when saving data to the database:" + ex.Message);
            }
            return taachanaMeasheretModel;
        }

        public RisTxBaaleyInyanBtik CreateBaalInyanBeTik(RisTxBaaleyInyanBtik baaleyInyanBeTikModel)
        {
            BaaleyInyanBtikContext context = new BaaleyInyanBtikContext();
            try
            {
                context.RisTxBaaleyInyanBtiks.Add(baaleyInyanBeTikModel);
                context.SaveChanges();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error when saving data to the database:" + ex.Message);
            }
            return baaleyInyanBeTikModel;
        }

        public RisTBaaleyInyan CreateBaalInyan(RisTBaaleyInyan baaleyInyanModel)
        {
            BaaleyInyanContext context = new BaaleyInyanContext();
            try
            {
                context.RisTBaaleyInyans.Add(baaleyInyanModel);
                context.SaveChanges();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error when saving data to the database:" + ex.Message);
            }
            return baaleyInyanModel;
        }
        public RisTBaaleyInyan GetBaalInyan(string key)
        {
            BaaleyInyanContext context = new BaaleyInyanContext();

            try
            {
                RisTBaaleyInyan baalInyan = context.RisTBaaleyInyans.Find(key);

                if (baalInyan != null)
                {
                    return baalInyan;
                }
                else
                {
                    Console.WriteLine($"baal Inyan with ID {key} not found.");
                    return null;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error when querying data from the database:" + ex.Message);
                return null;
            }
        }

        public void UpdateEssec(RisTEssek tikEssecModel)
        {
            ContextDB.EssecContext context = new ContextDB.EssecContext();
            var essecToUpdate = context.RisTEsseks.Find(tikEssecModel.PkCodeEssek);

            if (essecToUpdate != null)
            {
                context.Entry(essecToUpdate).CurrentValues.SetValues(tikEssecModel);

                context.SaveChanges();
            }
        }
        public RisTxBaaleyInyanLebakasha CreateBaaleyInyanLebakasha(RisTxBaaleyInyanLebakasha baaleyInyanLebakashaModel)
        {
            BaaleyInyanLebakashaContext context = new BaaleyInyanLebakashaContext();
            try
            {
                context.RisTxBaaleyInyanLebakashas.Add(baaleyInyanLebakashaModel);
                context.SaveChanges();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error when saving data to the database:" + ex.Message);
            }
            return baaleyInyanLebakashaModel;
        }

        public RisTSeruv CreateSeruv(RisTSeruv _seruvModel)
        {
            SeruvContext context = new SeruvContext();
            try
            {
                context.RisTSeruvs.Add(_seruvModel);
                context.SaveChanges();
                HandleContent.PrintObjectProperties(_seruvModel);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error when saving data to the database:" + ex.Message);
            }
            return _seruvModel;
        }
        public RisTxSeruvLetachana CreateSeruvLaTahana(RisTxSeruvLetachana seruvLaTahanaModel)
        {
            SeruvLaTahanaContext context = new SeruvLaTahanaContext();
            try
            {
                context.RisTxSeruvLetachanas.Add(seruvLaTahanaModel);
                context.SaveChanges();
                HandleContent.PrintObjectProperties(seruvLaTahanaModel);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error when saving data to the database:" + ex.Message);
            }
            return seruvLaTahanaModel;
        }

        public RisTxSeruvToTotzaatSeruv UpdateSeruvToTotzaatSeruv(RisTxSeruvToTotzaatSeruv seruvTotzahaModel)
        {
            SeruvToTotzaatSeruvContext context = new SeruvToTotzaatSeruvContext();
            try
            {
                context.RisTxSeruvToTotzaatSeruvs.Add(seruvTotzahaModel);
                context.SaveChanges();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error when saving data to the database:" + ex.Message);
            }
            return seruvTotzahaModel;
        }
    }
}

