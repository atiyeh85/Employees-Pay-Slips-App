namespace SalaryV2.Models.Corporate
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CNT.ContractType")]
    public partial class ContractType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ContractType()
        {
            Contracts = new HashSet<Contract>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ContractTypeID { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        [StringLength(50)]
        public string Title_En { get; set; }

        public int Version { get; set; }

        public int Creator { get; set; }

        public DateTime CreationDate { get; set; }

        public int LastModifier { get; set; }

        public DateTime LastModificationDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contract> Contracts { get; set; }
    }
}
