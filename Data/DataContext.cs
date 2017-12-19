using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using ch.wuerth.tobias.mux.Core.exceptions;
using ch.wuerth.tobias.mux.Core.io;
using ch.wuerth.tobias.mux.Core.logging;
using ch.wuerth.tobias.mux.Data.models;
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

            // index
            modelBuilder.Entity<User>(x => { x.HasIndex(y => y.Username).IsUnique(); });
            modelBuilder.Entity<AcoustId>(x =>
            {
                x.HasIndex(y => y.Id).IsUnique();
                x.HasMany(y => y.MusicbrainzRecords);
            });
            modelBuilder.Entity<MusicBrainzAlias>(x =>
            {
                x.HasIndex(y => y.UniqueHash).IsUnique();
                x.HasIndex(y => y.Name).IsUnique(false);
                x.HasIndex(y => y.UniqueHash).IsUnique();
                x.HasIndex(y => y.Name).IsUnique(false);
                x.HasMany(y => y.Records);
                x.HasMany(y => y.Releases);
                x.HasMany(y => y.Artists);
            });
            modelBuilder.Entity<MusicBrainzArtistCredit>(x =>
            {
                x.HasIndex(y => y.UniqueHash).IsUnique();
                x.HasIndex(y => y.Name).IsUnique(false);
                x.HasMany(y => y.Records);
                x.HasMany(y => y.Releases);
            });
            modelBuilder.Entity<MusicBrainzRecord>(x =>
            {
                x.HasIndex(y => y.MusicbrainzId).IsUnique();
                x.HasIndex(y => y.Title).IsUnique(false);
                x.HasMany(y => y.AcoustIds);
                x.HasMany(y => y.Aliases);
                x.HasMany(y => y.ArtistCredit);
                x.HasMany(y => y.Releases);
                x.HasMany(y => y.Tags);
            });
            modelBuilder.Entity<MusicBrainzRelease>(x =>
            {
                x.HasIndex(y => y.UniqueHash).IsUnique();
                x.HasIndex(y => y.Title).IsUnique(false);
                x.HasMany(y => y.Aliases);
                x.HasMany(y => y.ArtistCredit);
                x.HasMany(y => y.MusicBrainzRecords);
                x.HasMany(y => y.ReleaseEvents);
            });
            modelBuilder.Entity<MusicBrainzTag>(x =>
            {
                x.HasIndex(y => y.UniqueHash).IsUnique();
                x.HasMany(y => y.Records);
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
                x.HasMany(y => y.Releases);
                x.HasOne(y => y.Area).WithMany(y => y.ReleaseEvents);
            });
            modelBuilder.Entity<MusicBrainzIsoCode>(x =>
            {
                x.HasIndex(y => y.Code).IsUnique();
                x.HasMany(y => y.Areas);
            });
            modelBuilder.Entity<MusicBrainzArea>(x =>
            {
                x.HasMany(y => y.Iso31661Codes);
                x.HasMany(y => y.ReleaseEvents);
            });
            modelBuilder.Entity<MusicBrainzArtist>(x =>
            {
                x.HasMany(y => y.Aliases);
                x.HasMany(y => y.Credits);

            });

            _logger?.Information?.Log("Model created.");
        }
    }
}