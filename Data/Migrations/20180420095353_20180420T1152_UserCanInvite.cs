using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ch.wuerth.tobias.mux.Data.Migrations
{
    public partial class _20180420T1152_UserCanInvite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Boolean>("CanInvite", "User", nullable : false, defaultValue : false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn("CanInvite", "User");
        }
    }
}