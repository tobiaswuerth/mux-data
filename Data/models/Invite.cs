using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ch.wuerth.tobias.mux.Data.models
{
    [ Table("Invite") ]
    public class Invite
    {
        [ Key ]
        public Int32 UniqueId { get; set; }

        [ Required ]
        [ MinLength(16) ]
        [ MaxLength(16) ]
        public String Token { get; set; }

        [ Required ]
        public virtual User CreateUser { get; set; }

        [ Required ]
        public DateTime CreateDate { get; set; }

        [ Required ]
        public DateTime ExpirationDate { get; set; }

        public virtual User RegisteredUser { get; set; }
    }
}