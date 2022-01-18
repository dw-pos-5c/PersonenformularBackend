using Persons.DTOs;

namespace Persons.Services
{
    public class PersonsService
    {
        public readonly PersonsContext db;

        public PersonsService(PersonsContext db)
        {
            this.db = db;
        }

        public IEnumerable<PersonResponseDTO> GetAll()
        {
            return db.Persons
                .Include(x => x.Adress)
                .Include(x => x.Adress.City)
                .Select(person => PersonResponseDTO.From(person))
                .ToList();
        }

        public PersonResponseDTO GetSingle(int id)
        {
            return db.Persons
                .Include(x => x.Adress)
                .Include(x => x.Adress.City)
                .Select(person => PersonResponseDTO.From(person))
                .First(x => x.Id == id);
        }

        public Person AddSingle(PersonDTO person)
        {
            var dbEntry = db.Persons.Add(person.ToPerson());
            db.SaveChanges();
            return dbEntry.Entity;
        }
    }
}
