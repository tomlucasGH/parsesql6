using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ParseSQL6.Migrations
{
    public partial class OptimizeDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "columnidentifiers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    asciiend = table.Column<int>(nullable: false),
                    asciistart = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_columnidentifiers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "datasources",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    image_uri = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_datasources", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Query",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    QueryText = table.Column<string>(nullable: true),
                    customerid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Query", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "columnlist",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ColumnName = table.Column<string>(nullable: true),
                    QueryID = table.Column<int>(nullable: false),
                    TableName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_columnlist", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "whereclause",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ColumnName = table.Column<string>(nullable: true),
                    QueryID = table.Column<int>(nullable: false),
                    TableName = table.Column<string>(nullable: true),
                    comparison_operator = table.Column<string>(nullable: true),
                    comparison_value = table.Column<string>(nullable: true),
                    function_name = table.Column<string>(nullable: true),
                    function_string = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_whereclause", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Tables",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AliasName = table.Column<string>(nullable: true),
                    DB = table.Column<string>(nullable: true),
                    QueryMasterID = table.Column<int>(nullable: true),
                    QueryMasterID1 = table.Column<int>(nullable: true),
                    TableName = table.Column<string>(nullable: true),
                    owner = table.Column<string>(nullable: true),
                    queryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tables", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tables_Query_QueryMasterID",
                        column: x => x.QueryMasterID,
                        principalTable: "Query",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tables_Query_QueryMasterID1",
                        column: x => x.QueryMasterID1,
                        principalTable: "Query",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tables_QueryMasterID",
                table: "Tables",
                column: "QueryMasterID");

            migrationBuilder.CreateIndex(
                name: "IX_Tables_QueryMasterID1",
                table: "Tables",
                column: "QueryMasterID1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "columnidentifiers");

            migrationBuilder.DropTable(
                name: "datasources");

            migrationBuilder.DropTable(
                name: "columnlist");

            migrationBuilder.DropTable(
                name: "Tables");

            migrationBuilder.DropTable(
                name: "whereclause");

            migrationBuilder.DropTable(
                name: "Query");
        }
    }
}
