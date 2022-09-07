namespace Hospitality.Patient.API.Data
{
    public record HospitalPatient
    {
        public int HospitalPatientId { get; init; } 
        public string PatientName { get; init; }
        public string PatientSurname { get; init; }
        public string PatientPesel { get; init; }
        public DateTime BirthDate { get; init; }
        public string Address { get; init; }
        public string Email { get; init; }
        public string PhoneNumber { get; init; }
        public bool IsInsured { get; init; }
    }
}