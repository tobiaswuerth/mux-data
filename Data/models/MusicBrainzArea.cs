using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ch.wuerth.tobias.mux.Core.models;
using ch.wuerth.tobias.mux.Data.models.shadowentities;
using Newtonsoft.Json;

namespace ch.wuerth.tobias.mux.Data.models
{
    [Table("MusicBrainzArea")]
    public class MusicBrainzArea : IMusicBrainzArea
    {
        [JsonIgnore]
        public virtual List<MusicBrainzIsoCodeMusicBrainzArea> MusicBrainzIsoCodeMusicBrainzAreas { get; set; }

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