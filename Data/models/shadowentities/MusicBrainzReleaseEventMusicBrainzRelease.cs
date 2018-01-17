using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ch.wuerth.tobias.mux.Data.models.shadowentities
{
    [ Table("MusicBrainzReleaseEventMusicBrainzRelease") ]
    public class MusicBrainzReleaseEventMusicBrainzRelease
    {
        [ Column("MusicBrainzRelease_UniqueId") ]
        [ ForeignKey("MusicBrainzRelease_UniqueId") ]
        public Int32 MusicBrainzReleaseUniqueId { get; set; }

        public virtual MusicBrainzRelease MusicBrainzRelease { get; set; }

        [ Column("MusicBrainzReleaseEvent_UniqueId") ]
        [ ForeignKey("MusicBrainzReleaseEvent_UniqueId") ]
        public Int32 MusicBrainzReleaseEventUniqueId { get; set; }

        public virtual MusicBrainzReleaseEvent MusicBrainzReleaseEvent { get; set; }
    }
}