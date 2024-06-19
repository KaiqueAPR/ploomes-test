using Microsoft.EntityFrameworkCore;
using PloomesTest.Models;

namespace PloomesTest.Repositories
{
    /// <summary>
    /// Repository for managing Person entities.
    /// </summary>
    public class PersonRepository : IPersonRepository
    {
        private readonly PloomesTestContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonRepository"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public PersonRepository(PloomesTestContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves a Person entity by its ID.
        /// </summary>
        /// <param name="id">The ID of the Person entity.</param>
        /// <returns>The Person entity if found; otherwise, null.</returns>
        public async Task<Person> GetById(long id)
        {
            var person = await _context.Persons.FindAsync(id);
            if (person == null)
            {
                throw new KeyNotFoundException($"Person with id {id} was not found.");
            }
            return person;
        }

        /// <summary>
        /// Deletes an existing person.
        /// </summary>
        /// <param name="person">Person object to be deleted.</param>
        public async Task Delete(Person person)
        {
            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Adds a new Person entity to the database.
        /// </summary>
        /// <param name="person">The Person entity to add.</param>
        /// <returns>The added Person entity.</returns>
        public async Task<Person> Create(Person person)
        {
            _context.Persons.Add(person);
            await _context.SaveChangesAsync();
            return person;
        }

        /// <summary>
        /// Updates an existing person.
        /// </summary>
        /// <param name="person">Person object to be updated.</param>
        public async Task Update(Person person)
        {
            _context.Entry(person).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Retrieves all registered persons.
        /// </summary>
        /// <returns>List of all persons.</returns>
        public async Task<IEnumerable<Person>> GetAll()
        {
            return await _context.Persons.ToListAsync();
        }
    }
}
