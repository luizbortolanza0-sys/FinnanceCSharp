using Finnance.Data.Mappings;
using Finnance.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Finnance.Data;

public class FinnanceDataContext : DbContext
{
  public DbSet<User> Users { get; set; }
  public DbSet<Transacao> Transacoes { get; set; }
  public DbSet<RefreshToken> RefreshTokens { get; set; }
  protected override void OnConfiguring
  (DbContextOptionsBuilder options)
    => options.UseSqlite("DataSource=finnance.db;Cache=Shared");

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfiguration(new RefreshTokenMap());
    modelBuilder.ApplyConfiguration(new TransacaoMap());
    modelBuilder.ApplyConfiguration(new UserMap());
  }

}