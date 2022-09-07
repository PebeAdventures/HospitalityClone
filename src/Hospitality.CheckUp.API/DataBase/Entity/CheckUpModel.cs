namespace Hospitality.CheckUp.API.DataBase.Entity
{
    public class CheckUpModel
    {
        private int Id { get; set; }
        private string Description { get; set; }
        private int IdPatient { get; set; }

        private int IdDoctor { get; set; }
        private DateTime Time { get; set; }

    }
}
