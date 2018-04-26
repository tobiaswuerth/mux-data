using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ch.wuerth.tobias.mux.Data.models
{
    [ Table("User") ]
    public class User
    {
        [ Key ]
        public Int32 UniqueId { get; set; }

        [ Required ]
        [ MinLength(3) ]
        [ MaxLength(32) ]
        public String Username { get; set; }

        [ Required ]
        [ MaxLength(1024) ]
        public String Password { get; set; }

        [ Required ]
        public Boolean CanInvite { get; set; }

        public virtual Invite Invite { get; set; }

        public virtual List<Invite> Invites { get; set; }

        public virtual List<Playlist> Playlists { get; set; }

        public virtual List<PlaylistPermission> PlaylistPermissions { get; set; }

        public virtual List<PlaylistEntry> PlaylistEntries { get; set; }
    }
}