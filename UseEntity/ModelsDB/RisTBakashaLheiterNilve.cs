using System;
using System.Collections.Generic;

namespace Infrastructure.Models
{
    public partial class RisTBakashaLheiterNilve
    {
        public int Code { get; set; }
        public int FkCodeEssek { get; set; }
        public int FkCodeMahuiotLebakasha { get; set; }
        public int? FkSugHeiterNilve { get; set; }
        public DateTime? TarichHagashatBakashaHeiterNilve { get; set; }
        public int? MisparHagashaHeiterNilve { get; set; }
        public int? CodeMisparBakasha { get; set; }
        public int? FkStatusBakasha { get; set; }
        public DateTime? TarichStatusBakasha { get; set; }
        public decimal? ShetachHaheiterDrisha { get; set; }
        public decimal? ShetachHaheiterKviaa { get; set; }
        public DateTime? TaarichMinDrisha { get; set; }
        public DateTime? TaarichMinKviaa { get; set; }
        public DateTime? TaarichMaxDrisha { get; set; }
        public DateTime? TaarichMaxKviaa { get; set; }
        public string ShaaMinDrisha { get; set; }
        public string ShaaMinKviaa { get; set; }
        public string ShaaMaxDrisha { get; set; }
        public string ShaaMaxKviaa { get; set; }
        public int? KamutShulchanot { get; set; }
        public int? KamutShulchanotBar { get; set; }
        public int? KamutKisaot { get; set; }
        public bool? HimAlChofYam { get; set; }
        public int? YomSgira { get; set; }
        public decimal? MerchakMehamidrachaDrisha { get; set; }
        public decimal? MerchakMehamidrachaKviaa { get; set; }
        public bool? IndikatziaLemidrachaShetachPatuach { get; set; }
        public bool? IndikatziaToShetachDetailMivne { get; set; }
        public bool? SwHaskamaLetoranut { get; set; }
        public bool? SwEsekRechovMischari { get; set; }
        public bool? SwEsekMerkazKolel5 { get; set; }
        public bool? SwEsekTzirMerkazi { get; set; }
        public bool? SwEsekChotzeTzirMerkazi { get; set; }
        public string Adifut { get; set; }
        public int? KodEzor { get; set; }
        public int? SwMarkolGadolKatan { get; set; }
        public int? DargaLechishuvHaagra { get; set; }
        public int? MispurMehagrala { get; set; }
        public DateTime? TaarichHagrala { get; set; }
        public string ShaaHagrala { get; set; }
        public DateTime? TaarichBitol { get; set; }
        public int? SibatBitol { get; set; }
        public int? CodeMishtameshMevatel { get; set; }
        public string IpAddress { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public bool? IsActive { get; set; }
        public bool? Mevutal { get; set; }
        public string Michsholim { get; set; }
    }
}
