using System.ComponentModel.DataAnnotations;

namespace PloomesTest.Models;

public class Person
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Document { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
    public string Country { get; set; }
}