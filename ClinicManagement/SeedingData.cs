using ClinicManagement.Entities;
using ClinicManagement.Generator;
using ClinicMangmentSystem.Entites;
using static ClinicManagement.Enumes.DaysEnum;
using static ClinicMangmentSystem.Enums.gender;
using static ClinicMangmentSystem.Enums.state;

namespace ClinicManagement
{
    public class SeedingData
    {
        public static List<Office> LoadOffieces()
        {
            return new List<Office>()
            {
                new Office{Id=1,Name = "Off11-A",Address="First-Floor"},
                new Office{Id=2,Name = "Off12-A",Address="First-Floor"},
                new Office{Id=3,Name = "Off13-A",Address="First-Floor"},
                new Office{Id=4,Name = "Off21-B",Address="Second-Floor"},
                new Office{Id=5,Name = "Off22-B",Address="Second-Floor"},
                new Office{Id=6,Name = "Off23-B",Address="Second-Floor"}
            };
        }

        public static List<Department> LoadDepartments()
        {
            return new List<Department>()
            {
                new Department{Id = 1, DeptName = "Cardiology"},
                new Department{Id = 2, DeptName = "Dermatology"},
                new Department{Id = 3, DeptName = "Orthopedics"},
                new Department{Id = 4, DeptName = "Pediatrics"},
                new Department{Id = 5, DeptName = "Neurology"},
                new Department{Id = 6, DeptName = "Oncology"},
                new Department{Id = 7, DeptName = "Radiology"},
                new Department{Id = 8, DeptName = "Endocrimology"}
            };
        }

        public static List<Doctor> LoadDoctors()
        {
            return new List<Doctor>()
            {
                new Doctor{ Id = 1, Name = "Dr. Ahmed Tharwat",Phone = "+201022812243",Email = "Ahmed.Tharwat@clinic.com",Password = PasswordGenrator.GenerateRandomPassword(10) ,officeId=1,DeptId=1 },
                new Doctor{ Id = 2, Name = "Dr. Esraa Zaki",Phone="+201155698835",Email="Esraa.Zaki@clinic.com",Password = PasswordGenrator.GenerateRandomPassword(10),officeId=2,DeptId=2},
                new Doctor{ Id = 3, Name = "Dr. Ahmed Khaled",Phone="+201012345678",Email="Ahmed.Khaled@clinic.com",Password=PasswordGenrator.GenerateRandomPassword(10) ,officeId=3, DeptId = 3},
                new Doctor{ Id = 4, Name = "Dr. Fatima Hassan",Phone="+201198765432",Email="Fatima.Hassan@clinic.com",Password=PasswordGenrator.GenerateRandomPassword(10) ,officeId=4, DeptId = 4},
                new Doctor{ Id = 5, Name = "Dr. Mohamed Ali",Phone="+201234567890",Email="Mohamed.Ali@clinic.com",Password=PasswordGenrator.GenerateRandomPassword(10) ,officeId=null,DeptId=5},
                new Doctor{ Id = 6, Name = "Dr. Sara Mohamed",Phone="+201512345678",Email="Sara.Mohamed@clinic.com",Password=PasswordGenrator.GenerateRandomPassword(10) ,officeId = null, DeptId = 6},
                new Doctor{ Id = 7, Name = "Dr. Omar Mostafa",Phone="+201146890012",Email="Omar.Mostafa@clinic.com",Password=PasswordGenrator.GenerateRandomPassword(10) ,officeId=5, DeptId = 7},
                new Doctor{ Id = 8, Name = "Dr. Mohamed AdbEL-Hameed",Phone="+201014501522",Email="Mohamed.AbdEl-Hameed@clinic.com",Password=PasswordGenrator.GenerateRandomPassword(10) ,officeId=6, DeptId = 8}
            };
        }

