using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ch.wuerth.tobias.mux.Data.models.shadowentities
{
    [Table("MusicBrainzReleaseMusicBrainzRecord")]
    public class MusicBrainzReleaseMusicBrainzRecord
    {
        [Column("MusicBrainzRelease_UniqueId")]
        [ForeignKey("MusicBrainzRelease_UniqueId")]
        public Int32 MusicBrainzReleaseUniqueId { get; set; }

        public virtual MusicBrainzRelease MusicBrainzRelease { get; set; }

        [Column("MusicBrainzRecord_UniqueId")]
        [ForeignKey("MusicBrainzRecord_UniqueId")]
        public Int32 MusicBrainzRecordUniqueId { get; set; }

        public virtual MusicBrainzRecord MusicBrainzRecord { get; set; }
    }
}