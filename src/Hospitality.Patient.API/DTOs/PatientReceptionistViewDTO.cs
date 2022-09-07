namespace Hospitality.Patient.API.DTOs
{
    public class PatientReceptionistViewDTO
    {
        [Required]
        public string PatientName { get; set; }

        [Required]
        public string PatientSurname { get; set; }

        [Required]
        public string PatientPesel { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public bool IsInsured { get; set; }
    }
}