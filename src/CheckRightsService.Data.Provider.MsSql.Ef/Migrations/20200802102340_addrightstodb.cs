﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace LT.DigitalOffice.CheckRightsService.Data.Provider.MsSql.Ef.Migrations
{
    public partial class AddRightsToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Rights",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, null, "Add/Edit/Remove users" });

            migrationBuilder.InsertData(
                table: "Rights",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 2, null, "Add/Edit/Remove projects" });

            migrationBuilder.InsertData(
                table: "Rights",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 3, null, "Add/Edit/Remove email templates" });

            migrationBuilder.InsertData(
                table: "Rights",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 4, null, "Add/Edit/Remove departments" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Rights",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rights",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rights",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
               table: "Rights",
               keyColumn: "Id",
               keyValue: 4);
        }
    }
}
