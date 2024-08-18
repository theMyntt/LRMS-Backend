using System;

namespace lrms.Infra.Data.Entities;

public class ClientEntity
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Email { get; set; }
    public required string Phone { get; set; }
    public Guid CreatedBy { get; set; }
    public required UserEntity User { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
