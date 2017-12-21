using System;
using System.IO;
using ch.wuerth.tobias.mux.Core.exceptions;
using ch.wuerth.tobias.mux.Core.io;
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
        private readonly LoggerBundle _logger;

        public DataContext(DbContextOptions<DataContext> options, LoggerBundle logger = null) : base(options)
        {
            _logger = logger;

            _logger?.Information?.Log("Initializing data context...");

            if (!File.Exists(DatabaseSettingsFilePath))
            {
                _logger?.Information?.Log($"File '{DatabaseSettingsFilePath}' not found. Trying to create it...");
                Boolean save = FileInterface.Save(new DatabaseConfig(), DatabaseSettingsFilePath, true, _logger);
                if (!save)
                {
                    throw new ProcessAbortedException();
                }

                _logger?.Information?.Log($"File '{DatabaseSettingsFilePath}' successfully created.");
                _logger?.Information?.Log(
                    "Please edit the file and adjust as needed before restarting the application.");
                throw new ProcessAbortedException();
            }

            _logger?.Information?.Log($"Loading database config from '{DatabaseSettingsFilePath}'...");

            (DatabaseConfig output, Boolean success) res = FileInterface.Read<DatabaseConfig>(DatabaseSettingsFilePath);
            if (!res.success)
            {
                throw new ProcessAbortedException();
            }

            _config = res.output;
            _logger?.Information?.Log("Context initialized.");
        }

        private static String DatabaseSettingsFilePath
        {
            get { return Path.Combine(Location.ApplicationDataDirectoryPath, "mux_config_database.json"); }
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

        // shadow entities
        public virtual DbSet<MusicBrainzRecordAcoustId> SetMusicBrainzRecordAcoustId { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            _logger?.Information?.Log("Configuring context...");

            optionsBuilder.UseSqlServer(_config.ConnectionString);

            _logger?.Information?.Log("Context configured.");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _logger?.Information?.Log("Creating database model...");

            base.OnModelCreating(modelBuilder);

            // join tables / cross tables
            modelBuilder.Entity<MusicBrainzRecordAcoustId>(x =>
            {
                x.HasKey("MusicBrainzRecordUniqueId", "AcoustIdUniqueId");
            });
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

            _logger?.Information?.Log("Model created.");
        }
    }
}