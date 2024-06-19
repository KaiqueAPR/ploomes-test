using PloomesTest.Models;

namespace PloomesTest.Repositories;

public interface IPersonRepository
{
    Task<Person> GetById(long id);
    Task<IEnumerable<Person>> GetAll();
    Task<Person> Create(Person person);
    Task Update(Person person);
    Task Delete(Person person);
}
