using Finnance.Models.Entities;
using Finnance.Models.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finnance.Data.Mappings;

public class UserMap : IEntityTypeConfiguration<User>
{
  public void Configure(EntityTypeBuilder<User> builder)
  {
    builder.ToTable("Users");

    builder.HasKey(x => x.Id);

    builder.Property(x => x.Username)
    .IsRequired()
    .HasMaxLength(100);

    builder.HasIndex(x => x.Username)
    .IsUnique();

    builder.Property(x => x.Email)
    .HasConversion(
        email => email.Value,
        value => new Email(value))
    .IsRequired()
    .HasMaxLength(255);

    builder.HasIndex(x => x.Email)
    .IsUnique();

    builder.Property(x => x.IsActive)
    .IsRequired();

    builder.Property(x => x.PasswordHash)
    .IsRequired()
    .HasMaxLength(255);

    builder.Property(x => x.CreatedAt)
    .IsRequired();

    builder.Property(x => x.UpdatedAt);

    builder.Property(x => x.DeletedAt);
  }
}