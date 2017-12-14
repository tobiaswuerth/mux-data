using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ch.wuerth.tobias.mux.Core.models;
using Newtonsoft.Json;

namespace ch.wuerth.tobias.mux.Data.models
{
    public class MusicBrainzRelease : IMusicBrainzRelease
    {
        [JsonIgnore]
        public virtual List<MusicBrainzAlias> Aliases { get; set; }

        [JsonIgnore]
        public virtual List<MusicBrainzReleaseEvent> ReleaseEvents { get; set; }

        [JsonIgnore]
        public virtual List<MusicBrainzArtistCredit> ArtistCredit { get; set; }

        [JsonIgnore]
        public virtual MusicBrainzTextRepresentation TextRepresentation { get; set; }

        [JsonIgnore]
        public virtual List<MusicBrainzRecord> MusicBrainzRecords { get; set; }

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
        public String Title { get; set; }

        [MaxLength(1024)]
        [JsonProperty]
        public String Status { get; set; }

        [MaxLength(1024)]
        [JsonProperty]
        public String Quality { get; set; }

        [MaxLength(1024)]
        [JsonProperty]
        public String Country { get; set; }

        [JsonProperty]
        public DateTime? Date { get; set; }

        [MaxLength(1024)]
        [JsonProperty]
        public String Disambiguation { get; set; }

        [MaxLength(1024)]
        [JsonProperty]
        public String StatusId { get; set; }

        [MaxLength(1024)]
        [JsonProperty]
        public String Id { get; set; }

        [MaxLength(1024)]
        [JsonProperty]
        public String PackagingId { get; set; }

        [MaxLength(1024)]
        [JsonProperty]
        public String Barcode { get; set; }
    }
}