using System;
using System.ComponentModel.DataAnnotations;

namespace lrms.Application.DTOs;

public class UserInsertDTO
{
    [Required]
    public required string Name { get; set; }
    [Required]
    public required string Email { get; set; }
    [Required]
    public required string Password { get; set; }
    public Guid? CreatedBy { get; set; }

}

public class UserOutputDTO
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public Guid? CreatedBy { get; set; }
}
