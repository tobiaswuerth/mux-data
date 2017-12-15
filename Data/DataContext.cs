using System;
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
                _logger?.Information?.Log("Please edit the file and adjust as needed before restarting the application.");
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
            get { return Path.Combine(Location.ApplicationDataDirectoryPath, @"\mux_config_database.json"); }
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

            _logger?.Information?.Log("Model created.");
        }
    }
}