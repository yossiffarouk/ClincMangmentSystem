﻿using ClinicMangmentSystem.Entites;

namespace ClinicManagement.DTOS.Prescription
{
    public class EditPrescriptionDto
    {
        public int Id { get; set; }
        public string medicationName { get; set; } = null!;
        public string instructions { get; set; } = null!;
        public string Duration_of_treatment { get; set; } = null!;

        public int DoctorId { get; set; }
        
        public int PatientId { get; set; }
  
    }
}
