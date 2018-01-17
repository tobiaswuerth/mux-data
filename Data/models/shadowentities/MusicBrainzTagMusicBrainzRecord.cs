using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ch.wuerth.tobias.mux.Data.models.shadowentities
{
    [ Table("MusicBrainzTagMusicBrainzRecord") ]
    public class MusicBrainzTagMusicBrainzRecord
    {
        [ Column("MusicBrainzTag_UniqueId") ]
        [ ForeignKey("MusicBrainzTag_UniqueId") ]
        public Int32 MusicBrainzTagUniqueId { get; set; }

        public virtual MusicBrainzTag MusicBrainzTag { get; set; }

        [ Column("MusicBrainzRecord_UniqueId") ]
        [ ForeignKey("MusicBrainzRecord_UniqueId") ]
        public Int32 MusicBrainzRecordUniqueId { get; set; }

        public virtual MusicBrainzRecord MusicBrainzRecord { get; set; }
    }
}