using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ch.wuerth.tobias.mux.Data.models.shadowentities;
using Newtonsoft.Json;

namespace ch.wuerth.tobias.mux.Data.models
{
    [ Table("MusicBrainzReleaseEvent") ]
    public class MusicBrainzReleaseEvent
    {
        [ JsonProperty ]
        [ ForeignKey("Area_UniqueId") ]
        public virtual MusicBrainzArea Area { get; set; }

        [ JsonIgnore ]
        public virtual List<MusicBrainzReleaseEventMusicBrainzRelease> MusicBrainzReleaseEventMusicBrainzReleases { get; set; }

        [ Key ]
        [ JsonIgnore ]
        public Int32 UniqueId { get; set; }

        [ Required ]
        [ MaxLength(128) ]
        [ JsonIgnore ]
        public String UniqueHash { get; set; }

        [ JsonProperty ]
        public DateTime? Date { get; set; }
    }
}