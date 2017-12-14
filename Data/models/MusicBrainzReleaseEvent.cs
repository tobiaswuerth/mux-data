using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ch.wuerth.tobias.mux.Core.models;
using Newtonsoft.Json;

namespace ch.wuerth.tobias.mux.Data.models
{
    public class MusicBrainzReleaseEvent : IMusicBrainzReleaseEvent
    {
        [JsonProperty]
        public virtual MusicBrainzArea Area { get; set; }

        [JsonIgnore]
        public virtual List<MusicBrainzRelease> Releases { get; set; }

        [Key]
        [JsonIgnore]
        public Int32 UniqueId { get; set; }

        [Required]
        [MaxLength(128)]
        [JsonIgnore]
        public String UniqueHash { get; set; }

        [JsonProperty]
        public DateTime? Date { get; set; }
    }
}