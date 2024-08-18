using System;
using System.Text.RegularExpressions;
using lrms.Domain.Exceptions;

namespace lrms.Domain.Aggregates;

public class ClientAggregate
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string? Email { get; private set; }
    public string Phone { get; private set; }
    public UserAggregate CreatedBy { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    public ClientAggregate(string Name,
                           string? Email,
                           string Phone,
                           UserAggregate CreatedBy)
    {
        this.Name = Name;
        this.Email = Email;
        this.Phone = Phone;
        this.CreatedBy = CreatedBy;

        Id = Guid.NewGuid();
        CreatedAt = DateTime.Now;

        ValidateDomain();
    }

    public ClientAggregate(Guid Id,
                           string Name,
                           string? Email,
                           string Phone,
                           UserAggregate CreatedBy,
                           DateTime CreatedAt)
    {
        this.Id = Id;
        this.Name = Name;
        this.Email = Email;
        this.Phone = Phone;
        this.CreatedBy = CreatedBy;
        this.CreatedAt = CreatedAt;

        UpdatedAt = DateTime.Now;

        ValidateDomain();
    }

    public ClientAggregate(Guid Id,
                           string Name,
                           string? Email,
                           string Phone,
                           UserAggregate CreatedBy,
                           DateTime CreatedAt,
                           DateTime UpdatedAt)
    {
        this.Id = Id;
        this.Name = Name;
        this.Email = Email;
        this.Phone = Phone;
        this.CreatedBy = CreatedBy;
        this.CreatedAt = CreatedAt;
        this.UpdatedAt = UpdatedAt;

        ValidateDomain();
    }

    private void ValidateDomain()
    {
        string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        Regex emailRegex = new Regex(emailPattern);

        DomainValidatorException.When(!emailRegex.IsMatch(Email ?? ""), "Email não válido");
        DomainValidatorException.When(CreatedBy == null, "Nenhum usuário criou");
    }
}
