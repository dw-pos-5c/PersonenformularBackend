using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

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
            var regex = new Regex(RegexProvider.address);
            var groups = regex.Match(Address).Groups;

            var parsed = long.TryParse(groups["postal"].Value, out long postal);

            if (!parsed) return null;

            var city = new City
            {
                CountryCode = groups["code"].Value,
                Name = groups["city"].Value,
                PostalCode = postal,
            };

            parsed = long.TryParse(groups["streetNr"].Value, out long streetNr);

            if (!parsed) return null;

            var address = new Adress
            {
                City = city,
                StreetName = groups["street"].Value,
                StreetNr = streetNr,
            }; 

            return new Person
            {
                Firstname = Firstname,
                Lastname = Lastname,
                Born = Born,
                Tel = Tel,
                Adress = address,
            };
        }
    }
}
