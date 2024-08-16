using System;
using lrms.Domain.Aggregates;
using lrms.Infra.Data.Entities;
using lrms.Infra.Data.Interfaces;

namespace lrms.Infra.Data.Repositories;

public class UserMapper : IMapper<UserEntity, UserAggregate>
{
    public UserAggregate ToDomain(UserEntity entity)
    {
        return new UserAggregate(entity.Id, entity.Name, entity.Email, entity.Password, entity.CreatedBy, entity.CreatedAt, entity.LastAccess, entity.UpdatedAt);
    }

    public UserEntity ToPersistance(UserAggregate aggregate)
    {
        return new UserEntity
        {
            Id = aggregate.Id,
            Name = aggregate.Name,
            Email = aggregate.Email,
            Password = aggregate.Password,
            CreatedBy = aggregate.CreatedBy,
            CreatedAt = aggregate.CreatedAt,
            LastAccess = aggregate.LastAccess,
            UpdatedAt = aggregate.UpdatedAt,
        };
    }
}
