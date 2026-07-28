using Finnance.Models.Entities;

namespace Finnance.Services.Interfaces;
//Falta implementar

public interface ITransactionRepository
{
  public Task<Transacao[]> GetTransacaoAsync(Guid userId, int pageNumber, int pageSize);
  public Task<Transacao> AddAsync(Transacao transacao);
  public Task<bool> RemoveAsync(int id);
}