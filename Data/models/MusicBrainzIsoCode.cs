using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ch.wuerth.tobias.mux.Core.models;
using ch.wuerth.tobias.mux.Data.models.shadowentities;

namespace ch.wuerth.tobias.mux.Data.models
{
    [Table("MusicBrainzIsoCode")]
    public class MusicBrainzIsoCode : IMusicBrainzIsoCode
    {
        public virtual List<MusicBrainzIsoCodeMusicBrainzArea> MusicBrainzIsoCodeMusicBrainzAreas { get; set; }

        [Key]
        public Int32 UniqueId { get; set; }

        [MaxLength(3)]
        public String Code { get; set; }
    }
}