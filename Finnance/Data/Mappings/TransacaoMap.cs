using Finnance.Domain.ValueObjects;
using Finnance.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finnance.Data.Mappings;

public class TransacaoMap : IEntityTypeConfiguration<Transacao>
{
  public void Configure(EntityTypeBuilder<Transacao> builder)
  {
    builder.ToTable("Transacoes");

    builder.HasKey(x => x.Id);

    builder.Property(x => x.Id)
    .ValueGeneratedOnAdd();

    builder.HasOne(x => x.User)
    .WithMany()
    .HasForeignKey(x => x.UserId)
    .OnDelete(DeleteBehavior.Cascade);

    builder.Property(x => x.Amount)
    .HasConversion(
        money => money.Value,
        value => new Dinheiro(value))
    .IsRequired();

    builder.Property(x => x.Type)
    .IsRequired();

    builder.Property(x => x.Category)
    .IsRequired();

    builder.Property(x => x.Description)
    .IsRequired()
    .HasMaxLength(500);

    builder.Property(x => x.Date)
    .IsRequired();

    builder.Property(x => x.CreatedAt)
    .IsRequired();

    builder.Property(x => x.UpdatedAt);

    builder.Property(x => x.DeletedAt);

  }
}