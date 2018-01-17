using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ch.wuerth.tobias.mux.Data.models.shadowentities
{
    [ Table("MusicBrainzArtistCreditMusicBrainzRecord") ]
    public class MusicBrainzArtistCreditMusicBrainzRecord
    {
        [ Column("MusicBrainzArtistCredit_UniqueId") ]
        [ ForeignKey("MusicBrainzArtistCredit_UniqueId") ]
        public Int32 MusicBrainzArtistCreditUniqueId { get; set; }

        public virtual MusicBrainzArtistCredit MusicBrainzArtistCredit { get; set; }

        [ Column("MusicBrainzRecord_UniqueId") ]
        [ ForeignKey("MusicBrainzRecord_UniqueId") ]
        public Int32 MusicBrainzRecordUniqueId { get; set; }

        public virtual MusicBrainzRecord MusicBrainzRecord { get; set; }
    }
}