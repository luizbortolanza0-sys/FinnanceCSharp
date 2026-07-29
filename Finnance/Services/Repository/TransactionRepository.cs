using Finnance.Data;
using Finnance.Models.Entities;
using Finnance.Services.Interfaces;

namespace Finnance.Services.Repository;

public class TransactionRepository : ITransactionRepository
{
  private readonly FinnanceDataContext _context;

  public TransactionRepository(FinnanceDataContext context)
  {
    _context = context;
  }
  public Task<Transacao> AddAsync(Transacao transacao)
  {
    throw new NotImplementedException();
  }

  public Task<Transacao[]> GetTransacaoAsync(Guid userId, int pageNumber, int pageSize)
  {
    throw new NotImplementedException();
  }

  public Task<bool> RemoveAsync(int id)
  {
    throw new NotImplementedException();
  }
}