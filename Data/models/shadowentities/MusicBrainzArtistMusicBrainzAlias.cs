using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ch.wuerth.tobias.mux.Data.models.shadowentities
{
    [ Table("MusicBrainzArtistMusicBrainzAlias") ]
    public class MusicBrainzArtistMusicBrainzAlias
    {
        [ Column("MusicBrainzAlias_UniqueId") ]
        [ ForeignKey("MusicBrainzAlias_UniqueId") ]
        public Int32 MusicBrainzAliasUniqueId { get; set; }

        public virtual MusicBrainzAlias MusicBrainzAlias { get; set; }

        [ Column("MusicBrainzArtist_UniqueId") ]
        [ ForeignKey("MusicBrainzArtist_UniqueId") ]
        public Int32 MusicBrainzArtistUniqueId { get; set; }

        public virtual MusicBrainzArtist MusicBrainzArtist { get; set; }
    }
}