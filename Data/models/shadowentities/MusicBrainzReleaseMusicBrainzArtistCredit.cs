using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ch.wuerth.tobias.mux.Data.models.shadowentities
{
    [Table("MusicBrainzReleaseMusicBrainzArtistCredit")]
    public class MusicBrainzReleaseMusicBrainzArtistCredit
    {
        [Column("MusicBrainzRelease_UniqueId")]
        [ForeignKey("MusicBrainzRelease_UniqueId")]
        public Int32 MusicBrainzReleaseUniqueId { get; set; }

        public virtual MusicBrainzRelease MusicBrainzRelease { get; set; }

        [Column("MusicBrainzArtistCredit_UniqueId")]
        [ForeignKey("MusicBrainzArtistCredit_UniqueId")]
        public Int32 MusicBrainzArtistCreditUniqueId { get; set; }

        public virtual MusicBrainzArtistCredit MusicBrainzArtistCredit { get; set; }
    }
}