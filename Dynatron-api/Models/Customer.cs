using System.ComponentModel.DataAnnotations;

namespace Dynatron_api.Models;

public class Customer
{
    [Key]
    public int Id {get; set; }

    [Required(ErrorMessage = "First Name is required")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last Name is required")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Email is required")]
    public string Email { get; set; }

    public DateTime Created { get; set; }

    public DateTime Updated { get; set; }
}
