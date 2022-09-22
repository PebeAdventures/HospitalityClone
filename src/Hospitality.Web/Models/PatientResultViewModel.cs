using Hospitality.Common.DTO.Patient;
using System.ComponentModel.DataAnnotations;

namespace Hospitality.Web.Models
{
    public class PatientResultViewModel
    {
        public string? Result { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        //[RegularExpression(@"AaĄąBbCcĆćDdEeĘęFfGgHhIiJjKkLlŁłMmNnŃńOoÓóPpRrSsŚśTtUuWwYyZzŹźŻż", ErrorMessage = "Use letters only please")]
        //[UserName=[A-Za-zżźćńółęąśŻŹĆĄŚĘŁÓŃ]* [A-Za-zżźćńółęąśŻŹĆĄŚĘŁÓŃ]*\]
        [MinLength(3), MaxLength(25)]
        public string PatientName { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        [MinLength(3), MaxLength(25)]
        public string PatientSurname { get; set; }

        [Required]
        [MinLength(11), MaxLength(11)]
        public string PatientPesel { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime BirthDate { get; set; }

        [Required]
        [MinLength(3), MaxLength(25)]
        public string Address { get; set; }

        [Required]
        [MinLength(6), MaxLength(25)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", 
            ErrorMessage = "Please enter a valid e-mail adress")]
        public string Email { get; set; }

        [Required]
        [MinLength(9), MaxLength(9)]
        [RegularExpression(@"^([0-9]{3}[-\s]?){3}$", ErrorMessage = "Please enter a valid phone number")]
        public string PhoneNumber { get; set; }

        [DataType(DataType.Text)]
        public bool IsInsured { get; set; }
        [Required]
        public SpecialistEnum Specialist { get; set; }
    }
}
