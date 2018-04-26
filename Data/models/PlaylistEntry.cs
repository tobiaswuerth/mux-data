using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ch.wuerth.tobias.mux.Data.models
{
    [ Table("PlaylistEntry") ]
    public class PlaylistEntry
    {
        [ Key ]
        public Int32 UniqueId { get; set; }

        [ Required ]
        [ MaxLength(1024) ]
        public String Title { get; set; }

        [ Required ]
        public virtual User CreateUser { get; set; }

        [ Required ]
        public virtual Playlist Playlist { get; set; }

        [ Required ]
        public virtual Track Track { get; set; }
    }
}