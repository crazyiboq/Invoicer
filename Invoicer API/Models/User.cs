using Invoicer_API.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Invoicer_API.Models;

public class User: BaseEntity
{

    public string? Name { get; set; } = string.Empty;

    public string? Address { get; set; } = string.Empty;

    public string Email { get; set; }

    public string Password { get; set; }

    public string PhoneNumber { get; set; }

    
}
