﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospitality.Identity.Data.Migrations
{
<<<<<<<< HEAD:src/Hospitality.Identity.Data/Migrations/20221006091535_init.cs
    public partial class init : Migration
========
    public partial class initial : Migration
>>>>>>>> ExaminationTypeChange:src/Hospitality.Identity.Data/Migrations/20221006115136_initial.cs
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
<<<<<<<< HEAD:src/Hospitality.Identity.Data/Migrations/20221006091535_init.cs
                    { "5dda6473-4e0e-4aa0-8fc5-12a14d6fb8c6", "d3e79d9d-cad5-417f-bf5a-584a35203611", "Doctor", "DOCTOR" },
                    { "fb37470a-e9ba-4db6-ac77-36068236fcdd", "4b18777b-d294-4a45-8889-5f0e807596de", "Receptionist", "RECEPTIONIST" }
========
                    { "14744a2e-94bb-4810-886f-a6b2c94e431b", "bc73cf08-c01f-4c70-8583-a80f25e797a7", "Receptionist", "RECEPTIONIST" },
                    { "466a21fd-72e1-48df-9596-c5d29a857391", "79ceeccd-438e-4c49-a458-2dee59e263f9", "Doctor", "DOCTOR" }
>>>>>>>> ExaminationTypeChange:src/Hospitality.Identity.Data/Migrations/20221006115136_initial.cs
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
<<<<<<<< HEAD:src/Hospitality.Identity.Data/Migrations/20221006091535_init.cs
                    { "a39c518b-2174-4a12-8ba6-9212b21a800d", 0, "faedb380-d6bc-44ad-9271-a0df6c67e420", "receptionist", false, false, null, "RECEPTIONIST", null, "AQAAAAEAACcQAAAAEFCaG77SFb3WEhKEE/uBYxl/fj5lnDi2kiv1CaDUo/Cggf7wjUUJK+v/wQDv+Aw+6w==", null, false, "4780b93f-11d3-493b-8dda-fc166a6196c6", false, "Danuta Nowak" },
                    { "bfa6e69c-054b-4c13-a38a-cda77dd8d713", 0, "d0862d16-fe7a-44d5-96c4-cec929a013e7", "doctor", false, false, null, "DOCTOR", null, "AQAAAAEAACcQAAAAEHVOqYsH8aGrFpZMWcfpZ4NankrP83IbNLW4SWL3AAJfOIqgGjEq7gMSDpXlEwQNmQ==", null, false, "9dd3aa4f-047d-4b4a-9aeb-7ad29ddf04d6", false, "Dr. House" }
========
                    { "1e4fcfcc-2095-4de9-a254-ff810ea082be", 0, "d39bf3f5-7b05-4288-a174-3191fae2ed20", "receptionist", false, false, null, "RECEPTIONIST", null, "AQAAAAEAACcQAAAAEAN1HqzyvTO77LRifcMzRvr45UStX8eZkb4BHAjFY/Qkdbpo7wczin5uvFbmp6HJeQ==", null, false, "50ee14ce-75be-4ca1-a2b3-4684107f1899", false, "Danuta Nowak" },
                    { "bab7096a-2eaa-42e7-8733-70908f272c41", 0, "325be775-8e4f-4ef1-9c23-95246ef900ff", "doctor", false, false, null, "DOCTOR", null, "AQAAAAEAACcQAAAAEFWFlujeGkMhSN6IhqXgyVJ65hiurpUeI42aNZqAXJDY2Ax+6fL2/q85+HoPVrCdnQ==", null, false, "d97d67e5-83d6-4019-a715-636c27614ac6", false, "Dr. House" }
>>>>>>>> ExaminationTypeChange:src/Hospitality.Identity.Data/Migrations/20221006115136_initial.cs
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
<<<<<<<< HEAD:src/Hospitality.Identity.Data/Migrations/20221006091535_init.cs
                values: new object[] { "fb37470a-e9ba-4db6-ac77-36068236fcdd", "a39c518b-2174-4a12-8ba6-9212b21a800d" });
========
                values: new object[] { "14744a2e-94bb-4810-886f-a6b2c94e431b", "1e4fcfcc-2095-4de9-a254-ff810ea082be" });
>>>>>>>> ExaminationTypeChange:src/Hospitality.Identity.Data/Migrations/20221006115136_initial.cs

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
<<<<<<<< HEAD:src/Hospitality.Identity.Data/Migrations/20221006091535_init.cs
                values: new object[] { "5dda6473-4e0e-4aa0-8fc5-12a14d6fb8c6", "bfa6e69c-054b-4c13-a38a-cda77dd8d713" });
========
                values: new object[] { "466a21fd-72e1-48df-9596-c5d29a857391", "bab7096a-2eaa-42e7-8733-70908f272c41" });
>>>>>>>> ExaminationTypeChange:src/Hospitality.Identity.Data/Migrations/20221006115136_initial.cs

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
