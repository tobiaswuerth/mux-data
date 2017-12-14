using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ch.wuerth.tobias.mux.Core.models;

namespace ch.wuerth.tobias.mux.Data.models
{
    public class MusicBrainzRecord : IMusicBrainzRecord
    {
        public virtual List<AcoustId> AcoustIds { get; set; }
        public virtual List<MusicBrainzRelease> Releases { get; set; }
        public virtual List<MusicBrainzAlias> Aliases { get; set; }
        public virtual List<MusicBrainzTag> Tags { get; set; }
        public virtual List<MusicBrainzArtistCredit> ArtistCredit { get; set; }

        [Key]
        public Int32 UniqueId { get; set; }

        [Required]
        [MaxLength(40)]
        public String MusicbrainzId { get; set; }

        [MaxLength(255)]
        public String Title { get; set; }

        [MaxLength(4096)]
        public String Disambiguation { get; set; }

        public DateTime? LastMusicBrainzApiCall { get; set; }
        public String MusicBrainzApiCallError { get; set; }

        public Int32? Length { get; set; }
        public Boolean? Video { get; set; }

        public override String ToString()
        {
            return $"MusicBrainzRecord '{MusicbrainzId}'";
        }
    }
}