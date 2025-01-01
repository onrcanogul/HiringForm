using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace HiringForm.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Applicants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    Surname = table.Column<string>(type: "longtext", nullable: false),
                    Birthplace = table.Column<string>(type: "longtext", nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Gender = table.Column<string>(type: "longtext", nullable: false),
                    MaritalStatus = table.Column<string>(type: "longtext", nullable: false),
                    Address = table.Column<string>(type: "longtext", nullable: false),
                    City = table.Column<string>(type: "longtext", nullable: false),
                    Phone = table.Column<string>(type: "longtext", nullable: false),
                    Email = table.Column<string>(type: "longtext", nullable: false),
                    OtherProgrammingLanguages = table.Column<string>(type: "longtext", nullable: false),
                    Tools = table.Column<string>(type: "longtext", nullable: false),
                    NumberOfLanguages = table.Column<int>(type: "int", nullable: false),
                    AdditionalNotes = table.Column<string>(type: "longtext", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    KpssGrade = table.Column<double>(type: "double", nullable: false),
                    EnglishLevel = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicants", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Educations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    SchoolName = table.Column<string>(type: "longtext", nullable: false),
                    City = table.Column<string>(type: "longtext", nullable: false),
                    TimePeriod = table.Column<string>(type: "longtext", nullable: false),
                    Degree = table.Column<string>(type: "longtext", nullable: false),
                    ApplicantId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Educations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Educations_Applicants_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicants",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Internships",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CompanyName = table.Column<string>(type: "longtext", nullable: false),
                    Sector = table.Column<string>(type: "longtext", nullable: false),
                    Position = table.Column<string>(type: "longtext", nullable: false),
                    Duration = table.Column<string>(type: "longtext", nullable: false),
                    ApplicantId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Internships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Internships_Applicants_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicants",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "KnownLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ApplicantId = table.Column<int>(type: "int", nullable: false),
                    Language = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KnownLanguages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KnownLanguages_Applicants_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProgrammingLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ApplicantId = table.Column<int>(type: "int", nullable: false),
                    Language = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgrammingLanguages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgrammingLanguages_Applicants_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WorkExperiences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Experience = table.Column<int>(type: "int", nullable: false),
                    CompanyName = table.Column<string>(type: "longtext", nullable: false),
                    Sector = table.Column<string>(type: "longtext", nullable: false),
                    Position = table.Column<string>(type: "longtext", nullable: false),
                    Duration = table.Column<string>(type: "longtext", nullable: false),
                    ApplicantId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkExperiences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkExperiences_Applicants_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicants",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_ApplicantId",
                table: "Educations",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_Internships_ApplicantId",
                table: "Internships",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_KnownLanguages_ApplicantId",
                table: "KnownLanguages",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgrammingLanguages_ApplicantId",
                table: "ProgrammingLanguages",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkExperiences_ApplicantId",
                table: "WorkExperiences",
                column: "ApplicantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Educations");

            migrationBuilder.DropTable(
                name: "Internships");

            migrationBuilder.DropTable(
                name: "KnownLanguages");

            migrationBuilder.DropTable(
                name: "ProgrammingLanguages");

            migrationBuilder.DropTable(
                name: "WorkExperiences");

            migrationBuilder.DropTable(
                name: "Applicants");
        }
    }
}
