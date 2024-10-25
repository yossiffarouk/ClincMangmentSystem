using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClinicManagement.Migrations
{
    /// <inheritdoc />
    public partial class yossefaddmigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    { 1, 1, "Ahmed.Tharwat@clinic.com", "Dr. Ahmed Tharwat", "2U88~dVA9I", "+201022812243", 1 },
                    { 2, 2, "Esraa.Zaki@clinic.com", "Dr. Esraa Zaki", "wSzxjWHSXO", "+201155698835", 2 },
                    { 3, 3, "Ahmed.Khaled@clinic.com", "Dr. Ahmed Khaled", "w#mW9SFnU8", "+201012345678", 3 },
                    { 4, 4, "Fatima.Hassan@clinic.com", "Dr. Fatima Hassan", "9bGswO_f3@", "+201198765432", 4 },
                    { 5, 5, "Mohamed.Ali@clinic.com", "Dr. Mohamed Ali", "If-3^Tmw^O", "+201234567890", null },
                    { 6, 6, "Sara.Mohamed@clinic.com", "Dr. Sara Mohamed", "gVjW_fi#Tx", "+201512345678", null },
                    { 7, 7, "Omar.Mostafa@clinic.com", "Dr. Omar Mostafa", "79qo(kPgNg", "+201146890012", 5 },
                    { 8, 8, "Mohamed.AbdEl-Hameed@clinic.com", "Dr. Mohamed AdbEL-Hameed", "uTqLe@GNSW", "+201014501522", 6 }
                });

            migrationBuilder.InsertData(
                table: "tblAppointment",
                columns: new[] { "Id", "DoctorId", "PatientId", "Price", "Cause Of Disease", "State", "Time" },
                values: new object[,]
                {
                    { 1, 1, 1, 100m, "Routine check-up", "schedule", new DateTime(2024, 10, 21, 19, 8, 17, 56, DateTimeKind.Local).AddTicks(1086) },
                    { 2, 2, 2, 80m, "Flu symptoms", "completed", new DateTime(2024, 10, 19, 19, 8, 17, 56, DateTimeKind.Local).AddTicks(1122) },
                    { 3, 1, 3, 120m, "Back pain", "completed", new DateTime(2024, 10, 19, 19, 8, 17, 56, DateTimeKind.Local).AddTicks(1125) },
                    { 4, 3, 5, 200m, "Dental check-up", "schedule", new DateTime(2024, 10, 21, 19, 8, 17, 56, DateTimeKind.Local).AddTicks(1127) },
                    { 5, 2, 5, 90m, "Skin rash", "schedule", new DateTime(2024, 10, 25, 19, 8, 17, 56, DateTimeKind.Local).AddTicks(1129) },
                    { 6, 4, 6, 75m, "Eye examination", "completed", new DateTime(2024, 10, 17, 19, 8, 17, 56, DateTimeKind.Local).AddTicks(1133) },
                    { 7, 1, 7, 150m, "Physical therapy", "schedule", new DateTime(2024, 10, 22, 7, 8, 17, 56, DateTimeKind.Local).AddTicks(1135) },
                    { 8, 2, 8, 60m, "Cold and cough", "completed", new DateTime(2024, 10, 20, 7, 8, 17, 56, DateTimeKind.Local).AddTicks(1137) },
                    { 9, 3, 9, 110m, "Annual check-up", "completed", new DateTime(2024, 10, 20, 17, 53, 17, 56, DateTimeKind.Local).AddTicks(1139) },
                    { 10, 4, 10, 250m, "Chest pain", "schedule", new DateTime(2024, 10, 20, 20, 8, 17, 56, DateTimeKind.Local).AddTicks(1141) },
                    { 11, 1, 10, 85m, "Allergy consultation", "completed", new DateTime(2024, 10, 20, 18, 8, 17, 56, DateTimeKind.Local).AddTicks(1143) },
                    { 12, 2, 12, 95m, "Wound dressing", "schedule", new DateTime(2024, 10, 20, 21, 8, 17, 56, DateTimeKind.Local).AddTicks(1145) },
                    { 13, 3, 11, 70m, "Consultation for headache", "completed", new DateTime(2024, 10, 18, 22, 8, 17, 56, DateTimeKind.Local).AddTicks(1147) },
                    { 14, 4, 14, 120m, "Pregnancy check-up", "schedule", new DateTime(2024, 10, 20, 22, 38, 17, 56, DateTimeKind.Local).AddTicks(1149) },
                    { 15, 1, 12, 110m, "Diabetes management", "schedule", new DateTime(2024, 10, 21, 18, 8, 17, 56, DateTimeKind.Local).AddTicks(1150) },
                    { 16, 2, 10, 85m, "Blood pressure check", "completed", new DateTime(2024, 10, 20, 15, 38, 17, 56, DateTimeKind.Local).AddTicks(1152) },
                    { 17, 3, 11, 130m, "Knee pain assessment", "completed", new DateTime(2024, 10, 20, 21, 38, 17, 56, DateTimeKind.Local).AddTicks(1154) }
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
                columns: new[] { "Id", "Day", "DoctorComeIn", "DoctorId", "DoctorLeaveIn" },
                values: new object[,]
                {
                    { 1, "Monday", new TimeSpan(0, 9, 0, 0, 0), 1, new TimeSpan(0, 11, 0, 0, 0) },
                    { 2, "Monday", new TimeSpan(0, 9, 0, 0, 0), 1, new TimeSpan(0, 11, 0, 0, 0) },
                    { 3, "Tuesday", new TimeSpan(0, 9, 0, 0, 0), 2, new TimeSpan(0, 11, 0, 0, 0) },
                    { 4, "Tuesday", new TimeSpan(0, 9, 0, 0, 0), 3, new TimeSpan(0, 11, 0, 0, 0) },
                    { 5, "Wednesday", new TimeSpan(0, 9, 0, 0, 0), 4, new TimeSpan(0, 11, 0, 0, 0) },
                    { 6, "Wednesday", new TimeSpan(0, 9, 0, 0, 0), 4, new TimeSpan(0, 11, 0, 0, 0) },
                    { 7, "Thursday", new TimeSpan(0, 9, 0, 0, 0), 5, new TimeSpan(0, 11, 0, 0, 0) },
                    { 8, "Thursday", new TimeSpan(0, 9, 0, 0, 0), 5, new TimeSpan(0, 11, 0, 0, 0) },
                    { 9, "Friday", new TimeSpan(0, 9, 0, 0, 0), 6, new TimeSpan(0, 11, 0, 0, 0) },
                    { 10, "Friday", new TimeSpan(0, 9, 0, 0, 0), 7, new TimeSpan(0, 11, 0, 0, 0) },
                    { 11, "Saturday", new TimeSpan(0, 9, 0, 0, 0), 7, new TimeSpan(0, 11, 0, 0, 0) },
                    { 12, "Saturday", new TimeSpan(0, 9, 0, 0, 0), 8, new TimeSpan(0, 11, 0, 0, 0) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tblAppointment",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tblAppointment",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "tblAppointment",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "tblAppointment",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "tblAppointment",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "tblAppointment",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "tblAppointment",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "tblAppointment",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "tblAppointment",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "tblAppointment",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "tblAppointment",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "tblAppointment",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "tblAppointment",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "tblAppointment",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "tblAppointment",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "tblAppointment",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "tblAppointment",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "tblPrescreption",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tblPrescreption",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "tblPrescreption",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "tblPrescreption",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "tblPrescreption",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "tblPrescreption",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "tblPrescreption",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "tblPrescreption",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "tblPrescreption",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "tblPrescreption",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "tblPrescreption",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "tblPrescreption",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "tblPrescreption",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "tblPrescreption",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "tblPrescreption",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "tblPrescreption",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "tblPrescreption",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "tblPrescreption",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "tblPrescreption",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "tblPrescreption",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "tblSchedualeTime",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tblSchedualeTime",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "tblSchedualeTime",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "tblSchedualeTime",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "tblSchedualeTime",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "tblSchedualeTime",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "tblSchedualeTime",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "tblSchedualeTime",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "tblSchedualeTime",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "tblSchedualeTime",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "tblSchedualeTime",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "tblSchedualeTime",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "tblDoctor",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tblDoctor",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "tblDoctor",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "tblDoctor",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "tblDoctor",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "tblDoctor",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "tblDoctor",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "tblDoctor",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "tblPatient",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tblPatient",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "tblPatient",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "tblPatient",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "tblPatient",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "tblPatient",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "tblPatient",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "tblPatient",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "tblPatient",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "tblPatient",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "tblPatient",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "tblPatient",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "tblPatient",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "tblPatient",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "tblPatient",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "tblDepartment",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tblDepartment",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "tblDepartment",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "tblDepartment",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "tblDepartment",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "tblDepartment",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "tblDepartment",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "tblDepartment",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "tblOffice",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tblOffice",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "tblOffice",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "tblOffice",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "tblOffice",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "tblOffice",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
