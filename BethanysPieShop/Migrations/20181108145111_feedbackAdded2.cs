using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BethanysPieShop.Migrations
{
    public partial class feedbackAdded2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ComtactMe",
                table: "Feedbacks",
                newName: "ContactMe");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ContactMe",
                table: "Feedbacks",
                newName: "ComtactMe");
        }
    }
}
