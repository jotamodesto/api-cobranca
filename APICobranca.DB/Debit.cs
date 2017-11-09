namespace APICobranca.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Debit")]
    public partial class Debit
    {
        [Key]
        public int IdDebit { get; set; }

        [Required]
        [StringLength(16)]
        public string CardId { get; set; }

        [Required]
        [StringLength(50)]
        public string Code { get; set; }

        public decimal Value { get; set; }

        public DateTime DebitedAt { get; set; }

        public int IdUser { get; set; }

        public virtual User User { get; set; }
    }
}
