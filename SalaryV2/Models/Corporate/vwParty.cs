namespace SalaryV2.Models.Corporate
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GNR.vwParty")]
    public partial class vwParty
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PartyId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Type { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SubType { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(250)]
        public string Name { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(250)]
        public string Name_En { get; set; }

        [StringLength(250)]
        public string LastName { get; set; }

        [StringLength(250)]
        public string LastName_En { get; set; }

        [StringLength(40)]
        public string EconomicCode { get; set; }

        [StringLength(40)]
        public string RegistrationCode { get; set; }

        [StringLength(250)]
        public string Website { get; set; }

        [StringLength(250)]
        public string Email { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DLRef { get; set; }

        [Key]
        [Column(Order = 6)]
        public bool IsActive { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(250)]
        public string DLTitle { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(250)]
        public string DLTitle_En { get; set; }

        [Key]
        [Column(Order = 9)]
        [StringLength(40)]
        public string DLCode { get; set; }

        [Key]
        [Column(Order = 10)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DLType { get; set; }

        [Key]
        [Column(Order = 11)]
        [StringLength(501)]
        public string FullName { get; set; }

        [Key]
        [Column(Order = 12)]
        public bool IsVendor { get; set; }

        public int? VendorGroupingRef { get; set; }

        [Key]
        [Column(Order = 13)]
        public bool IsBroker { get; set; }

        public int? BrokerGroupingRef { get; set; }

        public decimal? CommissionRate { get; set; }

        public decimal? BrokerOpeningBalance { get; set; }

        [Key]
        [Column(Order = 14)]
        public bool IsEmployee { get; set; }

        [Key]
        [Column(Order = 15)]
        public bool IsCustomer { get; set; }

        public int? SalespersonPartyRef { get; set; }

        public decimal? DiscountRate { get; set; }

        public decimal? MaximumCredit { get; set; }

        public int? CustomerGroupingRef { get; set; }

        [StringLength(501)]
        public string SalespersonTitle { get; set; }

        [StringLength(400)]
        public string VendorGroupingTitle { get; set; }

        [StringLength(400)]
        public string VendorGroupingTitle_En { get; set; }

        [StringLength(400)]
        public string CustomerGroupingTitle { get; set; }

        [StringLength(400)]
        public string CustomerGroupingTitle_En { get; set; }

        public int? CustomerGroupingCode { get; set; }

        public int? BrokerGroupingCode { get; set; }

        [StringLength(400)]
        public string BrokerGroupingTitle { get; set; }

        [StringLength(400)]
        public string BrokerGroupingTitle_En { get; set; }

        [Key]
        [Column(Order = 16)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Version { get; set; }

        [Key]
        [Column(Order = 17)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Creator { get; set; }

        [Key]
        [Column(Order = 18)]
        public DateTime CreationDate { get; set; }

        [Key]
        [Column(Order = 19)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LastModifier { get; set; }

        [Key]
        [Column(Order = 20)]
        public DateTime LastModificationDate { get; set; }

        [StringLength(40)]
        public string IdentificationCode { get; set; }

        [Key]
        [Column(Order = 21)]
        public bool IsInBlacklist { get; set; }

        public int? BrokerOpeningBalanceType { get; set; }

        [StringLength(652)]
        public string FullAddress { get; set; }

        [StringLength(652)]
        public string FullAddress_En { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }

        [Key]
        [Column(Order = 22)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CustomerCategoryForTax { get; set; }

        public DateTime? BirthDate { get; set; }

        public DateTime? MarriageDate { get; set; }

        [Key]
        [Column(Order = 23)]
        public bool HasCredit { get; set; }

        [Key]
        [Column(Order = 24)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CreditCheckingType { get; set; }

        public decimal? CustomerRemaining { get; set; }

        [StringLength(36)]
        public string Guid { get; set; }

        [StringLength(20)]
        public string PartyFax { get; set; }
    }
}
