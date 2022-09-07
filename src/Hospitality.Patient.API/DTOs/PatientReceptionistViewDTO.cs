﻿namespace Hospitality.Patient.API.DTOs
{
    public class PatientReceptionistViewDTO
    {
        [Required]
        [MinLength(3), MaxLength(25)]
        public string PatientName { get; set; }

        [Required]
        [MinLength(3), MaxLength(25)]
        public string PatientSurname { get; set; }

        [Required]
        [MinLength(11), MaxLength(11)]
        public string PatientPesel { get; set; }
        
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime BirthDate { get; set; }

        [Required]
        [MinLength(3), MaxLength(25)]
        public string Address { get; set; }

        [Required]
        [MinLength(3), MaxLength(25)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [MinLength(9), MaxLength(9)]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public bool IsInsured { get; set; }
    }
}