using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Infrastructure.Models
{
    public partial class RisTTachanaMeasheret
    {

        public int PkCodeTachana { get; set; }
        public int PkCodeEssek { get; set; }
        public int PkCodeMautBebakasha { get; set; }
        public int? SugTachana { get; set; }
        public bool? AarachaMishtara { get; set; }
        public int? StatusAcharon { get; set; }
        public int? MishtameshMadkenStatus { get; set; }
        public int? FkKodHavatDaat { get; set; }
        public string TeurHavatDaat { get; set; }
        public int? YamimLeiter { get; set; }
        public DateTime? TaarichTukef { get; set; }
        public int? Mishtamesh { get; set; }
        public string ShemNatzig { get; set; }
        public DateTime? TaarichIdkunAcharon { get; set; }
        public bool? BetipulEsek { get; set; }
        public DateTime? TaarichSiumTipul { get; set; }
        public bool? BetipulTachana { get; set; }
        public string IpAddress { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public byte[] RowVersion { get; set; }
        public bool? IsActive { get; set; }
        public int? PathAlertStandartId { get; set; }
        public DateTime? TarichStatusAcharon { get; set; }
        public DateTime? TaarichAcharonHaavaraLetipulBealim { get; set; }
        public DateTime? TaarichAcharonSiumTipulBealim { get; set; }
        public int? MishtameshMeadkenTaarichAcharonSiumTipulBealim { get; set; }
        public int? MeadkenHeiterZmaniAchron { get; set; }
        public DateTime? TaarichLehiterZmaniAcharon { get; set; }
        public DateTime? TaarichTokefHiterZmaniAcharon { get; set; }
        public int? FkBakashaLheiterNilve { get; set; }
        public int? FkCodeDochBikorBesek { get; set; }
        public int? FkCodeMahuiotLebakashaDochBikor { get; set; }
        public int? KamutYamimLsyumTipul { get; set; }
        public int? KamutYamimletipulBealim { get; set; }
        public int? MishtameshMeadkenTaarichAcharonHaavaraLetipulBealim { get; set; }
        public int? FkCodeSibatEaTerufMismach { get; set; }
        public int? GoremMetapel { get; set; }
    }
}
