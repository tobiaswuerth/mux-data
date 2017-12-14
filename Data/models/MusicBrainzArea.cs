using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ch.wuerth.tobias.mux.Core.models;
using Newtonsoft.Json;

namespace ch.wuerth.tobias.mux.Data.models
{
    public class MusicBrainzArea : IMusicBrainzArea
    {
        [JsonIgnore]
        public virtual List<MusicBrainzIsoCode> Iso31661Codes { get; set; }

        [JsonIgnore]
        public virtual List<MusicBrainzReleaseEvent> ReleaseEvents { get; set; }

        [Key]
        [JsonIgnore]
        public Int32 UniqueId { get; set; }

        [MaxLength(1024)]
        [JsonProperty]
        public String Id { get; set; }

        [MaxLength(1024)]
        [JsonProperty]
        public String Name { get; set; }

        [MaxLength(4096)]
        [JsonProperty]
        public String Disambiguation { get; set; }

        [MaxLength(1024)]
        [JsonProperty]
        public String SortName { get; set; }
    }
}