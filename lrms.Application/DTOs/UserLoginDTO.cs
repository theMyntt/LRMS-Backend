using System;
using System.ComponentModel.DataAnnotations;

namespace lrms.Application.DTOs;

public class LoginInputDTO
{
    [Required]
    public required string Email { get; set; }
    [Required]
    public required string Password { get; set; }
}

public class LoginOutputDTO
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
}
