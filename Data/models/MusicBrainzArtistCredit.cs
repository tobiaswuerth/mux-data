using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ch.wuerth.tobias.mux.Data.models.shadowentities;
using Newtonsoft.Json;

namespace ch.wuerth.tobias.mux.Data.models
{
    [ Table("MusicBrainzArtistCredit") ]
    public class MusicBrainzArtistCredit
    {
        [ Required ]
        [ JsonIgnore ]
        [ ForeignKey("Artist_UniqueId") ]
        public virtual MusicBrainzArtist Artist { get; set; }

        [ JsonIgnore ]
        public virtual List<MusicBrainzReleaseMusicBrainzArtistCredit> MusicBrainzReleaseMusicBrainzArtistCredits { get; set; }

        [ JsonIgnore ]
        public virtual List<MusicBrainzArtistCreditMusicBrainzRecord> MusicBrainzArtistCreditMusicBrainzRecords { get; set; }

        [ Key ]
        [ JsonIgnore ]
        public Int32 UniqueId { get; set; }

        [ Required ]
        [ MaxLength(128) ]
        [ JsonIgnore ]
        public String UniqueHash { get; set; }

        [ MaxLength(1024) ]
        [ JsonProperty ]
        public String Name { get; set; }

        [ MaxLength(4096) ]
        [ JsonProperty ]
        public String Joinphrase { get; set; }
    }
}