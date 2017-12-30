using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace ch.wuerth.tobias.mux.Data.models
{
    [Table("MusicBrainzTextRepresentation")]
    public class MusicBrainzTextRepresentation
    {
        [JsonIgnore]
        public virtual List<MusicBrainzRelease> Releases { get; set; }

        [Key]
        [JsonIgnore]
        public Int32 UniqueId { get; set; }

        [Required]
        [MaxLength(128)]
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