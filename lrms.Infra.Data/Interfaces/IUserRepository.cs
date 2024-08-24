using System;
using lrms.Domain.Aggregates;

namespace lrms.Infra.Data.Interfaces;

public interface IUserRepository
{
    Task<UserAggregate?> Login(string email, string password);
    Task<bool> Insert(UserAggregate user);
    Task<UserAggregate?> FindById(Guid Id);
}
