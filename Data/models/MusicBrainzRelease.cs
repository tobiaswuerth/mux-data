using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ch.wuerth.tobias.mux.Data.models.shadowentities;
using Newtonsoft.Json;

namespace ch.wuerth.tobias.mux.Data.models
{
    [ Table("MusicBrainzRelease") ]
    public class MusicBrainzRelease
    {
        [ JsonIgnore ]
        public virtual List<MusicBrainzReleaseMusicBrainzAlias> MusicBrainzReleaseMusicBrainzAliases { get; set; }

        [ JsonIgnore ]
        public virtual List<MusicBrainzReleaseEventMusicBrainzRelease> MusicBrainzReleaseEventMusicBrainzReleases { get; set; }

        [ JsonIgnore ]
        public virtual List<MusicBrainzReleaseMusicBrainzArtistCredit> MusicBrainzReleaseMusicBrainzArtistCredits { get; set; }

        [ JsonIgnore ]
        [ ForeignKey("TextRepresentation_UniqueId") ]
        public virtual MusicBrainzTextRepresentation TextRepresentation { get; set; }

        [ JsonIgnore ]
        public virtual List<MusicBrainzReleaseMusicBrainzRecord> MusicBrainzReleaseMusicBrainzRecords { get; set; }

        [ Key ]
        [ JsonIgnore ]
        public Int32 UniqueId { get; set; }

        [ Required ]
        [ MaxLength(128) ]
        [ JsonIgnore ]
        public String UniqueHash { get; set; }

        [ MaxLength(1024) ]
        [ JsonProperty ]
        public String Title { get; set; }

        [ MaxLength(1024) ]
        [ JsonProperty ]
        public String Status { get; set; }

        [ MaxLength(1024) ]
        [ JsonProperty ]
        public String Quality { get; set; }

        [ MaxLength(1024) ]
        [ JsonProperty ]
        public String Country { get; set; }

        [ JsonProperty ]
        public DateTime? Date { get; set; }

        [ MaxLength(1024) ]
        [ JsonProperty ]
        public String Disambiguation { get; set; }

        [ MaxLength(1024) ]
        [ JsonProperty ]
        public String StatusId { get; set; }

        [ MaxLength(1024) ]
        [ JsonProperty ]
        public String Id { get; set; }

        [ MaxLength(1024) ]
        [ JsonProperty ]
        public String PackagingId { get; set; }

        [ MaxLength(1024) ]
        [ JsonProperty ]
        public String Barcode { get; set; }
    }
}