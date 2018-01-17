using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ch.wuerth.tobias.mux.Data.models.shadowentities
{
    [ Table("MusicBrainzReleaseMusicBrainzAlias") ]
    public class MusicBrainzReleaseMusicBrainzAlias
    {
        [ Column("MusicBrainzRelease_UniqueId") ]
        [ ForeignKey("MusicBrainzRelease_UniqueId") ]
        public Int32 MusicBrainzReleaseUniqueId { get; set; }

        public virtual MusicBrainzRelease MusicBrainzRelease { get; set; }

        [ Column("MusicBrainzAlias_UniqueId") ]
        [ ForeignKey("MusicBrainzAlias_UniqueId") ]
        public Int32 MusicBrainzAliasUniqueId { get; set; }

        public virtual MusicBrainzAlias MusicBrainzAlias { get; set; }
    }
}