        public static List<SchedualeTime> LoadSchedualeTimes()
        {
            return new List<SchedualeTime>()
            {
                new SchedualeTime{Id = 1,DoctorComeIn =TimeSpan.Parse("09:00:00"),DoctorLeaveIn = TimeSpan.Parse("11:00:00") , Day=Days.Monday,DoctorId = 1},
                new SchedualeTime{Id = 2,DoctorComeIn =TimeSpan.Parse("09:00:00"),DoctorLeaveIn = TimeSpan.Parse("11:00:00"), Day=Days.Monday,DoctorId = 1},
                new SchedualeTime{Id = 3,DoctorComeIn =TimeSpan.Parse("09:00:00"),DoctorLeaveIn = TimeSpan.Parse("11:00:00"),  Day=Days.Tuesday,DoctorId = 2},
                new SchedualeTime{Id = 4,DoctorComeIn =TimeSpan.Parse("09:00:00"),DoctorLeaveIn = TimeSpan.Parse("11:00:00"),  Day=Days.Tuesday,DoctorId = 3},
                new SchedualeTime{Id = 5,DoctorComeIn =TimeSpan.Parse("09:00:00"),DoctorLeaveIn = TimeSpan.Parse("11:00:00"), Day=Days.Wednesday,DoctorId = 4},
                new SchedualeTime{Id = 6,DoctorComeIn =TimeSpan.Parse("09:00:00"),DoctorLeaveIn = TimeSpan.Parse("11:00:00"),  Day=Days.Wednesday,DoctorId = 4},
                new SchedualeTime{Id = 7,DoctorComeIn =TimeSpan.Parse("09:00:00"),DoctorLeaveIn = TimeSpan.Parse("11:00:00"),  Day=Days.Thursday,DoctorId = 5},
                new SchedualeTime{Id = 8,DoctorComeIn =TimeSpan.Parse("09:00:00"),DoctorLeaveIn = TimeSpan.Parse("11:00:00"), Day=Days.Thursday,DoctorId = 5},
                new SchedualeTime{Id = 9,DoctorComeIn =TimeSpan.Parse("09:00:00"),DoctorLeaveIn = TimeSpan.Parse("11:00:00"), Day=Days.Friday,DoctorId = 6},
                new SchedualeTime{Id = 10,DoctorComeIn =TimeSpan.Parse("09:00:00"),DoctorLeaveIn = TimeSpan.Parse("11:00:00"), Day=Days.Friday,DoctorId = 7},
                new SchedualeTime{Id = 11,DoctorComeIn =TimeSpan.Parse("09:00:00"),DoctorLeaveIn = TimeSpan.Parse("11:00:00"), Day=Days.Saturday,DoctorId = 7},
                new SchedualeTime{Id = 12,DoctorComeIn =TimeSpan.Parse("09:00:00"),DoctorLeaveIn = TimeSpan.Parse("11:00:00"), Day=Days.Saturday,DoctorId = 8}
            };
        }

       

        public static List<Patient> LoadOfPatients()
        {
            return new List<Patient>
            {
                new Patient { Id = 1, Name = "Ahmed Ali", Age = 28, gender = Gender.Male, Phone = "+201011223344", Address = "Cairo, Egypt" },
                new Patient { Id = 2, Name = "Mona Hamed", Age = 25, gender = Gender.Female, Phone = "+201022334455", Address = "Alexandria, Egypt" },
                new Patient { Id = 3, Name = "Khaled Hassan", Age = 32, gender = Gender.Male, Phone = "+201033445566", Address = "Giza, Egypt" },
                new Patient { Id = 4, Name = "Sara Ibrahim", Age = 24, gender = Gender.Female, Phone = "+201244556677", Address = "Aswan, Egypt" },
                new Patient { Id = 5, Name = "Mahmoud Farouk", Age = 30, gender = Gender.Male, Phone = "+201055667788", Address = "Luxor, Egypt" },
                new Patient { Id = 6, Name = "Yasmine Khalil", Age = 27, gender = Gender.Female, Phone = "+211066778899", Address = "Mansoura, Egypt" },
                new Patient { Id = 7, Name = "Omar Saeed", Age = 35, gender = Gender.Male, Phone = "+201077889900", Address = "Port Said, Egypt" },
                new Patient { Id = 8, Name = "Aya Mostafa", Age = 29, gender = Gender.Female, Phone = "+201588990011", Address = "Suez, Egypt" },
                new Patient { Id = 9, Name = "Tamer Magdy", Age = 33, gender = Gender.Male, Phone = "+201099001122", Address = "Ismailia, Egypt" },
                new Patient { Id = 10, Name = "Nourhan Adel", Age = 26, gender = Gender.Female, Phone = "+201511122233", Address = "Zagazig, Egypt" },
                new Patient { Id = 11, Name = "Amr Reda", Age = 34, gender = Gender.Male, Phone = "+201122233344", Address = "Fayoum, Egypt" },
                new Patient { Id = 12, Name = "Rana Sameh", Age = 28, gender = Gender.Female, Phone = "+201033344455", Address = "Beni Suef, Egypt" },
                new Patient { Id = 13, Name = "Hossam Naguib", Age = 31, gender = Gender.Male, Phone = "+201044455566", Address = "Minya, Egypt" },
                new Patient { Id = 14, Name = "Mariam Fathi", Age = 23, gender = Gender.Female, Phone = "+201255566677", Address = "Assiut, Egypt" },
                new Patient { Id = 15, Name = "Mostafa Amin", Age = 36, gender = Gender.Male, Phone = "+201066677788", Address = "Sohag, Egypt" }
            };
        }

