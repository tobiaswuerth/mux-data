using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ch.wuerth.tobias.mux.Data.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable("AcoustId"
                , table => new
                {
                    UniqueId = table.Column<Int32>(nullable : false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                    , Id = table.Column<String>(maxLength : 40, nullable : false)
                }
                , constraints : table => { table.PrimaryKey("PK_AcoustId", x => x.UniqueId); });

            migrationBuilder.CreateTable("MusicBrainzAlias"
                , table => new
                {
                    UniqueId =
                    table.Column<Int32>(nullable : false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                    , Begin = table.Column<String>(maxLength : 1024, nullable : true)
                    , End = table.Column<String>(maxLength : 1024, nullable : true)
                    , Ended = table.Column<Boolean>(nullable : false)
                    , Locale = table.Column<String>(maxLength : 1024, nullable : true)
                    , Name = table.Column<String>(maxLength : 1024, nullable : true)
                    , Primary = table.Column<String>(maxLength : 1024, nullable : true)
                    , ShortName = table.Column<String>(maxLength : 1024, nullable : true)
                    , Type = table.Column<String>(maxLength : 1024, nullable : true)
                    , TypeId = table.Column<String>(maxLength : 1024, nullable : true)
                    , UniqueHash = table.Column<String>(maxLength : 128, nullable : false)
                }
                , constraints : table => { table.PrimaryKey("PK_MusicBrainzAlias", x => x.UniqueId); });

            migrationBuilder.CreateTable("MusicBrainzArea"
                , table => new
                {
                    UniqueId =
                    table.Column<Int32>(nullable : false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                    , Disambiguation = table.Column<String>(maxLength : 4096, nullable : true)
                    , Id = table.Column<String>(maxLength : 1024, nullable : true)
                    , Name = table.Column<String>(maxLength : 1024, nullable : true)
                    , SortName = table.Column<String>(maxLength : 1024, nullable : true)
                }
                , constraints : table => { table.PrimaryKey("PK_MusicBrainzArea", x => x.UniqueId); });

            migrationBuilder.CreateTable("MusicBrainzArtist"
                , table => new
                {
                    UniqueId =
                    table.Column<Int32>(nullable : false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                    , Disambiguation = table.Column<String>(maxLength : 4096, nullable : true)
                    , Name = table.Column<String>(maxLength : 1024, nullable : true)
                    , SortName = table.Column<String>(maxLength : 1024, nullable : true)
                    , UniqueHash = table.Column<String>(maxLength : 128, nullable : false)
                }
                , constraints : table => { table.PrimaryKey("PK_MusicBrainzArtist", x => x.UniqueId); });

            migrationBuilder.CreateTable("MusicBrainzIsoCode"
                , table => new
                {
                    UniqueId = table.Column<Int32>(nullable : false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                    , Code = table.Column<String>(maxLength : 3, nullable : true)
                }
                , constraints : table => { table.PrimaryKey("PK_MusicBrainzIsoCode", x => x.UniqueId); });

            migrationBuilder.CreateTable("MusicBrainzRecord"
                , table => new
                {
                    UniqueId =
                    table.Column<Int32>(nullable : false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                    , Disambiguation = table.Column<String>(maxLength : 4096, nullable : true)
                    , LastMusicBrainzApiCall = table.Column<DateTime>(nullable : true)
                    , Length = table.Column<Int32>(nullable : true)
                    , MusicBrainzApiCallError = table.Column<String>(nullable : true)
                    , MusicbrainzId = table.Column<String>(maxLength : 40, nullable : false)
                    , Title = table.Column<String>(maxLength : 255, nullable : true)
                    , Video = table.Column<Boolean>(nullable : true)
                }
                , constraints : table => { table.PrimaryKey("PK_MusicBrainzRecord", x => x.UniqueId); });

            migrationBuilder.CreateTable("MusicBrainzTag"
                , table => new
                {
                    UniqueId =
                    table.Column<Int32>(nullable : false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                    , Count = table.Column<Int32>(nullable : false)
                    , Name = table.Column<String>(maxLength : 4096, nullable : true)
                    , UniqueHash = table.Column<String>(maxLength : 128, nullable : false)
                }
                , constraints : table => { table.PrimaryKey("PK_MusicBrainzTag", x => x.UniqueId); });

            migrationBuilder.CreateTable("MusicBrainzTextRepresentation"
                , table => new
                {
                    UniqueId =
                    table.Column<Int32>(nullable : false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                    , Language = table.Column<String>(maxLength : 1024, nullable : true)
                    , Script = table.Column<String>(maxLength : 1024, nullable : true)
                    , UniqueHash = table.Column<String>(maxLength : 128, nullable : false)
                }
                , constraints : table => { table.PrimaryKey("PK_MusicBrainzTextRepresentation", x => x.UniqueId); });

            migrationBuilder.CreateTable("Track"
                , table => new
                {
                    UniqueId =
                    table.Column<Int32>(nullable : false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                    , AcoustIdApiError = table.Column<String>(nullable : true)
                    , AcoustIdApiErrorCode = table.Column<Int32>(nullable : true)
                    , Duration = table.Column<Double>(nullable : true)
                    , Fingerprint = table.Column<String>(nullable : true)
                    , FingerprintError = table.Column<String>(nullable : true)
                    , FingerprintHash = table.Column<String>(maxLength : 128, nullable : true)
                    , LastAcoustIdApiCall = table.Column<DateTime>(nullable : true)
                    , LastFingerprintCalculation = table.Column<DateTime>(nullable : true)
                    , Path = table.Column<String>(maxLength : 2048, nullable : false)
                }
                , constraints : table => { table.PrimaryKey("PK_Track", x => x.UniqueId); });

            migrationBuilder.CreateTable("User"
                , table => new
                {
                    UniqueId =
                    table.Column<Int32>(nullable : false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                    , Password = table.Column<String>(maxLength : 1024, nullable : false)
                    , Username = table.Column<String>(maxLength : 32, nullable : false)
                }
                , constraints : table => { table.PrimaryKey("PK_User", x => x.UniqueId); });

            migrationBuilder.CreateTable("MusicBrainzReleaseEvent"
                , table => new
                {
                    UniqueId =
                    table.Column<Int32>(nullable : false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                    , Area_UniqueId = table.Column<Int32>(nullable : true)
                    , Date = table.Column<DateTime>(nullable : true)
                    , UniqueHash = table.Column<String>(maxLength : 128, nullable : false)
                }
                , constraints : table =>
                {
                    table.PrimaryKey("PK_MusicBrainzReleaseEvent", x => x.UniqueId);
                    table.ForeignKey("FK_MusicBrainzReleaseEvent_MusicBrainzArea_Area_UniqueId"
                        , x => x.Area_UniqueId
                        , "MusicBrainzArea"
                        , "UniqueId"
                        , onDelete : ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable("MusicBrainzArtistCredit"
                , table => new
                {
                    UniqueId =
                    table.Column<Int32>(nullable : false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                    , Artist_UniqueId = table.Column<Int32>(nullable : false)
                    , Joinphrase = table.Column<String>(maxLength : 4096, nullable : true)
                    , Name = table.Column<String>(maxLength : 1024, nullable : true)
                    , UniqueHash = table.Column<String>(maxLength : 128, nullable : false)
                }
                , constraints : table =>
                {
                    table.PrimaryKey("PK_MusicBrainzArtistCredit", x => x.UniqueId);
                    table.ForeignKey("FK_MusicBrainzArtistCredit_MusicBrainzArtist_Artist_UniqueId"
                        , x => x.Artist_UniqueId
                        , "MusicBrainzArtist"
                        , "UniqueId"
                        , onDelete : ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable("MusicBrainzArtistMusicBrainzAlias"
                , table => new
                {
                    MusicBrainzAlias_UniqueId = table.Column<Int32>(nullable : false)
                    , MusicBrainzArtist_UniqueId = table.Column<Int32>(nullable : false)
                }
                , constraints : table =>
                {
                    table.PrimaryKey("PK_MusicBrainzArtistMusicBrainzAlias"
                        , x => new
                        {
                            x.MusicBrainzAlias_UniqueId
                            , x.MusicBrainzArtist_UniqueId
                        });
                    table.ForeignKey("FK_MusicBrainzArtistMusicBrainzAlias_MusicBrainzAlias_MusicBrainzAlias_UniqueId"
                        , x => x.MusicBrainzAlias_UniqueId
                        , "MusicBrainzAlias"
                        , "UniqueId"
                        , onDelete : ReferentialAction.Cascade);
                    table.ForeignKey("FK_MusicBrainzArtistMusicBrainzAlias_MusicBrainzArtist_MusicBrainzArtist_UniqueId"
                        , x => x.MusicBrainzArtist_UniqueId
                        , "MusicBrainzArtist"
                        , "UniqueId"
                        , onDelete : ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable("MusicBrainzIsoCodeMusicBrainzArea"
                , table => new
                {
                    MusicBrainzIsoCode_UniqueId = table.Column<Int32>(nullable : false)
                    , MusicBrainzArea_UniqueId = table.Column<Int32>(nullable : false)
                }
                , constraints : table =>
                {
                    table.PrimaryKey("PK_MusicBrainzIsoCodeMusicBrainzArea"
                        , x => new
                        {
                            x.MusicBrainzIsoCode_UniqueId
                            , x.MusicBrainzArea_UniqueId
                        });
                    table.ForeignKey("FK_MusicBrainzIsoCodeMusicBrainzArea_MusicBrainzArea_MusicBrainzArea_UniqueId"
                        , x => x.MusicBrainzArea_UniqueId
                        , "MusicBrainzArea"
                        , "UniqueId"
                        , onDelete : ReferentialAction.Cascade);
                    table.ForeignKey("FK_MusicBrainzIsoCodeMusicBrainzArea_MusicBrainzIsoCode_MusicBrainzIsoCode_UniqueId"
                        , x => x.MusicBrainzIsoCode_UniqueId
                        , "MusicBrainzIsoCode"
                        , "UniqueId"
                        , onDelete : ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable("MusicBrainzAliasMusicBrainzRecord"
                , table => new
                {
                    MusicBrainzAlias_UniqueId = table.Column<Int32>(nullable : false)
                    , MusicBrainzRecord_UniqueId = table.Column<Int32>(nullable : false)
                }
                , constraints : table =>
                {
                    table.PrimaryKey("PK_MusicBrainzAliasMusicBrainzRecord"
                        , x => new
                        {
                            x.MusicBrainzAlias_UniqueId
                            , x.MusicBrainzRecord_UniqueId
                        });
                    table.ForeignKey("FK_MusicBrainzAliasMusicBrainzRecord_MusicBrainzAlias_MusicBrainzAlias_UniqueId"
                        , x => x.MusicBrainzAlias_UniqueId
                        , "MusicBrainzAlias"
                        , "UniqueId"
                        , onDelete : ReferentialAction.Cascade);
                    table.ForeignKey("FK_MusicBrainzAliasMusicBrainzRecord_MusicBrainzRecord_MusicBrainzRecord_UniqueId"
                        , x => x.MusicBrainzRecord_UniqueId
                        , "MusicBrainzRecord"
                        , "UniqueId"
                        , onDelete : ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable("MusicBrainzRecordAcoustId"
                , table => new
                {
                    MusicBrainzRecord_UniqueId = table.Column<Int32>(nullable : false)
                    , AcoustId_UniqueId = table.Column<Int32>(nullable : false)
                }
                , constraints : table =>
                {
                    table.PrimaryKey("PK_MusicBrainzRecordAcoustId"
                        , x => new
                        {
                            x.MusicBrainzRecord_UniqueId
                            , x.AcoustId_UniqueId
                        });
                    table.ForeignKey("FK_MusicBrainzRecordAcoustId_AcoustId_AcoustId_UniqueId"
                        , x => x.AcoustId_UniqueId
                        , "AcoustId"
                        , "UniqueId"
                        , onDelete : ReferentialAction.Cascade);
                    table.ForeignKey("FK_MusicBrainzRecordAcoustId_MusicBrainzRecord_MusicBrainzRecord_UniqueId"
                        , x => x.MusicBrainzRecord_UniqueId
                        , "MusicBrainzRecord"
                        , "UniqueId"
                        , onDelete : ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable("MusicBrainzTagMusicBrainzRecord"
                , table => new
                {
                    MusicBrainzTag_UniqueId = table.Column<Int32>(nullable : false)
                    , MusicBrainzRecord_UniqueId = table.Column<Int32>(nullable : false)
                }
                , constraints : table =>
                {
                    table.PrimaryKey("PK_MusicBrainzTagMusicBrainzRecord"
                        , x => new
                        {
                            x.MusicBrainzTag_UniqueId
                            , x.MusicBrainzRecord_UniqueId
                        });
                    table.ForeignKey("FK_MusicBrainzTagMusicBrainzRecord_MusicBrainzRecord_MusicBrainzRecord_UniqueId"
                        , x => x.MusicBrainzRecord_UniqueId
                        , "MusicBrainzRecord"
                        , "UniqueId"
                        , onDelete : ReferentialAction.Cascade);
                    table.ForeignKey("FK_MusicBrainzTagMusicBrainzRecord_MusicBrainzTag_MusicBrainzTag_UniqueId"
                        , x => x.MusicBrainzTag_UniqueId
                        , "MusicBrainzTag"
                        , "UniqueId"
                        , onDelete : ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable("MusicBrainzRelease"
                , table => new
                {
                    UniqueId =
                    table.Column<Int32>(nullable : false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                    , Barcode = table.Column<String>(maxLength : 1024, nullable : true)
                    , Country = table.Column<String>(maxLength : 1024, nullable : true)
                    , Date = table.Column<DateTime>(nullable : true)
                    , Disambiguation = table.Column<String>(maxLength : 1024, nullable : true)
                    , Id = table.Column<String>(maxLength : 1024, nullable : true)
                    , PackagingId = table.Column<String>(maxLength : 1024, nullable : true)
                    , Quality = table.Column<String>(maxLength : 1024, nullable : true)
                    , Status = table.Column<String>(maxLength : 1024, nullable : true)
                    , StatusId = table.Column<String>(maxLength : 1024, nullable : true)
                    , TextRepresentation_UniqueId = table.Column<Int32>(nullable : true)
                    , Title = table.Column<String>(maxLength : 1024, nullable : true)
                    , UniqueHash = table.Column<String>(maxLength : 128, nullable : false)
                }
                , constraints : table =>
                {
                    table.PrimaryKey("PK_MusicBrainzRelease", x => x.UniqueId);
                    table.ForeignKey("FK_MusicBrainzRelease_MusicBrainzTextRepresentation_TextRepresentation_UniqueId"
                        , x => x.TextRepresentation_UniqueId
                        , "MusicBrainzTextRepresentation"
                        , "UniqueId"
                        , onDelete : ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable("AcoustIdResult"
                , table => new
                {
                    UniqueId =
                    table.Column<Int32>(nullable : false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                    , AcoustId_UniqueId = table.Column<Int32>(nullable : false)
                    , Score = table.Column<Double>(nullable : false)
                    , Track_UniqueId = table.Column<Int32>(nullable : false)
                }
                , constraints : table =>
                {
                    table.PrimaryKey("PK_AcoustIdResult", x => x.UniqueId);
                    table.ForeignKey("FK_AcoustIdResult_AcoustId_AcoustId_UniqueId"
                        , x => x.AcoustId_UniqueId
                        , "AcoustId"
                        , "UniqueId"
                        , onDelete : ReferentialAction.Cascade);
                    table.ForeignKey("FK_AcoustIdResult_Track_Track_UniqueId"
                        , x => x.Track_UniqueId
                        , "Track"
                        , "UniqueId"
                        , onDelete : ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable("MusicBrainzArtistCreditMusicBrainzRecord"
                , table => new
                {
                    MusicBrainzArtistCredit_UniqueId = table.Column<Int32>(nullable : false)
                    , MusicBrainzRecord_UniqueId = table.Column<Int32>(nullable : false)
                }
                , constraints : table =>
                {
                    table.PrimaryKey("PK_MusicBrainzArtistCreditMusicBrainzRecord"
                        , x => new
                        {
                            x.MusicBrainzArtistCredit_UniqueId
                            , x.MusicBrainzRecord_UniqueId
                        });
                    table.ForeignKey(
                        "FK_MusicBrainzArtistCreditMusicBrainzRecord_MusicBrainzArtistCredit_MusicBrainzArtistCredit_UniqueId"
                        , x => x.MusicBrainzArtistCredit_UniqueId
                        , "MusicBrainzArtistCredit"
                        , "UniqueId"
                        , onDelete : ReferentialAction.Cascade);
                    table.ForeignKey("FK_MusicBrainzArtistCreditMusicBrainzRecord_MusicBrainzRecord_MusicBrainzRecord_UniqueId"
                        , x => x.MusicBrainzRecord_UniqueId
                        , "MusicBrainzRecord"
                        , "UniqueId"
                        , onDelete : ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable("MusicBrainzReleaseEventMusicBrainzRelease"
                , table => new
                {
                    MusicBrainzRelease_UniqueId = table.Column<Int32>(nullable : false)
                    , MusicBrainzReleaseEvent_UniqueId = table.Column<Int32>(nullable : false)
                }
                , constraints : table =>
                {
                    table.PrimaryKey("PK_MusicBrainzReleaseEventMusicBrainzRelease"
                        , x => new
                        {
                            x.MusicBrainzRelease_UniqueId
                            , x.MusicBrainzReleaseEvent_UniqueId
                        });
                    table.ForeignKey(
                        "FK_MusicBrainzReleaseEventMusicBrainzRelease_MusicBrainzReleaseEvent_MusicBrainzReleaseEvent_UniqueId"
                        , x => x.MusicBrainzReleaseEvent_UniqueId
                        , "MusicBrainzReleaseEvent"
                        , "UniqueId"
                        , onDelete : ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_MusicBrainzReleaseEventMusicBrainzRelease_MusicBrainzRelease_MusicBrainzRelease_UniqueId"
                        , x => x.MusicBrainzRelease_UniqueId
                        , "MusicBrainzRelease"
                        , "UniqueId"
                        , onDelete : ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable("MusicBrainzReleaseMusicBrainzAlias"
                , table => new
                {
                    MusicBrainzRelease_UniqueId = table.Column<Int32>(nullable : false)
                    , MusicBrainzAlias_UniqueId = table.Column<Int32>(nullable : false)
                }
                , constraints : table =>
                {
                    table.PrimaryKey("PK_MusicBrainzReleaseMusicBrainzAlias"
                        , x => new
                        {
                            x.MusicBrainzRelease_UniqueId
                            , x.MusicBrainzAlias_UniqueId
                        });
                    table.ForeignKey("FK_MusicBrainzReleaseMusicBrainzAlias_MusicBrainzAlias_MusicBrainzAlias_UniqueId"
                        , x => x.MusicBrainzAlias_UniqueId
                        , "MusicBrainzAlias"
                        , "UniqueId"
                        , onDelete : ReferentialAction.Cascade);
                    table.ForeignKey("FK_MusicBrainzReleaseMusicBrainzAlias_MusicBrainzRelease_MusicBrainzRelease_UniqueId"
                        , x => x.MusicBrainzRelease_UniqueId
                        , "MusicBrainzRelease"
                        , "UniqueId"
                        , onDelete : ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable("MusicBrainzReleaseMusicBrainzArtistCredit"
                , table => new
                {
                    MusicBrainzRelease_UniqueId = table.Column<Int32>(nullable : false)
                    , MusicBrainzArtistCredit_UniqueId = table.Column<Int32>(nullable : false)
                }
                , constraints : table =>
                {
                    table.PrimaryKey("PK_MusicBrainzReleaseMusicBrainzArtistCredit"
                        , x => new
                        {
                            x.MusicBrainzRelease_UniqueId
                            , x.MusicBrainzArtistCredit_UniqueId
                        });
                    table.ForeignKey(
                        "FK_MusicBrainzReleaseMusicBrainzArtistCredit_MusicBrainzArtistCredit_MusicBrainzArtistCredit_UniqueId"
                        , x => x.MusicBrainzArtistCredit_UniqueId
                        , "MusicBrainzArtistCredit"
                        , "UniqueId"
                        , onDelete : ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_MusicBrainzReleaseMusicBrainzArtistCredit_MusicBrainzRelease_MusicBrainzRelease_UniqueId"
                        , x => x.MusicBrainzRelease_UniqueId
                        , "MusicBrainzRelease"
                        , "UniqueId"
                        , onDelete : ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable("MusicBrainzReleaseMusicBrainzRecord"
                , table => new
                {
                    MusicBrainzRelease_UniqueId = table.Column<Int32>(nullable : false)
                    , MusicBrainzRecord_UniqueId = table.Column<Int32>(nullable : false)
                }
                , constraints : table =>
                {
                    table.PrimaryKey("PK_MusicBrainzReleaseMusicBrainzRecord"
                        , x => new
                        {
                            x.MusicBrainzRelease_UniqueId
                            , x.MusicBrainzRecord_UniqueId
                        });
                    table.ForeignKey("FK_MusicBrainzReleaseMusicBrainzRecord_MusicBrainzRecord_MusicBrainzRecord_UniqueId"
                        , x => x.MusicBrainzRecord_UniqueId
                        , "MusicBrainzRecord"
                        , "UniqueId"
                        , onDelete : ReferentialAction.Cascade);
                    table.ForeignKey("FK_MusicBrainzReleaseMusicBrainzRecord_MusicBrainzRelease_MusicBrainzRelease_UniqueId"
                        , x => x.MusicBrainzRelease_UniqueId
                        , "MusicBrainzRelease"
                        , "UniqueId"
                        , onDelete : ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex("IX_AcoustId_Id", "AcoustId", "Id", unique : true);

            migrationBuilder.CreateIndex("IX_AcoustIdResult_AcoustId_UniqueId", "AcoustIdResult", "AcoustId_UniqueId");

            migrationBuilder.CreateIndex("IX_AcoustIdResult_Track_UniqueId", "AcoustIdResult", "Track_UniqueId");

            migrationBuilder.CreateIndex("IX_MusicBrainzAlias_Name", "MusicBrainzAlias", "Name");

            migrationBuilder.CreateIndex("IX_MusicBrainzAlias_UniqueHash", "MusicBrainzAlias", "UniqueHash", unique : true);

            migrationBuilder.CreateIndex("IX_MusicBrainzAliasMusicBrainzRecord_MusicBrainzRecord_UniqueId"
                , "MusicBrainzAliasMusicBrainzRecord"
                , "MusicBrainzRecord_UniqueId");

            migrationBuilder.CreateIndex("IX_MusicBrainzArtistCredit_Artist_UniqueId"
                , "MusicBrainzArtistCredit"
                , "Artist_UniqueId");

            migrationBuilder.CreateIndex("IX_MusicBrainzArtistCredit_Name", "MusicBrainzArtistCredit", "Name");

            migrationBuilder.CreateIndex("IX_MusicBrainzArtistCredit_UniqueHash"
                , "MusicBrainzArtistCredit"
                , "UniqueHash"
                , unique : true);

            migrationBuilder.CreateIndex("IX_MusicBrainzArtistCreditMusicBrainzRecord_MusicBrainzRecord_UniqueId"
                , "MusicBrainzArtistCreditMusicBrainzRecord"
                , "MusicBrainzRecord_UniqueId");

            migrationBuilder.CreateIndex("IX_MusicBrainzArtistMusicBrainzAlias_MusicBrainzArtist_UniqueId"
                , "MusicBrainzArtistMusicBrainzAlias"
                , "MusicBrainzArtist_UniqueId");

            migrationBuilder.CreateIndex("IX_MusicBrainzIsoCode_Code"
                , "MusicBrainzIsoCode"
                , "Code"
                , unique : true
                , filter : "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex("IX_MusicBrainzIsoCodeMusicBrainzArea_MusicBrainzArea_UniqueId"
                , "MusicBrainzIsoCodeMusicBrainzArea"
                , "MusicBrainzArea_UniqueId");

            migrationBuilder.CreateIndex("IX_MusicBrainzRecord_MusicbrainzId"
                , "MusicBrainzRecord"
                , "MusicbrainzId"
                , unique : true);

            migrationBuilder.CreateIndex("IX_MusicBrainzRecord_Title", "MusicBrainzRecord", "Title");

            migrationBuilder.CreateIndex("IX_MusicBrainzRecordAcoustId_AcoustId_UniqueId"
                , "MusicBrainzRecordAcoustId"
                , "AcoustId_UniqueId");

            migrationBuilder.CreateIndex("IX_MusicBrainzRelease_TextRepresentation_UniqueId"
                , "MusicBrainzRelease"
                , "TextRepresentation_UniqueId");

            migrationBuilder.CreateIndex("IX_MusicBrainzRelease_Title", "MusicBrainzRelease", "Title");

            migrationBuilder.CreateIndex("IX_MusicBrainzRelease_UniqueHash", "MusicBrainzRelease", "UniqueHash", unique : true);

            migrationBuilder.CreateIndex("IX_MusicBrainzReleaseEvent_Area_UniqueId"
                , "MusicBrainzReleaseEvent"
                , "Area_UniqueId");

            migrationBuilder.CreateIndex("IX_MusicBrainzReleaseEvent_UniqueHash"
                , "MusicBrainzReleaseEvent"
                , "UniqueHash"
                , unique : true);

            migrationBuilder.CreateIndex("IX_MusicBrainzReleaseEventMusicBrainzRelease_MusicBrainzReleaseEvent_UniqueId"
                , "MusicBrainzReleaseEventMusicBrainzRelease"
                , "MusicBrainzReleaseEvent_UniqueId");

            migrationBuilder.CreateIndex("IX_MusicBrainzReleaseMusicBrainzAlias_MusicBrainzAlias_UniqueId"
                , "MusicBrainzReleaseMusicBrainzAlias"
                , "MusicBrainzAlias_UniqueId");

            migrationBuilder.CreateIndex("IX_MusicBrainzReleaseMusicBrainzArtistCredit_MusicBrainzArtistCredit_UniqueId"
                , "MusicBrainzReleaseMusicBrainzArtistCredit"
                , "MusicBrainzArtistCredit_UniqueId");

            migrationBuilder.CreateIndex("IX_MusicBrainzReleaseMusicBrainzRecord_MusicBrainzRecord_UniqueId"
                , "MusicBrainzReleaseMusicBrainzRecord"
                , "MusicBrainzRecord_UniqueId");

            migrationBuilder.CreateIndex("IX_MusicBrainzTag_UniqueHash", "MusicBrainzTag", "UniqueHash", unique : true);

            migrationBuilder.CreateIndex("IX_MusicBrainzTagMusicBrainzRecord_MusicBrainzRecord_UniqueId"
                , "MusicBrainzTagMusicBrainzRecord"
                , "MusicBrainzRecord_UniqueId");

            migrationBuilder.CreateIndex("IX_MusicBrainzTextRepresentation_UniqueHash"
                , "MusicBrainzTextRepresentation"
                , "UniqueHash"
                , unique : true);

            migrationBuilder.CreateIndex("IX_Track_FingerprintHash", "Track", "FingerprintHash");

            migrationBuilder.CreateIndex("IX_Track_LastAcoustIdApiCall", "Track", "LastAcoustIdApiCall");

            migrationBuilder.CreateIndex("IX_Track_LastFingerprintCalculation", "Track", "LastFingerprintCalculation");

            migrationBuilder.CreateIndex("IX_Track_Path", "Track", "Path", unique : true);

            migrationBuilder.CreateIndex("IX_User_Username", "User", "Username", unique : true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("AcoustIdResult");

            migrationBuilder.DropTable("MusicBrainzAliasMusicBrainzRecord");

            migrationBuilder.DropTable("MusicBrainzArtistCreditMusicBrainzRecord");

            migrationBuilder.DropTable("MusicBrainzArtistMusicBrainzAlias");

            migrationBuilder.DropTable("MusicBrainzIsoCodeMusicBrainzArea");

            migrationBuilder.DropTable("MusicBrainzRecordAcoustId");

            migrationBuilder.DropTable("MusicBrainzReleaseEventMusicBrainzRelease");

            migrationBuilder.DropTable("MusicBrainzReleaseMusicBrainzAlias");

            migrationBuilder.DropTable("MusicBrainzReleaseMusicBrainzArtistCredit");

            migrationBuilder.DropTable("MusicBrainzReleaseMusicBrainzRecord");

            migrationBuilder.DropTable("MusicBrainzTagMusicBrainzRecord");

            migrationBuilder.DropTable("User");

            migrationBuilder.DropTable("Track");

            migrationBuilder.DropTable("MusicBrainzIsoCode");

            migrationBuilder.DropTable("AcoustId");

            migrationBuilder.DropTable("MusicBrainzReleaseEvent");

            migrationBuilder.DropTable("MusicBrainzAlias");

            migrationBuilder.DropTable("MusicBrainzArtistCredit");

            migrationBuilder.DropTable("MusicBrainzRelease");

            migrationBuilder.DropTable("MusicBrainzRecord");

            migrationBuilder.DropTable("MusicBrainzTag");

            migrationBuilder.DropTable("MusicBrainzArea");

            migrationBuilder.DropTable("MusicBrainzArtist");

            migrationBuilder.DropTable("MusicBrainzTextRepresentation");
        }
    }
}