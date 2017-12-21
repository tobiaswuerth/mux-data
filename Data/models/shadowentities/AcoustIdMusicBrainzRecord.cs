using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ch.wuerth.tobias.mux.Data.models.shadowentities
{
    [Table("MusicBrainzRecordAcoustId")]
    public class MusicBrainzRecordAcoustId
    {
        [Column("MusicBrainzRecord_UniqueId")]
        [ForeignKey("MusicBrainzRecord_UniqueId")]
        public Int32 MusicBrainzRecordUniqueId { get; set; }

        public virtual MusicBrainzRecord MusicBrainzRecord { get; set; }

        [Column("AcoustId_UniqueId")]
        [ForeignKey("AcoustId_UniqueId")]
        public Int32 AcoustIdUniqueId { get; set; }

        public virtual AcoustId AcoustId { get; set; }
    }
}