using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ch.wuerth.tobias.mux.Core.models;
using Newtonsoft.Json;

namespace ch.wuerth.tobias.mux.Data.models
{
    public class MusicBrainzArtist : IMusicBrainzArtist
    {
        [JsonIgnore]
        public virtual List<MusicBrainzAlias> Aliases { get; set; }

        [JsonIgnore]
        public virtual List<MusicBrainzArtistCredit> Credits { get; set; }

        [Key]
        [JsonIgnore]
        public Int32 UniqueId { get; set; }

        [Required]
        [MaxLength(128)]
        [JsonIgnore]
        public String UniqueHash { get; set; }

        [MaxLength(1024)]
        [JsonProperty]
        public String Name { get; set; }

        [MaxLength(1024)]
        [JsonProperty]
        public String SortName { set; get; }

        [MaxLength(4096)]
        [JsonProperty]
        public String Disambiguation { get; set; }
    }
}