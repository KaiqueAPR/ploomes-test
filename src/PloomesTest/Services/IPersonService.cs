using PloomesTest.DTOs.Request;
using PloomesTest.DTOs.Response;
using PloomesTest.Models;

namespace PloomesTest.Services;
public interface IPersonService
{
    Task<Person> GetPersonById(long id);
    Task<PersonResponse> CreatePersonAsync(CreatePersonRequest request);
    Task<bool> DeletePersonById(long id);
    Task<IEnumerable<Person>> GetAllPeople();
    Task UpdatePerson(long id, UpdatePersonRequest request);
}
