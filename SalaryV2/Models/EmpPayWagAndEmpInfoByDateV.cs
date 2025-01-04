namespace SalaryV2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ray.EmpPayWagAndEmpInfoByDateV")]
    public partial class EmpPayWagAndEmpInfoByDateV
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short Year { get; set; }

        [Key]
        [Column(Order = 1)]
        public byte Mnt { get; set; }

        [Key]
        [Column(Order = 2)]
        public byte Period { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long EmpId { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short Row { get; set; }

        public short? Flag { get; set; }

        public short? PayCodId { get; set; }

        [StringLength(100)]
        public string PayCodTit { get; set; }

        [Column(TypeName = "money")]
        public decimal? PayVal { get; set; }

        public short? DedCodId { get; set; }

        [StringLength(100)]
        public string DedCodTit { get; set; }

        [Column(TypeName = "money")]
        public decimal? DedVal { get; set; }

        public short? ExtCodId { get; set; }

        [StringLength(100)]
        public string ExtCodTit { get; set; }

        [Column(TypeName = "money")]
        public decimal? ExtVal { get; set; }

        [StringLength(100)]
        public string ExtValDsc { get; set; }

        public byte? MazId { get; set; }

        [StringLength(45)]
        public string Maz { get; set; }

        [Column(TypeName = "money")]
        public decimal? HokmVal { get; set; }

        public byte? SentByEmail { get; set; }

        public long? OrgEmpid { get; set; }

        public int? CrdId { get; set; }

        public int? EmpCenter { get; set; }

        [StringLength(25)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Fmly { get; set; }

        public byte? Sex { get; set; }

        public short? Country { get; set; }

        [StringLength(25)]
        public string Fthr { get; set; }

        [StringLength(15)]
        public string ShenId { get; set; }

        [StringLength(15)]
        public string ShenSerial { get; set; }

        [StringLength(8)]
        public string ShenDat { get; set; }

        public int? ShenCity { get; set; }

        public int? BrthPlc { get; set; }

        [StringLength(8)]
        public string BrthDat { get; set; }

        public byte? Mrg { get; set; }

        public byte? Soldur { get; set; }

        public byte? PhisicId { get; set; }

        public byte? Regen { get; set; }

        [StringLength(15)]
        public string WorkId { get; set; }

        [StringLength(15)]
        public string InsId { get; set; }

        [StringLength(45)]
        public string PhisicDesc { get; set; }

        public byte? Child { get; set; }

        public byte? Rlt { get; set; }

        public byte? NoIns { get; set; }

        public byte? NoCldVal { get; set; }

        public short? SoldrScor { get; set; }

        public short? HighScor { get; set; }

        public short? CorsScor { get; set; }

        public short? EduScor { get; set; }

        public short? ExpOutScor { get; set; }

        public short? ExpScor { get; set; }

        public byte? BankAcntTyp { get; set; }

        [StringLength(20)]
        public string Acnt { get; set; }

        public int? Bank { get; set; }

        public byte? BankAcntTyp2 { get; set; }

        [StringLength(20)]
        public string Acnt2 { get; set; }

        public int? Bank2 { get; set; }

        [StringLength(120)]
        public string Adrs { get; set; }

        [StringLength(60)]
        public string Tel { get; set; }

        public int? CrnEduTyp { get; set; }

        public short? CrnEduSub { get; set; }

        public byte? CnfEduTyp { get; set; }

        public short? CnfEduSub { get; set; }

        [StringLength(8)]
        public string EmpBgnDat { get; set; }

        [StringLength(8)]
        public string EmpDat { get; set; }

        [Key]
        [Column(Order = 5)]
        public byte CrnEmpTyp { get; set; }

        public int? CrnJob { get; set; }

        public int? CrnJobTenure { get; set; }

        public long? CrnPos { get; set; }

        public long? CrnPos2 { get; set; }

        public long? CrnPos3 { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CrnDeprt { get; set; }

        public int? CrnMisn { get; set; }

        [Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CrnCntr { get; set; }

        public int? CrnCntr2 { get; set; }

        public int? CrnCntr3 { get; set; }

        [Key]
        [Column(Order = 8)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short CrnlocId { get; set; }

        public short? CrnMislocId { get; set; }

        public short? ShiftGrp { get; set; }

        public byte? CrnGrp { get; set; }

        public byte? CrnExtGrop { get; set; }

        [Column(TypeName = "money")]
        public decimal? CrnGrad { get; set; }

        public byte? CrnLvl { get; set; }

        public byte? TaxTyp { get; set; }

        public short? HousStt { get; set; }

        public byte? NightTyp { get; set; }

        public byte? ShiftTyp { get; set; }

        public short? InsTyp { get; set; }

        [Column(TypeName = "money")]
        public decimal? OvrPrs { get; set; }

        [Column(TypeName = "money")]
        public decimal? OvrVctPrc { get; set; }

        public byte? AbsTyp { get; set; }

        public byte? DlyTyp { get; set; }

        public double? EmpRate1 { get; set; }

        public double? EmpRate2 { get; set; }

        public double? EmpRate3 { get; set; }

        public double? EmpRate4 { get; set; }

        public double? EmpRate5 { get; set; }

        [StringLength(12)]
        public string UserId { get; set; }

        [StringLength(20)]
        public string SaveNo { get; set; }

        [Column(TypeName = "money")]
        public decimal? YerVactRmnd { get; set; }

        [Column(TypeName = "money")]
        public decimal? YerSavRate { get; set; }

        [StringLength(15)]
        public string NationCode { get; set; }

        public byte? SocialAct { get; set; }

        [Column(TypeName = "money")]
        public decimal? MilitaryDue { get; set; }

        public int? CrnStage { get; set; }

        public int? MainLanguage { get; set; }

        public int? CrnZoneID { get; set; }

        public int? CrnSupervisionTypeID { get; set; }

        [Column(TypeName = "money")]
        public decimal? CrnEmployRate { get; set; }

        public byte? ActiveBank { get; set; }

        public int? CrnGuild { get; set; }

        [StringLength(20)]
        public string RecruitmentNo { get; set; }

        public short? TotalExpAcptDue { get; set; }

        [Column(TypeName = "money")]
        public decimal? EvalTotVal { get; set; }

        [StringLength(20)]
        public string BankCardNo { get; set; }

        [StringLength(20)]
        public string BankCardNo2 { get; set; }

        public int? CrnJobSection { get; set; }

        public int? Branch { get; set; }

        [StringLength(30)]
        public string RcvDat { get; set; }

        [StringLength(8)]
        public string LastPensionerAssistanceDat { get; set; }

        [StringLength(8)]
        public string LastPensionerDat { get; set; }

        public long? EmpidDead { get; set; }

        public byte? RltId { get; set; }

        public byte? AidyPay { get; set; }

        [StringLength(60)]
        public string Email { get; set; }

        [StringLength(8)]
        public string MrgDate { get; set; }

        public byte? FreeMaxOver { get; set; }

        [StringLength(10)]
        public string PostCod { get; set; }

        public int? TaxBranchCode { get; set; }

        [Column(TypeName = "money")]
        public decimal? PortionPrc { get; set; }

        [StringLength(20)]
        public string TelMobil { get; set; }

        [StringLength(30)]
        public string Sheba1 { get; set; }

        [StringLength(30)]
        public string Sheba2 { get; set; }

        public int? NativeStatus { get; set; }

        [StringLength(20)]
        public string RetirmntDocNo { get; set; }

        [StringLength(20)]
        public string RetirmntBrchCod { get; set; }

        public long? HeirsNo { get; set; }

        public int? EmployeeStatusId { get; set; }

        public int? CrnTypeOfContractId { get; set; }

        public int? CrnCorporateHousingStatusId { get; set; }

        public int? CrnWorkPlaceStatusId { get; set; }

        [StringLength(8)]
        public string OutDat { get; set; }

        public short? ProcessBatchNo { get; set; }

        [StringLength(8)]
        public string EmpOutDat { get; set; }

        [StringLength(8)]
        public string HKMENDDAT { get; set; }

        [StringLength(1000)]
        public string EBLGDESC { get; set; }
    }
}
