namespace Persons.DTOs
{
    public class PersonResponseDTO : PersonDTO
    {
        public long Id { get; set; }

        public static PersonResponseDTO From(Person person)
        {
            return new PersonResponseDTO
            {
                Id = person.Id,
                Firstname = person.Firstname,
                Lastname = person.Lastname,
                Born = person.Born,
                Tel = person.Tel,
                Address = person.Adress?.ToString() ?? "Empty",
            };
        }
    }
}
