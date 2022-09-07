namespace Hospitality.Patient.API.DTOs
{
    public record PatientDoctorViewDTO
    {
        [Required]
        [MinLength(3), MaxLength(25)]
        public string PatientName { get; init; }

        [Required]
        [MinLength(3), MaxLength(25)]
        public string PatientSurname { get; init; }
        
        [Required]
        [MinLength(11), MaxLength(11)]
        public string PatientPesel { get; init; }
        
        [Required]
        public DateTime BirthDate { get; init; }
    }
}