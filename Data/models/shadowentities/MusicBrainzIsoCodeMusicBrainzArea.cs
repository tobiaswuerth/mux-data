using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ch.wuerth.tobias.mux.Data.models.shadowentities
{
    [ Table("MusicBrainzIsoCodeMusicBrainzArea") ]
    public class MusicBrainzIsoCodeMusicBrainzArea
    {
        [ Column("MusicBrainzIsoCode_UniqueId") ]
        [ ForeignKey("MusicBrainzIsoCode_UniqueId") ]
        public Int32 MusicBrainzIsoCodeUniqueId { get; set; }

        public virtual MusicBrainzIsoCode MusicBrainzIsoCode { get; set; }

        [ Column("MusicBrainzArea_UniqueId") ]
        [ ForeignKey("MusicBrainzArea_UniqueId") ]
        public Int32 MusicBrainzAreaUniqueId { get; set; }

        public virtual MusicBrainzArea MusicBrainzArea { get; set; }
    }
}