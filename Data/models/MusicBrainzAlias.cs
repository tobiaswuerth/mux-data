using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ch.wuerth.tobias.mux.Core.models;
using ch.wuerth.tobias.mux.Data.models.shadowentities;
using Newtonsoft.Json;

namespace ch.wuerth.tobias.mux.Data.models
{
    [Table("MusicBrainzAlias")]
    public class MusicBrainzAlias : IMusicBrainzAlias
    {
        [JsonIgnore]
        public virtual List<MusicBrainzAliasMusicBrainzRecord> MusicBrainzAliasMusicBrainzRecords { get; set; }

        [JsonIgnore]
        public virtual List<MusicBrainzArtistMusicBrainzAlias> MusicBrainzArtistMusicBrainzAliases { get; set; }

        [JsonIgnore]
        public virtual List<MusicBrainzReleaseMusicBrainzAlias> MusicBrainzReleaseMusicBrainzAliases { get; set; }

        [Key]
        [JsonIgnore]
        public Int32 UniqueId { get; set; }

        [Required]
        [MaxLength(128)]
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