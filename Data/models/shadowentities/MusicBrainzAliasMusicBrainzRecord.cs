using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ch.wuerth.tobias.mux.Data.models.shadowentities
{
    [ Table("MusicBrainzAliasMusicBrainzRecord") ]
    public class MusicBrainzAliasMusicBrainzRecord
    {
        [ Column("MusicBrainzAlias_UniqueId") ]
        [ ForeignKey("MusicBrainzAlias_UniqueId") ]
        public Int32 MusicBrainzAliasUniqueId { get; set; }

        public virtual MusicBrainzAlias MusicBrainzAlias { get; set; }

        [ Column("MusicBrainzRecord_UniqueId") ]
        [ ForeignKey("MusicBrainzRecord_UniqueId") ]
        public Int32 MusicBrainzRecordUniqueId { get; set; }

        public virtual MusicBrainzRecord MusicBrainzRecord { get; set; }
    }
}