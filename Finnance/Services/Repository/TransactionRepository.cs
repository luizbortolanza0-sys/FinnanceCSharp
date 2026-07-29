using Finnance.Data;
using Finnance.Models.Entities;
using Finnance.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Finnance.Services.Repository;

public class TransactionRepository : ITransactionRepository
{
  private readonly FinnanceDataContext _context;

  public TransactionRepository(FinnanceDataContext context)
  {
    _context = context;
  }
  public async Task AddAsync(Transacao transacao)
  {
    await _context.Transacoes.AddAsync(transacao);
    await _context.SaveChangesAsync();
  }

  public async Task<List<Transacao>> GetTransacaoAsync(
    Guid userId,
    int pageNumber = 1,
    int pageSize = 10)
  {
    pageNumber = Math.Max(pageNumber, 1);
    pageSize = Math.Clamp(pageSize, 1, 100);
    return await _context.Transacoes.
      AsNoTracking().
      Where(t => t.UserId == userId).
      OrderBy(t => t.Date).
      Skip((pageNumber - 1) * pageSize).
      Take(pageSize).
      ToListAsync();
  }

  public Task<bool> RemoveAsync(int id)
  {
    throw new NotImplementedException();
  }
}