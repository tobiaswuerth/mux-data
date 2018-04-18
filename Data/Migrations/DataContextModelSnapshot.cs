﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ch.wuerth.tobias.mux.Data.Migrations
{
    [ DbContext(typeof(DataContext)) ]
    internal class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ch.wuerth.tobias.mux.Data.models.AcoustId"
                , b =>
                {
                    b.Property<Int32>("UniqueId").ValueGeneratedOnAdd();

                    b.Property<String>("Id").IsRequired().HasMaxLength(40);

                    b.HasKey("UniqueId");

                    b.HasIndex("Id").IsUnique();

                    b.ToTable("AcoustId");
                });

            modelBuilder.Entity("ch.wuerth.tobias.mux.Data.models.AcoustIdResult"
                , b =>
                {
                    b.Property<Int32>("UniqueId").ValueGeneratedOnAdd();

                    b.Property<Int32?>("AcoustId_UniqueId").IsRequired();

                    b.Property<Double>("Score");

                    b.Property<Int32?>("Track_UniqueId").IsRequired();

                    b.HasKey("UniqueId");

                    b.HasIndex("AcoustId_UniqueId");

                    b.HasIndex("Track_UniqueId");

                    b.ToTable("AcoustIdResult");
                });

            modelBuilder.Entity("ch.wuerth.tobias.mux.Data.models.Invite"
                , b =>
                {
                    b.Property<Int32>("UniqueId").ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDate");

                    b.Property<Int32>("CreateUserUniqueId");

                    b.Property<DateTime>("ExpirationDate");

                    b.Property<String>("Token").IsRequired().HasMaxLength(16);

                    b.HasKey("UniqueId");

                    b.HasIndex("CreateUserUniqueId");

                    b.ToTable("Invite");
                });

            modelBuilder.Entity("ch.wuerth.tobias.mux.Data.models.MusicBrainzAlias"
                , b =>
                {
                    b.Property<Int32>("UniqueId").ValueGeneratedOnAdd();

                    b.Property<String>("Begin").HasMaxLength(1024);

                    b.Property<String>("End").HasMaxLength(1024);

                    b.Property<Boolean>("Ended");

                    b.Property<String>("Locale").HasMaxLength(1024);

                    b.Property<String>("Name").HasMaxLength(1024);

                    b.Property<String>("Primary").HasMaxLength(1024);

                    b.Property<String>("ShortName").HasMaxLength(1024);

                    b.Property<String>("Type").HasMaxLength(1024);

                    b.Property<String>("TypeId").HasMaxLength(1024);

                    b.Property<String>("UniqueHash").IsRequired().HasMaxLength(128);

                    b.HasKey("UniqueId");

                    b.HasIndex("Name");

                    b.HasIndex("UniqueHash").IsUnique();

                    b.ToTable("MusicBrainzAlias");
                });

            modelBuilder.Entity("ch.wuerth.tobias.mux.Data.models.MusicBrainzArea"
                , b =>
                {
                    b.Property<Int32>("UniqueId").ValueGeneratedOnAdd();

                    b.Property<String>("Disambiguation").HasMaxLength(4096);

                    b.Property<String>("Id").HasMaxLength(1024);

                    b.Property<String>("Name").HasMaxLength(1024);

                    b.Property<String>("SortName").HasMaxLength(1024);

                    b.HasKey("UniqueId");

                    b.ToTable("MusicBrainzArea");
                });

            modelBuilder.Entity("ch.wuerth.tobias.mux.Data.models.MusicBrainzArtist"
                , b =>
                {
                    b.Property<Int32>("UniqueId").ValueGeneratedOnAdd();

                    b.Property<String>("Disambiguation").HasMaxLength(4096);

                    b.Property<String>("Name").HasMaxLength(1024);

                    b.Property<String>("SortName").HasMaxLength(1024);

                    b.Property<String>("UniqueHash").IsRequired().HasMaxLength(128);

                    b.HasKey("UniqueId");

                    b.ToTable("MusicBrainzArtist");
                });

            modelBuilder.Entity("ch.wuerth.tobias.mux.Data.models.MusicBrainzArtistCredit"
                , b =>
                {
                    b.Property<Int32>("UniqueId").ValueGeneratedOnAdd();

                    b.Property<Int32?>("Artist_UniqueId").IsRequired();

                    b.Property<String>("Joinphrase").HasMaxLength(4096);

                    b.Property<String>("Name").HasMaxLength(1024);

                    b.Property<String>("UniqueHash").IsRequired().HasMaxLength(128);

                    b.HasKey("UniqueId");

                    b.HasIndex("Artist_UniqueId");

                    b.HasIndex("Name");

                    b.HasIndex("UniqueHash").IsUnique();

                    b.ToTable("MusicBrainzArtistCredit");
                });

            modelBuilder.Entity("ch.wuerth.tobias.mux.Data.models.MusicBrainzIsoCode"
                , b =>
                {
                    b.Property<Int32>("UniqueId").ValueGeneratedOnAdd();

                    b.Property<String>("Code").HasMaxLength(3);

                    b.HasKey("UniqueId");

                    b.HasIndex("Code").IsUnique().HasFilter("[Code] IS NOT NULL");

                    b.ToTable("MusicBrainzIsoCode");
                });

            modelBuilder.Entity("ch.wuerth.tobias.mux.Data.models.MusicBrainzRecord"
                , b =>
                {
                    b.Property<Int32>("UniqueId").ValueGeneratedOnAdd();

                    b.Property<String>("Disambiguation").HasMaxLength(4096);

                    b.Property<DateTime?>("LastMusicBrainzApiCall");

                    b.Property<Int32?>("Length");

                    b.Property<String>("MusicBrainzApiCallError");

                    b.Property<String>("MusicbrainzId").IsRequired().HasMaxLength(40);

                    b.Property<String>("Title").HasMaxLength(255);

                    b.Property<Boolean?>("Video");

                    b.HasKey("UniqueId");

                    b.HasIndex("MusicbrainzId").IsUnique();

                    b.HasIndex("Title");

                    b.ToTable("MusicBrainzRecord");
                });

            modelBuilder.Entity("ch.wuerth.tobias.mux.Data.models.MusicBrainzRelease"
                , b =>
                {
                    b.Property<Int32>("UniqueId").ValueGeneratedOnAdd();

                    b.Property<String>("Barcode").HasMaxLength(1024);

                    b.Property<String>("Country").HasMaxLength(1024);

                    b.Property<DateTime?>("Date");

                    b.Property<String>("Disambiguation").HasMaxLength(1024);

                    b.Property<String>("Id").HasMaxLength(1024);

                    b.Property<String>("PackagingId").HasMaxLength(1024);

                    b.Property<String>("Quality").HasMaxLength(1024);

                    b.Property<String>("Status").HasMaxLength(1024);

                    b.Property<String>("StatusId").HasMaxLength(1024);

                    b.Property<Int32?>("TextRepresentation_UniqueId");

                    b.Property<String>("Title").HasMaxLength(1024);

                    b.Property<String>("UniqueHash").IsRequired().HasMaxLength(128);

                    b.HasKey("UniqueId");

                    b.HasIndex("TextRepresentation_UniqueId");

                    b.HasIndex("Title");

                    b.HasIndex("UniqueHash").IsUnique();

                    b.ToTable("MusicBrainzRelease");
                });

            modelBuilder.Entity("ch.wuerth.tobias.mux.Data.models.MusicBrainzReleaseEvent"
                , b =>
                {
                    b.Property<Int32>("UniqueId").ValueGeneratedOnAdd();

                    b.Property<Int32?>("Area_UniqueId");

                    b.Property<DateTime?>("Date");

                    b.Property<String>("UniqueHash").IsRequired().HasMaxLength(128);

                    b.HasKey("UniqueId");

                    b.HasIndex("Area_UniqueId");

                    b.HasIndex("UniqueHash").IsUnique();

                    b.ToTable("MusicBrainzReleaseEvent");
                });

            modelBuilder.Entity("ch.wuerth.tobias.mux.Data.models.MusicBrainzTag"
                , b =>
                {
                    b.Property<Int32>("UniqueId").ValueGeneratedOnAdd();

                    b.Property<Int32>("Count");

                    b.Property<String>("Name").HasMaxLength(4096);

                    b.Property<String>("UniqueHash").IsRequired().HasMaxLength(128);

                    b.HasKey("UniqueId");

                    b.HasIndex("UniqueHash").IsUnique();

                    b.ToTable("MusicBrainzTag");
                });

            modelBuilder.Entity("ch.wuerth.tobias.mux.Data.models.MusicBrainzTextRepresentation"
                , b =>
                {
                    b.Property<Int32>("UniqueId").ValueGeneratedOnAdd();

                    b.Property<String>("Language").HasMaxLength(1024);

                    b.Property<String>("Script").HasMaxLength(1024);

                    b.Property<String>("UniqueHash").IsRequired().HasMaxLength(128);

                    b.HasKey("UniqueId");

                    b.HasIndex("UniqueHash").IsUnique();

                    b.ToTable("MusicBrainzTextRepresentation");
                });

            modelBuilder.Entity("ch.wuerth.tobias.mux.Data.models.shadowentities.MusicBrainzAliasMusicBrainzRecord"
                , b =>
                {
                    b.Property<Int32>("MusicBrainzAliasUniqueId").HasColumnName("MusicBrainzAlias_UniqueId");

                    b.Property<Int32>("MusicBrainzRecordUniqueId").HasColumnName("MusicBrainzRecord_UniqueId");

                    b.HasKey("MusicBrainzAliasUniqueId", "MusicBrainzRecordUniqueId");

                    b.HasIndex("MusicBrainzRecordUniqueId");

                    b.ToTable("MusicBrainzAliasMusicBrainzRecord");
                });

            modelBuilder.Entity("ch.wuerth.tobias.mux.Data.models.shadowentities.MusicBrainzArtistCreditMusicBrainzRecord"
                , b =>
                {
                    b.Property<Int32>("MusicBrainzArtistCreditUniqueId").HasColumnName("MusicBrainzArtistCredit_UniqueId");

                    b.Property<Int32>("MusicBrainzRecordUniqueId").HasColumnName("MusicBrainzRecord_UniqueId");

                    b.HasKey("MusicBrainzArtistCreditUniqueId", "MusicBrainzRecordUniqueId");

                    b.HasIndex("MusicBrainzRecordUniqueId");

                    b.ToTable("MusicBrainzArtistCreditMusicBrainzRecord");
                });

            modelBuilder.Entity("ch.wuerth.tobias.mux.Data.models.shadowentities.MusicBrainzArtistMusicBrainzAlias"
                , b =>
                {
                    b.Property<Int32>("MusicBrainzAliasUniqueId").HasColumnName("MusicBrainzAlias_UniqueId");

                    b.Property<Int32>("MusicBrainzArtistUniqueId").HasColumnName("MusicBrainzArtist_UniqueId");

                    b.HasKey("MusicBrainzAliasUniqueId", "MusicBrainzArtistUniqueId");

                    b.HasIndex("MusicBrainzArtistUniqueId");

                    b.ToTable("MusicBrainzArtistMusicBrainzAlias");
                });

            modelBuilder.Entity("ch.wuerth.tobias.mux.Data.models.shadowentities.MusicBrainzIsoCodeMusicBrainzArea"
                , b =>
                {
                    b.Property<Int32>("MusicBrainzIsoCodeUniqueId").HasColumnName("MusicBrainzIsoCode_UniqueId");

                    b.Property<Int32>("MusicBrainzAreaUniqueId").HasColumnName("MusicBrainzArea_UniqueId");

                    b.HasKey("MusicBrainzIsoCodeUniqueId", "MusicBrainzAreaUniqueId");

                    b.HasIndex("MusicBrainzAreaUniqueId");

                    b.ToTable("MusicBrainzIsoCodeMusicBrainzArea");
                });

            modelBuilder.Entity("ch.wuerth.tobias.mux.Data.models.shadowentities.MusicBrainzRecordAcoustId"
                , b =>
                {
                    b.Property<Int32>("MusicBrainzRecordUniqueId").HasColumnName("MusicBrainzRecord_UniqueId");

                    b.Property<Int32>("AcoustIdUniqueId").HasColumnName("AcoustId_UniqueId");

                    b.HasKey("MusicBrainzRecordUniqueId", "AcoustIdUniqueId");

                    b.HasIndex("AcoustIdUniqueId");

                    b.ToTable("MusicBrainzRecordAcoustId");
                });

            modelBuilder.Entity("ch.wuerth.tobias.mux.Data.models.shadowentities.MusicBrainzReleaseEventMusicBrainzRelease"
                , b =>
                {
                    b.Property<Int32>("MusicBrainzReleaseUniqueId").HasColumnName("MusicBrainzRelease_UniqueId");

                    b.Property<Int32>("MusicBrainzReleaseEventUniqueId").HasColumnName("MusicBrainzReleaseEvent_UniqueId");

                    b.HasKey("MusicBrainzReleaseUniqueId", "MusicBrainzReleaseEventUniqueId");

                    b.HasIndex("MusicBrainzReleaseEventUniqueId");

                    b.ToTable("MusicBrainzReleaseEventMusicBrainzRelease");
                });

            modelBuilder.Entity("ch.wuerth.tobias.mux.Data.models.shadowentities.MusicBrainzReleaseMusicBrainzAlias"
                , b =>
                {
                    b.Property<Int32>("MusicBrainzReleaseUniqueId").HasColumnName("MusicBrainzRelease_UniqueId");

                    b.Property<Int32>("MusicBrainzAliasUniqueId").HasColumnName("MusicBrainzAlias_UniqueId");

                    b.HasKey("MusicBrainzReleaseUniqueId", "MusicBrainzAliasUniqueId");

                    b.HasIndex("MusicBrainzAliasUniqueId");

                    b.ToTable("MusicBrainzReleaseMusicBrainzAlias");
                });

            modelBuilder.Entity("ch.wuerth.tobias.mux.Data.models.shadowentities.MusicBrainzReleaseMusicBrainzArtistCredit"
                , b =>
                {
                    b.Property<Int32>("MusicBrainzReleaseUniqueId").HasColumnName("MusicBrainzRelease_UniqueId");

                    b.Property<Int32>("MusicBrainzArtistCreditUniqueId").HasColumnName("MusicBrainzArtistCredit_UniqueId");

                    b.HasKey("MusicBrainzReleaseUniqueId", "MusicBrainzArtistCreditUniqueId");

                    b.HasIndex("MusicBrainzArtistCreditUniqueId");

                    b.ToTable("MusicBrainzReleaseMusicBrainzArtistCredit");
                });

            modelBuilder.Entity("ch.wuerth.tobias.mux.Data.models.shadowentities.MusicBrainzReleaseMusicBrainzRecord"
                , b =>
                {
                    b.Property<Int32>("MusicBrainzReleaseUniqueId").HasColumnName("MusicBrainzRelease_UniqueId");

                    b.Property<Int32>("MusicBrainzRecordUniqueId").HasColumnName("MusicBrainzRecord_UniqueId");

                    b.HasKey("MusicBrainzReleaseUniqueId", "MusicBrainzRecordUniqueId");

                    b.HasIndex("MusicBrainzRecordUniqueId");

                    b.ToTable("MusicBrainzReleaseMusicBrainzRecord");
                });

            modelBuilder.Entity("ch.wuerth.tobias.mux.Data.models.shadowentities.MusicBrainzTagMusicBrainzRecord"
                , b =>
                {
                    b.Property<Int32>("MusicBrainzTagUniqueId").HasColumnName("MusicBrainzTag_UniqueId");

                    b.Property<Int32>("MusicBrainzRecordUniqueId").HasColumnName("MusicBrainzRecord_UniqueId");

                    b.HasKey("MusicBrainzTagUniqueId", "MusicBrainzRecordUniqueId");

                    b.HasIndex("MusicBrainzRecordUniqueId");

                    b.ToTable("MusicBrainzTagMusicBrainzRecord");
                });

            modelBuilder.Entity("ch.wuerth.tobias.mux.Data.models.Track"
                , b =>
                {
                    b.Property<Int32>("UniqueId").ValueGeneratedOnAdd();

                    b.Property<String>("AcoustIdApiError");

                    b.Property<Int32?>("AcoustIdApiErrorCode");

                    b.Property<Double?>("Duration");

                    b.Property<String>("Fingerprint");

                    b.Property<String>("FingerprintError");

                    b.Property<String>("FingerprintHash").HasMaxLength(128);

                    b.Property<DateTime?>("LastAcoustIdApiCall");

                    b.Property<DateTime?>("LastFingerprintCalculation");

                    b.Property<String>("Path").IsRequired().HasMaxLength(2048);

                    b.HasKey("UniqueId");

                    b.HasIndex("FingerprintHash");

                    b.HasIndex("LastAcoustIdApiCall");

                    b.HasIndex("LastFingerprintCalculation");

                    b.HasIndex("Path").IsUnique();

                    b.ToTable("Track");
                });

            modelBuilder.Entity("ch.wuerth.tobias.mux.Data.models.User"
                , b =>
                {
                    b.Property<Int32>("UniqueId").ValueGeneratedOnAdd();

                    b.Property<Int32?>("InviteUniqueId");

                    b.Property<String>("Password").IsRequired().HasMaxLength(1024);

                    b.Property<String>("Username").IsRequired().HasMaxLength(32);

                    b.HasKey("UniqueId");

                    b.HasIndex("InviteUniqueId").IsUnique().HasFilter("[InviteUniqueId] IS NOT NULL");

                    b.HasIndex("Username").IsUnique();

                    b.ToTable("User");
                });

            modelBuilder.Entity("ch.wuerth.tobias.mux.Data.models.AcoustIdResult"
                , b =>
                {
                    b.HasOne("ch.wuerth.tobias.mux.Data.models.AcoustId", "AcoustId")
                        .WithMany("AcoustIdResults")
                        .HasForeignKey("AcoustId_UniqueId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ch.wuerth.tobias.mux.Data.models.Track", "Track")
                        .WithMany("AcoustIdResults")
                        .HasForeignKey("Track_UniqueId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ch.wuerth.tobias.mux.Data.models.Invite"
                , b =>
                {
                    b.HasOne("ch.wuerth.tobias.mux.Data.models.User", "CreateUser")
                        .WithMany("Invites")
                        .HasForeignKey("CreateUserUniqueId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ch.wuerth.tobias.mux.Data.models.MusicBrainzArtistCredit"
                , b =>
                {
                    b.HasOne("ch.wuerth.tobias.mux.Data.models.MusicBrainzArtist", "Artist")
                        .WithMany("Credits")
                        .HasForeignKey("Artist_UniqueId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ch.wuerth.tobias.mux.Data.models.MusicBrainzRelease"
                , b =>
                {
                    b.HasOne("ch.wuerth.tobias.mux.Data.models.MusicBrainzTextRepresentation", "TextRepresentation")
                        .WithMany("Releases")
                        .HasForeignKey("TextRepresentation_UniqueId");
                });

            modelBuilder.Entity("ch.wuerth.tobias.mux.Data.models.MusicBrainzReleaseEvent"
                , b =>
                {
                    b.HasOne("ch.wuerth.tobias.mux.Data.models.MusicBrainzArea", "Area")
                        .WithMany("ReleaseEvents")
                        .HasForeignKey("Area_UniqueId");
                });

            modelBuilder.Entity("ch.wuerth.tobias.mux.Data.models.shadowentities.MusicBrainzAliasMusicBrainzRecord"
                , b =>
                {
                    b.HasOne("ch.wuerth.tobias.mux.Data.models.MusicBrainzAlias", "MusicBrainzAlias")
                        .WithMany("MusicBrainzAliasMusicBrainzRecords")
                        .HasForeignKey("MusicBrainzAliasUniqueId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ch.wuerth.tobias.mux.Data.models.MusicBrainzRecord", "MusicBrainzRecord")
                        .WithMany("MusicBrainzAliasMusicBrainzRecords")
                        .HasForeignKey("MusicBrainzRecordUniqueId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ch.wuerth.tobias.mux.Data.models.shadowentities.MusicBrainzArtistCreditMusicBrainzRecord"
                , b =>
                {
                    b.HasOne("ch.wuerth.tobias.mux.Data.models.MusicBrainzArtistCredit", "MusicBrainzArtistCredit")
                        .WithMany("MusicBrainzArtistCreditMusicBrainzRecords")
                        .HasForeignKey("MusicBrainzArtistCreditUniqueId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ch.wuerth.tobias.mux.Data.models.MusicBrainzRecord", "MusicBrainzRecord")
                        .WithMany("MusicBrainzArtistCreditMusicBrainzRecords")
                        .HasForeignKey("MusicBrainzRecordUniqueId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ch.wuerth.tobias.mux.Data.models.shadowentities.MusicBrainzArtistMusicBrainzAlias"
                , b =>
                {
                    b.HasOne("ch.wuerth.tobias.mux.Data.models.MusicBrainzAlias", "MusicBrainzAlias")
                        .WithMany("MusicBrainzArtistMusicBrainzAliases")
                        .HasForeignKey("MusicBrainzAliasUniqueId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ch.wuerth.tobias.mux.Data.models.MusicBrainzArtist", "MusicBrainzArtist")
                        .WithMany("MusicBrainzArtistMusicBrainzAliases")
                        .HasForeignKey("MusicBrainzArtistUniqueId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ch.wuerth.tobias.mux.Data.models.shadowentities.MusicBrainzIsoCodeMusicBrainzArea"
                , b =>
                {
                    b.HasOne("ch.wuerth.tobias.mux.Data.models.MusicBrainzArea", "MusicBrainzArea")
                        .WithMany("MusicBrainzIsoCodeMusicBrainzAreas")
                        .HasForeignKey("MusicBrainzAreaUniqueId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ch.wuerth.tobias.mux.Data.models.MusicBrainzIsoCode", "MusicBrainzIsoCode")
                        .WithMany("MusicBrainzIsoCodeMusicBrainzAreas")
                        .HasForeignKey("MusicBrainzIsoCodeUniqueId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ch.wuerth.tobias.mux.Data.models.shadowentities.MusicBrainzRecordAcoustId"
                , b =>
                {
                    b.HasOne("ch.wuerth.tobias.mux.Data.models.AcoustId", "AcoustId")
                        .WithMany("MusicBrainzRecordAcoustIds")
                        .HasForeignKey("AcoustIdUniqueId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ch.wuerth.tobias.mux.Data.models.MusicBrainzRecord", "MusicBrainzRecord")
                        .WithMany("MusicBrainzRecordAcoustIds")
                        .HasForeignKey("MusicBrainzRecordUniqueId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ch.wuerth.tobias.mux.Data.models.shadowentities.MusicBrainzReleaseEventMusicBrainzRelease"
                , b =>
                {
                    b.HasOne("ch.wuerth.tobias.mux.Data.models.MusicBrainzReleaseEvent", "MusicBrainzReleaseEvent")
                        .WithMany("MusicBrainzReleaseEventMusicBrainzReleases")
                        .HasForeignKey("MusicBrainzReleaseEventUniqueId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ch.wuerth.tobias.mux.Data.models.MusicBrainzRelease", "MusicBrainzRelease")
                        .WithMany("MusicBrainzReleaseEventMusicBrainzReleases")
                        .HasForeignKey("MusicBrainzReleaseUniqueId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ch.wuerth.tobias.mux.Data.models.shadowentities.MusicBrainzReleaseMusicBrainzAlias"
                , b =>
                {
                    b.HasOne("ch.wuerth.tobias.mux.Data.models.MusicBrainzAlias", "MusicBrainzAlias")
                        .WithMany("MusicBrainzReleaseMusicBrainzAliases")
                        .HasForeignKey("MusicBrainzAliasUniqueId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ch.wuerth.tobias.mux.Data.models.MusicBrainzRelease", "MusicBrainzRelease")
                        .WithMany("MusicBrainzReleaseMusicBrainzAliases")
                        .HasForeignKey("MusicBrainzReleaseUniqueId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ch.wuerth.tobias.mux.Data.models.shadowentities.MusicBrainzReleaseMusicBrainzArtistCredit"
                , b =>
                {
                    b.HasOne("ch.wuerth.tobias.mux.Data.models.MusicBrainzArtistCredit", "MusicBrainzArtistCredit")
                        .WithMany("MusicBrainzReleaseMusicBrainzArtistCredits")
                        .HasForeignKey("MusicBrainzArtistCreditUniqueId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ch.wuerth.tobias.mux.Data.models.MusicBrainzRelease", "MusicBrainzRelease")
                        .WithMany("MusicBrainzReleaseMusicBrainzArtistCredits")
                        .HasForeignKey("MusicBrainzReleaseUniqueId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ch.wuerth.tobias.mux.Data.models.shadowentities.MusicBrainzReleaseMusicBrainzRecord"
                , b =>
                {
                    b.HasOne("ch.wuerth.tobias.mux.Data.models.MusicBrainzRecord", "MusicBrainzRecord")
                        .WithMany("MusicBrainzReleaseMusicBrainzRecords")
                        .HasForeignKey("MusicBrainzRecordUniqueId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ch.wuerth.tobias.mux.Data.models.MusicBrainzRelease", "MusicBrainzRelease")
                        .WithMany("MusicBrainzReleaseMusicBrainzRecords")
                        .HasForeignKey("MusicBrainzReleaseUniqueId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ch.wuerth.tobias.mux.Data.models.shadowentities.MusicBrainzTagMusicBrainzRecord"
                , b =>
                {
                    b.HasOne("ch.wuerth.tobias.mux.Data.models.MusicBrainzRecord", "MusicBrainzRecord")
                        .WithMany("MusicBrainzTagMusicBrainzRecords")
                        .HasForeignKey("MusicBrainzRecordUniqueId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ch.wuerth.tobias.mux.Data.models.MusicBrainzTag", "MusicBrainzTag")
                        .WithMany("MusicBrainzTagMusicBrainzRecords")
                        .HasForeignKey("MusicBrainzTagUniqueId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ch.wuerth.tobias.mux.Data.models.User"
                , b =>
                {
                    b.HasOne("ch.wuerth.tobias.mux.Data.models.Invite", "Invite")
                        .WithOne("RegisteredUser")
                        .HasForeignKey("ch.wuerth.tobias.mux.Data.models.User", "InviteUniqueId");
                });
#pragma warning restore 612, 618
        }
    }
}