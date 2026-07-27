using Finnance.Data;
using Finnance.DTOs.Dashboard;
using Finnance.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Finnance.Services.Interfaces;

public interface ITransactionRepository
{
  public Task<Transacao[]> GetTransacaoAsync(Guid userId, int pageNumber, int pageSize);
  public Task<Transacao> AddAsync(Transacao transacao);
  public Task<bool> RemoveAsync(int id);
}