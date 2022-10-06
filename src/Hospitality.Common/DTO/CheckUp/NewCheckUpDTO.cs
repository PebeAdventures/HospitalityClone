namespace Hospitality.Common.DTO.CheckUp
{
    public class NewCheckUpDTO
    {
        public string Description { get; set; }
        public int IdPatient { get; set; }
        public Guid IdDoctor { get; set; }
        public bool IsInsured { get; set; }
    }
}
