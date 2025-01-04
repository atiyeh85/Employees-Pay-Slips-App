namespace SalaryV2.NewFolder1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PAY.vwPersonnel")]
    public partial class vwPersonnel
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PersonnelId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PartyRef { get; set; }

        [StringLength(250)]
        public string BirthIdentity { get; set; }

        public int? BirthLocationRef { get; set; }

        [StringLength(250)]
        public string FatherName { get; set; }

        public DateTime? BirthDate { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Nationality { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MarriageStatus { get; set; }

        public DateTime? StatusDate { get; set; }

        public int? Children { get; set; }

        public int? FamilyCount { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EducationDegree { get; set; }

        [StringLength(250)]
        public string EducationField { get; set; }

        [StringLength(50)]
        public string InsuranceNumber { get; set; }

        [StringLength(50)]
        public string SupportInsuranceNumber { get; set; }

        public int? InsuranceDay { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MilitaryStatus { get; set; }

        public int? BankRef { get; set; }

        public int? BankBranchRef { get; set; }

        public int? AccountTypeRef { get; set; }

        [StringLength(250)]
        public string AccountNo { get; set; }

        [StringLength(250)]
        public string LocationTitle { get; set; }

        [StringLength(250)]
        public string LocationTitle_En { get; set; }

        [StringLength(250)]
        public string BankTitle { get; set; }

        [StringLength(250)]
        public string BankTitle_En { get; set; }

        [StringLength(250)]
        public string BankBranchCode { get; set; }

        [StringLength(250)]
        public string BranchTitle { get; set; }

        [StringLength(250)]
        public string BranchTitle_En { get; set; }

        [StringLength(250)]
        public string AccountTypeTitle { get; set; }

        public int? BankAccountType { get; set; }

        [StringLength(250)]
        public string AccountTypeTitle_En { get; set; }

        [StringLength(250)]
        public string BirthSerial { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(250)]
        public string DLTitle { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(250)]
        public string DLTitle_En { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(40)]
        public string DLCode { get; set; }

        [Key]
        [Column(Order = 9)]
        public bool IsEmployee { get; set; }

        [Key]
        [Column(Order = 10)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Sex { get; set; }

        [StringLength(40)]
        public string IdentificationCode { get; set; }

        [Key]
        [Column(Order = 11)]
        public bool IsActive { get; set; }

        [Key]
        [Column(Order = 12)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DlRef { get; set; }

        [Key]
        [Column(Order = 13)]
        [StringLength(250)]
        public string FirstName { get; set; }

        [Key]
        [Column(Order = 14)]
        [StringLength(250)]
        public string FirstName_En { get; set; }

        [StringLength(250)]
        public string LastName { get; set; }

        [StringLength(250)]
        public string LastName_En { get; set; }

        [Key]
        [Column(Order = 15)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmployeeStatus { get; set; }
    }
}
