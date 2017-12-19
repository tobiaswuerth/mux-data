using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ch.wuerth.tobias.mux.Core.models;

namespace ch.wuerth.tobias.mux.Data.models
{
    [Table("AcoustId")]
    public class AcoustId : IAcoustId
    {
        public virtual List<AcoustIdResult> AcoustIdResults { get; set; }
        public virtual List<MusicBrainzRecord> MusicbrainzRecords { get; set; }

        [Key]
        public Int32 UniqueId { get; set; }

        [Required]
        [MaxLength(40)]
        public String Id { get; set; }
    }
}