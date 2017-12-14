using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ch.wuerth.tobias.mux.Core.models;

namespace ch.wuerth.tobias.mux.Data.models
{
    public class AcoustId : IAcoustId
    {
        public virtual IList<AcoustIdResult> AcoustIdResults { get; set; }
        public virtual IList<MusicBrainzRecord> MusicbrainzRecords { get; set; }

        [Key]
        public Int32 UniqueId { get; set; }

        [Required]
        [MaxLength(40)]
        // todo index unique true
        public String Id { get; set; }
    }
}