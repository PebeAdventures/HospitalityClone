namespace Hospitality.Common.DTO.CheckUp
{
    public class NewCheckUpDTO
    {
        private int Id { get; set; }
        private string Description { get; set; }
        private int IdPatient { get; set; }

        private int IdDoctor { get; set; }
        private DateTime Time { get; set; }
    }
}
