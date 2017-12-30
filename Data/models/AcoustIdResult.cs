using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ch.wuerth.tobias.mux.Data.models
{
    [Table("AcoustIdResult")]
    public class AcoustIdResult
    {
        [Required]
        [ForeignKey("AcoustId_UniqueId")]
        public virtual AcoustId AcoustId { get; set; }

        [Required]
        [ForeignKey("Track_UniqueId")]
        public virtual Track Track { get; set; }

        [Key]
        public Int32 UniqueId { get; set; }

        [Required]
        public Double Score { get; set; }
    }
}