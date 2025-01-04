namespace SalaryV2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ray.EmpDeprt")]
    public partial class EmpDeprt
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EmpDeprt()
        {
            EmpDeprt1 = new HashSet<EmpDeprt>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DeprtId { get; set; }

        [StringLength(150)]
        public string Depart { get; set; }

        [StringLength(12)]
        public string Mngr { get; set; }

        public int? MainDeprtId { get; set; }

        [StringLength(6000)]
        public string DeprtDesc { get; set; }

        [StringLength(6000)]
        public string DeprtRangeFree { get; set; }

        [StringLength(6000)]
        public string DeprtRelation { get; set; }

        [StringLength(8)]
        public string CancelDate { get; set; }

        [StringLength(60)]
        public string CancelDsc { get; set; }

        [StringLength(2000)]
        public string branch_filter_spec { get; set; }

        public int? AreaId { get; set; }

        public int? Photo { get; set; }

        [StringLength(36)]
        public string PhotoX { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] RowVersion { get; set; }

        public Guid RowGuid { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmpDeprt> EmpDeprt1 { get; set; }

        public virtual EmpDeprt EmpDeprt2 { get; set; }
    }
}
