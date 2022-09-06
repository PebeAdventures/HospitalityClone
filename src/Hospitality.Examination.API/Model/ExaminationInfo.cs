using Hospitality.Examination.API.Model.Enums;

namespace Hospitality.Examination.API.Model
{
    public class ExaminationInfo
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string Description { get; set; }
        public ExaminationType Type { get; set; }
        public ExaminationStatus Status { get; set; }
    }
}