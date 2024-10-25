using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClinicManagement.Migrations
{
    /// <inheritdoc />
    public partial class finalVersion : Migration
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
                name: "tblAppointments",
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
                    table.PrimaryKey("PK_tblAppointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblAppointments_tblDoctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "tblDoctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblAppointments_tblPatient_PatientId",
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
                    StartTime = table.Column<TimeSpan>(type: "Time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "Time", nullable: false),
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

            migrationBuilder.InsertData(
                table: "tblDepartment",
                columns: new[] { "Id", "DepartmentName" },
                values: new object[,]
                {
                    { 1, "Cardiology" },
                    { 2, "Dermatology" },
                    { 3, "Orthopedics" },
                    { 4, "Pediatrics" },
                    { 5, "Neurology" },
                    { 6, "Oncology" },
                    { 7, "Radiology" },
                    { 8, "Endocrimology" }
                });

            migrationBuilder.InsertData(
                table: "tblOffice",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[,]
                {
                    { 1, "First-Floor", "Off11-A" },
                    { 2, "First-Floor", "Off12-A" },
                    { 3, "First-Floor", "Off13-A" },
                    { 4, "Second-Floor", "Off21-B" },
                    { 5, "Second-Floor", "Off22-B" },
                    { 6, "Second-Floor", "Off23-B" }
                });

            migrationBuilder.InsertData(
                table: "tblPatient",
                columns: new[] { "Id", "Address", "Age", "Name", "Phone", "gender" },
                values: new object[,]
                {
                    { 1, "Cairo, Egypt", 28, "Ahmed Ali", "+201011223344", "Male" },
                    { 2, "Alexandria, Egypt", 25, "Mona Hamed", "+201022334455", "Female" },
                    { 3, "Giza, Egypt", 32, "Khaled Hassan", "+201033445566", "Male" },
                    { 4, "Aswan, Egypt", 24, "Sara Ibrahim", "+201244556677", "Female" },
                    { 5, "Luxor, Egypt", 30, "Mahmoud Farouk", "+201055667788", "Male" },
                    { 6, "Mansoura, Egypt", 27, "Yasmine Khalil", "+211066778899", "Female" },
                    { 7, "Port Said, Egypt", 35, "Omar Saeed", "+201077889900", "Male" },
                    { 8, "Suez, Egypt", 29, "Aya Mostafa", "+201588990011", "Female" },
                    { 9, "Ismailia, Egypt", 33, "Tamer Magdy", "+201099001122", "Male" },
                    { 10, "Zagazig, Egypt", 26, "Nourhan Adel", "+201511122233", "Female" },
                    { 11, "Fayoum, Egypt", 34, "Amr Reda", "+201122233344", "Male" },
                    { 12, "Beni Suef, Egypt", 28, "Rana Sameh", "+201033344455", "Female" },
                    { 13, "Minya, Egypt", 31, "Hossam Naguib", "+201044455566", "Male" },
                    { 14, "Assiut, Egypt", 23, "Mariam Fathi", "+201255566677", "Female" },
                    { 15, "Sohag, Egypt", 36, "Mostafa Amin", "+201066677788", "Male" }
                });

            migrationBuilder.InsertData(
                table: "tblDoctor",
                columns: new[] { "Id", "DeptId", "Email", "Name", "Password", "Phone", "officeId" },
                values: new object[,]
                {
                    { 1, 1, "Ahmed.Tharwat@clinic.com", "Dr. Ahmed Tharwat", "YV56ZjRGQFd+aV4y", "+201022812243", 1 },
                    { 2, 2, "Esraa.Zaki@clinic.com", "Dr. Esraa Zaki", "QiMmVUtKMFchdTE0", "+201155698835", 2 },
                    { 3, 3, "Ahmed.Khaled@clinic.com", "Dr. Ahmed Khaled", "TV9vbXhANzVGYl5l", "+201012345678", 3 },
                    { 4, 4, "Fatima.Hassan@clinic.com", "Dr. Fatima Hassan", "b1FWdCQ2dX4mRG41", "+201198765432", 4 },
                    { 5, 5, "Mohamed.Ali@clinic.com", "Dr. Mohamed Ali", "cGR1Z15wYWVXbX4x", "+201234567890", null },
                    { 6, 6, "Sara.Mohamed@clinic.com", "Dr. Sara Mohamed", "N2hkMn4hRChWTWIp", "+201512345678", null },
                    { 7, 7, "Omar.Mostafa@clinic.com", "Dr. Omar Mostafa", "T1FBJWtfN1NqQW9R", "+201146890012", 5 },
                    { 8, 8, "Mohamed.AbdEl-Hameed@clinic.com", "Dr. Mohamed AdbEL-Hameed", "OVp3NChKZm4jZ1Bu", "+201014501522", 6 },
                    { 9, 4, "AhmedIssam@gmail.com", "Dr. Ahmed Issam", "NFUmJCZPKiVqOUpU", "+201001626756", null },
                    { 10, 6, "MohamedTawfiq@gmail.com", "Dr. Mohamed Tawfiq", "TksoKGkxJnVpKCFk", "+201557945331", null }
                });

            migrationBuilder.InsertData(
                table: "tblAppointments",
                columns: new[] { "Id", "DoctorId", "PatientId", "Price", "Cause Of Disease", "State", "Time" },
                values: new object[,]
                {
                    { 1, 1, 1, 100m, "Routine check-up", "schedule", new DateTime(2024, 10, 24, 18, 41, 58, 632, DateTimeKind.Local).AddTicks(7351) },
                    { 2, 2, 2, 80m, "Flu symptoms", "completed", new DateTime(2024, 10, 22, 18, 41, 58, 632, DateTimeKind.Local).AddTicks(7386) },
                    { 3, 1, 3, 120m, "Back pain", "completed", new DateTime(2024, 10, 22, 18, 41, 58, 632, DateTimeKind.Local).AddTicks(7389) },
                    { 4, 3, 5, 200m, "Dental check-up", "schedule", new DateTime(2024, 10, 24, 18, 41, 58, 632, DateTimeKind.Local).AddTicks(7392) },
                    { 5, 2, 5, 90m, "Skin rash", "schedule", new DateTime(2024, 10, 28, 18, 41, 58, 632, DateTimeKind.Local).AddTicks(7394) },
                    { 6, 4, 6, 75m, "Eye examination", "completed", new DateTime(2024, 10, 20, 18, 41, 58, 632, DateTimeKind.Local).AddTicks(7398) },
                    { 7, 1, 7, 150m, "Physical therapy", "schedule", new DateTime(2024, 10, 25, 6, 41, 58, 632, DateTimeKind.Local).AddTicks(7401) },
                    { 8, 2, 8, 60m, "Cold and cough", "completed", new DateTime(2024, 10, 23, 6, 41, 58, 632, DateTimeKind.Local).AddTicks(7403) },
                    { 9, 3, 9, 110m, "Annual check-up", "completed", new DateTime(2024, 10, 23, 17, 26, 58, 632, DateTimeKind.Local).AddTicks(7405) },
                    { 10, 4, 10, 250m, "Chest pain", "schedule", new DateTime(2024, 10, 23, 19, 41, 58, 632, DateTimeKind.Local).AddTicks(7409) },
                    { 11, 1, 10, 85m, "Allergy consultation", "completed", new DateTime(2024, 10, 23, 17, 41, 58, 632, DateTimeKind.Local).AddTicks(7411) },
                    { 12, 2, 12, 95m, "Wound dressing", "schedule", new DateTime(2024, 10, 23, 20, 41, 58, 632, DateTimeKind.Local).AddTicks(7414) },
                    { 13, 3, 11, 70m, "Consultation for headache", "completed", new DateTime(2024, 10, 21, 21, 41, 58, 632, DateTimeKind.Local).AddTicks(7423) },
                    { 14, 4, 14, 120m, "Pregnancy check-up", "schedule", new DateTime(2024, 10, 23, 22, 11, 58, 632, DateTimeKind.Local).AddTicks(7426) },
                    { 15, 1, 12, 110m, "Diabetes management", "schedule", new DateTime(2024, 10, 24, 17, 41, 58, 632, DateTimeKind.Local).AddTicks(7428) },
                    { 16, 2, 10, 85m, "Blood pressure check", "completed", new DateTime(2024, 10, 23, 15, 11, 58, 632, DateTimeKind.Local).AddTicks(7430) },
                    { 17, 3, 11, 130m, "Knee pain assessment", "completed", new DateTime(2024, 10, 23, 21, 11, 58, 632, DateTimeKind.Local).AddTicks(7433) }
                });

            migrationBuilder.InsertData(
                table: "tblPrescreption",
                columns: new[] { "Id", "DoctorId", "Duration_of_treatment", "PatientId", "instructions", "medicationName" },
                values: new object[,]
                {
                    { 1, 1, "7 days", 1, "Take 1 tablet daily", "Aspirin" },
                    { 2, 2, "10 days", 1, "Take 2 tablets daily", "Ibuprofen" },
                    { 3, 1, "5 days", 2, "Take 1 capsule every 8 hours", "Amoxicillin" },
                    { 4, 4, "30 days", 3, "Take 1 tablet daily", "Lisinopril" },
                    { 5, 2, "60 days", 4, "Take 1 tablet twice daily", "Metformin" },
                    { 6, 6, "90 days", 5, "Take 1 tablet daily", "Amlodipine" },
                    { 7, 8, "120 days", 5, "Take 1 tablet at night", "Simvastatin" },
                    { 8, 6, "14 days", 6, "Take 1 capsule daily before meals", "Omeprazole" },
                    { 9, 2, "180 days", 7, "Take 1 tablet daily", "Atorvastatin" },
                    { 10, 8, "30 days", 8, "Use inhaler as needed", "Albuterol" },
                    { 11, 3, "60 days", 9, "Take 1 tablet daily", "Levothyroxine" },
                    { 12, 7, "90 days", 10, "Take 1 tablet twice daily", "Metoprolol" },
                    { 13, 1, "120 days", 11, "Take 1 tablet daily", "Losartan" },
                    { 14, 4, "60 days", 11, "Take 1 capsule every 12 hours", "Gabapentin" },
                    { 15, 5, "30 days", 12, "Take 1 tablet daily", "Furosemide" },
                    { 16, 1, "90 days", 12, "Take 1 tablet daily", "Hydrochlorothiazide" },
                    { 17, 5, "120 days", 13, "Take 1 tablet daily", "Citalopram" },
                    { 18, 3, "180 days", 13, "Take 1 tablet daily", "Sertraline" },
                    { 19, 4, "30 days", 14, "Take 1 tablet daily in the evening", "Montelukast" },
                    { 20, 5, "60 days", 15, "Take 1 capsule daily", "Tamsulosin" }
                });

            migrationBuilder.InsertData(
                table: "tblSchedualeTime",
                columns: new[] { "Id", "Day", "DoctorId", "EndTime", "StartTime" },
                values: new object[,]
                {
                    { 1, "Monday", 1, new TimeSpan(0, 11, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 2, "Monday", 1, new TimeSpan(0, 13, 0, 0, 0), new TimeSpan(0, 11, 0, 0, 0) },
                    { 3, "Tuesday", 2, new TimeSpan(0, 12, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 4, "Tuesday", 3, new TimeSpan(0, 15, 0, 0, 0), new TimeSpan(0, 13, 0, 0, 0) },
                    { 5, "Wednesday", 4, new TimeSpan(0, 12, 0, 0, 0), new TimeSpan(0, 10, 0, 0, 0) },
                    { 6, "Wednesday", 4, new TimeSpan(0, 14, 0, 0, 0), new TimeSpan(0, 12, 0, 0, 0) },
                    { 7, "Thursday", 5, new TimeSpan(0, 11, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 8, "Thursday", 5, new TimeSpan(0, 16, 0, 0, 0), new TimeSpan(0, 14, 0, 0, 0) },
                    { 9, "Friday", 6, new TimeSpan(0, 12, 0, 0, 0), new TimeSpan(0, 10, 0, 0, 0) },
                    { 10, "Friday", 7, new TimeSpan(0, 15, 0, 0, 0), new TimeSpan(0, 13, 0, 0, 0) },
                    { 11, "Saturday", 7, new TimeSpan(0, 11, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 12, "Saturday", 8, new TimeSpan(0, 13, 0, 0, 0), new TimeSpan(0, 11, 0, 0, 0) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblAppointments_DoctorId",
                table: "tblAppointments",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_tblAppointments_PatientId",
                table: "tblAppointments",
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
                name: "tblAppointments");

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
