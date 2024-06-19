using System.ComponentModel.DataAnnotations;

namespace PloomesTest.DTOs.Request;

public class UpdatePersonRequest
{
    [Required]
    public string Name { get; set; }

    [Required]
    [StringLength(14, MinimumLength = 11, ErrorMessage = "Nacional Document must contain between 11 and 14 characters.")]
    [RegularExpression(@"^\d+$")]
    public string Document { get; set; }

    [Required]
    [StringLength(250, MinimumLength = 1, ErrorMessage = "Email address must contain between 1 and 250 characters.")]
    public string Email { get; set; }

    [Required]
    [StringLength(11, MinimumLength = 10, ErrorMessage = "Phone must contain between 10 and 11 digits.")]
    [RegularExpression(@"^\d+$")]
    public string Phone { get; set; }

    [Required]
    [StringLength(200, MinimumLength = 1, ErrorMessage = "Address must contain between 1 and 200 characters.")]
    public string Address { get; set; }

    [Required]
    [StringLength(40, MinimumLength = 1, ErrorMessage = "State must contain between 1 and 40 characters.")]
    public string State { get; set; }

    [Required]
    [StringLength(8, MinimumLength = 8, ErrorMessage = "Zip Code must contain 8 characters.")]
    [RegularExpression(@"^\d+$")]
    public string ZipCode { get; set; }

    [Required]
    [StringLength(60, MinimumLength = 1, ErrorMessage = "Country must contain between 1 and 60 characters.")]
    public string Country { get; set; }
}