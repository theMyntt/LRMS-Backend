using System;

namespace lrms.Application.DTOs;

public class ClientInsertDTO
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public Guid CreatedBy { get; set; }
}
