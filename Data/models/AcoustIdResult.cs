using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ch.wuerth.tobias.mux.Core.models;

namespace ch.wuerth.tobias.mux.Data.models
{
    [Table("AcoustIdResult")]
    public class AcoustIdResult : IAcoustIdResult
    {
        [Required]
        public virtual AcoustId AcoustId { get; set; }

        [Required]
        public virtual Track Track { get; set; }

        [Key]
        public Int32 UniqueId { get; set; }

        [Required]
        public Double Score { get; set; }
    }
}