using System.ComponentModel.DataAnnotations;

namespace Crito.Models;

public class ContactFormEntity
{
    public string Name { get; set; } = null!;

    [Key]
    public string Email { get; set; } = null!;

    public string Message { get; set; } = null!;
}
