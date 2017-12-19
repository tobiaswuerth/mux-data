using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ch.wuerth.tobias.mux.Data.models
{
    [Table("User")]
    public class User
    {
        [Key]
        public Int32 UniqueId { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(32)]
        public String Username { get; set; }

        [Required]
        [MaxLength(1024)]
        public String Password { get; set; }
    }
}