using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ch.wuerth.tobias.mux.Data.models
{
    [ Table("PlaylistPermission") ]
    public class PlaylistPermission
    {
        [ Key ]
        public Int32 UniqueId { get; set; }

        [ Required ]
        public virtual User User { get; set; }

        [ Required ]
        public virtual Playlist Playlist { get; set; }

        [ Required ]
        public Boolean CanModify { get; set; }
    }
}