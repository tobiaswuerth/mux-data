using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ch.wuerth.tobias.mux.Data.Migrations
{
    public partial class _20180430T2012 : Migration
    {
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<String>("Title"
                , "MusicBrainzRecord"
                , maxLength : 255
                , nullable : true
                , oldClrType : typeof(String)
                , oldMaxLength : 1024
                , oldNullable : true);
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<String>("Title"
                , "MusicBrainzRecord"
                , maxLength : 1024
                , nullable : true
                , oldClrType : typeof(String)
                , oldMaxLength : 255
                , oldNullable : true);
        }
    }
}