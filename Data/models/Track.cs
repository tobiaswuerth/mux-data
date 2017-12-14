using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ch.wuerth.tobias.mux.Core.models;

namespace ch.wuerth.tobias.mux.Data.models
{
    public class Track : ITrack
    {
        public virtual List<AcoustIdResult> AcoustIdResults { get; set; }

        [Key]
        public Int32 UniqueId { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(2048)]
        // todo index unique true
        public String Path { get; set; }

        // todo index unique false
        public DateTime? LastFingerprintCalculation { get; set; }

        public String FingerprintError { get; set; }

        public Double? Duration { get; set; }
        public String Fingerprint { get; set; }

        [MaxLength(128)]
        // todo index unique false
        public String FingerprintHash { get; set; }

        // todo index unique false
        public DateTime? LastAcoustIdApiCall { get; set; }

        public override String ToString()
        {
            return $"Track '{Path}'";
        }
    }
}