﻿using ClinicManagement.Entities;
using ClinicManagement.Enumes;
using static ClinicManagement.Enumes.DaysEnum;

namespace ClinicMangmentSystem.Entites
{
    public class SchedualeTime
    {
        public int Id { get; set; }
        public TimeSpan DoctorComeIn { get; set; }
        public TimeSpan DoctorLeaveIn { get; set; }
        public Days Day { get; set; }

        // Time with Doctor (M to 1)
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }= null!;
    }
  
}
