using System;
using System.IO;
using ch.wuerth.tobias.mux.Core.logging;
using ch.wuerth.tobias.mux.Data.models;
using ch.wuerth.tobias.mux.Data.models.shadowentities;
using global::ch.wuerth.tobias.mux.Core.global;
using Microsoft.EntityFrameworkCore;

namespace ch.wuerth.tobias.mux.Data
{
    public class DataContext : DbContext
    {
        private readonly DatabaseConfig _config;

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            LoggerBundle.Debug("Initializing data context...");
            try
            {
                _config = Configurator.Request<DatabaseConfig>(DatabaseSettingsFilePath);
            }
            catch (Exception ex)
            {
                LoggerBundle.Fatal("Could not load database config file", ex);
                Environment.Exit(1);
            }
            
            LoggerBundle.Debug("Context initialized.");
        }

        private static String DatabaseSettingsFilePath
        {
            get
            {
                return Path.Combine(Location.ApplicationDataDirectoryPath, "mux_config_database.json");
            }
        }

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
        public virtual DbSet<Invite> SetInvites { get; set; }

        // shadow entities
        // these had to be added because of the switch from .net 4.x to .net core 2.x. EF in this version does not
        // support many-to-many references yet without defining it explicitly
        // https://docs.microsoft.com/en-us/ef/core/modeling/relationships#many-to-many

