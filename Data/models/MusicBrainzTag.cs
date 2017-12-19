using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ch.wuerth.tobias.mux.Core.models;
using Newtonsoft.Json;

namespace ch.wuerth.tobias.mux.Data.models
{
    [Table("MusicBrainzTag")]
    public class MusicBrainzTag : IMusicBrainzTag
    {
        [JsonIgnore]
        public virtual List<MusicBrainzRecord> Records { get; set; }

        [Key]
        [JsonIgnore]
        public Int32 UniqueId { get; set; }

        [Required]
        [MaxLength(128)]
        [JsonIgnore]
        public String UniqueHash { get; set; }

        [MaxLength(4096)]
        [JsonProperty]
        public String Name { get; set; }

        [JsonProperty]
        public Int32 Count { get; set; }
    }
}