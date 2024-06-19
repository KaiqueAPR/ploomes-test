using Microsoft.EntityFrameworkCore;
using PloomesTest.Models;

namespace PloomesTest.Repositories
{

    public class PersonRepository : IPersonRepository
    {
        private readonly PloomesTestContext _context;

        public PersonRepository(PloomesTestContext context)
        {
            _context = context;
        }

        public async Task<Person> GetById(long id)
        {
            var person = await _context.Persons.FindAsync(id);
            if (person == null)
            {
                throw new KeyNotFoundException($"Person with id {id} was not found.");
            }
            return person;
        }

        public async Task Delete(Person person)
        {
            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();
        }

        public async Task<Person> Create(Person person)
        {
            _context.Persons.Add(person);
            await _context.SaveChangesAsync();
            return person;
        }

        public async Task Update(Person person)
        {
            _context.Entry(person).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Person>> GetAll()
        {
            return await _context.Persons.ToListAsync();
        }
    }
}
