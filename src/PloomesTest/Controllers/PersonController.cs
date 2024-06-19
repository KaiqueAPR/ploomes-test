using Microsoft.AspNetCore.Mvc;
using PloomesTest.DTOs.Request;
using PloomesTest.DTOs.Response;
using PloomesTest.Services;

/// <summary>
/// Controller for managing Person entities.
/// </summary>
[ApiController]
[Route("api/persons")]
public class PersonController : ControllerBase
{
    private readonly IPersonService _personService;

    public PersonController(IPersonService personService)
    {
        _personService = personService;
    }

    /// <summary>
    /// Creates a new Person entity.
    /// </summary>
    /// <param name="request">The request data to create a new Person entity.</param>
    /// <returns>A response containing the created Person entity data.</returns>
    [HttpPost]
    public async Task<ActionResult<PersonResponse>> CreatePerson(CreatePersonRequest request)
    {
        var response = await _personService.CreatePersonAsync(request);
        return CreatedAtAction(nameof(GetPersonById), new { id = response.Id }, response);
    }

    /// <summary>
    /// Retrieves all people.
    /// </summary>
    /// <returns>A response containing the collection of people.</returns>
    [HttpGet]
    public async Task<IActionResult> GetAllPeople()
    {
        var people = await _personService.GetAllPeople();
        return Ok(people);
    }

    /// <summary>
    /// Retrieves a Person entity by ID.
    /// </summary>
    /// <param name="id">The ID of the Person entity to retrieve.</param>
    /// <returns>
    ///   A response containing the Person entity if found; otherwise, NotFound.
    /// </returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPersonById(long id)
    {
        var person = await _personService.GetPersonById(id);
        if (person == null)
        {
            return NotFound();
        }
        return Ok(person);
    }

    /// <summary>
    /// Deletes a Person entity by ID.
    /// </summary>
    /// <param name="id">The ID of the Person entity to delete.</param>
    /// <returns>
    ///   <see cref="NotFoundResult"/> if the person with the specified ID was not found;
    ///   otherwise, <see cref="NoContentResult"/> indicating successful deletion.
    /// </returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePersonById(long id)
    {
        var isDeleted = await _personService.DeletePersonById(id);
        if (!isDeleted)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Updates an existing Person entity.
    /// </summary>
    /// <param name="id">The ID of the Person entity to be updated.</param>
    /// <param name="request">The request data containing updated Person information.</param>
    /// <returns>
    ///   An <see cref="IActionResult"/> indicating the result of the update operation.
    /// </returns>
    /// <response code="200">If the update is successful, returns a message indicating the success.</response>
    /// <response code="400">If the model state is invalid, returns a BadRequest with the model state.</response>
    /// <response code="404">If the Person entity is not found, returns a NotFound with the exception message.</response>
    /// <response code="500">If an internal server error occurs, returns a StatusCode 500 with the exception message.</response>


    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePerson(long id, [FromBody] UpdatePersonRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            await _personService.UpdatePerson(id, request);
            return Ok(new { Message = $"The Person with ID equals to {id} was successfully changed!" });
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
        }
    }

}