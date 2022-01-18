namespace Persons.DTOs
{
    public class PersonResponseDTO : PersonDTO
    {
        public long Id { get; set; }

        public static PersonResponseDTO From(Person person)
        {
            var address = person.Adress;

            return new PersonResponseDTO
            {
                Id = person.Id,
                Firstname = person.Firstname,
                Lastname = person.Lastname,
                Born = person.Born,
                Tel = person.Tel,
                Address = $"{address.City?.CountryCode}-{address.City?.PostalCode} {address.City?.Name}, {address.StreetName} {address.StreetNr}",
            };
        }
    }
}
