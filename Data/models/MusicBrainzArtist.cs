using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ch.wuerth.tobias.mux.Data.models.shadowentities;
using Newtonsoft.Json;

namespace ch.wuerth.tobias.mux.Data.models
{
    [ Table("MusicBrainzArtist") ]
    public class MusicBrainzArtist
    {
        [ JsonIgnore ]
        public virtual List<MusicBrainzArtistMusicBrainzAlias> MusicBrainzArtistMusicBrainzAliases { get; set; }

        [ JsonIgnore ]
        public virtual List<MusicBrainzArtistCredit> Credits { get; set; }

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

        [ MaxLength(1024) ]
        [ JsonProperty ]
        public String SortName { set; get; }

        [ MaxLength(4096) ]
        [ JsonProperty ]
        public String Disambiguation { get; set; }
    }
}