using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ch.wuerth.tobias.mux.Core.models;
using Newtonsoft.Json;

namespace ch.wuerth.tobias.mux.Data.models
{
    public class MusicBrainzArtistCredit : IMusicBrainzArtistCredit
    {
        [Required]
        [JsonIgnore]
        public virtual MusicBrainzArtist Artist { get; set; }

        [JsonIgnore]
        public virtual List<MusicBrainzRelease> Releases { get; set; }

        [JsonIgnore]
        public virtual List<MusicBrainzRecord> Records { get; set; }

        [Key]
        [JsonIgnore]
        public Int32 UniqueId { get; set; }

        [Required]
        [MaxLength(128)]
        // todo index unique true
        [JsonIgnore]
        public String UniqueHash { get; set; }

        [MaxLength(1024)]
        // todo index unique false
        [JsonProperty]
        public String Name { get; set; }

        [MaxLength(4096)]
        [JsonProperty]
        public String Joinphrase { get; set; }
    }
}