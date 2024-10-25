using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicManagement.Migrations
{
    /// <inheritdoc />
    public partial class yossefaddmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblDepartment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    DepartmentName = table.Column<string>(type: "Varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDepartment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblOffice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false),
                    Address = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblOffice", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblPatient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Address = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPatient", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblDoctor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Password = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    officeId = table.Column<int>(type: "int", nullable: true),
                    DeptId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDoctor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblDoctor_tblDepartment_DeptId",
                        column: x => x.DeptId,
                        principalTable: "tblDepartment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblDoctor_tblOffice_officeId",
                        column: x => x.officeId,
                        principalTable: "tblOffice",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tblAppointment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CauseOfDisease = table.Column<string>(name: "Cause Of Disease", type: "Varchar(50)", maxLength: 50, nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "Decimal(15,2)", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAppointment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblAppointment_tblDoctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "tblDoctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblAppointment_tblPatient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "tblPatient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblPrescreption",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    medicationName = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false),
                    instructions = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Durationoftreatment = table.Column<string>(name: "Duration_of_treatment", type: "varchar(50)", maxLength: 50, nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPrescreption", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblPrescreption_tblDoctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "tblDoctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblPrescreption_tblPatient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "tblPatient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblSchedualeTime",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    DoctorComeIn = table.Column<TimeSpan>(type: "time", nullable: false),
                    DoctorLeaveIn = table.Column<TimeSpan>(type: "time", nullable: false),
                    Day = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSchedualeTime", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblSchedualeTime_tblDoctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "tblDoctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblAppointment_DoctorId",
                table: "tblAppointment",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_tblAppointment_PatientId",
                table: "tblAppointment",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_tblDoctor_DeptId",
                table: "tblDoctor",
                column: "DeptId");

            migrationBuilder.CreateIndex(
                name: "IX_tblDoctor_officeId",
                table: "tblDoctor",
                column: "officeId",
                unique: true,
                filter: "[officeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tblPrescreption_DoctorId",
                table: "tblPrescreption",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_tblPrescreption_PatientId",
                table: "tblPrescreption",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_tblSchedualeTime_DoctorId",
                table: "tblSchedualeTime",
                column: "DoctorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblAppointment");

            migrationBuilder.DropTable(
                name: "tblPrescreption");

            migrationBuilder.DropTable(
                name: "tblSchedualeTime");

            migrationBuilder.DropTable(
                name: "tblPatient");

            migrationBuilder.DropTable(
                name: "tblDoctor");

            migrationBuilder.DropTable(
                name: "tblDepartment");

            migrationBuilder.DropTable(
                name: "tblOffice");
        }
    }
}
