using Microsoft.AspNetCore.Mvc;
using PloomesTest.DTOs.Request;
using PloomesTest.DTOs.Response;
using PloomesTest.Models;
public interface IRegisterPerson
{
    Task<ActionResult<Person>> GetPersonById(long id);
    Task<PersonResponse> CreatePersonAsync(CreatePersonRequest request);
    Task<bool> DeletePersonById(long id);
    Task<IEnumerable<Person>> GetAllPeople();
    Task UpdatePerson(long id, UpdatePersonRequest request);
}
