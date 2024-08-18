using System;
using lrms.Domain.Aggregates;

namespace lrms.Infra.Data.Interfaces;

public interface IClientRepository
{
    Task<bool> Insert(ClientAggregate aggregate);
    Task<bool> Delete(ClientAggregate aggregate);
    Task<bool> Edit(ClientAggregate aggregate);
    Task<IEnumerable<ClientAggregate>> FindAll(int page, int limit);
}
