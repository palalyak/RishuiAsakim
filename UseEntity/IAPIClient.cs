using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace Infrastructure
{
    internal interface IAPIClient
    {
        Task<RestResponse> CreateBusiness<T>(T payload) where T : class;
        Task<RestResponse> UpdateBusiness<T>(T payload) where T : class;
        Task<RestResponse> SearchBusiness<T>(T searchCriteria) where T : class;
        RestResponse GetBusinessById(int businessId);
        RestResponse CreateAdditionalPermitRequest<T>(T payload) where T : class;
        RestResponse CreateDraftLicense<T>(T payload) where T : class;
        RestResponse UpdateRefuseScheduledHearing<T>(T payload) where T : class;
        RestResponse CancelRefuseLicense<T>(T payload) where T : class;
        RestResponse UpdateRequestAdditionalPermit<T>(T payload) where T : class;
        RestResponse FeeCalculation<T>(T payload) where T : class;
        RestResponse CheckAdditionalPermitPossibility<T>(T payload) where T : class;
        //RestResponse<List<T>> GetPermitRequestsForStationTreatment<T>(T payload) where T : class;
        RestResponse GetPermitRequestsForStationTreatment<T>(T payload) where T : class;
        RestResponse GetBusinessAdditionalPermits<T>(T payload);
        RestResponse GetBusinessData<T>(T payload) where T : class;
        RestResponse RenewAdditionalPermit<T>(T payload) where T : class;
        RestResponse GetGISLayer<T>(T payload) where T : class;
        RestResponse ApproveAdditionalPermit<T>(T payload) where T : class;
        RestResponse CreateRequestItemReq<T>(T payload) where T : class;
        RestResponse CreateApprovingStartion<T>(T payload) where T : class;


    }
}
