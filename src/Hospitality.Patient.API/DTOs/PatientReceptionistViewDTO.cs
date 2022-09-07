namespace Hospitality.Patient.API.DTOs
{
    public record PatientReceptionistViewDTO
    {
        public int PatientId { get; init; }

        [Required]
        public string PatientName { get; init; }

        [Required]
        public string PatientSurname { get; init; }

        [Required]
        public string PatientPesel { get; init; }
        [Required]
        public DateTime BirthDate { get; init; }

        [Required]
        public string Address { get; init; }

        [Required]
        public string Email { get; init; }

        [Required]
        public string PhoneNumber { get; init; }

        [Required]
        public bool IsInsured { get; init; }
    }
}