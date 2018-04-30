using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ch.wuerth.tobias.mux.Data.Migrations
{
    public partial class _20180426T1053_Playlist : Migration
    {
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("PlaylistEntry");

            migrationBuilder.DropTable("PlaylistPermission");

            migrationBuilder.DropTable("Playlist");
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable("Playlist"
                , table => new
                {
                    UniqueId =
                    table.Column<Int32>(nullable : false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                    , CreateUserUniqueId = table.Column<Int32>(nullable : false)
                    , Name = table.Column<String>(maxLength : 64, nullable : false)
                }
                , constraints : table =>
                {
                    table.PrimaryKey("PK_Playlist", x => x.UniqueId);
                    table.ForeignKey("FK_Playlist_User_CreateUserUniqueId"
                        , x => x.CreateUserUniqueId
                        , "User"
                        , "UniqueId"
                        , onDelete : ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable("PlaylistEntry"
                , table => new
                {
                    UniqueId =
                    table.Column<Int32>(nullable : false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                    , CreateUserUniqueId = table.Column<Int32>(nullable : false)
                    , PlaylistUniqueId = table.Column<Int32>(nullable : false)
                    , Title = table.Column<String>(maxLength : 1024, nullable : false)
                    , TrackUniqueId = table.Column<Int32>(nullable : false)
                }
                , constraints : table =>
                {
                    table.PrimaryKey("PK_PlaylistEntry", x => x.UniqueId);
                    table.ForeignKey("FK_PlaylistEntry_User_CreateUserUniqueId"
                        , x => x.CreateUserUniqueId
                        , "User"
                        , "UniqueId"
                        , onDelete : ReferentialAction.NoAction);
                    table.ForeignKey("FK_PlaylistEntry_Playlist_PlaylistUniqueId"
                        , x => x.PlaylistUniqueId
                        , "Playlist"
                        , "UniqueId"
                        , onDelete : ReferentialAction.NoAction);
                    table.ForeignKey("FK_PlaylistEntry_Track_TrackUniqueId"
                        , x => x.TrackUniqueId
                        , "Track"
                        , "UniqueId"
                        , onDelete : ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable("PlaylistPermission"
                , table => new
                {
                    UniqueId =
                    table.Column<Int32>(nullable : false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                    , CanModify = table.Column<Boolean>(nullable : false)
                    , PlaylistUniqueId = table.Column<Int32>(nullable : false)
                    , UserUniqueId = table.Column<Int32>(nullable : false)
                }
                , constraints : table =>
                {
                    table.PrimaryKey("PK_PlaylistPermission", x => x.UniqueId);
                    table.ForeignKey("FK_PlaylistPermission_Playlist_PlaylistUniqueId"
                        , x => x.PlaylistUniqueId
                        , "Playlist"
                        , "UniqueId"
                        , onDelete : ReferentialAction.NoAction);
                    table.ForeignKey("FK_PlaylistPermission_User_UserUniqueId"
                        , x => x.UserUniqueId
                        , "User"
                        , "UniqueId"
                        , onDelete : ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex("IX_Playlist_CreateUserUniqueId", "Playlist", "CreateUserUniqueId");

            migrationBuilder.CreateIndex("IX_PlaylistEntry_CreateUserUniqueId", "PlaylistEntry", "CreateUserUniqueId");

            migrationBuilder.CreateIndex("IX_PlaylistEntry_PlaylistUniqueId", "PlaylistEntry", "PlaylistUniqueId");

            migrationBuilder.CreateIndex("IX_PlaylistEntry_TrackUniqueId", "PlaylistEntry", "TrackUniqueId");

            migrationBuilder.CreateIndex("IX_PlaylistPermission_PlaylistUniqueId", "PlaylistPermission", "PlaylistUniqueId");

            migrationBuilder.CreateIndex("IX_PlaylistPermission_UserUniqueId", "PlaylistPermission", "UserUniqueId");
        }
    }
}