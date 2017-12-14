using System;
using System.ComponentModel.DataAnnotations;

namespace ch.wuerth.tobias.mux.Data.models
{
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