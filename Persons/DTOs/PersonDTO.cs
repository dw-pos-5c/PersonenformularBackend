using System.ComponentModel.DataAnnotations;

namespace Persons.DTOs
{
    public class PersonDTO
    {
        [RegularExpression(RegexProvider.firstname,
            ErrorMessage = "Firstname has to begin with capital letter and has to be at least 3 chars long")]
        public string Firstname { get; set; }

        [RegularExpression(RegexProvider.lastname,
            ErrorMessage = "Lehner, DelPiro")]
        public string Lastname { get; set; }

        [RegularExpression(RegexProvider.date,
            ErrorMessage = "Format: 01.02.2005")]
        public string Born { get; set; }

        [RegularExpression(RegexProvider.tel,
            ErrorMessage = "Format: +43 (10) 1234")]
        public string Tel { get; set; }

        [RegularExpression(RegexProvider.address,
            ErrorMessage = "Format: A-4600 Wels, Straße 1")]
        public string Address { get; set; }

        public Person ToPerson()
        {
            return new Person
            {
                Firstname = Firstname,
                Lastname = Lastname,
                Born = Born,
                Tel = Tel,
                Adress = new Adress(),
            };
        }
    }
}
