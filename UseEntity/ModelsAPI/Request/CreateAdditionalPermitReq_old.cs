using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ModelsAPI.Request
{


    //Requestadditionalpermit

    public class RequestadditionalpermitReq2
    {
        public int id { get; set; }
        public int businessId { get; set; }
        public int requestItemId { get; set; }
        public int additionalPermitTypeId { get; set; }
        public string? additionalPermitTypeDesc { get; set; }
        public DateTime? createdDate { get; set; }
        public int? submissionNumber { get; set; }
        public int? submissionId { get; set; }
        public DateTime? statusDate { get; set; }
        public double? determinedArea { get; set; }
        public DateTime? determinedValidityStartDate { get; set; }
        public DateTime? determinedValidityEndDate { get; set; }
        public string determinedStartHour { get; set; }
        public string determinedEndHour { get; set; }
        public int? quantityTable { get; set; }
        public int? quantityBarTable { get; set; }
        public int? quantityChairs { get; set; }
        public bool? isOnBeach { get; set; }
        public int? closeDay { get; set; }
        public double? requestDistanceSidewalk { get; set; }
        public double? determinedDistanceSidewalk { get; set; }
        public bool? indicationOpenAreaSidewalk { get; set; }
        public bool? indicationBuildingAreaDetail { get; set; }
        public bool? consentDuty { get; set; }
        public bool? isCommercialStreet { get; set; }
        public bool? isCenterInclusive5 { get; set; }
        public bool? isCentralAxis { get; set; }
        public bool? isCrossesCentralAxis { get; set; }
        public string? priority { get; set; }
        public int? areaId { get; set; }
        public int? isBigSupermarket { get; set; }
        public int? gradeFeeCalc { get; set; }
        public int? lotteryNumber { get; set; }
        public DateTime? lotteryDate { get; set; }
        public int? lotteryHour { get; set; }
        public DateTime? cancelDate { get; set; }
        public int? cancelReasonId { get; set; }
        public int? cancelUserId { get; set; }
        public int? diagramType { get; set; }
        public int? frontHeight { get; set; }
        public int? frontWidth { get; set; }
        public int? frontDistance { get; set; }
        public int? rightHeight { get; set; }
        public int? rightWidth { get; set; }
        public int? rightDistance { get; set; }
        public int? leftHeight { get; set; }
        public int? leftWidth { get; set; }
        public int? leftDistance { get; set; }

        public bool isRequestRenew { get; set; }
        public DateTime? submissionDate { get; set; }
        public DateTime? requestValidityStartDate { get; set; }
        public DateTime? requestValidityEndDate { get; set; }
        public string requestStartHour { get; set; }
        public string requestEndHour { get; set; }
        public double? requestArea { get; set; }
        public int statusId { get; set; }

        public Additionalpermit2[] additionalPermit { get; set; } = Array.Empty<Additionalpermit2>();
        public Permitobstacle2[] permitObstacles { get; set; } = Array.Empty<Permitobstacle2>();
    }

    public class Additionalpermit2
    {
        public int id { get; set; }
        public int businessId { get; set; }
        public int additionalPermitTypeId { get; set; }
        public int requestAdditionalPermitId { get; set; }
        public int statusId { get; set; }
        public string explanation { get; set; }
        public int requestDistanceSidewalk { get; set; }
        public bool indicationOpenAreaSidewalk { get; set; }
        public bool indicationBuildingAreaDetail { get; set; }
        public DateTime cancelDate { get; set; }
        public int cancelReasonId { get; set; }
        public int cancelUserId { get; set; }
        public int itemNumber { get; set; }
        public bool isCanceled { get; set; }
        public string requestAdditionalPermit { get; set; }
        public Additionalpermittype2 additionalPermitType { get; set; }
        public Additionalpermitstatus2 additionalPermitStatus { get; set; }
        public DateTime validityStartDate { get; set; }
        public DateTime validityEndDate { get; set; }
        public int approvedUserId { get; set; }
        public string approvedUserName { get; set; }
        public DateTime approvedDate { get; set; }
        public string mainItemDescription { get; set; }
    }

    public class Additionalpermittype2
    {
        public int code { get; set; }
        public string description { get; set; }
        public int renewType { get; set; }
        public bool isFeeRequired { get; set; }
        public bool isDependLicense { get; set; }
        public DateTime dateStart { get; set; }
        public DateTime dateEnd { get; set; }
        public int minPermitPriod { get; set; }
        public int maxPermitPriod { get; set; }
        public int renewMonths { get; set; }
        public int infrastructureWorksTypeId { get; set; }
        public int additionalPermitTypeId { get; set; }
        public string itemsGroup { get; set; }
        public DateTime startPermitSeason { get; set; }
        public DateTime endPermitSeason { get; set; }
    }

    public class Additionalpermitstatus2
    {
        public int code { get; set; }
        public string description { get; set; }
    }

    public class Permitobstacle2
    {
        public int amount { get; set; }
        public string description { get; set; }
        public int code { get; set; }
    }


}



