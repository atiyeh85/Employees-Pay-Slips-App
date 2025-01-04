namespace SalaryV2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ray.Emp")]
    public partial class Emp
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Emp()
        {
            Emp1 = new HashSet<Emp>();
            Emp11 = new HashSet<Emp>();
            EmpPayWags = new HashSet<EmpPayWag>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long EmpId { get; set; }

        public long? OrgEmpid { get; set; }

        public int? CrdId { get; set; }

        public int? EmpCenter { get; set; }

        [StringLength(25)]
        public string Name { get; set; }

        [Required]
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

        public byte? CrnEduTyp { get; set; }

        public short? CrnEduSub { get; set; }

        public byte? CnfEduTyp { get; set; }

        public short? CnfEduSub { get; set; }

        [StringLength(8)]
        public string EmpBgnDat { get; set; }

        [StringLength(8)]
        public string EmpDat { get; set; }

        public byte? CrnEmpTyp { get; set; }

        public int? CrnJob { get; set; }

        public int? CrnJobTenure { get; set; }

        public long? CrnPos { get; set; }

        public long? CrnPos2 { get; set; }

        public long? CrnPos3 { get; set; }

        public int? CrnDeprt { get; set; }

        public int? CrnMisn { get; set; }

        public int? CrnCntr { get; set; }

        public int? CrnCntr2 { get; set; }

        public int? CrnCntr3 { get; set; }

        public short? CrnlocId { get; set; }

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

        public int? Photo { get; set; }

        [StringLength(36)]
        public string PhotoX { get; set; }

        public int? Sign { get; set; }

        [StringLength(36)]
        public string SignX { get; set; }

        public int? PoliceDocPic { get; set; }

        [StringLength(36)]
        public string PoliceDocPicX { get; set; }

        public int? ShenDocPic { get; set; }

        [StringLength(36)]
        public string ShenDocPicX { get; set; }

        public int? SoldurDocPic { get; set; }

        [StringLength(36)]
        public string SoldurDocPicX { get; set; }

        public double? EmpRate1 { get; set; }

        public double? EmpRate2 { get; set; }

        public double? EmpRate3 { get; set; }

        public double? EmpRate4 { get; set; }

        public double? EmpRate5 { get; set; }

        [StringLength(12)]
        public string UserId { get; set; }

        [StringLength(20)]
        public string SaveNo { get; set; }

        public byte? PrsntTyp { get; set; }

        [Column(TypeName = "money")]
        public decimal? YerVactRmnd { get; set; }

        [Column(TypeName = "money")]
        public decimal? YerSavRate { get; set; }

        [StringLength(15)]
        public string NationCode { get; set; }

        [StringLength(12)]
        public string TshUsrCnfrm { get; set; }

        public short? TshIntTel { get; set; }

        [Column(TypeName = "money")]
        public decimal? TshRate { get; set; }

        public int? DocPic { get; set; }

        [StringLength(36)]
        public string DocPicX { get; set; }

        public byte? SocialAct { get; set; }

        public byte? IsTsh { get; set; }

        public short? ProcessBatchNo { get; set; }

        public byte? IsChanged { get; set; }

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

        [StringLength(100)]
        public string AllBranchReplication { get; set; }

        [StringLength(10)]
        public string PostCod { get; set; }

        public int? TaxBranchCode { get; set; }

        [StringLength(20)]
        public string TelMobil { get; set; }

        [StringLength(30)]
        public string Sheba1 { get; set; }

        [StringLength(30)]
        public string Sheba2 { get; set; }

        [Column(TypeName = "money")]
        public decimal? PortionPrc { get; set; }

        [StringLength(20)]
        public string RetirmntDocNo { get; set; }

        [StringLength(20)]
        public string RetirmntBrchCod { get; set; }

        public long? HeirsNo { get; set; }

        public int? NativeStatus { get; set; }

        public int? OrganVassal { get; set; }

        public byte? IsRfh { get; set; }

        [StringLength(12)]
        public string UsrEdit { get; set; }

        public int? EmployeeStatusId { get; set; }

        public int? CorporateVehicleStatusId { get; set; }

        public int? CrnCorporateHousingStatusId { get; set; }

        public int? CrnWorkPlaceStatusId { get; set; }

        public int? CrnTypeOfContractId { get; set; }

        [StringLength(8)]
        public string TempPayOffDat { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [StringLength(100)]
        public string AllBranch { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int? SumGrops { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [StringLength(8)]
        public string OutDat { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [StringLength(8)]
        public string EmpOutDat { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Emp> Emp1 { get; set; }

        public virtual Emp Emp2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Emp> Emp11 { get; set; }

        public virtual Emp Emp3 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmpPayWag> EmpPayWags { get; set; }
    }
}
