using PloomesTest.DTOs.Request;
using PloomesTest.DTOs.Response;
using PloomesTest.Models;
using PloomesTest.Repositories;

namespace PloomesTest.Services;

public class PersonService : IPersonService
{
    private readonly IPersonRepository _personRepository;

    public PersonService(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    public async Task<Person> GetPersonById(long id)
    {
        return await _personRepository.GetById(id);
    }

    public async Task<PersonResponse> CreatePersonAsync(CreatePersonRequest request)
    {
        var person = new Person
        {
            Id = request.Id,
            Name = request.Name,
            Document = request.Document,
            Email = request.Email,
            Phone = request.Phone,
            Address = request.Address,
            State = request.State,
            ZipCode = request.ZipCode,
            Country = request.Country
        };

        var createdPerson = await _personRepository.Create(person);

        return new PersonResponse
        {
            Id = createdPerson.Id,
            Name = createdPerson.Name,
            Document = createdPerson.Document,
            Email = createdPerson.Email,
            Phone = createdPerson.Phone,
            Address = createdPerson.Address,
            State = createdPerson.State,
            ZipCode = createdPerson.ZipCode,
            Country = createdPerson.Country
        };
    }

    public async Task<bool> DeletePersonById(long id)
    {
        var person = await _personRepository.GetById(id);
        if (person == null)
        {
            return false;
        }
        await _personRepository.Delete(person);

        return true;
    }

    public async Task<IEnumerable<Person>> GetAllPeople()
    {
        return await _personRepository.GetAll();
    }

    public async Task UpdatePerson(long id, UpdatePersonRequest request)
    {
        var existingPerson = await _personRepository.GetById(id);
        if (existingPerson == null)
        {
            throw new KeyNotFoundException($"Person with ID {id} not found.");
        }

        existingPerson.Name = request.Name;
        existingPerson.Email = request.Email;
        existingPerson.Phone = request.Phone;
        existingPerson.Address = request.Address;
        existingPerson.State = request.State;
        existingPerson.ZipCode = request.ZipCode;
        existingPerson.Country = request.Country;

        await _personRepository.Update(existingPerson);
    }
}