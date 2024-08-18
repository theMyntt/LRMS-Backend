using System;
using lrms.Infra.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace lrms.Infra.Data.EntitiesConfiguration;

public class ClientEntityConfiguration : IEntityTypeConfiguration<ClientEntity>
{
    public void Configure(EntityTypeBuilder<ClientEntity> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .HasOne(prop => prop.User)
            .WithMany()
            .HasForeignKey(prop => prop.CreatedBy)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasIndex(prop => prop.Email).IsUnique();
        builder.HasIndex(prop => prop.Phone).IsUnique();

        builder.Property(prop => prop.Id).IsRequired();
        builder.Property(prop => prop.Phone).IsRequired();
        builder.Property(prop => prop.CreatedAt).IsRequired();
    }
}