        public static List<Prescription> LoadOfPrescriptions()
        {
            return new List<Prescription>
            {
                new Prescription { Id = 1, medicationName = "Aspirin", instructions = "Take 1 tablet daily", Duration_of_treatment = "7 days", DoctorId = 1, PatientId = 1 },
                new Prescription { Id = 2, medicationName = "Ibuprofen", instructions = "Take 2 tablets daily", Duration_of_treatment = "10 days", DoctorId = 2, PatientId = 1 },
                new Prescription { Id = 3, medicationName = "Amoxicillin", instructions = "Take 1 capsule every 8 hours", Duration_of_treatment = "5 days", DoctorId = 1, PatientId = 2 },
                new Prescription { Id = 4, medicationName = "Lisinopril", instructions = "Take 1 tablet daily", Duration_of_treatment = "30 days", DoctorId = 4, PatientId = 3 },
                new Prescription { Id = 5, medicationName = "Metformin", instructions = "Take 1 tablet twice daily", Duration_of_treatment = "60 days", DoctorId = 2, PatientId = 4 },
                new Prescription { Id = 6, medicationName = "Amlodipine", instructions = "Take 1 tablet daily", Duration_of_treatment = "90 days", DoctorId = 6, PatientId = 5 },
                new Prescription { Id = 7, medicationName = "Simvastatin", instructions = "Take 1 tablet at night", Duration_of_treatment = "120 days", DoctorId = 8, PatientId = 5 },
                new Prescription { Id = 8, medicationName = "Omeprazole", instructions = "Take 1 capsule daily before meals", Duration_of_treatment = "14 days", DoctorId = 6, PatientId = 6 },
                new Prescription { Id = 9, medicationName = "Atorvastatin", instructions = "Take 1 tablet daily", Duration_of_treatment = "180 days", DoctorId = 2, PatientId = 7 },
                new Prescription { Id = 10, medicationName = "Albuterol", instructions = "Use inhaler as needed", Duration_of_treatment = "30 days", DoctorId = 8, PatientId = 8 },
                new Prescription { Id = 11, medicationName = "Levothyroxine", instructions = "Take 1 tablet daily", Duration_of_treatment = "60 days", DoctorId = 3, PatientId = 9 },
                new Prescription { Id = 12, medicationName = "Metoprolol", instructions = "Take 1 tablet twice daily", Duration_of_treatment = "90 days", DoctorId = 7, PatientId = 10 },
                new Prescription { Id = 13, medicationName = "Losartan", instructions = "Take 1 tablet daily", Duration_of_treatment = "120 days", DoctorId = 1, PatientId = 11 },
                new Prescription { Id = 14, medicationName = "Gabapentin", instructions = "Take 1 capsule every 12 hours", Duration_of_treatment = "60 days", DoctorId = 4, PatientId = 11 },
                new Prescription { Id = 15, medicationName = "Furosemide", instructions = "Take 1 tablet daily", Duration_of_treatment = "30 days", DoctorId = 5, PatientId = 12 },
                new Prescription { Id = 16, medicationName = "Hydrochlorothiazide", instructions = "Take 1 tablet daily", Duration_of_treatment = "90 days", DoctorId = 1, PatientId = 12 },
                new Prescription { Id = 17, medicationName = "Citalopram", instructions = "Take 1 tablet daily", Duration_of_treatment = "120 days", DoctorId = 5, PatientId = 13 },
                new Prescription { Id = 18, medicationName = "Sertraline", instructions = "Take 1 tablet daily", Duration_of_treatment = "180 days", DoctorId = 3, PatientId = 13 },
                new Prescription { Id = 19, medicationName = "Montelukast", instructions = "Take 1 tablet daily in the evening", Duration_of_treatment = "30 days", DoctorId = 4, PatientId = 14 },
                new Prescription { Id = 20, medicationName = "Tamsulosin", instructions = "Take 1 capsule daily", Duration_of_treatment = "60 days", DoctorId = 5, PatientId = 15 }
            };
        }

