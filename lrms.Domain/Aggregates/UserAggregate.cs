using System;
using System.Text.RegularExpressions;
using lrms.Domain.Exceptions;

namespace lrms.Domain.Aggregates;

public class UserAggregate
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public DateTime? LastAccess { get; private set; }
    public Guid? CreatedBy { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    public UserAggregate(string Name,
                         string Email,
                         string Password,
                         Guid? CreatedBy)
    {
        Id = Guid.NewGuid();
        this.Name = Name.ToUpper();
        this.Email = Email.ToLower();
        this.Password = Password;
        this.CreatedBy = CreatedBy;
        this.CreatedAt = DateTime.UtcNow;

        ValidateDomain();
    }

    public UserAggregate(Guid Id,
                         string Name,
                         string Email,
                         string Password,
                         Guid? CreatedBy,
                         DateTime? LastAccess,
                         DateTime CreatedAt)
    {
        this.Id = Id;
        this.Name = Name.ToUpper();
        this.Email = Email.ToLower();
        this.Password = Password;
        this.CreatedBy = CreatedBy;
        this.CreatedAt = CreatedAt;
        this.LastAccess = LastAccess;
        this.UpdatedAt = DateTime.UtcNow;

        ValidateDomain();
    }

    public UserAggregate(Guid Id,
                         string Name,
                         string Email,
                         string Password,
                         Guid? CreatedBy,
                         DateTime CreatedAt,
                         DateTime? LastAccess,
                         DateTime? UpdatedAt)
    {
        this.Id = Id;
        this.Name = Name.ToUpper();
        this.Email = Email.ToLower();
        this.Password = Password;
        this.CreatedBy = CreatedBy;
        this.CreatedAt = CreatedAt;
        this.LastAccess = LastAccess;
        this.UpdatedAt = UpdatedAt;
    }

    private void ValidateDomain()
    {
        string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        Regex emailRegex = new Regex(emailPattern);

        DomainValidatorException.When(Name.Length < 1, "O nome precisa ter no minimo 1 letra");
        DomainValidatorException.When(Password.Length < 8, "A senha precisa ter no minimo 8 letras");
        DomainValidatorException.When(!emailRegex.IsMatch(Email), "O email não é válido");
    }
}
