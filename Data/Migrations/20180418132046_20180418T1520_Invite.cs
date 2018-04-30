using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ch.wuerth.tobias.mux.Data.Migrations
{
    public partial class _20180418T1520_Invite : Migration
    {
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey("FK_User_Invite_InviteUniqueId", "User");

            migrationBuilder.DropTable("Invite");

            migrationBuilder.DropIndex("IX_User_InviteUniqueId", "User");

            migrationBuilder.DropColumn("InviteUniqueId", "User");
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Int32>("InviteUniqueId", "User", nullable : true);

            migrationBuilder.CreateTable("Invite"
                , table => new
                {
                    UniqueId =
                    table.Column<Int32>(nullable : false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                    , CreateDate = table.Column<DateTime>(nullable : false)
                    , CreateUserUniqueId = table.Column<Int32>(nullable : false)
                    , ExpirationDate = table.Column<DateTime>(nullable : false)
                    , Token = table.Column<String>(maxLength : 16, nullable : false)
                }
                , constraints : table =>
                {
                    table.PrimaryKey("PK_Invite", x => x.UniqueId);
                    table.ForeignKey("FK_Invite_User_CreateUserUniqueId"
                        , x => x.CreateUserUniqueId
                        , "User"
                        , "UniqueId"
                        , onDelete : ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex("IX_User_InviteUniqueId"
                , "User"
                , "InviteUniqueId"
                , unique : true
                , filter : "[InviteUniqueId] IS NOT NULL");

            migrationBuilder.CreateIndex("IX_Invite_CreateUserUniqueId", "Invite", "CreateUserUniqueId");

            migrationBuilder.AddForeignKey("FK_User_Invite_InviteUniqueId"
                , "User"
                , "InviteUniqueId"
                , "Invite"
                , principalColumn : "UniqueId"
                , onDelete : ReferentialAction.Restrict);
        }
    }
}