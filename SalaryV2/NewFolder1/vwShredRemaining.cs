namespace SalaryV2.NewFolder1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GNR.vwShredRemaining")]
    public partial class vwShredRemaining
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ShredID { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime Date { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Number { get; set; }

        public decimal? InterestPenaltyTotalAmount { get; set; }

        public decimal? InterestPenaltyRemainingAmount { get; set; }

        public decimal? InterestPenaltyTotalReceivedAmount { get; set; }

        [Key]
        [Column(Order = 3)]
        public decimal ShredTotalAmount { get; set; }

        [Key]
        [Column(Order = 4)]
        public decimal ShredTotalReceivedAmount { get; set; }

        public decimal? ShredRemainingAmount { get; set; }
    }
}
