namespace SalaryV2.Models.Corporate
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PAY.vwContract")]
    public partial class vwContract
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ContractId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PersonnelRef { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int WorkSiteRef { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int JobRef { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TaxGroupRef { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TaxBranchRef { get; set; }

        public int? InsuranceBranchRef { get; set; }

        public int? SupportingInsuranceBranchRef { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ContractType { get; set; }

        [Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Number { get; set; }

        [Key]
        [Column(Order = 8)]
        public DateTime IssueDate { get; set; }

        [Key]
        [Column(Order = 9)]
        public DateTime ExpireDate { get; set; }

        public DateTime? EndDate { get; set; }

        [Key]
        [Column(Order = 10)]
        public DateTime EmploymentDate { get; set; }

        [Key]
        [Column(Order = 11)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmploymentType { get; set; }

        public decimal? NonTaxableAmount { get; set; }

        [Key]
        [Column(Order = 12)]
        public bool HasInsurance { get; set; }

        [Key]
        [Column(Order = 13)]
        public bool HasHardJob { get; set; }

        [Key]
        [Column(Order = 14)]
        public bool HasSupportingInsurance { get; set; }

        [Key]
        [Column(Order = 15)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Version { get; set; }

        [Key]
        [Column(Order = 16)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Creator { get; set; }

        [Key]
        [Column(Order = 17)]
        public DateTime CreationDate { get; set; }

        [Key]
        [Column(Order = 18)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LastModifier { get; set; }

        [Key]
        [Column(Order = 19)]
        public DateTime LastModificationDate { get; set; }

        [StringLength(250)]
        public string InsuranceBranchTitle { get; set; }

        public int? InsuranceBranchDlRef { get; set; }

        [StringLength(40)]
        public string InsuranceBranchCode { get; set; }

        [StringLength(250)]
        public string SupportingInsuranceBranchTitle { get; set; }

        public int? SupportingInsuranceBranchDlRef { get; set; }

        [StringLength(40)]
        public string SupportingInsuranceBranchCode { get; set; }

        [Key]
        [Column(Order = 20)]
        [StringLength(250)]
        public string TaxBranchTitle { get; set; }

        [Key]
        [Column(Order = 21)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TaxBranchDlRef { get; set; }

        [Key]
        [Column(Order = 22)]
        [StringLength(40)]
        public string TaxBranchCode { get; set; }

        [Key]
        [Column(Order = 23)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TaxBranchAdjustmentType { get; set; }

        [Key]
        [Column(Order = 24)]
        [StringLength(250)]
        public string JobTitle { get; set; }

        [Key]
        [Column(Order = 25)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int JobCode { get; set; }

        [Key]
        [Column(Order = 26)]
        [StringLength(250)]
        public string TaxGroupTitle { get; set; }

        [Key]
        [Column(Order = 27)]
        [StringLength(250)]
        public string WorksiteTitle { get; set; }

        [Key]
        [Column(Order = 28)]
        [StringLength(250)]
        public string WorksiteTitle_En { get; set; }

        [Key]
        [Column(Order = 29)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int WorkSiteCode { get; set; }

        [Key]
        [Column(Order = 30)]
        [StringLength(250)]
        public string CostCenterTitle { get; set; }

        [Key]
        [Column(Order = 31)]
        [StringLength(250)]
        public string CostCenterTitle_En { get; set; }

        public int? CostCenterDLRef { get; set; }

        [Key]
        [Column(Order = 32)]
        [StringLength(40)]
        public string CostCenterCode { get; set; }

        [Key]
        [Column(Order = 33)]
        [StringLength(250)]
        public string PersonnelTitle { get; set; }

        [Key]
        [Column(Order = 34)]
        [StringLength(40)]
        public string PersonnelCode { get; set; }

        [StringLength(250)]
        public string PersonnelBirthLocationTitle { get; set; }

        [Key]
        [Column(Order = 35)]
        [StringLength(250)]
        public string PersonnelFirstName { get; set; }

        [StringLength(250)]
        public string PersonnelLastName { get; set; }

        [StringLength(250)]
        public string PersonnelFatherName { get; set; }

        [StringLength(250)]
        public string PersonnelBirthIdentity { get; set; }

        public DateTime? PersonnelBirthDate { get; set; }

        [Key]
        [Column(Order = 36)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PersonnelEducationDegree { get; set; }

        [StringLength(250)]
        public string PersonnelEducationField { get; set; }

        [StringLength(4000)]
        public string Description { get; set; }

        [Key]
        [Column(Order = 37)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PersonnelDLRef { get; set; }

        [StringLength(40)]
        public string PersonnelIdentificationCode { get; set; }

        [StringLength(250)]
        public string PersonnelBankTitle_En { get; set; }

        [StringLength(250)]
        public string PersonnelBankTitle { get; set; }

        [StringLength(250)]
        public string PersonnelBankBranchCode { get; set; }

        [StringLength(250)]
        public string PersonnelBranchTitle { get; set; }

        [StringLength(250)]
        public string PersonnelBranchTitle_En { get; set; }

        [StringLength(250)]
        public string PersonnelAccountTypeTitle { get; set; }

        [StringLength(250)]
        public string PersonnelAccountTypeTitle_En { get; set; }

        [StringLength(250)]
        public string PersonnelAccountNo { get; set; }

        public int? PersonnelAccountTypeRef { get; set; }

        public int? PersonnelBankBranchRef { get; set; }

        public int? PersonnelBankRef { get; set; }

        [StringLength(250)]
        public string PartyLocationTitle { get; set; }

        [StringLength(400)]
        public string PartyAddress { get; set; }

        [Key]
        [Column(Order = 38)]
        public bool HasEmployerInsuranceException { get; set; }

        [Key]
        [Column(Order = 39)]
        public bool HasUnemploymentException { get; set; }

        [Key]
        [Column(Order = 40)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmployerInsuranceExceptionPercent { get; set; }

        public decimal? BonusSum { get; set; }

        public decimal? LeakageSum { get; set; }

        [Key]
        [Column(Order = 41)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IsLastContract { get; set; }

        [StringLength(500)]
        public string SupportingInsuranceName { get; set; }
    }
}
