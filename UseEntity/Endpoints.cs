using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class Endpoints
    {
        public static readonly string CREATE_BUSINESS = "/BusinessManagement/api/Business/Add";
        public static readonly string Update_BUSINESS = "/BusinessManagement/api/Business/Update";
        public static readonly string GET_BUSINESS = "/BusinessManagement/api/Business/GetById";
        public static readonly string GET_BUSINESS_DATA = "/BusinessManagement/api/Business/GetBusinessData";
        public static readonly string SEARCH_BUSINESS = "/BusinessManagement/api/Business/Search";

        public static readonly string MANAGE_STATIONS_WORKING_PROCESS = "/LicenseService/api/License/ManagerStationsWorkingProcess";
        public static readonly string MANAGE_ADDITIONAL_PERMITS_STATIONS_PROCESS = "/LicenseService/api/License/";

        public static readonly string CALCULATE_WORKS_DAYS = "/LicenseService/api/License/GetWorkDays";

        public static readonly string CREATE_ADDITIONAL_PERMIT_REQUEST = "/LicenseService/api/AdditionalPermit/CreateAdditionalPermitRequest";
        public static readonly string UPDATE_REQUEST_ADDITIONAL_PERMIT = "/LicenseService/api/AdditionalPermit/UpdateRequestAdditionalPermit";
        public static readonly string GET_PERMIT_REQUESTS_FOR_STATION_THREATMENT = "/ManagementApi/api/Station/GetPermitRequestsForStationTreatment";
        public static readonly string GET_BUSINESS_ADDITIONAL_PERMITS = "/LicenseService/api/AdditionalPermit/GetBusinessAdditionalPermits";
        public static readonly string RENEW_ADDITIONAL_PERMIT = "/LicenseService/api/AdditionalPermit/RenewAdditionalPermit";

        public static readonly string CREATE_LICENSE = "/LicenseService/api/License/CreateLicense";
        public static readonly string UPDATE_REFUSE_SHEUDULED_HEARNING = "LicenseService/api/License/UpdateRefuseScheduledHearing";
        public static readonly string CANCEL_REFUSE_LICENSE = "/ManagementApi/api/license/CancelRefuseLicense";

        public static readonly string CHECK_ADDITIONAL_PERMIT_POSSIBILITY = "LicenseService/api/AdditionalPermit/CheckAdditionalPermitPossibility";
        public static readonly string APPROVE_ADDITIONAL_PERMIT = "ManagementApi/api/AdditionalPermit/ApproveAdditionalPermit";
        public static readonly string FREE_CALCULATION_FOR_ADDITIONAL_PERMIT = "LicenseService/api/AdditionalPermit/FeeCalculation";

        public static readonly string GET_GIS_LAYER = "/CoreService/api/GIS/GetGISLayer";
    }
    
}
