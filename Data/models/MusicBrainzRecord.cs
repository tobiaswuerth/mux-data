using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ch.wuerth.tobias.mux.Data.models.shadowentities;

namespace ch.wuerth.tobias.mux.Data.models
{
    [Table("MusicBrainzRecord")]
    public class MusicBrainzRecord
    {
        public virtual List<MusicBrainzRecordAcoustId> MusicBrainzRecordAcoustIds { get; set; }
        public virtual List<MusicBrainzReleaseMusicBrainzRecord> MusicBrainzReleaseMusicBrainzRecords { get; set; }
        public virtual List<MusicBrainzAliasMusicBrainzRecord> MusicBrainzAliasMusicBrainzRecords { get; set; }
        public virtual List<MusicBrainzTagMusicBrainzRecord> MusicBrainzTagMusicBrainzRecords { get; set; }

        public virtual List<MusicBrainzArtistCreditMusicBrainzRecord> MusicBrainzArtistCreditMusicBrainzRecords
        {
            get;
            set;
        }

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