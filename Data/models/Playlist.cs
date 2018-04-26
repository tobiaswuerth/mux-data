using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ch.wuerth.tobias.mux.Data.models
{
    [ Table("Playlist") ]
    public class Playlist
    {
        [ Key ]
        public Int32 UniqueId { get; set; }

        [ Required ]
        [ MinLength(3) ]
        [ MaxLength(64) ]
        public String Name { get; set; }

        [ Required ]
        public virtual User CreateUser { get; set; }

        public virtual List<PlaylistEntry> PlaylistEntries { get; set; }

        public virtual List<PlaylistPermission> PlaylistPermissions { get; set; }
    }
}