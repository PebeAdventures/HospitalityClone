namespace Hospitality.Web.Models
{
    public class RegistrationPatientModel
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string pesel { get; set; }
        public DateTime date { get; set; }
        public string address { get; set; }
        public string phoneNumber { get; set; }

        public string specialist { get; set; }
        public bool isHealthInsurance { get; set; }
    }
}
