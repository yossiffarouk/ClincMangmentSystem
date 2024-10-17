using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClinicManagement.Migrations
{
    /// <inheritdoc />
    public partial class FinalUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblAppointment_tblSchedualeAppointment_SchedualeAppointmentId",
                table: "tblAppointment");

            migrationBuilder.DropTable(
                name: "tblSchedualeAppointment");

            migrationBuilder.DropIndex(
                name: "IX_tblAppointment_SchedualeAppointmentId",
                table: "tblAppointment");

            migrationBuilder.DropColumn(
                name: "SchedualeAppointmentId",
                table: "tblAppointment");

            migrationBuilder.AddColumn<DateTime>(
                name: "Time",
                table: "tblAppointment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "tblAppointment",
                keyColumn: "Id",
                keyValue: 1,
                column: "Time",
                value: new DateTime(2024, 10, 18, 19, 30, 25, 594, DateTimeKind.Local).AddTicks(3739));

            migrationBuilder.UpdateData(
                table: "tblAppointment",
                keyColumn: "Id",
                keyValue: 2,
                column: "Time",
                value: new DateTime(2024, 10, 16, 19, 30, 25, 594, DateTimeKind.Local).AddTicks(3778));

            migrationBuilder.UpdateData(
                table: "tblAppointment",
                keyColumn: "Id",
                keyValue: 3,
                column: "Time",
                value: new DateTime(2024, 10, 16, 19, 30, 25, 594, DateTimeKind.Local).AddTicks(3781));

            migrationBuilder.UpdateData(
                table: "tblAppointment",
                keyColumn: "Id",
                keyValue: 4,
                column: "Time",
                value: new DateTime(2024, 10, 18, 19, 30, 25, 594, DateTimeKind.Local).AddTicks(3784));

            migrationBuilder.UpdateData(
                table: "tblAppointment",
                keyColumn: "Id",
                keyValue: 5,
                column: "Time",
                value: new DateTime(2024, 10, 22, 19, 30, 25, 594, DateTimeKind.Local).AddTicks(3788));

            migrationBuilder.UpdateData(
                table: "tblAppointment",
                keyColumn: "Id",
                keyValue: 6,
                column: "Time",
                value: new DateTime(2024, 10, 14, 19, 30, 25, 594, DateTimeKind.Local).AddTicks(3792));

            migrationBuilder.UpdateData(
                table: "tblAppointment",
                keyColumn: "Id",
                keyValue: 7,
                column: "Time",
                value: new DateTime(2024, 10, 19, 7, 30, 25, 594, DateTimeKind.Local).AddTicks(3795));

            migrationBuilder.UpdateData(
                table: "tblAppointment",
                keyColumn: "Id",
                keyValue: 8,
                column: "Time",
                value: new DateTime(2024, 10, 17, 7, 30, 25, 594, DateTimeKind.Local).AddTicks(3798));

            migrationBuilder.UpdateData(
                table: "tblAppointment",
                keyColumn: "Id",
                keyValue: 9,
                column: "Time",
                value: new DateTime(2024, 10, 17, 18, 15, 25, 594, DateTimeKind.Local).AddTicks(3801));

            migrationBuilder.UpdateData(
                table: "tblAppointment",
                keyColumn: "Id",
                keyValue: 10,
                column: "Time",
                value: new DateTime(2024, 10, 17, 20, 30, 25, 594, DateTimeKind.Local).AddTicks(3805));

            migrationBuilder.UpdateData(
                table: "tblAppointment",
                keyColumn: "Id",
                keyValue: 11,
                column: "Time",
                value: new DateTime(2024, 10, 17, 18, 30, 25, 594, DateTimeKind.Local).AddTicks(3808));

            migrationBuilder.UpdateData(
                table: "tblAppointment",
                keyColumn: "Id",
                keyValue: 12,
                column: "Time",
                value: new DateTime(2024, 10, 17, 21, 30, 25, 594, DateTimeKind.Local).AddTicks(3811));

            migrationBuilder.UpdateData(
                table: "tblAppointment",
                keyColumn: "Id",
                keyValue: 13,
                column: "Time",
                value: new DateTime(2024, 10, 15, 22, 30, 25, 594, DateTimeKind.Local).AddTicks(3814));

            migrationBuilder.UpdateData(
                table: "tblAppointment",
                keyColumn: "Id",
                keyValue: 14,
                column: "Time",
                value: new DateTime(2024, 10, 17, 23, 0, 25, 594, DateTimeKind.Local).AddTicks(3818));

            migrationBuilder.UpdateData(
                table: "tblAppointment",
                keyColumn: "Id",
                keyValue: 15,
                column: "Time",
                value: new DateTime(2024, 10, 18, 18, 30, 25, 594, DateTimeKind.Local).AddTicks(3821));

            migrationBuilder.UpdateData(
                table: "tblAppointment",
                keyColumn: "Id",
                keyValue: 16,
                column: "Time",
                value: new DateTime(2024, 10, 17, 16, 0, 25, 594, DateTimeKind.Local).AddTicks(3823));

            migrationBuilder.UpdateData(
                table: "tblAppointment",
                keyColumn: "Id",
                keyValue: 17,
                column: "Time",
                value: new DateTime(2024, 10, 17, 22, 0, 25, 594, DateTimeKind.Local).AddTicks(3826));

            migrationBuilder.UpdateData(
                table: "tblDoctor",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "z@ZQ$NBmjc");

            migrationBuilder.UpdateData(
                table: "tblDoctor",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "vTWkNQNKa#");

            migrationBuilder.UpdateData(
                table: "tblDoctor",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "x*~#lf&hQH");

            migrationBuilder.UpdateData(
                table: "tblDoctor",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "7s-k%f$@!_");

            migrationBuilder.UpdateData(
                table: "tblDoctor",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "M%A^LK)*i(");

            migrationBuilder.UpdateData(
                table: "tblDoctor",
                keyColumn: "Id",
                keyValue: 6,
                column: "Password",
                value: "4E3~gjH#^O");

            migrationBuilder.UpdateData(
                table: "tblDoctor",
                keyColumn: "Id",
                keyValue: 7,
                column: "Password",
                value: "*eKVlsmfU)");

            migrationBuilder.UpdateData(
                table: "tblDoctor",
                keyColumn: "Id",
                keyValue: 8,
                column: "Password",
                value: "p6-K%x_&jU");

            migrationBuilder.UpdateData(
                table: "tblPrescreption",
                keyColumn: "Id",
                keyValue: 1,
                column: "Duration_of_treatment",
                value: "7 days");

            migrationBuilder.UpdateData(
                table: "tblPrescreption",
                keyColumn: "Id",
                keyValue: 2,
                column: "Duration_of_treatment",
                value: "10 days");

            migrationBuilder.UpdateData(
                table: "tblPrescreption",
                keyColumn: "Id",
                keyValue: 3,
                column: "Duration_of_treatment",
                value: "5 days");

            migrationBuilder.UpdateData(
                table: "tblPrescreption",
                keyColumn: "Id",
                keyValue: 4,
                column: "Duration_of_treatment",
                value: "30 days");

            migrationBuilder.UpdateData(
                table: "tblPrescreption",
                keyColumn: "Id",
                keyValue: 5,
                column: "Duration_of_treatment",
                value: "60 days");

            migrationBuilder.UpdateData(
                table: "tblPrescreption",
                keyColumn: "Id",
                keyValue: 6,
                column: "Duration_of_treatment",
                value: "90 days");

            migrationBuilder.UpdateData(
                table: "tblPrescreption",
                keyColumn: "Id",
                keyValue: 7,
                column: "Duration_of_treatment",
                value: "120 days");

            migrationBuilder.UpdateData(
                table: "tblPrescreption",
                keyColumn: "Id",
                keyValue: 8,
                column: "Duration_of_treatment",
                value: "14 days");

            migrationBuilder.UpdateData(
                table: "tblPrescreption",
                keyColumn: "Id",
                keyValue: 9,
                column: "Duration_of_treatment",
                value: "180 days");

            migrationBuilder.UpdateData(
                table: "tblPrescreption",
                keyColumn: "Id",
                keyValue: 10,
                column: "Duration_of_treatment",
                value: "30 days");

            migrationBuilder.UpdateData(
                table: "tblPrescreption",
                keyColumn: "Id",
                keyValue: 11,
                column: "Duration_of_treatment",
                value: "60 days");

            migrationBuilder.UpdateData(
                table: "tblPrescreption",
                keyColumn: "Id",
                keyValue: 12,
                column: "Duration_of_treatment",
                value: "90 days");

            migrationBuilder.UpdateData(
                table: "tblPrescreption",
                keyColumn: "Id",
                keyValue: 13,
                column: "Duration_of_treatment",
                value: "120 days");

            migrationBuilder.UpdateData(
                table: "tblPrescreption",
                keyColumn: "Id",
                keyValue: 14,
                column: "Duration_of_treatment",
                value: "60 days");

            migrationBuilder.UpdateData(
                table: "tblPrescreption",
                keyColumn: "Id",
                keyValue: 15,
                column: "Duration_of_treatment",
                value: "30 days");

            migrationBuilder.UpdateData(
                table: "tblPrescreption",
                keyColumn: "Id",
                keyValue: 16,
                column: "Duration_of_treatment",
                value: "90 days");

            migrationBuilder.UpdateData(
                table: "tblPrescreption",
                keyColumn: "Id",
                keyValue: 17,
                column: "Duration_of_treatment",
                value: "120 days");

            migrationBuilder.UpdateData(
                table: "tblPrescreption",
                keyColumn: "Id",
                keyValue: 18,
                column: "Duration_of_treatment",
                value: "180 days");

            migrationBuilder.UpdateData(
                table: "tblPrescreption",
                keyColumn: "Id",
                keyValue: 19,
                column: "Duration_of_treatment",
                value: "30 days");

            migrationBuilder.UpdateData(
                table: "tblPrescreption",
                keyColumn: "Id",
                keyValue: 20,
                column: "Duration_of_treatment",
                value: "60 days");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Time",
                table: "tblAppointment");

            migrationBuilder.AddColumn<int>(
                name: "SchedualeAppointmentId",
                table: "tblAppointment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "tblSchedualeAppointment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSchedualeAppointment", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "tblAppointment",
                keyColumn: "Id",
                keyValue: 1,
                column: "SchedualeAppointmentId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "tblAppointment",
                keyColumn: "Id",
                keyValue: 2,
                column: "SchedualeAppointmentId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "tblAppointment",
                keyColumn: "Id",
                keyValue: 3,
                column: "SchedualeAppointmentId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "tblAppointment",
                keyColumn: "Id",
                keyValue: 4,
                column: "SchedualeAppointmentId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "tblAppointment",
                keyColumn: "Id",
                keyValue: 5,
                column: "SchedualeAppointmentId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "tblAppointment",
                keyColumn: "Id",
                keyValue: 6,
                column: "SchedualeAppointmentId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "tblAppointment",
                keyColumn: "Id",
                keyValue: 7,
                column: "SchedualeAppointmentId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "tblAppointment",
                keyColumn: "Id",
                keyValue: 8,
                column: "SchedualeAppointmentId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "tblAppointment",
                keyColumn: "Id",
                keyValue: 9,
                column: "SchedualeAppointmentId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "tblAppointment",
                keyColumn: "Id",
                keyValue: 10,
                column: "SchedualeAppointmentId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "tblAppointment",
                keyColumn: "Id",
                keyValue: 11,
                column: "SchedualeAppointmentId",
                value: 11);

            migrationBuilder.UpdateData(
                table: "tblAppointment",
                keyColumn: "Id",
                keyValue: 12,
                column: "SchedualeAppointmentId",
                value: 12);

            migrationBuilder.UpdateData(
                table: "tblAppointment",
                keyColumn: "Id",
                keyValue: 13,
                column: "SchedualeAppointmentId",
                value: 13);

            migrationBuilder.UpdateData(
                table: "tblAppointment",
                keyColumn: "Id",
                keyValue: 14,
                column: "SchedualeAppointmentId",
                value: 14);

            migrationBuilder.UpdateData(
                table: "tblAppointment",
                keyColumn: "Id",
                keyValue: 15,
                column: "SchedualeAppointmentId",
                value: 15);

            migrationBuilder.UpdateData(
                table: "tblAppointment",
                keyColumn: "Id",
                keyValue: 16,
                column: "SchedualeAppointmentId",
                value: 16);

            migrationBuilder.UpdateData(
                table: "tblAppointment",
                keyColumn: "Id",
                keyValue: 17,
                column: "SchedualeAppointmentId",
                value: 17);

            migrationBuilder.UpdateData(
                table: "tblDoctor",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "@8#y0P#tb*");

            migrationBuilder.UpdateData(
                table: "tblDoctor",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "cad37OTyo&");

            migrationBuilder.UpdateData(
                table: "tblDoctor",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "I~$b@QbIsp");

            migrationBuilder.UpdateData(
                table: "tblDoctor",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "%PyAFX7XeW");

            migrationBuilder.UpdateData(
                table: "tblDoctor",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "3%V5wuw8o6");

            migrationBuilder.UpdateData(
                table: "tblDoctor",
                keyColumn: "Id",
                keyValue: 6,
                column: "Password",
                value: ")80%-eeN!&");

            migrationBuilder.UpdateData(
                table: "tblDoctor",
                keyColumn: "Id",
                keyValue: 7,
                column: "Password",
                value: "F*$N6t5k$G");

            migrationBuilder.UpdateData(
                table: "tblDoctor",
                keyColumn: "Id",
                keyValue: 8,
                column: "Password",
                value: "2ys5tE6EC$");

            migrationBuilder.UpdateData(
                table: "tblPrescreption",
                keyColumn: "Id",
                keyValue: 1,
                column: "Duration_of_treatment",
                value: null);

            migrationBuilder.UpdateData(
                table: "tblPrescreption",
                keyColumn: "Id",
                keyValue: 2,
                column: "Duration_of_treatment",
                value: null);

            migrationBuilder.UpdateData(
                table: "tblPrescreption",
                keyColumn: "Id",
                keyValue: 3,
                column: "Duration_of_treatment",
                value: null);

            migrationBuilder.UpdateData(
                table: "tblPrescreption",
                keyColumn: "Id",
                keyValue: 4,
                column: "Duration_of_treatment",
                value: null);

            migrationBuilder.UpdateData(
                table: "tblPrescreption",
                keyColumn: "Id",
                keyValue: 5,
                column: "Duration_of_treatment",
                value: null);

            migrationBuilder.UpdateData(
                table: "tblPrescreption",
                keyColumn: "Id",
                keyValue: 6,
                column: "Duration_of_treatment",
                value: null);

            migrationBuilder.UpdateData(
                table: "tblPrescreption",
                keyColumn: "Id",
                keyValue: 7,
                column: "Duration_of_treatment",
                value: null);

            migrationBuilder.UpdateData(
                table: "tblPrescreption",
                keyColumn: "Id",
                keyValue: 8,
                column: "Duration_of_treatment",
                value: null);

            migrationBuilder.UpdateData(
                table: "tblPrescreption",
                keyColumn: "Id",
                keyValue: 9,
                column: "Duration_of_treatment",
                value: null);

            migrationBuilder.UpdateData(
                table: "tblPrescreption",
                keyColumn: "Id",
                keyValue: 10,
                column: "Duration_of_treatment",
                value: null);

            migrationBuilder.UpdateData(
                table: "tblPrescreption",
                keyColumn: "Id",
                keyValue: 11,
                column: "Duration_of_treatment",
                value: null);

            migrationBuilder.UpdateData(
                table: "tblPrescreption",
                keyColumn: "Id",
                keyValue: 12,
                column: "Duration_of_treatment",
                value: null);

            migrationBuilder.UpdateData(
                table: "tblPrescreption",
                keyColumn: "Id",
                keyValue: 13,
                column: "Duration_of_treatment",
                value: null);

            migrationBuilder.UpdateData(
                table: "tblPrescreption",
                keyColumn: "Id",
                keyValue: 14,
                column: "Duration_of_treatment",
                value: null);

            migrationBuilder.UpdateData(
                table: "tblPrescreption",
                keyColumn: "Id",
                keyValue: 15,
                column: "Duration_of_treatment",
                value: null);

            migrationBuilder.UpdateData(
                table: "tblPrescreption",
                keyColumn: "Id",
                keyValue: 16,
                column: "Duration_of_treatment",
                value: null);

            migrationBuilder.UpdateData(
                table: "tblPrescreption",
                keyColumn: "Id",
                keyValue: 17,
                column: "Duration_of_treatment",
                value: null);

            migrationBuilder.UpdateData(
                table: "tblPrescreption",
                keyColumn: "Id",
                keyValue: 18,
                column: "Duration_of_treatment",
                value: null);

            migrationBuilder.UpdateData(
                table: "tblPrescreption",
                keyColumn: "Id",
                keyValue: 19,
                column: "Duration_of_treatment",
                value: null);

            migrationBuilder.UpdateData(
                table: "tblPrescreption",
                keyColumn: "Id",
                keyValue: 20,
                column: "Duration_of_treatment",
                value: null);

            migrationBuilder.InsertData(
                table: "tblSchedualeAppointment",
                columns: new[] { "Id", "Time" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 18, 19, 12, 59, 599, DateTimeKind.Local).AddTicks(8349) },
                    { 2, new DateTime(2024, 10, 16, 19, 12, 59, 599, DateTimeKind.Local).AddTicks(8389) },
                    { 3, new DateTime(2024, 10, 16, 19, 12, 59, 599, DateTimeKind.Local).AddTicks(8392) },
                    { 4, new DateTime(2024, 10, 18, 19, 12, 59, 599, DateTimeKind.Local).AddTicks(8395) },
                    { 5, new DateTime(2024, 10, 22, 19, 12, 59, 599, DateTimeKind.Local).AddTicks(8397) },
                    { 6, new DateTime(2024, 10, 14, 19, 12, 59, 599, DateTimeKind.Local).AddTicks(8401) },
                    { 7, new DateTime(2024, 10, 19, 7, 12, 59, 599, DateTimeKind.Local).AddTicks(8403) },
                    { 8, new DateTime(2024, 10, 17, 7, 12, 59, 599, DateTimeKind.Local).AddTicks(8406) },
                    { 9, new DateTime(2024, 10, 17, 17, 57, 59, 599, DateTimeKind.Local).AddTicks(8409) },
                    { 10, new DateTime(2024, 10, 18, 19, 12, 59, 599, DateTimeKind.Local).AddTicks(8413) },
                    { 11, new DateTime(2024, 10, 16, 19, 12, 59, 599, DateTimeKind.Local).AddTicks(8415) },
                    { 12, new DateTime(2024, 10, 19, 19, 12, 59, 599, DateTimeKind.Local).AddTicks(8418) },
                    { 13, new DateTime(2024, 10, 17, 18, 27, 59, 599, DateTimeKind.Local).AddTicks(8420) },
                    { 14, new DateTime(2024, 10, 21, 7, 12, 59, 599, DateTimeKind.Local).AddTicks(8423) },
                    { 15, new DateTime(2024, 10, 17, 19, 35, 59, 599, DateTimeKind.Local).AddTicks(8426) },
                    { 16, new DateTime(2024, 10, 17, 15, 42, 59, 599, DateTimeKind.Local).AddTicks(8428) },
                    { 17, new DateTime(2024, 10, 15, 7, 12, 59, 599, DateTimeKind.Local).AddTicks(8431) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblAppointment_SchedualeAppointmentId",
                table: "tblAppointment",
                column: "SchedualeAppointmentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tblAppointment_tblSchedualeAppointment_SchedualeAppointmentId",
                table: "tblAppointment",
                column: "SchedualeAppointmentId",
                principalTable: "tblSchedualeAppointment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
