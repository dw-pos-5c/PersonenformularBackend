using Persons.DTOs;

namespace Persons.Services
{
    public class PersonsService
    {
        public PersonsContext Db { get; }

        public PersonsService(PersonsContext db)
        {
            Db = db;
        }

        public IEnumerable<Person> GetAll()
        {
            return Db.Persons.AsEnumerable();
        }

        public Person GetSingle(int id)
        {
            return Db.Persons.First(x => x.Id == id);
        }

        public Person AddSingle(PersonDTO person)
        {
            var dbEntry = Db.Persons.Add(person.ToPerson());
            Db.SaveChanges();
            return dbEntry.Entity;
        }
    }
}
