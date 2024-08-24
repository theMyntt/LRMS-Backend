using System;
using lrms.Domain.Aggregates;
using lrms.Infra.Data.Context;
using lrms.Infra.Data.Entities;
using lrms.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lrms.Infra.Data.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly DatabaseContext _context;
    private readonly IMapper<ClientEntity, ClientAggregate> _mapper;

    public ClientRepository(DatabaseContext context, IMapper<ClientEntity, ClientAggregate> mapper)
    {
        this._context = context;
        this._mapper = mapper;
    }

    public async Task<bool> Delete(ClientAggregate aggregate)
    {
        try
        {
            _context.Clientes.Remove(_mapper.ToPersistance(aggregate));
            await _context.SaveChangesAsync();

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public Task<bool> Edit(ClientAggregate aggregate)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<ClientAggregate>> FindAll(int page, int limit)
    {
        int skip = (limit - 1) * page;

        var entities = await _context.Clientes
        .Skip(skip)
        .Take(limit)
        .Select(entity => _mapper.ToDomain(entity))
        .ToListAsync();

        return entities;
    }

    public async Task<bool> Insert(ClientAggregate aggregate)
    {
        try
        {
            var entity = _mapper.ToPersistance(aggregate);

            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
