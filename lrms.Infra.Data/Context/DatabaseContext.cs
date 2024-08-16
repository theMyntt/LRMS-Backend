using System;
using lrms.Infra.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace lrms.Infra.Data.Context;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions options) : base(options) { }

    public DbSet<UserEntity> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);
    }
}