        public static List<Appointment> LoadOfAppointmets()
        {
            return new List<Appointment>
            {
                 new Appointment
                 {
                    Id = 1,
                    Reason = "Routine check-up",
                    State = State.schedule,
                    Price = 100.0,
                    DoctorId = 1,
                    PatientId = 1,
                    Time = DateTime.Now.AddDays(1)
                 },
                new Appointment
                {
                    Id = 2,
                    Reason = "Flu symptoms",
                    State = State.completed,
                    Price = 80.0,
                    DoctorId = 2,
                    PatientId = 2,
                    Time = DateTime.Now.AddDays(-1)
                },
                new Appointment
                {
                    Id = 3,
                    Reason = "Back pain",
                    State = State.completed,
                    Price = 120.0,
                    DoctorId = 1,
                    PatientId = 3,
                    Time = DateTime.Now.AddDays(-1)

                },
                new Appointment
                {
                    Id = 4,
                    Reason = "Dental check-up",
                    State = State.schedule,
                    Price = 200.0,
                    DoctorId = 3,
                    PatientId = 5,
                    Time = DateTime.Now.AddDays(1)
                },
                new Appointment
                {
                    Id = 5,
                    Reason = "Skin rash",
                    State = State.schedule,
                    Price = 90.0,
                    DoctorId = 2,
                    PatientId = 5,
                    Time = DateTime.Now.AddDays(5)
                },
                new Appointment
                {
                    Id = 6,
                    Reason = "Eye examination",
                    State = State.completed,
                    Price = 75.0,
                    DoctorId = 4,
                    PatientId = 6,
                    Time = DateTime.Now.AddDays(-3)
                },
                new Appointment
                {
                    Id = 7,
                    Reason = "Physical therapy",
                    State = State.schedule,
                    Price = 150.0,
                    DoctorId = 1,
                    PatientId = 7,
                    Time = DateTime.Now.AddDays(1.5)
                },
                new Appointment
                {
                    Id = 8,
                    Reason = "Cold and cough",
                    State = State.completed,
                    Price = 60.0,
                    DoctorId = 2,
                    PatientId = 8,
                    Time = DateTime.Now.AddDays(-0.5)
                },
                new Appointment
                {
                    Id = 9,
                    Reason = "Annual check-up",
                    State = State.completed,
                    Price = 110.0,
                    DoctorId = 3,
                    PatientId = 9,
                  Time = DateTime.Now.AddHours(-1.25)

                },
                new Appointment
                {
                    Id = 10,
                    Reason = "Chest pain",
                    State = State.schedule,
                    Price = 250.0,
                    DoctorId = 4,
                    PatientId = 10,
                    Time = DateTime.Now.AddHours(1)

                },
                new Appointment
                {
                    Id = 11,
                    Reason = "Allergy consultation",
                    State = State.completed,
                    Price = 85.0,
                    DoctorId = 1,
                    PatientId = 10,
                   Time = DateTime.Now.AddHours(-1)

                },
                new Appointment
                {
                    Id = 12,
                    Reason = "Wound dressing",
                    State = State.schedule,
                    Price = 95.0,
                    DoctorId = 2,
                    PatientId = 12,
                   Time = DateTime.Now.AddHours(2)

                },
                new Appointment
                {
                    Id = 13,
                    Reason = "Consultation for headache",
                    State = State.completed,
                    Price = 70.0,
                    DoctorId = 3,
                    PatientId = 11,
                   Time = DateTime.Now.AddHours(-45)

                },
                new Appointment
                {
                    Id = 14,
                    Reason = "Pregnancy check-up",
                    State = State.schedule,
                    Price = 120.0,
                    DoctorId = 4,
                    PatientId = 14,
                  Time = DateTime.Now.AddHours(3.5)

                },
                new Appointment
                {
                    Id = 15,
                    Reason = "Diabetes management",
                    State = State.schedule,
                    Price = 110.0,
                    DoctorId = 1,
                    PatientId = 12,
                    Time = DateTime.Now.AddHours(23)

                },
                new Appointment
                {
                    Id = 16,
                    Reason = "Blood pressure check",
                    State = State.completed,
                    Price = 85.0,
                    DoctorId = 2,
                    PatientId = 10,
                    Time = DateTime.Now.AddHours(-3.5)
                },
                new Appointment
                {
                    Id = 17,
                    Reason = "Knee pain assessment",
                    State = State.completed,
                    Price = 130.0,
                    DoctorId = 3,
                    PatientId = 11,
                    Time   = DateTime.Now.AddHours(2.5)
                }
            };
        }
    }
}
