using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ch.wuerth.tobias.mux.Core.models;
using Newtonsoft.Json;

namespace ch.wuerth.tobias.mux.Data.models
{
    public class MusicBrainzTextRepresentation : IMusicBrainzTextRepresentation
    {
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
        public String Script { get; set; }

        [MaxLength(1024)]
        [JsonProperty]
        public String Language { get; set; }
    }
}