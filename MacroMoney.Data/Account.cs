namespace MacroMoney.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Account")]
    public partial class Account
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(100)]
        public string AccountType { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Column(TypeName = "money")]
        public decimal StartingBalance { get; set; }

        public Guid UserId { get; set; }
    }
}
