using ch.wuerth.tobias.mux.Data.models;
using Microsoft.EntityFrameworkCore;

namespace ch.wuerth.tobias.mux.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public virtual DbSet<User> SetUsers { get; set; }
        public virtual DbSet<Track> SetTracks { get; set; }
        public virtual DbSet<AcoustId> SetAcoustIds { get; set; }
        public virtual DbSet<AcoustIdResult> SetAcoustIdResults { get; set; }
        public virtual DbSet<MusicBrainzRecord> SetMusicBrainzRecords { get; set; }
        public virtual DbSet<MusicBrainzRelease> SetReleases { get; set; }
        public virtual DbSet<MusicBrainzReleaseEvent> SetReleaseEvents { get; set; }
        public virtual DbSet<MusicBrainzAlias> SetAliases { get; set; }
        public virtual DbSet<MusicBrainzArea> SetAreas { get; set; }
        public virtual DbSet<MusicBrainzArtist> SetArtists { get; set; }
        public virtual DbSet<MusicBrainzArtistCredit> SetArtistCredits { get; set; }
        public virtual DbSet<MusicBrainzIsoCode> SetIsoCodes { get; set; }
        public virtual DbSet<MusicBrainzTag> SetTags { get; set; }
        public virtual DbSet<MusicBrainzTextRepresentation> SetTextRepresentations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // todo read connectionstring from central settings file
            optionsBuilder.UseSqlServer(@"YOUR_CONNECTIONSTRING");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasIndex(x => x.Username).IsUnique();
            modelBuilder.Entity<AcoustId>().HasIndex(x => x.Id).IsUnique();
            modelBuilder.Entity<MusicBrainzAlias>().HasIndex(x => x.UniqueHash).IsUnique();
            modelBuilder.Entity<MusicBrainzAlias>().HasIndex(x => x.Name).IsUnique(false);
            modelBuilder.Entity<MusicBrainzArtist>().HasIndex(x => x.UniqueHash).IsUnique();
            modelBuilder.Entity<MusicBrainzArtist>().HasIndex(x => x.Name).IsUnique(false);
            modelBuilder.Entity<MusicBrainzArtistCredit>().HasIndex(x => x.UniqueHash).IsUnique();
            modelBuilder.Entity<MusicBrainzArtistCredit>().HasIndex(x => x.Name).IsUnique(false);
            modelBuilder.Entity<MusicBrainzRecord>().HasIndex(x => x.MusicbrainzId).IsUnique();
            modelBuilder.Entity<MusicBrainzRecord>().HasIndex(x => x.Title).IsUnique(false);
            modelBuilder.Entity<MusicBrainzRelease>().HasIndex(x => x.UniqueHash).IsUnique();
            modelBuilder.Entity<MusicBrainzRelease>().HasIndex(x => x.Title).IsUnique(false);
            modelBuilder.Entity<MusicBrainzTag>().HasIndex(x => x.UniqueHash).IsUnique();
            modelBuilder.Entity<Track>().HasIndex(x => x.Path).IsUnique();
            modelBuilder.Entity<Track>().HasIndex(x => x.LastFingerprintCalculation).IsUnique(false);
            modelBuilder.Entity<Track>().HasIndex(x => x.FingerprintHash).IsUnique(false);
            modelBuilder.Entity<Track>().HasIndex(x => x.LastAcoustIdApiCall).IsUnique(false);
            modelBuilder.Entity<MusicBrainzTextRepresentation>().HasIndex(x => x.UniqueHash).IsUnique();
            modelBuilder.Entity<MusicBrainzReleaseEvent>().HasIndex(x => x.UniqueHash).IsUnique();
            modelBuilder.Entity<MusicBrainzIsoCode>().HasIndex(x => x.Code).IsUnique();
        }
    }
}