        public virtual DbSet<MusicBrainzRecordAcoustId> SetMusicBrainzRecordAcoustId { get; set; }
        public virtual DbSet<MusicBrainzAliasMusicBrainzRecord> SetMusicBrainzAliasMusicBrainzRecord { get; set; }
        public virtual DbSet<MusicBrainzArtistCreditMusicBrainzRecord> SetMusicBrainzArtistCreditMusicBrainzRecord { get; set; }
        public virtual DbSet<MusicBrainzArtistMusicBrainzAlias> SetMusicBrainzArtistMusicBrainzAlias { get; set; }
        public virtual DbSet<MusicBrainzIsoCodeMusicBrainzArea> SetMusicBrainzIsoCodeMusicBrainzArea { get; set; }
        public virtual DbSet<MusicBrainzReleaseEventMusicBrainzRelease> SetMusicBrainzReleaseEventMusicBrainzRelease { get; set; }
        public virtual DbSet<MusicBrainzReleaseMusicBrainzAlias> SetMusicBrainzReleaseMusicBrainzAlias { get; set; }
        public virtual DbSet<MusicBrainzReleaseMusicBrainzArtistCredit> SetMusicBrainzReleaseMusicBrainzArtistCredit { get; set; }
        public virtual DbSet<MusicBrainzReleaseMusicBrainzRecord> SetMusicBrainzReleaseMusicBrainzRecord { get; set; }
        public virtual DbSet<MusicBrainzTagMusicBrainzRecord> SetMusicBrainzTagMusicBrainzRecord { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            LoggerBundle.Trace("Configuring context...");

            optionsBuilder.UseSqlServer(_config.ConnectionString);

            LoggerBundle.Trace("Context configured.");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            LoggerBundle.Trace("Creating database model...");

            base.OnModelCreating(modelBuilder);

            // join tables / cross tables
            modelBuilder.Entity<MusicBrainzRecordAcoustId>(x => { x.HasKey("MusicBrainzRecordUniqueId", "AcoustIdUniqueId"); });
            modelBuilder.Entity<MusicBrainzAliasMusicBrainzRecord>(x =>
            {
                x.HasKey("MusicBrainzAliasUniqueId", "MusicBrainzRecordUniqueId");
            });
            modelBuilder.Entity<MusicBrainzReleaseMusicBrainzAlias>(x =>
            {
                x.HasKey("MusicBrainzReleaseUniqueId", "MusicBrainzAliasUniqueId");
            });
            modelBuilder.Entity<MusicBrainzReleaseMusicBrainzArtistCredit>(x =>
            {
                x.HasKey("MusicBrainzReleaseUniqueId", "MusicBrainzArtistCreditUniqueId");
            });
            modelBuilder.Entity<MusicBrainzArtistCreditMusicBrainzRecord>(x =>
            {
                x.HasKey("MusicBrainzArtistCreditUniqueId", "MusicBrainzRecordUniqueId");
            });
            modelBuilder.Entity<MusicBrainzTagMusicBrainzRecord>(x =>
            {
                x.HasKey("MusicBrainzTagUniqueId", "MusicBrainzRecordUniqueId");
            });
            modelBuilder.Entity<MusicBrainzReleaseMusicBrainzRecord>(x =>
            {
                x.HasKey("MusicBrainzReleaseUniqueId", "MusicBrainzRecordUniqueId");
            });
            modelBuilder.Entity<MusicBrainzReleaseEventMusicBrainzRelease>(x =>
            {
                x.HasKey("MusicBrainzReleaseUniqueId", "MusicBrainzReleaseEventUniqueId");
            });
            modelBuilder.Entity<MusicBrainzArtistMusicBrainzAlias>(x =>
            {
                x.HasKey("MusicBrainzAliasUniqueId", "MusicBrainzArtistUniqueId");
            });
            modelBuilder.Entity<MusicBrainzIsoCodeMusicBrainzArea>(x =>
            {
                x.HasKey("MusicBrainzIsoCodeUniqueId", "MusicBrainzAreaUniqueId");
            });

            // index and references
            modelBuilder.Entity<User>(x => { x.HasIndex(y => y.Username).IsUnique(); });
            modelBuilder.Entity<AcoustId>(x =>
            {
                x.HasIndex(y => y.Id).IsUnique();

                x.HasMany(y => y.MusicBrainzRecordAcoustIds).WithOne(y => y.AcoustId);
                x.HasMany(y => y.AcoustIdResults).WithOne(y => y.AcoustId);
            });
            modelBuilder.Entity<MusicBrainzAlias>(x =>
            {
                x.HasIndex(y => y.UniqueHash).IsUnique();
                x.HasIndex(y => y.Name).IsUnique(false);
                x.HasIndex(y => y.UniqueHash).IsUnique();
                x.HasIndex(y => y.Name).IsUnique(false);

                x.HasMany(y => y.MusicBrainzAliasMusicBrainzRecords).WithOne(y => y.MusicBrainzAlias);
                x.HasMany(y => y.MusicBrainzReleaseMusicBrainzAliases).WithOne(y => y.MusicBrainzAlias);
                x.HasMany(y => y.MusicBrainzArtistMusicBrainzAliases).WithOne(y => y.MusicBrainzAlias);
            });
            modelBuilder.Entity<MusicBrainzArtistCredit>(x =>
            {
                x.HasIndex(y => y.UniqueHash).IsUnique();
                x.HasIndex(y => y.Name).IsUnique(false);

                x.HasMany(y => y.MusicBrainzArtistCreditMusicBrainzRecords).WithOne(y => y.MusicBrainzArtistCredit);
                x.HasMany(y => y.MusicBrainzReleaseMusicBrainzArtistCredits).WithOne(y => y.MusicBrainzArtistCredit);
            });
            modelBuilder.Entity<MusicBrainzRecord>(x =>
            {
                x.HasIndex(y => y.MusicbrainzId).IsUnique();
                x.HasIndex(y => y.Title).IsUnique(false);

                x.HasMany(y => y.MusicBrainzRecordAcoustIds).WithOne(y => y.MusicBrainzRecord);
                x.HasMany(y => y.MusicBrainzAliasMusicBrainzRecords).WithOne(y => y.MusicBrainzRecord);
                x.HasMany(y => y.MusicBrainzArtistCreditMusicBrainzRecords).WithOne(y => y.MusicBrainzRecord);
                x.HasMany(y => y.MusicBrainzReleaseMusicBrainzRecords).WithOne(y => y.MusicBrainzRecord);
                x.HasMany(y => y.MusicBrainzTagMusicBrainzRecords).WithOne(y => y.MusicBrainzRecord);
            });
            modelBuilder.Entity<MusicBrainzRelease>(x =>
            {
                x.HasIndex(y => y.UniqueHash).IsUnique();
                x.HasIndex(y => y.Title).IsUnique(false);

                x.HasMany(y => y.MusicBrainzReleaseMusicBrainzAliases).WithOne(y => y.MusicBrainzRelease);
                x.HasMany(y => y.MusicBrainzReleaseMusicBrainzArtistCredits).WithOne(y => y.MusicBrainzRelease);
                x.HasMany(y => y.MusicBrainzReleaseMusicBrainzRecords).WithOne(y => y.MusicBrainzRelease);
                x.HasMany(y => y.MusicBrainzReleaseEventMusicBrainzReleases).WithOne(y => y.MusicBrainzRelease);
            });
            modelBuilder.Entity<MusicBrainzTag>(x =>
            {
                x.HasIndex(y => y.UniqueHash).IsUnique();

                x.HasMany(y => y.MusicBrainzTagMusicBrainzRecords).WithOne(y => y.MusicBrainzTag);
            });
            modelBuilder.Entity<Track>(x =>
            {
                x.HasIndex(y => y.Path).IsUnique();
                x.HasIndex(y => y.LastFingerprintCalculation).IsUnique(false);
                x.HasIndex(y => y.FingerprintHash).IsUnique(false);
                x.HasIndex(y => y.LastAcoustIdApiCall).IsUnique(false);
            });
            modelBuilder.Entity<MusicBrainzTextRepresentation>(x => { x.HasIndex(y => y.UniqueHash).IsUnique(); });
            modelBuilder.Entity<MusicBrainzReleaseEvent>(x =>
            {
                x.HasIndex(y => y.UniqueHash).IsUnique();

                x.HasMany(y => y.MusicBrainzReleaseEventMusicBrainzReleases).WithOne(y => y.MusicBrainzReleaseEvent);
            });
            modelBuilder.Entity<MusicBrainzIsoCode>(x =>
            {
                x.HasIndex(y => y.Code).IsUnique();

                x.HasMany(y => y.MusicBrainzIsoCodeMusicBrainzAreas).WithOne(y => y.MusicBrainzIsoCode);
            });
            modelBuilder.Entity<MusicBrainzArea>(x =>
            {
                x.HasMany(y => y.MusicBrainzIsoCodeMusicBrainzAreas).WithOne(y => y.MusicBrainzArea);
                x.HasMany(y => y.ReleaseEvents).WithOne(y => y.Area);
            });
            modelBuilder.Entity<MusicBrainzArtist>(x =>
            {
                x.HasMany(y => y.MusicBrainzArtistMusicBrainzAliases).WithOne(y => y.MusicBrainzArtist);
                x.HasMany(y => y.Credits);
            });
            modelBuilder.Entity<Invite>(x =>
            {
                x.HasOne(y => y.CreateUser).WithMany(y => y.Invites);
                x.HasOne(y => y.RegisteredUser).WithOne(y => y.Invite).IsRequired(false);
            });

            LoggerBundle.Trace("Model created.");
        }
    }
}