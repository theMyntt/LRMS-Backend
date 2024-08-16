using System;
using lrms.Domain.Aggregates;
using lrms.Infra.Data.Context;
using lrms.Infra.Data.Entities;
using lrms.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lrms.Infra.Data.Repositories;

public class UserRepository(DatabaseContext context, IMapper<UserEntity, UserAggregate> mapper) : IUserRepository
{
    private readonly DatabaseContext _context = context;
    private readonly IMapper<UserEntity, UserAggregate> _mapper = mapper;

    public async Task<bool> Insert(UserAggregate user)
    {
        try
        {
            await _context.Usuarios.AddAsync(_mapper.ToPersistance(user));
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<UserAggregate?> Login(string email, string password)
    {
        var user = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);

        // I know, this is stupid
        if (user == null) return null;

        return _mapper.ToDomain(user);
    }
}
