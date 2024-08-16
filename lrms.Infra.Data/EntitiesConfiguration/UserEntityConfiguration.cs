using System;
using lrms.Infra.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace lrms.Infra.Data.EntitiesConfiguration;

public class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasIndex(prop => prop.Email).IsUnique();

        builder.Property(prop => prop.Id).IsRequired();
        builder.Property(prop => prop.Name).IsRequired().HasMaxLength(128);
        builder.Property(prop => prop.Email).IsRequired().HasMaxLength(128);
        builder.Property(prop => prop.Password).IsRequired().HasMaxLength(255);
        builder.Property(prop => prop.CreatedAt).IsRequired();

        builder.HasOne<UserEntity>().WithMany().HasForeignKey(x => x.Id).OnDelete(DeleteBehavior.NoAction);
    }
}
