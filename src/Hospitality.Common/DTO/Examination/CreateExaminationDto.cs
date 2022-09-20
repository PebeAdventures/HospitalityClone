namespace Hospitality.Common.DTO.Examination
{
    public class CreateExaminationDto
    {
        public int PatientId { get; set; }
        public int Status { get; set; }
        public string Description { get; set; }
        public int ExaminationTypeId { get; set; }
    }
}