using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ch.wuerth.tobias.mux.Data.models
{
    [Table("Track")]
    public class Track
    {
        public virtual List<AcoustIdResult> AcoustIdResults { get; set; }

        [Key]
        public Int32 UniqueId { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(2048)]
        public String Path { get; set; }

        public DateTime? LastFingerprintCalculation { get; set; }

        public String FingerprintError { get; set; }

        public Double? Duration { get; set; }
        public String Fingerprint { get; set; }

        [MaxLength(128)]
        public String FingerprintHash { get; set; }

        public DateTime? LastAcoustIdApiCall { get; set; }

        public override String ToString()
        {
            return $"Track '{Path}'";
        }
    }
}