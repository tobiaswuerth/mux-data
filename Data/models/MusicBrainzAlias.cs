using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ch.wuerth.tobias.mux.Core.models;
using Newtonsoft.Json;

namespace ch.wuerth.tobias.mux.Data.models
{
    public class MusicBrainzAlias : IMusicBrainzAlias
    {
        [JsonIgnore]
        public virtual List<MusicBrainzRecord> Records { get; set; }

        [JsonIgnore]
        public virtual List<MusicBrainzArtist> Artists { get; set; }

        [JsonIgnore]
        public virtual List<MusicBrainzRelease> Releases { get; set; }

        [Key]
        [JsonIgnore]
        public Int32 UniqueId { get; set; }

        [Required]
        [MaxLength(128)]
        // todo index unique true
        [JsonIgnore]
        public String UniqueHash { get; set; }

        [MaxLength(1024)]
        [JsonProperty]
        public String Begin { get; set; }

        [MaxLength(1024)]
        [JsonProperty]
        public String Locale { get; set; }

        [MaxLength(1024)]
        [JsonProperty]
        public String TypeId { get; set; }

        [MaxLength(1024)]
        [JsonProperty]
        public String End { get; set; }

        [MaxLength(1024)]
        // todo index unique false
        [JsonProperty]
        public String Name { get; set; }

        [MaxLength(1024)]
        [JsonProperty]
        public String Type { get; set; }

        [MaxLength(1024)]
        [JsonProperty]
        public String ShortName { get; set; }

        [MaxLength(1024)]
        [JsonProperty]
        public String Primary { get; set; }

        [JsonProperty]
        public Boolean Ended { get; set; }
    }
}