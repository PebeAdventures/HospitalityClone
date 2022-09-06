namespace Hospitality.CheckUp.API.Model
{
    public class CheckUp
    {
        private int Id { get; set; }
        private string Description { get; set; }
        private int IdPatient { get; set; }

        private int IdDoctor { get; set; }
        private DateTime Time { get; set; }

    }
}
