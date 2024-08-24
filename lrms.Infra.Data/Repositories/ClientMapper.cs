using System;
using lrms.Domain.Aggregates;
using lrms.Infra.Data.Entities;
using lrms.Infra.Data.Interfaces;

namespace lrms.Infra.Data.Repositories;

public class ClientMapper : IMapper<ClientEntity, ClientAggregate>
{
    private readonly UserMapper mapper = new();

    public ClientAggregate ToDomain(ClientEntity entity)
    {
        return new ClientAggregate(entity.Id, entity.Name, entity.Email, entity.Phone, mapper.ToDomain(entity.User), entity.CreatedAt, entity.UpdatedAt);
    }

    public ClientEntity ToPersistance(ClientAggregate aggregate)
    {
        return new ClientEntity
        {
            Id = aggregate.Id,
            Name = aggregate.Name,
            Phone = aggregate.Phone,
            CreatedAt = aggregate.CreatedAt,
            User = mapper.ToPersistance(aggregate.CreatedBy),
            CreatedBy = aggregate.CreatedBy.Id,
            Email = aggregate.Email,
            UpdatedAt = aggregate.UpdatedAt
        };
    }
}
